using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculadoraDeJurosSimplesEComposto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            Limpar();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private async void btnCalculoSimples_Click(object sender, EventArgs e)
        {
            bool vpValido = double.TryParse(txtVPSimples.Text, out double vp);
            bool txValido = double.TryParse(txtTxSimples.Text, out double tx);
            bool nValido = double.TryParse(txtNSimples.Text, out double n);

            if (vpValido && txValido && nValido && n > 0 && tx > 0 && vp > 0)
            {
                txtResSimples.Text = "R$" + calcularJurosSimples(vp, tx, n).ToString("F2");
            }
            else
            {
                Limpar();
                labelAviso.Location = new Point(168, 39);
                labelAviso.Visible = true;
                System.Media.SystemSounds.Hand.Play();
                await Task.Delay(4000);
                labelAviso.Visible = false;
            }
        }

        private double calcularJurosSimples(double vp, double taxa, double tempo)
        {

            return vp * (1 + (taxa/100) * tempo);
        }

        private void Limpar()
        {
            txtNComposto.Clear();
            txtNSimples.Clear();
            txtResComposto.Clear();
            txtResSimples.Clear();
            txtTxComposto.Clear();
            txtTxSimples.Clear();
            txtVPComposto.Clear();
            txtVPSimples.Clear();
        }

        private async void btnCalculoComposto_Click(object sender, EventArgs e)
        {
            bool vpValido = double.TryParse(txtVPComposto.Text, out double vp);
            bool txValido = double.TryParse(txtTxComposto.Text, out double tx);
            bool nValido = double.TryParse(txtNComposto.Text, out double n);

            if (vpValido && txValido && nValido && n > 0 && tx > 0 && vp > 0)
            {
                txtResComposto.Text = "R$" + calcularJurosCompostos(vp, tx, n).ToString("F2");
            }
            else
            {
                Limpar();
                labelAviso.Location = new Point(168, 41);
                labelAviso.Visible = true;
                System.Media.SystemSounds.Hand.Play();
                await Task.Delay(4000);
                labelAviso.Visible = false;
            }
        }

        private double calcularJurosCompostos(double vp, double taxa, double tempo)
        {
            return vp * Math.Pow((1 + taxa / 100),tempo);
        }
    }
}
