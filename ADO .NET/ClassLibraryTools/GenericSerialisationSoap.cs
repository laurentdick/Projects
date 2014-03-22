using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Soap;

namespace ClassLibraryTools
{
    public static class SerialisationSoap<T> where T : class, new()
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
                SoapFormatter formatter = new SoapFormatter();

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
                    SoapFormatter formatter = new SoapFormatter();

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
