using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web.Routing;
using Nop.Core;
using Nop.Core.Domain.Directory;
using Nop.Core.Domain.Orders;
using Nop.Core.Domain.Payments;
using Nop.Core.Domain.Shipping;
using Nop.Core.Plugins;
using Nop.Plugin.Payments.Emi.Controllers;
using Nop.Services.Configuration;
using Nop.Services.Directory;
using Nop.Services.Localization;

using Nop.Web.Framework;
using Nop.Services.Payments;
using SFA;
using System.Web;

namespace Nop.Plugin.Payments.Emi
{
    
        /// <summary>
        /// Payu payment processor
        /// </summary>
        public class EmiPaymentProcessor : BasePlugin, IPaymentMethod
        {
            #region Fields

            private readonly EmiPaymentSettings _EmiPaymentSettings;
            private readonly ISettingService _settingService;
            private readonly ICurrencyService _currencyService;
            private readonly CurrencySettings _currencySettings;
            private readonly IWebHelper _webHelper;

            #endregion

            #region Ctor

            public EmiPaymentProcessor(EmiPaymentSettings EmiPaymentSettings,
                ISettingService settingService, ICurrencyService currencyService,
                CurrencySettings currencySettings, IWebHelper webHelper)
            {
                this._EmiPaymentSettings = EmiPaymentSettings;
                this._settingService = settingService;
                this._currencyService = currencyService;
                this._currencySettings = currencySettings;
                this._webHelper = webHelper;
            }

            #endregion

            #region Utilities

            #endregion

            #region Methods

            /// <summary>
            /// Process a payment
            /// </summary>
            /// <param name="processPaymentRequest">Payment info required for an order processing</param>
            /// <returns>Process payment result</returns>
            public ProcessPaymentResult ProcessPayment(ProcessPaymentRequest processPaymentRequest)
            {
                var result = new ProcessPaymentResult();
                result.NewPaymentStatus = PaymentStatus.Pending;
                return result;
            }

            /// <summary>
            /// Post process payment (used by payment gateways that require redirecting to a third-party URL)
            /// </summary>
            /// <param name="postProcessPaymentRequest">Payment info required for an order processing</param>
            //public void PostProcessPayment(PostProcessPaymentRequest postProcessPaymentRequest)
            //{

            //    PGResponse objPGResponse = new PGResponse();
            //    CustomerDetails oCustomer = new CustomerDetails();
            //    SessionDetail oSession = new SessionDetail();
            //    AirLineTransaction oAirLine = new AirLineTransaction();
            //    MerchanDise oMerchanDise = new MerchanDise();

            //    SFA.CardInfo objCardInfo = new SFA.CardInfo();

            //    SFA.Merchant objMerchant = new SFA.Merchant();

            //    ShipToAddress objShipToAddress = new ShipToAddress();
            //    BillToAddress oBillToAddress = new BillToAddress();
            //    ShipToAddress oShipToAddress = new ShipToAddress();
            //    MPIData objMPI = new MPIData();
            //    PGReserveData oPGreservData = new PGReserveData();
            //    Address oHomeAddress = new Address();
            //    Address oOfficeAddress = new Address();
            //    // For getting unique MerchantTxnID 
            //    // Only for testing purpose. 
            //    // In actual scenario the merchant has to pass his transactionID
            //    DateTime oldTime = new DateTime(1970, 01, 01, 00, 00, 00);
            //    DateTime currentTime = DateTime.Now;
            //    TimeSpan structTimespan = currentTime - oldTime;
            //    string lMrtTxnID = ((long)structTimespan.TotalMilliseconds).ToString();
            //    var merchantId = _EmiPaymentSettings.MerchantId.ToString();
            //    var orderId = postProcessPaymentRequest.Order.Id;
            //    var Id = orderId.ToString();
            //    var amount = postProcessPaymentRequest.Order.TotalTransactionAmount.ToString(new CultureInfo("en-US", false).NumberFormat);
            //    //Setting Merchant Details
            //    objMerchant.setMerchantDetails(merchantId, "", "", "", lMrtTxnID, Id, "PaymentEmi/Return", "POST", "INR", "INV123", "req.Sale", amount, "GMT+05:30", "ASP.NET64", "true", "ASP.NET64", "ASP.NET64", "ASP.NET64");

