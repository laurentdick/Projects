using System;
using System.Collections;
using System.Collections.Generic;

using ClassLibraryTools;


namespace TestGenericPersonne
{
    public class Personne
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public int CP { get; set; }
    }

    [Serializable]
    public class Config
    {
        private List<Personne> _keywords = new List<Personne>();

        public List<Personne> KeyWords { get { return _keywords; } set { _keywords = value; } }

        public void AddRange(IEnumerable<Personne> collection)
        {
            _keywords.AddRange(collection);
        }
    }

    internal static class TestGenericSerializationXML
    {        
        public static void Test()
        {
            new Title("Test Generic Serialization XML");

            Config config = new Config();

            config.AddRange(new Personne[] {
                new Personne() { Nom = "DICK", Prenom = "Laurent", CP = 57580 },
                new Personne() { Nom = "KAABAR", Prenom = "Rabab", CP = 57000 },
            });

            SerialisationXML<Config>.Serialize(System.Environment.CurrentDirectory + "\\test.xml", config);
//            config = (Config)SerialisationXML.DeSerialize(System.Environment.CurrentDirectory + "\\test.xml", config.GetType());

            new Title("Fin du Test Generic Serialization XML");
        }
    }
}
