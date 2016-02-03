using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Nop.Web.Models.Catalog
{
    public class ProductEmiModal
    {
        public List<EmiModal> HdfcList { get; set; }
        public List<EmiModal> SBI { get; set; }
        public List<EmiModal> ICICI { get; set; }
        public List<EmiModal> AXIS { get; set; }
        public List<EmiModal> Citibank { get; set; }
        public List<EmiModal> Kotak { get; set; }

        public ProductEmiModal LoadJson(double price)
        {
            using (StreamReader r = new StreamReader(Path.Combine(HttpContext.Current.Server.MapPath("~"), @"Scripts/EMIJson.json")))
            {
                string json = r.ReadToEnd();
                ProductEmiModal modal = JsonConvert.DeserializeObject<ProductEmiModal>(json);
                modal.HdfcList = CalculateEMI(price, modal.HdfcList);
                modal.SBI = CalculateEMI(price, modal.SBI);
                modal.ICICI = CalculateEMI(price, modal.ICICI);
                modal.AXIS = CalculateEMI(price, modal.AXIS);
                modal.Citibank = CalculateEMI(price, modal.Citibank);
                modal.Kotak = CalculateEMI(price, modal.Kotak);
                return modal;
            }

        }

        List<EmiModal> CalculateEMI(double price, List<EmiModal> modal)
        {
            double p = price;

            foreach (var banklist in modal)
            {
                double r = banklist.Interest / 12 / 100;
                double n = banklist.EMITenure;
                banklist.EMIAmount = Math.Round(((p * r * Math.Pow((1 + r), n)) / ((Math.Pow((1 + r), n) - 1))));
                banklist.TotalPayment = Math.Round(banklist.EMIAmount * banklist.EMITenure);
            }
            return modal;
        }
    }

    public class EmiModal
    {
        public string BankName { get; set; }
        public double EMITenure { get; set; }
        public double Interest { get; set; }
        public double EMIAmount { get; set; }
        public double TotalPayment { get; set; }
    }


    
}