using ROASApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionsMethods
{
    /* Extension metodların içerisinde olduğu sınıf static olmak zorunda
     * extension metod static olmak zorunda
     * 
     */
    public static class MyExtensions
    {
        public static void Brief(this ROAS roas)
        {
            Console.WriteLine($" Reklam Kanalı : {roas.reklamKanali}\t Reklam Maliyeti :{roas.reklamMaliyeti}");
        }




        public static int ToInt32(this string str )
        {
            return Convert.ToInt32( str );  
        }
    }
}
