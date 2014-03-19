using System.Collections.Generic;

namespace BindingSourceForm
{
    class Airplane
    {
        private static int lastID = 0;
        private int _id;

        public int ID { get { return _id; } }
        public int FuelLeftKg { get; set; }
        public string Model { get; set; }

        private List<Passenger> _passengers;
        public List<Passenger> Passengers { get { return _passengers; } }

        public Airplane()
        {
            _id = ++lastID;
            _passengers = new List<Passenger>();
            _passengers.Add(new Passenger("DICK Laurent"));
            FuelLeftKg = 1500;
            Model = "Airbus A380";
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="model"></param>
        /// <param name="fuelKg"></param>
        public Airplane(string model, int fuelKg) : this()
        {
            _passengers.Clear();
            Model = model;
            FuelLeftKg = fuelKg;
        }
    }
}
