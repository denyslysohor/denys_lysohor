using System;
using System.IO;

namespace MyLogger
{
    public class FileService
    {
        string date = DateTime.UtcNow.ToString("dd.MM.yyyy.hh.mm");
        string path = @"/Users/denyslysohor/logs";

        public void BusinnessException()
        {
            string typeOfLog1 = "Action got this custom Exception: Skipped logic";
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }

            using (FileStream flstream = new FileStream($"{path}/{date}.json", FileMode.OpenOrCreate))
            {
                byte[] array = System.Text.Encoding.Default.GetBytes(typeOfLog1);
                flstream.Write(array, 0, array.Length);
            }

        }

        public void ErrorException()
        {
            string typeOfLog2 = "Error";
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }

            using (FileStream flstream1 = new FileStream($"{path}/{date}.json", FileMode.OpenOrCreate))
            {
                byte[] array = System.Text.Encoding.Default.GetBytes(typeOfLog2);
                flstream1.Write(array, 0, array.Length);
            }
        }
    }
}
