using System;
using System.Linq;
using System.IO;
using System.Drawing;

namespace SpotlightPictureExtractor
{
    class ExtractImages
    {
        public string pathToSource = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + 
            @"\Packages\Microsoft.Windows.ContentDeliveryManager_cw5n1h2txyewy\LocalState\Assets"; //Path to Spotlight pictures
        public string pathToDestination = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Spootlight Wallpapers"; //Desktop folder for wallpapers

        public void DirectoryCheck()
        {
            if (!Directory.Exists(pathToSource) || (bool)!Directory.EnumerateFileSystemEntries(pathToSource).Any())
            {
                Console.WriteLine("Source folder doesn't exist or empty, check your Spotlight settings. Press any key for exit");
                Console.ReadKey();
                throw new Exception ("Source folder doesn't exist or empty, check your Spotlight settings."); //Stop the program if Spotlight is switched off
            }

            if (!Directory.Exists(pathToDestination))
            {
                Directory.CreateDirectory(pathToDestination); //Create directory on Desktop
            }
        }

        public void CopyFiles()
        {
            DirectoryInfo di = new DirectoryInfo(pathToSource);
            FileInfo[] files = di.GetFiles();
            int fileName = Properties.Settings.Default.FileName;//File naming is set up in settings. Numbers are used as file names
            Image tempImage;
            
            foreach (FileInfo file in files)
            {
                tempImage = Image.FromFile(file.DirectoryName + "\\" + file.Name);
                if (tempImage.Width == 1920 && tempImage.Height == 1080) //Only FullHD wallpapers
                {
                    file.CopyTo(pathToDestination + "\\" + fileName + ".jpg"); //Rename files and add extensions
                    fileName++;
                }
            }

            Properties.Settings.Default.FileName = fileName;
            Properties.Settings.Default.Save();
        }


    }
}
