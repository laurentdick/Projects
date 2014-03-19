using System;

namespace TestGenericPersonne
{
    public class Title
    {
        public Title(string title)
        {
            int lineLength = 80;
            int paddingLeft = title.Length + ((lineLength - title.Length) / 2);

            Console.WriteLine(Environment.NewLine + title.PadLeft(paddingLeft, '-').PadRight(lineLength, '-'));
        }
    }
}
