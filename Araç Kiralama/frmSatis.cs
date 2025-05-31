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
    public partial class frmSatis : Form
    {
        public frmSatis()
        {
            InitializeComponent();
        }
        Araç_Kiralama arac = new Araç_Kiralama();
        private void frmSatis_Load(object sender, EventArgs e)
        {
            string sorgu2 = "select * from satis";
            SqlDataAdapter adtr2=new SqlDataAdapter();
            dataGridView1.DataSource = arac.listele(adtr2,sorgu2);
            arac.satisHesapla(label1);
        }
    }
}
