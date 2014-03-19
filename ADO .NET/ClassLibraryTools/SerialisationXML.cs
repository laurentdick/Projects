using System;
using System.IO;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace ClassLibraryTools
{
    /// <summary>
    /// Classe statique de sérialisation XML
    /// </summary>
    public static class SerialisationXML
    {
        /// <summary>
        /// Sérialisation XML d'un objet quelconque
        /// </summary>
        public static void Serialize(string nomFichier, object obj)
        {
            FileStream fs = new FileStream(nomFichier, FileMode.Create);

            try
            {
                XmlSerializer formatter = new XmlSerializer(obj.GetType());

                formatter.Serialize(fs, obj);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Echec de la sérialization XML. Raison: " + e.Message);
            }
            finally
            {
                fs.Close();
            }
        }

        /// <summary>
        /// Désérialisation XML d'un objet quelconque
        /// </summary>
        public static object DeSerialize(string nomFichier, Type typeObject)
        {
           object obj = null;

            if (File.Exists(nomFichier))
            {
                FileStream fs = new FileStream(nomFichier, FileMode.Open);

                try
                {
                    XmlSerializer formatter = new XmlSerializer(typeObject);

                    obj = formatter.Deserialize(fs);
                }
                catch (SerializationException e)
                {
                    Console.WriteLine("Echec de la désérialization XML. Raison: " + e.Message);
                }
                finally
                {
                    fs.Close();
                }
            }
            else
            {
                obj = Activator.CreateInstance(typeObject);
            }

            return obj;
        }
    }
}
