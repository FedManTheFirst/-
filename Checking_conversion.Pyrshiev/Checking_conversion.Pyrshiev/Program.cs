using System;

namespace Checking_conversion.Pyrshiev
{
    class Program
    {
        static void Main(string[] args)
        {
            Int16 i16 = 1; Int32 i32 = 1; double db = 1;
            i16 = 132;
            //i16 = db; - db more then short
            i32 = i16;
            //i32 = db; - db more then int

        }
    }
}
