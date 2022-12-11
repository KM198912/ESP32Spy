using System.IO.Ports;
using System.Threading;
using System;
namespace SESP32SpySNES
{
    class Program
    {
        static SerialPort _serialPort;
        public static void Main()
        {
            _serialPort = new SerialPort();
            _serialPort.PortName = "COM8";
            _serialPort.BaudRate = 115200;
            _serialPort.Open();
            Console.WriteLine("ESP32 SNES Reader");
            while (true)
            {
                string a = _serialPort.ReadExisting();
                if (!string.IsNullOrEmpty(a))
                {
                    int buttons = int.Parse(a);
                    switch(buttons)
                    {
                        case 3:
                            Console.WriteLine("Start Pressed");
                            break;
                        case 0:
                            Console.WriteLine("B Pressed");
                            break;
                        case 8:
                            Console.WriteLine("A Pressed");
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}