            //    // Setting BillToAddress Details
            //    oBillToAddress.setAddressDetails(postProcessPaymentRequest.Order.CustomerId.ToString(),
            //                                      postProcessPaymentRequest.Order.Customer.SystemName,
            //                                      postProcessPaymentRequest.Order.BillingAddress.Address1,
            //                                      postProcessPaymentRequest.Order.BillingAddress.Address2,
            //                                      "",
            //                                      postProcessPaymentRequest.Order.BillingAddress.City,
            //                                      "", postProcessPaymentRequest.Order.BillingAddress.ZipPostalCode,
            //                                      postProcessPaymentRequest.Order.BillingAddress.Country.Name,
            //                                      postProcessPaymentRequest.Order.Customer.Email);

            //    // Setting ShipToAddress Details
            //    oShipToAddress.setAddressDetails(postProcessPaymentRequest.Order.BillingAddress.Address1,
            //                                    postProcessPaymentRequest.Order.BillingAddress.Address2,
            //                                    "",
            //                                    postProcessPaymentRequest.Order.BillingAddress.City,
            //                                    "",
            //                                    postProcessPaymentRequest.Order.BillingAddress.ZipPostalCode,
            //                                    postProcessPaymentRequest.Order.BillingAddress.Country.Name,
            //                                    postProcessPaymentRequest.Order.Customer.Email);

            //    //Setting MPI datails.
            //    //objMPI.setMPIRequestDetails ("1000","INR10.00","356","2","2 shirts","","","","0","","image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/vnd.ms-powerpoint, application/vnd.ms-excel, application/msword, application/x-shockwave-flash, */*","Mozilla/4.0 (compatible; MSIE 5.5; Windows NT 5.0)");

            //    // Setting Name home/office Address Details 
            //    // Order of Parameters =>        AddLine1, AddLine2,      AddLine3,   City,   State ,  Zip,          Country, Email id
            //    oHomeAddress.setAddressDetails("2Sandeep", "Uttam Corner", "Chinchwad", "Pune", "state", "4385435873", "IND", "test@test.com");

            //    // Order of Parameters =>        AddLine1, AddLine2,      AddLine3,   City,   State ,  Zip,          Country, Email id
            //    oOfficeAddress.setAddressDetails("2Opus", "MayFairTowers", "Wakdewadi", "Pune", "state", "4385435873", "IND", "test@test.com");

            //    // Stting  Customer Details 
            //    // Order of Parameters =>  First Name,LastName ,Office Address Object,Home Address Object,Mobile No,RegistrationDate, flag for matching bill to address and ship to address 
            //    oCustomer.setCustomerDetails(postProcessPaymentRequest.Order.Customer.SystemName, "", oOfficeAddress, oHomeAddress, "", "13-06-2007", "Y");

            //    //Setting Merchant Dise Details 
            //    // Order of Parameters =>       Item Purchased,Quantity,Brand,ModelNumber,Buyers Name,flag value for matching CardName and BuyerName
            //    oMerchanDise.setMerchanDiseDetails("Computer", "2", "Intel", "P4", "Sandeep Patil", "Y");

            //    //Setting  Session Details        
            //    // Order of Parameters =>     Remote Address, Cookies Value            Browser Country,Browser Local Language,Browser Local Lang Variant,Browser User Agent'
            //    oSession.setSessionDetails(getRemoteAddr(), getSecureCookie(HttpContext.Current.Request), "", HttpContext.Current.Request.ServerVariables["HTTP_ACCEPT_LANGUAGE"], "", HttpContext.Current.Request.ServerVariables["HTTP_USER_AGENT"]);

            //    //Settingr AirLine Transaction Details  
            //    //Order of Parameters =>               Booking Date,FlightDate,Flight   Time,Flight Number,Passenger Name,Number Of Tickets,flag for matching card name and customer name,PNR,sector from,sector to'
            //    oAirLine.setAirLineTransactionDetails("10-06-2007", "22-06-2007", "13:20", "119", "Sandeep", "1", "Y", "25c", "Pune", "Mumbai");

