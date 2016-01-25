using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Nop.Core;
using Nop.Core.Domain.Payments;
using Nop.Plugin.Payments.Emi.Models;
using Nop.Services.Configuration;
using Nop.Services.Orders;
using Nop.Services.Payments;
using Nop.Services.Localization;

using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Security;
using SFA;

namespace Nop.Plugin.Payments.Emi.Controllers
{
    public class PaymentEmiController : BasePaymentController
    {
        private readonly ISettingService _settingService;
        private readonly IPaymentService _paymentService;
        private readonly IOrderService _orderService;
        private readonly IOrderProcessingService _orderProcessingService;
        private FormCollection form;
        private readonly EmiPaymentSettings _EmiPaymentSettings;
        private readonly PaymentSettings _paymentSettings;
        private readonly ILocalizationService _localizationService;

        public PaymentEmiController(ISettingService settingService, 
            IPaymentService paymentService, IOrderService orderService, 
            IOrderProcessingService orderProcessingService,
             ILocalizationService localizationService,
            EmiPaymentSettings EmiPaymentSettings,
            PaymentSettings paymentSettings)
        {
            this._settingService = settingService;
            this._paymentService = paymentService;
            this._orderService = orderService;
            this._orderProcessingService = orderProcessingService;
            this._EmiPaymentSettings = EmiPaymentSettings;
            this._localizationService = localizationService;
            this._paymentSettings = paymentSettings;
            
        }
        

        [AdminAuthorize]
        [ChildActionOnly]
        public ActionResult Configure()
        {
            var model = new ConfigurationModel();
            model.MerchantId = _EmiPaymentSettings.MerchantId;
            model.Key = _EmiPaymentSettings.Key;
            model.MerchantParam = _EmiPaymentSettings.MerchantParam;
            model.PayUri = _EmiPaymentSettings.PayUri;
            model.AdditionalFee = _EmiPaymentSettings.AdditionalFee;
            
           // return View("Nop.Plugin.Payments.Payu.Views.PaymentPayu.Configure", model);
            
           return View("~/Plugins/Payments.Emi/Views/PaymentEmi/Configure.cshtml", model);

           //return View("~/Plugins/Payments.PayPalStandard/Views/PaymentPayPalStandard/Configure.cshtml", model);
        }

        [HttpPost]
        [AdminAuthorize]
        [ChildActionOnly]
        public ActionResult Configure(ConfigurationModel model)
        {
            if (!ModelState.IsValid)
                return Configure();

            //save settings
            _EmiPaymentSettings.MerchantId = model.MerchantId;
            _EmiPaymentSettings.Key = model.Key;
            _EmiPaymentSettings.MerchantParam = model.MerchantParam;
            _EmiPaymentSettings.PayUri = model.PayUri;
            _EmiPaymentSettings.AdditionalFee = model.AdditionalFee;
            _settingService.SaveSetting(_EmiPaymentSettings);
            
            //return View("Nop.Plugin.Payments.Payu.Views.PaymentPayu.Configure", model);
            //return View("~/Plugins/Payments.Payu/Views/PaymentPayu/Configure.cshtml", model);

            SuccessNotification(_localizationService.GetResource("Admin.Plugins.Saved"));

            return Configure();
        }

        [ChildActionOnly]
        public ActionResult PaymentInfo()
        {
            var model = new PaymentInfoModel();
            //return View("Nop.Plugin.Payments.Payu.Views.PaymentPayu.PaymentInfo", model);
            return View("~/Plugins/Payments.Emi/Views/PaymentEmi/PaymentInfo.cshtml", model);

        }

        [NonAction]
        public override IList<string> ValidatePaymentForm(FormCollection form)
        {
            var warnings = new List<string>();
            return warnings;
        }

        [NonAction]
        public override ProcessPaymentRequest GetPaymentInfo(FormCollection form)
        {
            var paymentInfo = new ProcessPaymentRequest();
            return paymentInfo;
        }


        [ValidateInput(false)]
        public ActionResult Return(string orderId)
        {

            PGResponse oPgResp = new PGResponse();
            EncryptionUtil lEncUtil = new EncryptionUtil();
            string respcd = null;
            string respmsg = null;
            string astrResponseData = null;
            string strMerchantId, astrFileName = null;
            string strKey = null;
            string strDigest = null;
            string astrsfaDigest = null;

            strMerchantId = "96084546";
            astrFileName = "c://key//96084546.key";
           
            if (Request.ServerVariables["REQUEST_METHOD"] == "POST")
            {

                astrResponseData = Request.Form["DATA"];
                strDigest = Request.Form["EncryptedData"];
                astrsfaDigest = lEncUtil.getHMAC(astrResponseData, astrFileName, strMerchantId);

                if (strDigest.Equals(astrsfaDigest))
                {
                    oPgResp.getResponse(astrResponseData);
                    respcd = oPgResp.RespCode;
                    respmsg = oPgResp.RespMessage;

                    var order = _orderService.GetOrderById(Int32.Parse(orderId));
                    if (_orderProcessingService.CanMarkOrderAsPaid(order))
                    {
                        _orderProcessingService.MarkOrderAsPaid(order);
                    }

                    //Thank you for shopping with us. Your credit card has been charged and your transaction is successful
                    return RedirectToRoute("CheckoutCompleted", new { orderId = order.Id });
                }

                else
                {
                    return RedirectToAction("Index", "Home", new { area = "" });
                }
            }
            else
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }

            Response.Write("Response code      :" + oPgResp.RespCode);
            Response.Write("<br>");
            Response.Write("\nResponse Message :" + oPgResp.RespMessage);
            Response.Write("<br>");
            Response.Write("\nMerchant Txn Id  :" + oPgResp.TxnId);
            Response.Write("<br>");
            Response.Write("\nEpg Txn Id		:" + oPgResp.EPGTxnId);
            Response.Write("<br>");
            Response.Write("\nAuthId Code		:" + oPgResp.AuthIdCode);
            Response.Write("<br>");
            Response.Write("RRN			    :" + oPgResp.RRN);
            Response.Write("<br>");
            Response.Write("CVRESP Code	    :" + oPgResp.CVRespCode);
            Response.Write("<br>");
            Response.Write("Cookie String	    :" + oPgResp.Cookie);
            Response.Write("<br>");
            Response.Write("FDMS Score		    :" + oPgResp.FDMSScore);
            Response.Write("<br>");
            Response.Write("FDMS Result        :" + oPgResp.FDMSResult);
        }

        [ValidateInput(false)]
        public ActionResult ReturnDistributedOrder(FormCollection form)
        {
            return View();
        }
    }
}
