using System;
using System.Threading;

namespace HardwareTest
{
    public class Program
    {
        public static void Main()
        {
            using var _Xiaogyan = new Xiaogyan();
            _Xiaogyan.begin();

            while (true)
            {
                if (_Xiaogyan.ButtonA.Read() != 0)
                {
                    _Xiaogyan.Led.Write(1);
                }
                else
                {
                    _Xiaogyan.Led.Write(0);
                }

                Thread.Sleep(100);
            }
        }
    }
}