            //    SFAClient objSFAClient = new SFAClient("c:\\inetpub\\wwwroot\\SFAClient\\Config\\");
            //    objPGResponse = objSFAClient.postSSL(objMPI, objMerchant, oBillToAddress, oShipToAddress, oPGreservData, oCustomer, oSession, oAirLine, oMerchanDise);

            //    if (objPGResponse.RedirectionUrl != "" & objPGResponse.RedirectionUrl != null)
            //    {
            //        string strResponseURL = objPGResponse.RedirectionUrl;
            //        HttpContext.Current.Response.Redirect(strResponseURL);
            //    }
            //    else
            //    {
            //        HttpContext.Current.Response.Write("Response Code:" + objPGResponse.RespCode);
            //        HttpContext.Current.Response.Write("Response message:" + objPGResponse.RespMessage);
            //    }

            //}

            public void PostProcessPayment(PostProcessPaymentRequest postProcessPaymentRequest)
            {

                PGResponse objPGResponse = new PGResponse();
                CustomerDetails oCustomer = new CustomerDetails();
                SessionDetail oSession = new SessionDetail();
                AirLineTransaction oAirLine = new AirLineTransaction();
                MerchanDise oMerchanDise = new MerchanDise();

                SFA.CardInfo objCardInfo = new SFA.CardInfo();

                SFA.Merchant objMerchant = new SFA.Merchant();

                ShipToAddress objShipToAddress = new ShipToAddress();
                BillToAddress oBillToAddress = new BillToAddress();
                ShipToAddress oShipToAddress = new ShipToAddress();
                MPIData objMPI = new MPIData();
                PGReserveData oPGreservData = new PGReserveData();
                Address oHomeAddress = new Address();
                Address oOfficeAddress = new Address();
                // For getting unique MerchantTxnID 
                // Only for testing purpose. 
                // In actual scenario the merchant has to pass his transactionID
                DateTime oldTime = new DateTime(1970, 01, 01, 00, 00, 00);
                DateTime currentTime = DateTime.Now;
                TimeSpan structTimespan = currentTime - oldTime;
                string lMrtTxnID = ((long)structTimespan.TotalMilliseconds).ToString();
                var merchantId = _EmiPaymentSettings.MerchantId.ToString();
                var orderId = postProcessPaymentRequest.Order.Id;
                
                var Id = orderId.ToString();
                var amount = postProcessPaymentRequest.Order.TotalTransactionAmount.ToString(new CultureInfo("en-US", false).NumberFormat);
             

                //Setting Merchant Details
                objMerchant.setMerchantDetails(merchantId, "", "", "", lMrtTxnID, Id, "https://www.laorigin.com/PaymentEmi/Return?orderId=" + Id, "POST", "INR", "INV123", "req.Sale", amount, "GMT+05:30", "ASP.NET64", "true", "ASP.NET64", "ASP.NET64", "ASP.NET64");

                // Setting BillToAddress Details
                   oBillToAddress.setAddressDetails(postProcessPaymentRequest.Order.CustomerId.ToString(),
                                                      postProcessPaymentRequest.Order.Customer.SystemName,
                                                   postProcessPaymentRequest.Order.BillingAddress.Address1,
                                                    postProcessPaymentRequest.Order.BillingAddress.Address2,
                                                    "",
                                                     postProcessPaymentRequest.Order.BillingAddress.City,
                                                    postProcessPaymentRequest.Order.BillingAddress.StateProvince.Name
                                                    , postProcessPaymentRequest.Order.BillingAddress.ZipPostalCode,
                                                    postProcessPaymentRequest.Order.BillingAddress.Country.Name,
                                                     postProcessPaymentRequest.Order.Customer.Email);

                   // Setting ShipToAddress Details
                   oShipToAddress.setAddressDetails(postProcessPaymentRequest.Order.BillingAddress.Address1,
                                                   postProcessPaymentRequest.Order.BillingAddress.Address2,
                                                   "",
                                                   postProcessPaymentRequest.Order.BillingAddress.City,
                                                   postProcessPaymentRequest.Order.BillingAddress.StateProvince.Name,
                                                 
                                                   postProcessPaymentRequest.Order.BillingAddress.ZipPostalCode,
                                                   postProcessPaymentRequest.Order.BillingAddress.Country.Name,
                                                   postProcessPaymentRequest.Order.Customer.Email);

                   //Setting MPI datails.
                   //objMPI.setMPIRequestDetails ("1000","INR10.00","356","2","2 shirts","","","","0","","image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/vnd.ms-powerpoint, application/vnd.ms-excel, application/msword, application/x-shockwave-flash, */*","Mozilla/4.0 (compatible; MSIE 5.5; Windows NT 5.0)");

                   // Setting Name home/office Address Details 
                   // Order of Parameters =>        AddLine1, AddLine2,      AddLine3,   City,   State ,  Zip,          Country, Email id
                   oHomeAddress.setAddressDetails("2Sandeep", "Uttam Corner", "Chinchwad", "Pune", "state", "4385435873", "IND", "test@test.com");

                   // Order of Parameters =>        AddLine1, AddLine2,      AddLine3,   City,   State ,  Zip,          Country, Email id
                   oOfficeAddress.setAddressDetails("2Opus", "MayFairTowers", "Wakdewadi", "Pune", "state", "4385435873", "IND", "test@test.com");

                   // Stting  Customer Details 
                   // Order of Parameters =>  First Name,LastName ,Office Address Object,Home Address Object,Mobile No,RegistrationDate, flag for matching bill to address and ship to address 
                   oCustomer.setCustomerDetails(postProcessPaymentRequest.Order.Customer.SystemName, "", oOfficeAddress, oHomeAddress, "", "13-06-2007", "Y");

                   //Setting Merchant Dise Details 
                   // Order of Parameters =>       Item Purchased,Quantity,Brand,ModelNumber,Buyers Name,flag value for matching CardName and BuyerName
                   oMerchanDise.setMerchanDiseDetails("Computer", "2", "Intel", "P4", "Sandeep Patil", "Y");

                //Setting  Session Details        
                // Order of Parameters =>     Remote Address, Cookies Value            Browser Country,Browser Local Language,Browser Local Lang Variant,Browser User Agent'
                oSession.setSessionDetails(getRemoteAddr(), getSecureCookie(HttpContext.Current.Request), "", HttpContext.Current.Request.ServerVariables["HTTP_ACCEPT_LANGUAGE"], "", HttpContext.Current.Request.ServerVariables["HTTP_USER_AGENT"]);

                //Settingr AirLine Transaction Details  
                //Order of Parameters =>               Booking Date,FlightDate,Flight   Time,Flight Number,Passenger Name,Number Of Tickets,flag for matching card name and customer name,PNR,sector from,sector to'
                oAirLine.setAirLineTransactionDetails("10-06-2007", "22-06-2007", "13:20", "119", "Sandeep", "1", "Y", "25c", "Pune", "Mumbai");

                SFAClient objSFAClient = new SFAClient("c:\\inetpub\\wwwroot\\SFAClient\\Config\\");
                objPGResponse = objSFAClient.postSSL(objMPI, objMerchant, oBillToAddress, oShipToAddress, oPGreservData, oCustomer, oSession, oAirLine, oMerchanDise);

                if (objPGResponse.RedirectionUrl != "" & objPGResponse.RedirectionUrl != null)
                {
                    string strResponseURL = objPGResponse.RedirectionUrl;
                    HttpContext.Current.Response.Redirect(strResponseURL);
                }
                else
                {
                    HttpContext.Current.Response.Write("Response Code:" + objPGResponse.RespCode);
                    HttpContext.Current.Response.Write("Response message:" + objPGResponse.RespMessage);
                }

            }


