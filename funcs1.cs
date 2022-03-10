using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoW
{
    public static class funcs1
    {
        public static string parseWay(string way)
        {
            int beg = way.LastIndexOf("\\");
            way = "\\" + way.Remove(0, beg + 1);
            return way;
        }

        public static string parseDirectory(string wayOut, string newName, bool isFile)
        {
            string ex = ""; 

            if (isFile)
            {
                int beg = wayOut.LastIndexOf(".");
                ex = wayOut.Remove(0, beg);
            }

            int end = wayOut.LastIndexOf("\\");
            string way = wayOut.Remove(end, wayOut.Length - end);

            way += "\\" + newName + ex; 
            return way;
        }

        public static string chooseDirectory()
        {
            System.Windows.Forms.FolderBrowserDialog fbdReader = new System.Windows.Forms.FolderBrowserDialog();
            if (fbdReader.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                return fbdReader.SelectedPath;
            }
            return "";
        }
    }
}
