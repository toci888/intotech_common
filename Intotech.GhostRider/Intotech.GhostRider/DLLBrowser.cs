using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.GhostRider
{
    public class DLLBrowser
    {
        public string SelectDLL()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "DLL files (*.dll)|*.dll";
            openFileDialog.InitialDirectory = "C:\\";

            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string PathToDLL = openFileDialog.FileName;
                return PathToDLL;
            }

            return null;
        }
        
    }
}