            public string getRemoteAddr()
		    {
                string UserIPAddress = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
			    if(UserIPAddress==null){
                    UserIPAddress = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
			    }
			    return UserIPAddress;
		    }

		    public string  getSecureCookie(HttpRequest Request){
		
			    HttpCookie secureCookie = Request.Cookies["vsc"];
				if(secureCookie!=null)
				{
				return secureCookie.ToString();
				}
				else{
				return "";
				}
	
		
		    }
            /// <summary>
            /// Post process payment (used by payment gateways that require redirecting to a third-party URL)
            /// </summary>
            /// <param name="postProcessPaymentRequest">Payment info required for an order processing</param>
            public void PostProcessPaymentDistributedOrder(PostProcessTransactionPaymentRequest postProcessPaymentRequest)
            {

                PGResponse objPGResponse = new PGResponse();
                CustomerDetails oCustomer = new CustomerDetails();
                SessionDetail oSession = new SessionDetail();
                AirLineTransaction oAirLine = new AirLineTransaction();
                MerchanDise oMerchanDise = new MerchanDise();

                SFA.CardInfo objCardInfo = new SFA.CardInfo();

                SFA.Merchant objMerchant = new SFA.Merchant();

                ShipToAddress objShipToAddress = new ShipToAddress();
                BillToAddress oBillToAddress = new BillToAddress();
                ShipToAddress oShipToAddress = new ShipToAddress();
                MPIData objMPI = new MPIData();
                PGReserveData oPGreservData = new PGReserveData();
                Address oHomeAddress = new Address();
                Address oOfficeAddress = new Address();
                // For getting unique MerchantTxnID 
                // Only for testing purpose. 
                // In actual scenario the merchant has to pass his transactionID
                DateTime oldTime = new DateTime(1970, 01, 01, 00, 00, 00);
                DateTime currentTime = DateTime.Now;
                TimeSpan structTimespan = currentTime - oldTime;
                string lMrtTxnID = ((long)structTimespan.TotalMilliseconds).ToString();
                var merchantId = _EmiPaymentSettings.MerchantId.ToString();
                var orderId = postProcessPaymentRequest.CurrentOrderTransaction.TransactionId;
                var Id = orderId.ToString();
                var amount = postProcessPaymentRequest.CurrentOrderTransaction.TransactionAmount.ToString(new CultureInfo("en-US", false).NumberFormat);


                //Setting Merchant Details
                objMerchant.setMerchantDetails(merchantId, merchantId, merchantId, "", lMrtTxnID, Id, "https://www.laorigin.com/PaymentEmi/ReturnDistributedOrder?orderId=" + Id, "POST", "INR", "INV123", "req.Sale", amount, "GMT+05:30", "ASP.NET64", "true", "ASP.NET64", "ASP.NET64", "ASP.NET64");

                // Setting BillToAddress Details
                oBillToAddress.setAddressDetails(postProcessPaymentRequest.Order.CustomerId.ToString(),
                                                   postProcessPaymentRequest.Order.Customer.SystemName,
                                                postProcessPaymentRequest.Order.BillingAddress.Address1,
                                                 postProcessPaymentRequest.Order.BillingAddress.Address2,
                                                 "",
                                                  postProcessPaymentRequest.Order.BillingAddress.City,
                                                 postProcessPaymentRequest.Order.BillingAddress.StateProvince.Name
                                                 , postProcessPaymentRequest.Order.BillingAddress.ZipPostalCode,
                                                 postProcessPaymentRequest.Order.BillingAddress.Country.Name,
                                                  postProcessPaymentRequest.Order.Customer.Email);

                // Setting ShipToAddress Details
                oShipToAddress.setAddressDetails(postProcessPaymentRequest.Order.BillingAddress.Address1,
                                                postProcessPaymentRequest.Order.BillingAddress.Address2,
                                                "",
                                                postProcessPaymentRequest.Order.BillingAddress.City,
                                                postProcessPaymentRequest.Order.BillingAddress.StateProvince.Name,

                                                postProcessPaymentRequest.Order.BillingAddress.ZipPostalCode,
                                                postProcessPaymentRequest.Order.BillingAddress.Country.Name,
                                                postProcessPaymentRequest.Order.Customer.Email);

                //Setting MPI datails.
                //objMPI.setMPIRequestDetails ("1000","INR10.00","356","2","2 shirts","","","","0","","image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/vnd.ms-powerpoint, application/vnd.ms-excel, application/msword, application/x-shockwave-flash, */*","Mozilla/4.0 (compatible; MSIE 5.5; Windows NT 5.0)");

                // Setting Name home/office Address Details 
                // Order of Parameters =>        AddLine1, AddLine2,      AddLine3,   City,   State ,  Zip,          Country, Email id
                oHomeAddress.setAddressDetails("2Sandeep", "Uttam Corner", "Chinchwad", "Pune", "state", "4385435873", "IND", "test@test.com");

                // Order of Parameters =>        AddLine1, AddLine2,      AddLine3,   City,   State ,  Zip,          Country, Email id
                oOfficeAddress.setAddressDetails("2Opus", "MayFairTowers", "Wakdewadi", "Pune", "state", "4385435873", "IND", "test@test.com");

                // Stting  Customer Details 
                // Order of Parameters =>  First Name,LastName ,Office Address Object,Home Address Object,Mobile No,RegistrationDate, flag for matching bill to address and ship to address 
                oCustomer.setCustomerDetails(postProcessPaymentRequest.Order.Customer.SystemName, "", oOfficeAddress, oHomeAddress, "", "13-06-2007", "Y");

                //Setting Merchant Dise Details 
                // Order of Parameters =>       Item Purchased,Quantity,Brand,ModelNumber,Buyers Name,flag value for matching CardName and BuyerName
                oMerchanDise.setMerchanDiseDetails("Computer", "2", "Intel", "P4", "Sandeep Patil", "Y");

                //Setting  Session Details        
                // Order of Parameters =>     Remote Address, Cookies Value            Browser Country,Browser Local Language,Browser Local Lang Variant,Browser User Agent'
                oSession.setSessionDetails(getRemoteAddr(), getSecureCookie(HttpContext.Current.Request), "", HttpContext.Current.Request.ServerVariables["HTTP_ACCEPT_LANGUAGE"], "", HttpContext.Current.Request.ServerVariables["HTTP_USER_AGENT"]);

                //Settingr AirLine Transaction Details  
                //Order of Parameters =>               Booking Date,FlightDate,Flight   Time,Flight Number,Passenger Name,Number Of Tickets,flag for matching card name and customer name,PNR,sector from,sector to'
                oAirLine.setAirLineTransactionDetails("10-06-2007", "22-06-2007", "13:20", "119", "Sandeep", "1", "Y", "25c", "Pune", "Mumbai");

                SFAClient objSFAClient = new SFAClient("c:\\inetpub\\wwwroot\\SFAClient\\Config\\");
                objPGResponse = objSFAClient.postSSL(objMPI, objMerchant, oBillToAddress, oShipToAddress, oPGreservData, oCustomer, oSession, oAirLine, oMerchanDise);

                if (objPGResponse.RedirectionUrl != "" & objPGResponse.RedirectionUrl != null)
                {
                    string strResponseURL = objPGResponse.RedirectionUrl;
                    HttpContext.Current.Response.Redirect(strResponseURL);
                }
                else
                {
                    HttpContext.Current.Response.Write("Response Code:" + objPGResponse.RespCode);
                    HttpContext.Current.Response.Write("Response message:" + objPGResponse.RespMessage);
                }
            }



