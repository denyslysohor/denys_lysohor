using System;
namespace DataStorage
{
    public class DataStore : IDataStore<string>
    {
        public int Count => array.Length;

        public string[] Items => array;

        private string[] array = new string[0];


        public void Add(string item)
        {
            string[] array1 = new string[array.Length + 1];

            for (int i = 0; i < array.Length; i++)
            {
                array1[i] = array[i];
            }

            array1[array.Length] = item;

            array = array1;
        }

        public void Remove(string item)
        {
            bool isConsist = false;

            foreach (var el in array)
            {
                if (el == item)
                {
                    isConsist = true;
                }
            }

            if (isConsist == true)
            {
                string[] array2 = new string[array.Length];

                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] != item)
                    {
                        array2[i] = array[i];
                    }

                }
                array = array2;
            }
        }
    }
}
