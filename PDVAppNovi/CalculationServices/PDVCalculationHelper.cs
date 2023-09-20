

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PDVAppNovi.CalculationServices
{
    public class PDVCalculationHelper
    {

        public static decimal GetPDVPodatke(PDVCalculationData data)
        {
            decimal numericBookingSales = data.NumericUpDownBookingSales.Value;
            decimal numericCommissionNoPDVBooking = data.NumericUpDownCommissionNoPDVBooking.Value;
            decimal numericAirbnbSales = data.NumericUpDownAirbnbSales.Value;
            decimal numericCommissionNoPDVAirbnb = data.NumericUpDownCommissionNoPDVAirbnb.Value;
            decimal BookingPDV = (numericBookingSales - numericCommissionNoPDVBooking) * 13 / 113;
            decimal BookingOsnovica = numericBookingSales - numericCommissionNoPDVBooking - BookingPDV;
            decimal AirbnbPDV = (numericAirbnbSales - numericCommissionNoPDVAirbnb) * 13 / 113;
            decimal AirbnbOsnovica = numericAirbnbSales - numericCommissionNoPDVAirbnb - AirbnbPDV;
            decimal OsnovicaUkupno = BookingOsnovica + AirbnbOsnovica;
            decimal PDVUkupno = BookingPDV + AirbnbPDV;
            decimal CommissionTotalOsnovica = numericCommissionNoPDVAirbnb + numericCommissionNoPDVBooking;
            decimal CommissionTotalPDVValue = CommissionTotalOsnovica * 25 / 100;

            data.LabelBookingOsnovica.Text = BookingOsnovica.ToString("C");
            data.LabelBookingPDV.Text = BookingPDV.ToString("C");
            data.NumericUpDownBookingSales.Value = numericBookingSales;
            data.NumericUpDownCommissionNoPDVBooking.Value = numericCommissionNoPDVBooking;
            data.NumericUpDownAirbnbSales.Value = numericAirbnbSales;
            data.NumericUpDownCommissionNoPDVAirbnb.Value = numericCommissionNoPDVAirbnb;
            data.LabelAirbnbOsnovica.Text = AirbnbOsnovica.ToString("C");
            data.LabelAirbnbPDV.Text = AirbnbPDV.ToString("C");
            data.LabelOsnovicaUkupno.Text = OsnovicaUkupno.ToString("C");
            data.LabelPDVUkupno.Text = PDVUkupno.ToString("C");
            data.LabelCommisionTotalOsnovicaValue.Text = CommissionTotalOsnovica.ToString("C");
            data.LabelCommisionTotalPDVValue.Text = CommissionTotalPDVValue.ToString("C");
            data.LabelOdjeljak2Red2OsnovicaValue.Text = OsnovicaUkupno.ToString("C");
            data.LabelOdjeljak2Red2PDVValue.Text = PDVUkupno.ToString("C");
            data.LabelOdjeljak2Red10OsnovicaValue.Text = CommissionTotalOsnovica.ToString("C");
            data.LabelOdjeljak2Red10PDVValue.Text = CommissionTotalPDVValue.ToString("C");
            data.LabelOdjeljak3Red10OsnovicaValue.Text = CommissionTotalOsnovica.ToString("C");
            data.LabelOdjeljak3Red10PDVValue.Text = CommissionTotalPDVValue.ToString("C");

            return BookingPDV;
        }
    }
}