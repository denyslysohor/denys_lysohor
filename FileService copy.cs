using System;
using System.IO;

namespace MyLogger
{
    public class FileService
    {
        string date = DateTime.UtcNow.ToString("dd.MM.yyyy.hh.mm");
        string path = @"/Users/denyslysohor/logs";

        public void WriteBusinnessException(string typeOfLog1)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }

            using (FileStream flstream = new FileStream($"{path}/{date}.txt", FileMode.OpenOrCreate))
            {
                byte[] array = System.Text.Encoding.Default.GetBytes(typeOfLog1);
                flstream.Write(array, 0, array.Length);
            }
        }

        public void WriteErrorException(string typeOfLog2)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }

            using (FileStream flstream1 = new FileStream($"{path}/{date}.txt", FileMode.OpenOrCreate))
            {
                byte[] array = System.Text.Encoding.Default.GetBytes(typeOfLog2);
                flstream1.Write(array, 0, array.Length);
            }
        }
    }
}