            //Hide payment begins

            public bool HidePaymentMethod(IList<ShoppingCartItem> cart)
            {
                //you can put any logic here
                //for example, hide this payment method if all products in the cart are downloadable
                //or hide this payment method if current customer is from certain country
                return false;
            }

            //hide payment ends

            /// <summary>
            /// Gets additional handling fee
            /// </summary>
            /// <param name="cart">Shoping cart</param>
            /// <returns>Additional handling fee</returns>
            public decimal GetAdditionalHandlingFee(IList<ShoppingCartItem> cart)
            {
                return _EmiPaymentSettings.AdditionalFee;
            }

            /// <summary>
            /// Captures payment
            /// </summary>
            /// <param name="capturePaymentRequest">Capture payment request</param>
            /// <returns>Capture payment result</returns>
            public CapturePaymentResult Capture(CapturePaymentRequest capturePaymentRequest)
            {
                var result = new CapturePaymentResult();
                result.AddError("Capture method not supported");
                return result;
            }

            /// <summary>
            /// Refunds a payment
            /// </summary>
            /// <param name="refundPaymentRequest">Request</param>
            /// <returns>Result</returns>
            public RefundPaymentResult Refund(RefundPaymentRequest refundPaymentRequest)
            {
                var result = new RefundPaymentResult();
                result.AddError("Refund method not supported");
                return result;
            }

