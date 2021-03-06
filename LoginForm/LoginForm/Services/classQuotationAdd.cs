﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginForm.DataSet;

namespace LoginForm.Services
{
    
    class classQuotationAdd
    {
        public static string customersearchID;
        public static string customersearchname;
        public static string customerID;
        public static string customername;
        public static List<Customer> CustomerSearch()
        {
            IMEEntities IME = new IMEEntities();
            List<Customer> c = new List<Customer>();
            if (customersearchname == "")
            {
                c = IME.Customers.Where(a => a.ID.Contains(customersearchID)).ToList();
            }
            else
            {
                c = IME.Customers.Where(a => a.c_name.Contains(customersearchname)).ToList();
            }
            return c;
        }

        public static SuperDisk ItemGetSuperDisk(string ItemID)
        {
            IMEEntities IME = new IMEEntities();
            
            return IME.SuperDisks.Where(a => a.Article_No == ItemID).FirstOrDefault();

        }
        public static SuperDiskP ItemGetSuperDiskP(string ItemID)
        {
            IMEEntities IME = new IMEEntities();
            return IME.SuperDiskPs.Where(a => a.Article_No == ItemID).FirstOrDefault();

        }
        public static ExtendedRange ItemGetExtendedRange(string ItemID)
        {
            IMEEntities IME = new IMEEntities();
            return IME.ExtendedRanges.Where(a => a.ArticleNo == ItemID).FirstOrDefault();
        }
        public static decimal GetCost(string ArticleNo, int quantity)
        {
            #region GetCost
            if (quantity == 0) { return -1; }
            IMEEntities IME = new IMEEntities();
            SlidingPrice sp = IME.SlidingPrices.Where(a => a.ArticleNo == ArticleNo).FirstOrDefault();
            decimal result;
            try
            {
                if (quantity< sp.Col2Break && sp.DiscountedPrice1 != 0)
                {
                    return result = Decimal.Parse(sp.DiscountedPrice1.ToString());
                }
                else if (quantity < sp.Col3Break && sp.DiscountedPrice2 != 0)
                {
                    return result = Decimal.Parse(sp.DiscountedPrice2.ToString());
                }
                else if (quantity < sp.Col4Break && sp.DiscountedPrice3 != 0)
                {
                    return result = Decimal.Parse(sp.DiscountedPrice3.ToString());
                }
                else if (quantity < sp.Col5Break && sp.DiscountedPrice4 != 0)
                {
                    return result = Decimal.Parse(sp.DiscountedPrice4.ToString());
                }
                else if (sp.DiscountedPrice4 != 0) { return result = Decimal.Parse(sp.DiscountedPrice5.ToString()); }
            }
            catch { }
            return -1;// fiyatının olmadığı gösteriyor
            #endregion
        }
        public static decimal GetLandingCost(string ArticleNo)
        {
            #region Calculating LandingCost
            IMEEntities IME = new IMEEntities();
            SlidingPrice sp = IME.SlidingPrices.Where(a => a.ArticleNo == ArticleNo).FirstOrDefault();
            decimal p = 0;
            if (sp != null) { p = Decimal.Parse(sp.DiscountedPrice1.ToString());}
            decimal w=0;
            var sd = IME.SuperDisks.Where(a => a.Article_No == ArticleNo).FirstOrDefault();
            var sdP = IME.SuperDiskPs.Where(a => a.Article_No == ArticleNo).FirstOrDefault();
            var er = IME.ExtendedRanges.Where(a => a.ArticleNo == ArticleNo).FirstOrDefault();
            if (sd != null)
            {
                w = Decimal.Parse(sd.Standard_Weight.ToString());
                w=(w/ (decimal)1000);
            }
            else if(sdP != null)
            {
                w = Decimal.Parse(sdP.Standard_Weight.ToString());
                w = (w / (decimal)1000);
            }
            else if (er!= null)
            {
                w = Decimal.Parse(er.ExtendedRangeWeight.ToString());
                w = (w / (decimal)1000);
            }
           
            decimal l=0;
            if (!(w == 0 || p == 0))
            {
                l = (p + (w * ((decimal)1.7)) + (((decimal)0.0675) * (p + (w * ((decimal)1.7)))));
                return l;
            }
            return l;
            #endregion
        }
        public static decimal GetPrice(string ArticleNo, int quantity)
        {
            #region GetPrice
            if (quantity == 0) { return -1; }
            IMEEntities IME = new IMEEntities();
            SlidingPrice sp = IME.SlidingPrices.Where(a => a.ArticleNo == ArticleNo).FirstOrDefault();
            decimal result;
            try
            {
                if (quantity < sp.Col2Break && sp.DiscountedPrice1 != 0)
                {
                    return result = Decimal.Parse(sp.Col1Price.ToString());
                }
                else if (quantity < sp.Col3Break && sp.DiscountedPrice2 != 0)
                {
                    return result = Decimal.Parse(sp.Col2Price.ToString());
                }
                else if (quantity < sp.Col4Break && sp.DiscountedPrice3 != 0)
                {
                    return result = Decimal.Parse(sp.Col3Price.ToString());
                }
                else if (quantity < sp.Col5Break && sp.DiscountedPrice4 != 0)
                {
                    return result = Decimal.Parse(sp.Col4Price.ToString());
                }
                else if (sp.DiscountedPrice4 != 0) { return result = Decimal.Parse(sp.Col5Price.ToString()); }
            }
            catch { }
            return -1;// fiyatının olmadığı gösteriyor
            #endregion
        }
    }
}
