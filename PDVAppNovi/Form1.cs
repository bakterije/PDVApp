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

        public Form1()
        {
            InitializeComponent();
            rowHeight = 30;
            racunManager = new RacunManager(panel1);
            racunManager.CreateRowR1Racuni(rowCount, rowHeight, itemWidth, itemHeight, horizontalSpace);
            rowCount++;
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
            PDVCalculationHelper.GetPDVPodatke(labelBookingOsnovica, labelBookingPDV, numericUpDownBookingSales,
            numericUpDownCommissionNoPDVBooking, numericUpDownAirbnbSales, numericUpDownCommissionNoPDVAirbnb,
            labelAirbnbOsnovica, labelAirbnbPDV, labelOsnovicaUkupno, labelPDVUkupno, labelCommisionTotalOsnovicaValue, labelCommisionTotalPDVValue);
        }
    }
}