            /// <summary>
            /// Voids a payment
            /// </summary>
            /// <param name="voidPaymentRequest">Request</param>
            /// <returns>Result</returns>
            public VoidPaymentResult Void(VoidPaymentRequest voidPaymentRequest)
            {
                var result = new VoidPaymentResult();
                result.AddError("Void method not supported");
                return result;
            }

            /// <summary>
            /// Process recurring payment
            /// </summary>
            /// <param name="processPaymentRequest">Payment info required for an order processing</param>
            /// <returns>Process payment result</returns>
            public ProcessPaymentResult ProcessRecurringPayment(ProcessPaymentRequest processPaymentRequest)
            {
                var result = new ProcessPaymentResult();
                result.AddError("Recurring payment not supported");
                return result;
            }

            /// <summary>
            /// Cancels a recurring payment
            /// </summary>
            /// <param name="cancelPaymentRequest">Request</param>
            /// <returns>Result</returns>
            public CancelRecurringPaymentResult CancelRecurringPayment(CancelRecurringPaymentRequest cancelPaymentRequest)
            {
                var result = new CancelRecurringPaymentResult();
                result.AddError("Recurring payment not supported");
                return result;
            }

            /// <summary>
            /// Gets a value indicating whether customers can complete a payment after order is placed but not completed (for redirection payment methods)
            /// </summary>
            /// <param name="order">Order</param>
            /// <returns>Result</returns>
            public bool CanRePostProcessPayment(Order order)
            {
                if (order == null)
                    throw new ArgumentNullException("order");

                //Payu is the redirection payment method
                //It also validates whether order is also paid (after redirection) so customers will not be able to pay twice

                //payment status should be Pending
                if (order.PaymentStatus != PaymentStatus.Pending)
                    return false;

                //let's ensure that at least 1 minute passed after order is placed
                if ((DateTime.UtcNow - order.CreatedOnUtc).TotalMinutes < 1)
                    return false;

                return true;
            }

