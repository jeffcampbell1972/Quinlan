using System;

using Quinlan.Domain.Models;

namespace Quinlan.MVC.Services
{
    public static class FormatService
    {
        public static string BuildAttributes(Card card)
        {
            string attributes = "";

            if (card.RCFlag)
            {
                attributes = "RC";
            }
            if (card.SPFlag)
            {
                if (attributes != "")
                {
                    attributes = String.Format("{0} / {1}", attributes, "SP");
                }
                else
                {
                    attributes = "SP";
                }
            }
            if (card.PatchFlag)
            {
                if (attributes != "")
                {
                    attributes = String.Format("{0} / {1}", attributes, "RELIC");
                }
                else
                {
                    attributes = "Relic";
                }
            }
            if (card.AUFlag)
            {
                if (attributes != "")
                {
                    attributes = String.Format("{0} / {1}", attributes, "AU");
                }
                else
                {
                    attributes = "AU";
                }
            }

            return attributes;
        }
    
        public static string FormatDollars(decimal? amount)
        {
            if (amount == null)
            {
                return "";
            }

            decimal _amount = Convert.ToDecimal(amount);

            return _amount.ToString("c");
        }
    }
}
