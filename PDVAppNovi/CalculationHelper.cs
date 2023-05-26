using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PDVAppNovi
{
    public class CalculationHelper
    {
        private static List<string> porezneStope = new List<string>()
        {
            "5%",
            "13%",
            "25%"
        };

        public static int GetPoreznaStopa(ComboBox poreznaStopa)
        {
            int selectedInt;
            if (poreznaStopa.SelectedIndex == -1)
            {
                selectedInt = 0;
            }
            else
            {
                selectedInt = poreznaStopa.SelectedIndex;
            }
            string selected = porezneStope[selectedInt];
            selected = selected.Replace("%", "");
            if (int.TryParse(selected, out int stopa))
            {
                Console.WriteLine(selected);
                return stopa;
            }
            else
            {
                return 0;
            }
        }

        public static decimal GetUkupneR1Iznose(List<RacunManager.RacunRow> racuni, Label labelOsnovicaUkupnoR1,
            Label labelPDVUkupnoR1, Label labelUkupnoR1, Label labelOsnovica25, Label labelPDV25, 
            Label labelUkupnoR125, Label labelOsnovica5, Label labelPDV5, Label labelUkupnoR15,
            Label labelOsnovica13, Label labelPDV13, Label labelUkupnoR113)
        {
            decimal ukupnaOsnovica = 0;
            decimal ukupniPDV = 0;
            decimal ukupniracun;
            decimal ukupnaOsnovica25 = 0;
            decimal ukupniPDV25 = 0;
            decimal ukupniRacun25;
            decimal ukupnaOsnovica5 = 0;
            decimal ukupniPDV5 = 0;
            decimal ukupniRacun5;
            decimal ukupnaOsnovica13 = 0;
            decimal ukupniPDV13 = 0;
            decimal ukupniRacun13;

            foreach (RacunManager.RacunRow racunRow in racuni)
            {
                if (racunRow.PoreznaStopa.SelectedItem.ToString() == "25%")
                {
                    ukupnaOsnovica25 += racunRow.Osnovica.Value;
                    ukupniPDV25 += racunRow.PDV.Value;
                }
                if (racunRow.PoreznaStopa.SelectedItem.ToString() == "5%")
                {
                    ukupnaOsnovica5 += racunRow.Osnovica.Value;
                    ukupniPDV5 += racunRow.PDV.Value;
                }
                
                    if (racunRow.PoreznaStopa.SelectedItem.ToString() == "13%")
                {
                    ukupnaOsnovica13 += racunRow.Osnovica.Value;
                    ukupniPDV13 += racunRow.PDV.Value;
                }
                
                ukupnaOsnovica += racunRow.Osnovica.Value;
                ukupniPDV += racunRow.PDV.Value;
            }


            // Izracun svih poreznih stopa
            ukupniracun = ukupnaOsnovica + ukupniPDV;
            labelOsnovicaUkupnoR1.Text = ukupnaOsnovica.ToString("C");
            labelPDVUkupnoR1.Text = ukupniPDV.ToString("C");
            labelUkupnoR1.Text = ukupniracun.ToString("C");
            
            // Izracun R1 Racuna Kamatna stopa 25%
            ukupniRacun25 = ukupnaOsnovica25 + ukupniPDV25;
            labelOsnovica25.Text = ukupnaOsnovica25.ToString("C");
            labelPDV25.Text = ukupniPDV25.ToString("C");
            labelUkupnoR125.Text = ukupniRacun25.ToString("C");

            // Izracun R1 Racuna Kamatna stopa 5%
            ukupniRacun5 = ukupnaOsnovica25 + ukupniPDV5;
            labelOsnovica5.Text = ukupnaOsnovica5.ToString("C");
            labelPDV5.Text = ukupniPDV5.ToString("C");
            labelUkupnoR15.Text = ukupniRacun5.ToString("C");

            // Izracun R1 Racuna Kamatna stopa 13%
            ukupniRacun13 = ukupnaOsnovica13 + ukupniPDV13;
            labelOsnovica13.Text = ukupnaOsnovica13.ToString("C");
            labelPDV13.Text = ukupniPDV13.ToString("C");
            labelUkupnoR113.Text = ukupniRacun13.ToString("C");

            return ukupniracun;
        }
    }
}