            /// <summary>
            /// Gets a route for provider configuration
            /// </summary>
            /// <param name="actionName">Action name</param>
            /// <param name="controllerName">Controller name</param>
            /// <param name="routeValues">Route values</param>
            public void GetConfigurationRoute(out string actionName, out string controllerName, out RouteValueDictionary routeValues)
            {
                actionName = "Configure";
                controllerName = "PaymentEmi";
                routeValues = new RouteValueDictionary() { { "Namespaces", "Nop.Plugin.Payments.Emi.Controllers" }, { "area", null } };
            }

            /// <summary>
            /// Gets a route for payment info
            /// </summary>
            /// <param name="actionName">Action name</param>
            /// <param name="controllerName">Controller name</param>
            /// <param name="routeValues">Route values</param>
            public void GetPaymentInfoRoute(out string actionName, out string controllerName, out RouteValueDictionary routeValues)
            {
                actionName = "PaymentInfo";
                controllerName = "PaymentEmi";
                routeValues = new RouteValueDictionary() { { "Namespaces", "Nop.Plugin.Payments.Emi.Controllers" }, { "area", null } };
            }

            public Type GetControllerType()
            {
                return typeof(PaymentEmiController);
            }

            public override void Install()
            {
                var settings = new EmiPaymentSettings()
                {
                    MerchantId = "",
                    Key = "",
                    MerchantParam = "",
                    PayUri = "https://payseal.icicibank.com/mpi/Ssl.jsp",
                    AdditionalFee = 0,
                };
                _settingService.SaveSetting(settings);

                //locales
                this.AddOrUpdatePluginLocaleResource("Plugins.Payments.Emi.RedirectionTip", "You will be redirected to ICICI site to complete the order.");
                this.AddOrUpdatePluginLocaleResource("Plugins.Payments.Emi.MerchantId", "Merchant ID");
                this.AddOrUpdatePluginLocaleResource("Plugins.Payments.Emi.MerchantId.Hint", "Enter merchant ID.");
                this.AddOrUpdatePluginLocaleResource("Plugins.Payments.Emi.Key", "Working Key");
                this.AddOrUpdatePluginLocaleResource("Plugins.Payments.Emi.Key.Hint", "Enter working key.");
                this.AddOrUpdatePluginLocaleResource("Plugins.Payments.Emi.MerchantParam", "Merchant Param");
                this.AddOrUpdatePluginLocaleResource("Plugins.Payments.Emi.MerchantParam.Hint", "Enter merchant param.");
                this.AddOrUpdatePluginLocaleResource("Plugins.Payments.Emi.PayUri", "Pay URI");
                this.AddOrUpdatePluginLocaleResource("Plugins.Payments.Emi.PayUri.Hint", "Enter Pay URI.");
                this.AddOrUpdatePluginLocaleResource("Plugins.Payments.Emi.AdditionalFee", "Additional fee");
                this.AddOrUpdatePluginLocaleResource("Plugins.Payments.Emi.AdditionalFee.Hint", "Enter additional fee to charge your customers.");

                base.Install();
            }

