using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SpotlightPictureExtractor
{
    class Program
    {
        static void Main(string[] args)
        {
            ExtractImages ei = new ExtractImages();
            
            ei.DirectoryCheck(); //Check whether directory exists or not 
            ei.CopyFiles(); //Copy and modify wallpapers
        }
    }
}
