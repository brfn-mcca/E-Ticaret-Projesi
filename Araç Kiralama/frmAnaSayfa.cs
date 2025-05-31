using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Araç_Kiralama
{
    public partial class frmAnaSayfa : Form
    {
        public frmAnaSayfa()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmMüşteriEkle ekle = new frmMüşteriEkle();
            ekle.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmMüşteriListele litele = new frmMüşteriListele();
            litele.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmAraçKayıt kayıt = new frmAraçKayıt();
            kayıt.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmAraçLislete listele = new frmAraçLislete();
            listele.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmSözleşme sozlesme = new frmSözleşme();
            sozlesme.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmSatis satis = new frmSatis();
            satis.ShowDialog();
        }
    }
}
