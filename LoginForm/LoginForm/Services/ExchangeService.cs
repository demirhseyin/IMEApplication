﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using LoginForm.DataSet;
using System.Windows.Forms;

namespace LoginForm.Services
{
    class ExchangeService
    {
        public string GetExchangeRateforEuro()
        {

            string today = "http://www.tcmb.gov.tr/kurlar/today.xml";

            var xmlDoc = new XmlDocument();
            xmlDoc.Load(today);



            string BuyEuro = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteBuying").InnerXml;
            string SellEuro = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteSelling").InnerXml;

            return SellEuro;
        }

        public ExchangeRate GetExchangeRateforDolar()
        {
            ExchangeRate RateForDolar = new ExchangeRate();
            string today = "http://www.tcmb.gov.tr/kurlar/today.xml";

            var xmlDoc = new XmlDocument();
            xmlDoc.Load(today);

            string Name = "USD";
            DateTime TodayDate = new DateTime();
            TodayDate = DateTime.Now.Date;
            string BuyUSDeffective = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteBuying").InnerXml;
            string SellUSDEffective = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteSelling").InnerXml;
            string BuyUSD = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/ForexSelling").InnerXml;
            string SellUSD = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/ForexBuying").InnerXml;

            if (BuyUSD.Contains('.'))
                BuyUSD = BuyUSD.Replace('.', ',');
            if (BuyUSDeffective.Contains('.'))
                BuyUSDeffective = BuyUSDeffective.Replace('.', ',');
            if (SellUSD.Contains('.'))
                SellUSD = SellUSD.Replace('.', ',');
            if (SellUSDEffective.Contains('.'))
                SellUSDEffective = SellUSDEffective.Replace('.', ',');
     
            RateForDolar.Code = Name;
            RateForDolar.RateDate = TodayDate;
            RateForDolar.ExchangeBuy = Decimal.Parse(BuyUSD);
            RateForDolar.ExchangeSell = Decimal.Parse(SellUSD);
            RateForDolar.ExchangeBuyEffective = Decimal.Parse(BuyUSDeffective);
            RateForDolar.ExchangeSellEffective = Decimal.Parse(SellUSDEffective);
           
            return RateForDolar;
        }

        public ExchangeRate GetExchangeRateforSterlin()
        {

            ExchangeRate RateforSterlin = new ExchangeRate();
            string today = "http://www.tcmb.gov.tr/kurlar/today.xml";

            var xmlDoc = new XmlDocument();
            xmlDoc.Load(today);

            string Name = "STR";
            DateTime TodayDate = new DateTime();
            TodayDate = DateTime.Now.Date;
            string BuySTReffective = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='GBP']/BanknoteBuying").InnerXml;
            string SellSTREffective = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='GBP']/BanknoteSelling").InnerXml;
            string BuySTR = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/ForexSelling").InnerXml;
            string SellSTR = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/ForexBuying").InnerXml;

            if (BuySTR.Contains('.'))
                BuySTR = BuySTR.Replace('.', ',');
            if (BuySTReffective.Contains('.'))
                BuySTReffective = BuySTReffective.Replace('.', ',');
            if (SellSTR.Contains('.'))
                SellSTR = SellSTR.Replace('.', ',');
            if (SellSTREffective.Contains('.'))
                SellSTREffective = SellSTREffective.Replace('.', ',');

            RateforSterlin.Code = Name;
            RateforSterlin.RateDate = TodayDate;
            RateforSterlin.ExchangeBuy = Decimal.Parse(BuySTR);
            RateforSterlin.ExchangeSell = Decimal.Parse(SellSTR);
            RateforSterlin.ExchangeBuyEffective = Decimal.Parse(BuySTReffective);
            RateforSterlin.ExchangeSellEffective = Decimal.Parse(SellSTREffective);

            return RateforSterlin;
        }
    }
}
