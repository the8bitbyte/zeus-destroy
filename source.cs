using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace zeus_destroy
{
    internal class Program
    {
        static void Main()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("M\"\"\"MMV .gP\"Ya `7MM  `7MM  ,pP\"Ybd               ,,                                                    \r\n'  AMV ,M'   Yb  MM    MM  8I   `\"             `7MM                    mm                              \r\n  AMV  8M\"\"\"\"\"\"  MM    MM  `YMMMa.               MM                    MM                              \r\n AMV  ,YM.    ,  MM    MM  L.   I8          ,M\"\"bMM  .gP\"Ya  ,pP\"Ybd mmMMmm `7Mb,od8 ,pW\"Wq.`7M'   `MF'\r\nAMMmmmM `Mbmmd'  `Mbod\"YML.M9mmmP'        ,AP    MM ,M'   Yb 8I   `\"   MM     MM' \"'6W'   `Wb VA   ,V  \r\n ____________________      .   ,          8MI    MM 8M\"\"\"\"\"\" `YMMMa.   MM     MM    8M     M8  VA ,V   \r\n/                    /\\  . , ; .          `Mb    MM YM.    , L.   I8   MM     MM    YA.   ,A9   VVV    \r\n|                    |~~~~~X.;' .          `Wbmd\"MML.`Mbmmd' M9mmmP'   `Mbmo.JMML.   `Ybmd9'    ,V   \r\n\\____________________\\/' `\" ' `                                                                ,V     \r\n                            '                                                               OOb\"       ");
            
            Console.WriteLine("\n[ 1 ] destroy a file\n[ 2 ] about zeus destroy\n[ 3 ] quit");
            string maininput = Console.ReadLine();
            if (maininput == "1")
            {
                destroy();
            }
            if (maininput == "2")
            {
                Console.WriteLine("zeus destroy is a console application used to perminatly delete files in a way where they can not be recovered, when you delete a file the data is still there but it is just free to be written to, this app corrupts the data before deleteing therefor making that data useless");
                Console.WriteLine("\npress any key to continue...");
                Console.ReadKey();
                Console.Clear();
                Main();
            }
            if (maininput == "3")
            {
                return;
            }
        }
        static void destroy()
        {
            Console.WriteLine("please enter the filepath of the file you wish to remove");
            string destroyinput = Console.ReadLine();
            string Ddestroyinput = destroyinput.Replace("\"", "");
            try
            {
                
                long fileSize = new FileInfo(Ddestroyinput).Length;

                
                byte[] junkData = GenerateRandomData(fileSize);

                
                File.WriteAllBytes(Ddestroyinput, junkData);

                Console.WriteLine("Random junk data written to the file successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            File.Delete(Ddestroyinput);
            Console.WriteLine("file removed successfully");
            Thread.Sleep(1500);
            Console.Clear();
            Main();
        }
        static byte[] GenerateRandomData(long size)
        {
            const int chunkSize = 1024; // 1 KB chunk size
            byte[] data = new byte[size];

            using (RandomNumberGenerator rng = new RNGCryptoServiceProvider())
            {
                for (long offset = 0; offset < size; offset += chunkSize)
                {
                    int chunk = (int)Math.Min(chunkSize, size - offset);
                    rng.GetBytes(data, (int)offset, chunk);
                }
            }

            return data;
        }
    }
}
