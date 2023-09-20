using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace PDVAppNovi
{
    public partial class Form1 : Form
    {
        private int rowHeight;
        private int rowCount = 0;
        private int itemWidth = 120;
        private int itemHeight = 30;
        private int horizontalSpace = 165;
        private RacunManager racunManager;
        decimal airbnbSalesSum;
        decimal airbnbCommissionSum;
        private List<string> enteredAndSavedValues = new List<string>();



        public Form1()
        {
            InitializeComponent();
            rowHeight = 30;
            racunManager = new RacunManager(panel1);
            racunManager.CreateRowR1Racuni(rowCount, rowHeight, itemWidth, itemHeight, horizontalSpace);
            rowCount++;
            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonAddNewRow_Click(object sender, EventArgs e)
        {
            racunManager.CreateRowR1Racuni(rowCount, rowHeight, itemWidth, itemHeight, horizontalSpace);
            rowCount++;
        }

        private void buttonIzracunajR1Racun_Click(object sender, EventArgs e)
        {
            R1RacunCalculationHelper.GetUkupneR1Iznose(racunManager.Racuni, labelOsnovicaUkupnoR1, labelPDVUkupnoR1, labelUkupnoR1,
                labelOsnovica25, labelPDV25, labelUkupnoR125, labelOsnovica5, labelPDV5, labelUkupnoR15,
             labelOsnovica13, labelPDV13, labelUkupnoR113);
        }

        private void buttonIzracunajPDV_Click(object sender, EventArgs e)
        {
            PDVCalculationData data = new PDVCalculationData
            {
                LabelBookingOsnovica = labelBookingOsnovica,
                LabelBookingPDV = labelBookingPDV,
                NumericUpDownBookingSales = numericUpDownBookingSales,
                NumericUpDownCommissionNoPDVBooking = numericUpDownCommissionNoPDVBooking,
                NumericUpDownAirbnbSales = numericUpDownAirbnbSales,
                NumericUpDownCommissionNoPDVAirbnb = numericUpDownCommissionNoPDVAirbnb,
                LabelAirbnbOsnovica = labelAirbnbOsnovica,
                LabelAirbnbPDV = labelAirbnbPDV,
                LabelOsnovicaUkupno = labelOsnovicaUkupno,
                LabelPDVUkupno = labelPDVUkupno,
                LabelCommisionTotalOsnovicaValue = labelCommisionTotalOsnovicaValue,
                LabelCommisionTotalPDVValue = labelCommisionTotalPDVValue,
                LabelOdjeljak2Red2OsnovicaValue = labelOdjeljak2Red2OsnovicaValue,
                LabelOdjeljak2Red2PDVValue = labelOdjeljak2Red2PDVValue,
                LabelOdjeljak2Red10OsnovicaValue = labelOdjeljak2Red10OsnovicaValue,
                LabelOdjeljak2Red10PDVValue = labelOdjeljak2Red10PDVValue,
                LabelOdjeljak3Red10OsnovicaValue = labelOdjeljak3Red10OsnovicaValue,
                LabelOdjeljak3Red10PDVValue = labelOdjeljak3Red10PDVValue,


            };

            PDVCalculationHelper.GetPDVPodatke(data);
        }


        private void RemoveButton_Click(object sender, EventArgs e)
        {
            racunManager.DeleteRacunRow(rowCount, rowHeight);
            rowCount--;

        }

        private void SaveButtonAirbnb_Click(object sender, EventArgs e)
        {
            AirbnbDataManager.SaveAirbnbData(
                ref airbnbSalesSum,
                ref airbnbCommissionSum,
                numericUpDownAirbnbSales,
                numericUpDownCommissionNoPDVAirbnb,
                enteredAndSavedValues,
                listBoxAirbnb,
                labelAirbnbSumSaved);
        }


        private void buttonLoadCSV_Click(object sender, EventArgs e)
        {

        }

        private void ClearButtonAirbnb_Click(object sender, EventArgs e)
        {
            listBoxAirbnb.Items.Clear();
            airbnbSalesSum = 0;
            airbnbCommissionSum = 0;
            numericUpDownAirbnbSales.Value = 0;
            numericUpDownCommissionNoPDVAirbnb.Value = 0;

        }

        private void ClearLastRowButtonAirbnb_Click(object sender, EventArgs e)
        {

            int totalItemNumber = listBoxAirbnb.Items.Count;
            if (totalItemNumber > 0)
            {
                string lastItem = listBoxAirbnb.Items[totalItemNumber - 1].ToString();
                string[] values = lastItem.Split(new[] { "," }, StringSplitOptions.None);

                if (values.Length == 2)
                {
                    decimal salesToRemove, commisionToRemove;

                    if (values[0].StartsWith("Sales: ") && values[1].StartsWith(" Commission: ") &&
                        decimal.TryParse(values[0].Substring(7), out salesToRemove) &&
                        decimal.TryParse(values[1].Substring(12), out commisionToRemove))
                    {
                        airbnbSalesSum -= salesToRemove;
                        airbnbCommissionSum -= commisionToRemove;
                        numericUpDownAirbnbSales.Value = airbnbSalesSum;
                        numericUpDownCommissionNoPDVAirbnb.Value = airbnbCommissionSum;

                    }
                }
                listBoxAirbnb.Items.RemoveAt(totalItemNumber - 1);
            }

        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                AirbnbDataManager.SaveAirbnbData(
                    ref airbnbSalesSum,
                    ref airbnbCommissionSum,
                    numericUpDownAirbnbSales,
                    numericUpDownCommissionNoPDVAirbnb,
                    enteredAndSavedValues,
                    listBoxAirbnb,
                    labelAirbnbSumSaved);
            }
        }

    }
}