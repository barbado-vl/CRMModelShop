using CrmBL;
using System;

using System.Windows.Forms;

namespace CrmUi
{
    public partial class SellerForm : Form
    {
        public Seller Seller { get; set; }
        
        public SellerForm()
        {
            InitializeComponent();
        }

        public SellerForm(Seller seller) : this() // конструктор при внесении изменений черз окно каталога
        {
            Seller = seller ?? new Seller();
            textBox1.Text = seller.Name;

        }

        private void label1_Click(object sender, EventArgs e) // CustomerForm_Load ???
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Seller = Seller ?? new Seller();
            Seller.Name = textBox1.Text;

            Close();
        }
    }
}
