using System;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace ClassLibraryTools
{
    /// <summary>
    /// Classe générique de Sérialisation XML
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class SerialisationXML<T> where T : class, new()
    {
        /// <summary>
        /// Sérialisation
        /// </summary>
        /// <param name="nomFichier"></param>
        /// <param name="obj"></param>
        public static void Serialize(string nomFichier, T obj)
        {
            FileStream fs = new FileStream(nomFichier, FileMode.Create);

            try
            {
                XmlSerializer formatter = new XmlSerializer(typeof(T));

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
        /// Désérialisation
        /// </summary>
        /// <param name="nomFichier"></param>
        /// <returns></returns>
        public static T DeSerialize(string nomFichier)
        {
            T obj = null;

            if (File.Exists(nomFichier))
            {
                FileStream fs = new FileStream(nomFichier, FileMode.Open);

                try
                {
                    XmlSerializer formatter = new XmlSerializer(typeof(T));

                    obj = formatter.Deserialize(fs) as T;
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
                obj = new T();
            }

            return obj;
        }
    }
}
