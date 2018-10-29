using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coala
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void btnAlteraImagem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.Title = "Abrir imagem";
            dlg.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = dlg.FileName;
            }

            dlg.Dispose();
        }

        private void NovoClick(object sender, EventArgs e)
        {
            Random r = new Random();
            DataGridViewRow row = (DataGridViewRow)dG.Rows[0].Clone();
            row.Cells[0].Value = r.Next(1, 8000);
            row.Cells[1].Value = txtNome.Text;
            row.Cells[2].Value = txtSobrenome.Text;
            row.Cells[3].Value = txtCidade.Text;
            row.Cells[4].Value = txtEstado.Text;
            row.Cells[5].Value = txtNasc.Text;
            row.Cells[6].Value = txtEmail.Text;
            dG.Rows.Add(row);

        private void ClickDel(object sender, EventArgs e)
        {

        }
    }
}
