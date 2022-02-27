using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BD_ITOG
{
    public static class InicialItem
    {
        public static DataGridView DaraGrid(List<string> headText, List<bool> isVisible = null)
        {
            int n = headText.Count;
           
            if (isVisible == null)
            {
                isVisible = new List<bool>(n);
                for (var i = 0; i < n; i++)
                    isVisible.Add(true);
            }
            var nVisible = isVisible.FindAll(x => x == true).Count;

            var dataGrid = new DataGridView();
            DataGridViewTextBoxColumn[] column = new DataGridViewTextBoxColumn[n];
            for (int i = 0; i < n; i++)
            {
                column[i] = new DataGridViewTextBoxColumn();
                column[i].HeaderText = headText[i];
                column[i].Name = headText[i];
                column[i].Visible = isVisible[i];
            }
            dataGrid.Columns.AddRange(column);

            return dataGrid;
        }

        public static Button Button(string text, DockStyle Ds = DockStyle.None)
        {
            return new Button
            {
                Text = text,
                Dock = Ds
            };
        }

        public static TextBox TextBox(DockStyle Ds = DockStyle.None)
        {
            return new TextBox
            {
                Dock = Ds
            };
        }
    }
}
