using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PDVAppNovi
{
    public class RacunManager
    {
        public List<RacunRow> Racuni { get; private set; }
        private Panel panel;

        public RacunManager(Panel panel)
        {
            this.panel = panel;
            Racuni = new List<RacunRow>();
        }

        public void CreateRow(int rowCount, int rowHeight, int itemWidth, int itemHeight, int horizontalSpace)
        {
            int currentPositionZ = rowCount * (rowHeight + 10);
            int horisontalOffset = 10;
            // Create controls for the new row
            RacunRow racunRow = new RacunRow();
            racunRow.Osnovica.Location = new Point(horisontalOffset, currentPositionZ);
            racunRow.Osnovica.Height = itemHeight;
            racunRow.Osnovica.Width = itemWidth;

            racunRow.PDV.Location = new Point(horizontalSpace + horisontalOffset, currentPositionZ);
            racunRow.PDV.Height = itemHeight;
            racunRow.PDV.Width = itemWidth;

            racunRow.PoreznaStopa.FormattingEnabled = true;
            racunRow.PoreznaStopa.Location = new Point((horizontalSpace * 2) + horisontalOffset, currentPositionZ);
            racunRow.PoreznaStopa.Height = itemHeight;
            racunRow.PoreznaStopa.Width = itemWidth;
            racunRow.PoreznaStopa.DropDownStyle = ComboBoxStyle.DropDownList;
            racunRow.PoreznaStopa.Name = $"PoreznaStopa_{rowCount}";
            racunRow.PoreznaStopaValue();

            // Add the controls to the panel
            panel.AutoScroll = false;
            panel.Controls.Add(racunRow.Osnovica);
            panel.Controls.Add(racunRow.PDV);
            panel.Controls.Add(racunRow.PoreznaStopa);
            panel.AutoScrollMinSize = new Size(0, rowCount * 30);
            panel.AutoScroll = true;

            Racuni.Add(racunRow);
        }

        public class RacunRow
        {
            public NumericUpDown Osnovica { get; set; }
            public NumericUpDown PDV { get; set; }
            public ComboBox PoreznaStopa { get; set; }

            public int PoreznaStopaValue() => getPoreznaStopa();

            private List<string> porezneStope = new List<string>()
            {
                "5%",
                "13%",
                "25%"
            };

            public RacunRow()
            {
                Osnovica = new NumericUpDown();
                PDV = new NumericUpDown();
                PoreznaStopa = new ComboBox();
                PoreznaStopa.DataSource = porezneStope;
            }

            private int getPoreznaStopa()
            {
                int selectedInt;
                if (PoreznaStopa.SelectedIndex == -1)
                {
                    selectedInt = 0;
                }
                else
                {
                    selectedInt = PoreznaStopa.SelectedIndex;
                }
                string selected = porezneStope[selectedInt];
                selected = selected.Replace("%", "");
                if (int.TryParse(selected, out int stopa))
                {
                    return stopa;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}