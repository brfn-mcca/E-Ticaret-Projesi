using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Araç_Kiralama
{
    public partial class frmSözleşme : Form
    {
        public frmSözleşme()
        {
            InitializeComponent();
        }
        Araç_Kiralama arac = new Araç_Kiralama();
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void frmSözleşme_Load(object sender, EventArgs e)
        {
            Bos_Araclar();
            Yenile();
        }

        private void Bos_Araclar()
        {
            string sorgu2 = "select * from araç where durumu='BOŞ'";
            arac.Bos_Araclar(comboAraclar, sorgu2);
        }

        private void Yenile()
        {
            string sorgu3 = "select* from sozlesme";
            SqlDataAdapter adtr2 = new SqlDataAdapter();
            dataGridView1.DataSource = arac.listele(adtr2, sorgu3);
        }

        private void txtTc_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void comboAraclar_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sorgu2 = "select * from araç where plaka like'" + comboAraclar.SelectedItem + "'";
            arac.CombodanGetir(comboAraclar, txtMarka, txtSeri, txtYil, txtRenk, sorgu2);
        }

        private void comboKiraŞekli_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sorgu2 = "select * from araç where plaka like'" + comboAraclar.SelectedItem + "'";
            arac.UcretHesapla(comboKiraŞekli,txtKiraUcreti,sorgu2);
            
        }

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            TimeSpan gun =DateTime.Parse( dateDonus.Text) - DateTime.Parse (dateCıkıs.Text);
            int gun2 = gun.Days;
            txtGun.Text = gun2.ToString();
            txtTutar.Text = (gun2 * int.Parse(txtKiraUcreti.Text)).ToString();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();

        }

        private void Temizle()
        {
            dateCıkıs.Text = DateTime.Now.ToShortDateString();
            dateDonus.Text = DateTime.Now.ToShortDateString();
            comboKiraŞekli.Text = " ";
            txtKiraUcreti.Text = " ";
            txtGun.Text = " ";
            txtTutar.Text = " ";
        }

        private void btnS_Ekle_Click(object sender, EventArgs e)
        {
            string sorgu2 = "insert into sozlesme(tc,adSoyad,telefon,ehliyetNo,e_Tarih,e_Yer,plaka,marka,seri,yil,renk,kiraSekli,kiraUcreti,gun,tutar,cTarih,dTarih)values(@tc,@adSoyad,@telefon,@ehliyetNo,@e_Tarih,@e_Yer,@plaka,@marka,@seri,@yil,@renk,@kiraSekli,@kiraUcreti,@gun,@tutar,@cTarih,@dTarih)";
            SqlCommand komut2 = new SqlCommand();
            komut2.Parameters.AddWithValue("@tc", txtTc.Text);
            komut2.Parameters.AddWithValue("@adsoyad", txtAdSoyad.Text);
            komut2.Parameters.AddWithValue("@telefon", txtTelefon.Text);
            komut2.Parameters.AddWithValue("@ehliyetNo", txtE_No.Text);
            komut2.Parameters.AddWithValue("@e_Tarih", txtE_Tarih.Text);
            komut2.Parameters.AddWithValue("@e_Yer", txtE_Yer.Text);
            komut2.Parameters.AddWithValue("@plaka", comboAraclar.Text);
            komut2.Parameters.AddWithValue("@marka", txtMarka.Text);
            komut2.Parameters.AddWithValue("@seri", txtSeri.Text);
            komut2.Parameters.AddWithValue("@yil", txtYil.Text);
            komut2.Parameters.AddWithValue("@renk", txtRenk.Text);
            komut2.Parameters.AddWithValue("@kiraSekli", comboKiraŞekli.Text);
            komut2.Parameters.AddWithValue("@kiraUcreti", int.Parse(txtKiraUcreti.Text));
            komut2.Parameters.AddWithValue("@gun", int.Parse(txtGun.Text));
            komut2.Parameters.AddWithValue("@tutar", int.Parse(txtTutar.Text));
            komut2.Parameters.AddWithValue("@cTarih", dateCıkıs.Text);
            komut2.Parameters.AddWithValue("@dTarih", dateDonus.Text);
            arac.ekle_sil_güncelle(komut2, sorgu2);

            string sorgu3 = "update araç set durumu='DOLU'where plaka='" + comboAraclar.Text + "'";
            SqlCommand komut3 = new SqlCommand();
            arac.ekle_sil_güncelle(komut3, sorgu3);
            comboAraclar.Items.Clear();
            Bos_Araclar();
            Yenile();
            comboAraclar.Text = " ";
            foreach (Control item in groupBox1.Controls)
                if (item is TextBox)
                    item.Text = " ";
            foreach (Control item in groupBox2.Controls)
                if (item is TextBox)
                    item.Text = " ";
            Temizle();
            MessageBox.Show("Sözleşme Eklendi");
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtTcAra_TextChanged(object sender, EventArgs e)
        {
            if (txtTc.Text == " ")
                foreach (Control item in groupBox1.Controls)
                    if (item is TextBox)
                        item.Text = " ";
            string sorgu2 = "select * from Müşteri where tc like'" + txtTcAra.Text + "'";
            arac.TC_Ara(txtTcAra,txtTc, txtAdSoyad, txtTelefon, sorgu2);
        }

        private void btnS_Guncelle_Click(object sender, EventArgs e)
        {
            string sorgu2 = "update sozlesme set tc=@tc,adSoyad=@adSoyad,telefon=@telefon,ehliyetNo=@ehliyetNo,e_tarih=@e_tarih,e_yer=@e_yer,marka=@marka,seri=@seri,yil=@yil, renk=@renk,kiraSekli=@kiraSekli,kiraUcreti=@kiraUcreti,gun=@gun,tutar=@tutar,cTarih=@cTarih,dTarih=@dTarih where plaka=@plaka";
            SqlCommand komut2 = new SqlCommand();
            komut2.Parameters.AddWithValue("@tc", txtTc.Text);
            komut2.Parameters.AddWithValue("@adsoyad", txtAdSoyad.Text);
            komut2.Parameters.AddWithValue("@telefon", txtTelefon.Text);
            komut2.Parameters.AddWithValue("@ehliyetNo", txtE_No.Text);
            komut2.Parameters.AddWithValue("@e_Tarih", txtE_Tarih.Text);
            komut2.Parameters.AddWithValue("@e_Yer", txtE_Yer.Text);
            komut2.Parameters.AddWithValue("@plaka", comboAraclar.Text);
            komut2.Parameters.AddWithValue("@marka", txtMarka.Text);
            komut2.Parameters.AddWithValue("@seri", txtSeri.Text);
            komut2.Parameters.AddWithValue("@yil", txtYil.Text);
            komut2.Parameters.AddWithValue("@renk", txtRenk.Text);
            komut2.Parameters.AddWithValue("@kiraSekli", comboKiraŞekli.Text);
            komut2.Parameters.AddWithValue("@kiraUcreti", int.Parse(txtKiraUcreti.Text));
            komut2.Parameters.AddWithValue("@gun", int.Parse(txtGun.Text));
            komut2.Parameters.AddWithValue("@tutar", int.Parse(txtTutar.Text));
            komut2.Parameters.AddWithValue("@cTarih", dateCıkıs.Text);
            komut2.Parameters.AddWithValue("@dTarih", dateDonus.Text);
            arac.ekle_sil_güncelle(komut2, sorgu2);
            comboAraclar.Items.Clear();
            Bos_Araclar();
            Yenile();
            comboAraclar.Text = " ";
            foreach (Control item in groupBox1.Controls)
                if (item is TextBox)
                    item.Text = " ";
            foreach (Control item in groupBox2.Controls)
                if (item is TextBox)
                    item.Text = " ";
            Temizle();
            MessageBox.Show("Sözleşme Güncellendi");
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            txtTc.Text = satir.Cells[0].Value.ToString();
            txtAdSoyad.Text = satir.Cells[1].Value.ToString();
            txtTelefon.Text = satir.Cells[2].Value.ToString();
            txtE_No.Text = satir.Cells[3].Value.ToString();
            txtE_Tarih.Text = satir.Cells[4].Value.ToString();
            txtE_Yer.Text = satir.Cells[5].Value.ToString();
            comboAraclar.Text = satir.Cells[6].Value.ToString();
            txtMarka.Text = satir.Cells[7].Value.ToString();
            txtSeri.Text = satir.Cells[8].Value.ToString();
            txtYil.Text = satir.Cells[9].Value.ToString();
            txtRenk.Text = satir.Cells[10].Value.ToString();
            comboKiraŞekli.Text = satir.Cells[11].Value.ToString();
            txtKiraUcreti.Text = satir.Cells[12].Value.ToString();
            txtGun.Text = satir.Cells[13].Value.ToString();
            txtTutar.Text = satir.Cells[14].Value.ToString();
            dateCıkıs.Text = satir.Cells[15].Value.ToString();
            dateDonus.Text = satir.Cells[16].Value.ToString();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            DateTime bugun = DateTime.Parse(DateTime.Now.ToShortDateString());
            DateTime donus = DateTime.Parse(satir.Cells["dTarih"].Value.ToString());
            int ucret = int.Parse(satir.Cells["kiraUcreti"].Value.ToString());
            TimeSpan gunfarki = bugun - donus;
            int _gunfarki = gunfarki.Days;
            int ucretFarki;
            ucretFarki = _gunfarki * ucret;
            txtekstra.Text = ucretFarki.ToString();
        }

        private void btnAracTeslim_Click(object sender, EventArgs e)
        {
            if (txtekstra.Text != " ") 
            {
                DataGridViewRow satir = dataGridView1.CurrentRow;
                DateTime bugun = DateTime.Parse(DateTime.Now.ToShortDateString());
                int ucret = int.Parse(satir.Cells["kiraUcreti"].Value.ToString());
                int tutar = int.Parse(satir.Cells["tutar"].Value.ToString());
                DateTime cıkıs = DateTime.Parse(satir.Cells["cTarih"].Value.ToString());
                TimeSpan gun = bugun - cıkıs;
                int _gun = gun.Days;
                int toplamTutar = _gun * ucret;
                string sorgu1 = " ";
                txtekstra.Text = "delete from sozlesme where plaka='" + satir.Cells["plaka"].Value.ToString() + "'  ";
                SqlCommand komut = new SqlCommand();
                arac.ekle_sil_güncelle(komut, sorgu1);
                string sorgu2 = "update araç set durumu='BOŞ' where plaka='" + satir.Cells["plaka"].Value.ToString() + "'";
                SqlCommand komut3 = new SqlCommand();
                arac.ekle_sil_güncelle(komut3, sorgu2);
                string sorgu3 = "insert into satis(tc,adSoyad,plaka,marka,seri,yil,renk,gun,fiyat,tutar,tarih1,tarih2)values(@tc,@adSoyad,@plaka,@marka,@seri,@yil,@renk,@gun,@fiyat,@tutar,@tarih1,@tarih2)";
                SqlCommand komut2 = new SqlCommand();
                komut2.Parameters.AddWithValue("@tc", satir.Cells["tc"].Value.ToString());
                komut2.Parameters.AddWithValue("@adsoyad", satir.Cells["adSoyad"].Value.ToString());
                komut2.Parameters.AddWithValue("@plaka", satir.Cells["plaka"].Value.ToString());
                komut2.Parameters.AddWithValue("@marka", satir.Cells["marka"].Value.ToString());
                komut2.Parameters.AddWithValue("@seri", satir.Cells["seri"].Value.ToString());
                komut2.Parameters.AddWithValue("@yil", satir.Cells["yil"].Value.ToString());
                komut2.Parameters.AddWithValue("@renk", satir.Cells["renk"].Value.ToString());
                komut2.Parameters.AddWithValue("@gun", _gun);
                komut2.Parameters.AddWithValue("@fiyat",ucret);
                komut2.Parameters.AddWithValue("@tutar", toplamTutar);
                komut2.Parameters.AddWithValue("@tarih1", satir.Cells["cTarih"].Value.ToString());
                komut2.Parameters.AddWithValue("@tarih2", DateTime.Now.ToShortDateString());
                arac.ekle_sil_güncelle(komut2, sorgu3);
                MessageBox.Show("Araç teslim edildi.");
                comboAraclar.Items.Clear();
                Bos_Araclar();
                Yenile();
                comboAraclar.Text = " ";
                foreach (Control item in groupBox1.Controls)
                    if (item is TextBox)
                        item.Text = " ";
                foreach (Control item in groupBox2.Controls)
                    if (item is TextBox)
                        item.Text = " ";
                Temizle();
                comboAraclar.Text = " ";


            }
            else if (txtekstra.Text == " ")
            {
                MessageBox.Show("Lütfen seçim yapınız", "Uyarı");
            }
        }
    }
}
