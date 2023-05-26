using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PDVAppNovi
{
    public class PDVCalculationHelper
    {
    
        public static decimal GetPDVPodatke(Label labelBookingOsnovica, Label labelBookingPDV,NumericUpDown numericUpDownBookingSales,
            NumericUpDown numericUpDownCommissionNoPDVBooking, NumericUpDown numericUpDownAirbnbSales, NumericUpDown numericUpDownCommissionNoPDVAirbnb,
            Label labelAirbnbOsnovica,Label labelAirbnbPDV, Label labelOsnovicaUkupno, Label labelPDVUkupno, 
            Label labelCommisionTotalOsnovicaValue, Label labelCommisionTotalPDVValue)
        {
            decimal BookingOsnovica;
            decimal BookingPDV;
            decimal AirbnbOsnovica;
            decimal AirbnbPDV;
            decimal numericAirbnbSales;
            decimal numericCommissionNoPDVAirbnb;
            decimal numericBookingSales;
            decimal numericCommissionNoPDVBooking;
            decimal OsnovicaUkupno;
            decimal PDVUkupno;
            decimal CommissionTotalOsnovica;
            decimal CommissionTotalPDVValue;


            numericBookingSales = numericUpDownBookingSales.Value;
            numericCommissionNoPDVBooking = numericUpDownCommissionNoPDVBooking.Value;
            numericAirbnbSales = numericUpDownAirbnbSales.Value;
            numericCommissionNoPDVAirbnb = numericUpDownCommissionNoPDVAirbnb.Value;



            BookingPDV = (numericUpDownBookingSales.Value - numericUpDownCommissionNoPDVBooking.Value) * 13 / Convert.ToDecimal(113);
            BookingOsnovica = numericBookingSales - numericCommissionNoPDVBooking - BookingPDV;
            AirbnbPDV = (numericUpDownAirbnbSales.Value - numericUpDownCommissionNoPDVAirbnb.Value) * 13 / Convert.ToDecimal(113);
            AirbnbOsnovica = numericBookingSales - numericCommissionNoPDVAirbnb - AirbnbPDV;
            OsnovicaUkupno = BookingOsnovica + AirbnbOsnovica;
            PDVUkupno = BookingPDV + AirbnbPDV;
            CommissionTotalOsnovica = numericCommissionNoPDVAirbnb + numericCommissionNoPDVBooking;
            CommissionTotalPDVValue = CommissionTotalOsnovica * 25 / Convert.ToDecimal(100);

            labelBookingOsnovica.Text = BookingOsnovica.ToString("C");
            labelBookingPDV.Text = BookingPDV.ToString("C");
            labelAirbnbOsnovica.Text = AirbnbOsnovica.ToString("C");
            labelAirbnbPDV.Text = AirbnbPDV.ToString("C");
            labelOsnovicaUkupno.Text = OsnovicaUkupno.ToString("C");
            labelPDVUkupno.Text = PDVUkupno.ToString("C");
            labelCommisionTotalOsnovicaValue.Text = CommissionTotalOsnovica.ToString("C");
            labelCommisionTotalPDVValue.Text = CommissionTotalPDVValue.ToString("C");
            return BookingPDV;



                }
        
    }
}
