using CrmBL;
using System;

using System.Windows.Forms;

namespace CrmUi
{
    public partial class ProductForm : Form
    {
        public Product Product { get; set; }
        
        public ProductForm()      // консруктор при обращении через окно добавить
        {
            InitializeComponent(); 
        }

        public ProductForm(Product product) : this() // конструктор при внесении изменений черз окно каталога
        {
            Product = product ?? new Product();
            textBox1.Text = Product.Name;
            numericUpDown1.Value = Product.Price;
            numericUpDown2.Value = Product.Count;
        }

        private void label1_Click(object sender, EventArgs e) // CustomerForm_Load ???
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Product = Product ?? new Product();
            Product.Name = textBox1.Text;
            Product.Price = numericUpDown1.Value;
            Product.Count = Convert.ToInt32(numericUpDown2.Value);
            Close();
        }

    }
}
