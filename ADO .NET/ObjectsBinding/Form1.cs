using System;
using System.Windows.Forms;

namespace ObjectsBinding
{
    public partial class Form1 : Form
    {
        private BindingSource bindingSource1;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bindingSource1 = new BindingSource();
            bindingSource1.DataSource = Controls;

            dataGridView1.DataSource = bindingSource1;
            dataGridView1.AutoGenerateColumns = true;
        }
    }

}
