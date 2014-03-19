using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace BindingSourceForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Airplane a1, a2, a3;
            airplaneBindingSource.Add(a1 = new Airplane("Boeing 747", 800));
            airplaneBindingSource.Add(a2 = new Airplane("Airbus A380", 1023));
            airplaneBindingSource.Add(a3 = new Airplane("Cessna 162", 67));
            a1.Passengers.Add(new Passenger("Joe Shmuck"));
            a1.Passengers.Add(new Passenger("Jack B. Nimble"));
            a1.Passengers.Add(new Passenger("Jib Jab"));
            a2.Passengers.Add(new Passenger("Jackie Tyler"));
            a2.Passengers.Add(new Passenger("Jane Doe"));
            a3.Passengers.Add(new Passenger("John Smith"));

            lstPassengers.DataSource = airplaneBindingSource;
            lstPassengers.DisplayMember = "Passengers.Name";

            ((BindingList<Airplane>)airplaneBindingSource.List).AllowNew = true;
        }
    }
}
