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
                    switch(a)
                    {
                        case "0":
                            Console.WriteLine("B Pressed");
                            break;
                        case "1":
                            Console.WriteLine("Y Pressed");
                            break;
                        case "2":
                            Console.WriteLine("SELECT Pressed");
                            break;
                        case "3":
                            Console.WriteLine("START Pressed");
                            break;
                        case "4":
                            Console.WriteLine("UP Pressed");
                            break;
                        case "5":
                            Console.WriteLine("DOWN Pressed");
                            break;
                        case "6":
                            Console.WriteLine("LEFT Pressed");
                            break;
                        case "7":
                            Console.WriteLine("RIGHT Pressed");
                            break;
                        case "8":
                            Console.WriteLine("A Pressed");
                            break;
                        case "9":
                            Console.WriteLine("X Pressed");
                            break;
                        case "Left":
                            Console.WriteLine("L Pressed");
                            break;
                        case "Right":
                            Console.WriteLine("R Pressed");
                            break;









                        default:
                            break;
                    }
                }
            }
        }
    }
}