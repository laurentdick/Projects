
namespace BindingSourceForm
{
    class Passenger
    {
        private static int lastID = 0;
        public int _id;
        public int ID { get { return _id; } }
        public string Name { get; set; }

        public Passenger(string name)
        {
            _id = ++lastID; Name = name;
        }
    }
}
