using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace BD_ITOG
{
    class MainForm : Form
    {
        public MainForm()
		{
            this.Width = 400;
            this.Height = 300;
            this.MinimumSize = new Size(350, 250);
            this.StartPosition = FormStartPosition.CenterScreen;

            var Librarian = InicialItem.Button("Библиотекари", DockStyle.Fill);
            var Book = InicialItem.Button("Книги", DockStyle.Fill);
            var Abonement = InicialItem.Button("Читательские билеты", DockStyle.Fill);
            var NewReadrer = InicialItem.Button("Зарегистрировать читателя", DockStyle.Fill);
            var NewBook = InicialItem.Button("Добавить книгу", DockStyle.Fill);
            var NewAuthor = InicialItem.Button("Добавить Автора", DockStyle.Fill);
            var ItogVid = InicialItem.Button("Итоги выдачи", DockStyle.Fill);
            var ItogBibl = InicialItem.Button("Итоги библиотекари", DockStyle.Fill);
            var thief = InicialItem.Button("Должники", DockStyle.Fill);

            var table = new TableLayoutPanel();
            table.RowStyles.Clear();

            int Rows = 3;
            for (var i = 0; i < Rows; i++)
            {
                table.RowStyles.Add(new RowStyle(SizeType.Percent, 100 / Rows));
            }
            var Cols = 3;
            for (var i = 0; i < Cols; i++)
            {
                table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100 / Cols));
            }

            table.Controls.Add(Librarian, 0, 0);
            table.Controls.Add(Book, 0, 1);
            table.Controls.Add(Abonement, 0, 2);

            table.Controls.Add(NewReadrer, 1, 0);
            table.Controls.Add(NewBook, 1, 1);
            table.Controls.Add(NewAuthor, 1, 2);

            table.Controls.Add(ItogVid, 2, 0);
            table.Controls.Add(ItogBibl, 2, 1);
            table.Controls.Add(thief, 2, 2);

            table.Dock = DockStyle.Fill;
            Controls.Add(table);


            Librarian.Click += (sender, args) => new LibrarianForm().ShowDialog();

            //чтобы не зависало при первом открытии форм
            string connectionString = @"Data Source=KOMPYTER-ALEKSE\SQLEXPRESS;Initial Catalog=InSy;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            connection.Close();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "MainForm";
            this.Text = "Меню";
            this.ResumeLayout(false);

        }
    }
}
