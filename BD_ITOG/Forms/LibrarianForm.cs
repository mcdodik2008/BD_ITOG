using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BD_ITOG
{
    class LibrarianForm : Form
    {

        Button delete, save, newString, Chanje;
        TextBox Librarian, DataBirthDay;
        DataGridView dataGrid;
        public LibrarianForm()
        {
            Width = 340;
            Height = 380;
            MinimumSize = new Size(400, 300);
            MaximumSize = new Size(750, 650);
            StartPosition = FormStartPosition.CenterScreen;

            delete = InicialItem.Button("Удалить");
            save = InicialItem.Button("Сохранить");
            newString = InicialItem.Button("Новый");
            Chanje = InicialItem.Button("Изменить");

            Librarian = new TextBox();
            DataBirthDay = new TextBox();

            var headText = new List<string> { "id_lib", "Библиотекарь", "Дата рождения" };
            var isVisible = new List<bool> { false, true, true };
            var nVisible = isVisible.FindAll(x => x == true).Count;
            dataGrid = InicialItem.DaraGrid(headText, isVisible);

            Load += (sender, args) => { LibrarianForm_Load(sender, EventArgs.Empty); OnSizeChanged(EventArgs.Empty); };
            SizeChanged += (sender, args) =>
            {
                var width = this.Width;
                var heigth = this.Height;
                // Позиционируем и изменяем размер таблички
                PlaseResizeDataGrid(nVisible, width, heigth);
                PlaseResizeButtons(width, heigth);
                PlaseResizeTextBox(nVisible);
            };

            AddControls();   
        }

        private void FillingDatagrid(List<List<string>> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                dataGrid.Rows.Add();
                dataGrid.Rows[i].Cells[0].Value = list[i][0];
                dataGrid.Rows[i].Cells[1].Value = list[i][1];
                dataGrid.Rows[i].Cells[2].Value = list[i][2];
            }
        }

        private void LibrarianForm_Load(object sender, EventArgs e)
        {

            string book = @"select *
                               from InSy.dbo.Librarian";
            FillingDatagrid(SQL.ReadSql(book));
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // LibrarianForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "LibrarianForm";
            this.ResumeLayout(false);

        }

        private void PlaseResizeDataGrid(int nVisible, int width, int heigth)
        {
            dataGrid.Location = new Point(10, 10);
            dataGrid.Width = width - 35;
            dataGrid.Height = heigth - 160;
            foreach (DataGridViewTextBoxColumn col in dataGrid.Columns)
            {
                col.Width = (dataGrid.Width - 44) / nVisible;
            }
        }
        private void PlaseResizeTextBox(int nVisible)
        {
            Librarian.Width = DataBirthDay.Width = (dataGrid.Width - 44) / nVisible;
            Librarian.Height = DataBirthDay.Height = 20;
            Librarian.Location = new Point(47, dataGrid.Bottom + 10);
            DataBirthDay.Location = new Point(Librarian.Right + 5, dataGrid.Bottom + 10);
        }
        private void PlaseResizeButtons(int width, int heigth)
        {
            var bntWidth = (width - 65) / 4;
            var btnHeigth = heigth / 10;
            delete.Size = new Size(bntWidth, btnHeigth);
            save.Size = new Size(bntWidth, btnHeigth);
            newString.Size = new Size(bntWidth, btnHeigth);
            Chanje.Size = new Size(bntWidth, btnHeigth);

            delete.Location = new Point(10, heigth - btnHeigth - 40);
            save.Location = new Point(delete.Right + 10, heigth - btnHeigth - 40);
            newString.Location = new Point(save.Right + 10, heigth - btnHeigth - 40);
            Chanje.Location = new Point(newString.Right + 10, heigth - btnHeigth - 40);
        }
        private void AddControls()
        {
            Controls.Add(dataGrid);
            Controls.Add(delete);
            Controls.Add(save);
            Controls.Add(newString);
            Controls.Add(Chanje);
            Controls.Add(Librarian);
            Controls.Add(DataBirthDay);
        }
    }
}
