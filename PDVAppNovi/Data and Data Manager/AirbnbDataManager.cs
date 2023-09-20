using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDVAppNovi
{
    public class AirbnbDataManager
    {
        public static void SaveAirbnbData(
            ref decimal airbnbSalesSum,
            ref decimal airbnbCommissionSum,
            NumericUpDown numericUpDownAirbnbSales,
            NumericUpDown numericUpDownCommissionNoPDVAirbnb,
            List<string> enteredAndSavedValues,
            ListBox listBoxAirbnb,
            Label labelAirbnbSumSaved)
        {
            decimal airbnbSalesToAdd = numericUpDownAirbnbSales.Value;
            decimal airbnbCommissionToAdd = numericUpDownCommissionNoPDVAirbnb.Value;

            airbnbSalesSum += airbnbSalesToAdd;
            airbnbCommissionSum += airbnbCommissionToAdd;

            numericUpDownAirbnbSales.Value = airbnbSalesSum;
            numericUpDownCommissionNoPDVAirbnb.Value = airbnbCommissionSum;

            string valueToAdd = $"Sales: {airbnbSalesToAdd}, Commission: {airbnbCommissionToAdd}";
            enteredAndSavedValues.Add(valueToAdd);

            listBoxAirbnb.Items.Add(valueToAdd);

            labelAirbnbSumSaved.Text = "Saved and Updated";
        }
    }

}
