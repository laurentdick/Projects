using System;
using System.Windows.Forms;

using PatternLibrary;

namespace CollectionEnumBinding
{
    public partial class Form1 : Form
    {
        private Node nodes;
        private BindingSource nodeBinding;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Node rep1, rep2, rep3;

            nodes = new Node("root");
            nodes.AddRange(
                new Node[]
                {
                    rep1 = new Node("répertoire1"),
                    rep2 = new Node("répertoire2"),
                    rep3 = new Node("répertoire3")
                });

            rep1.AddRange(
                new Node[]
                {
                    new Node("File1"),
                    new Node("File2"),
                    new Node("File3"),
                    new Node("File4"),
                    new Node("File5"),
                    new Node("File6"),
                });

            rep2.AddRange(
                new Node[]
                {
                    new Node("File1"),
                    new Node("File2"),
                    new Node("File3"),
                });

            rep3.AddRange(
                new Node[]
                {
                    new Node("File1"),
                });

            nodeBinding = new BindingSource();
            nodeBinding.Add(nodes);

            listBox1.DataSource = nodeBinding;
            listBox1.DisplayMember = "Name";

            listBox2.DataSource = nodeBinding;
            listBox2.DisplayMember = "Nodes.Name";

            listBox3.DataSource = nodeBinding;
            listBox3.DisplayMember = "Nodes.Nodes.Name";
        }
    }
}