            public override void Uninstall()
            {
                //locales

                this.DeletePluginLocaleResource("Plugins.Payments.Emi.RedirectionTip");
                this.DeletePluginLocaleResource("Plugins.Payments.Emi.MerchantId");
                this.DeletePluginLocaleResource("Plugins.Payments.Emi.MerchantId.Hint");
                this.DeletePluginLocaleResource("Plugins.Payments.Emi.Key");
                this.DeletePluginLocaleResource("Plugins.Payments.Emi.Key.Hint");
                this.DeletePluginLocaleResource("Plugins.Payments.Emi.MerchantParam");
                this.DeletePluginLocaleResource("Plugins.Payments.Emi.MerchantParam.Hint");
                this.DeletePluginLocaleResource("Plugins.Payments.Emi.PayUri");
                this.DeletePluginLocaleResource("Plugins.Payments.Emi.PayUri.Hint");
                this.DeletePluginLocaleResource("Plugins.Payments.Emi.AdditionalFee");
                this.DeletePluginLocaleResource("Plugins.Payments.Emi.AdditionalFee.Hint");

                base.Uninstall();
            }
            #endregion

            #region Properies

            /// <summary>
            /// Gets a value indicating whether capture is supported
            /// </summary>
            public bool SupportCapture
            {
                get
                {
                    return false;
                }
            }

            /// <summary>
            /// Gets a value indicating whether partial refund is supported
            /// </summary>
            public bool SupportPartiallyRefund
            {
                get
                {
                    return false;
                }
            }

            /// <summary>
            /// Gets a value indicating whether refund is supported
            /// </summary>
            public bool SupportRefund
            {
                get
                {
                    return false;
                }
            }

            /// <summary>
            /// Gets a value indicating whether void is supported
            /// </summary>
            public bool SupportVoid
            {
                get
                {
                    return false;
                }
            }

            /// <summary>
            /// Gets a recurring payment type of payment method
            /// </summary>
            public RecurringPaymentType RecurringPaymentType
            {
                get
                {
                    return RecurringPaymentType.NotSupported;
                }
            }

            /// <summary>
            /// Gets a payment method type
            /// </summary>
            public PaymentMethodType PaymentMethodType
            {
                get
                {
                    return PaymentMethodType.Redirection;
                }
            }


            public bool SkipPaymentInfo
            {
                get
                {
                    return false;
                }
            }




            #endregion
        }
    }

