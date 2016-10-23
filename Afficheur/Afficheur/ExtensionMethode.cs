using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afficheur
{
    public static class ExtensionMethode
    {    
        public static List<String> JPGList(this String[] tab)
        {
            return tab.Where(c => c.ToLower().EndsWith(".jpg")).ToList();
        }
    }    
}
