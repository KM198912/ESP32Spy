using System.IO.Ports;
using System.Threading;
using System;
using Nini.Config;
using System.Linq;

namespace SESP32SpySNES
{
    class Program
    {
        static SerialPort _serialPort;
        static IConfigSource _source;
        public static void Main()
        {
             _source = new IniConfigSource("ESP32Spy.ini");
            string com_port = _source.Configs["Config"].Get("COM_PORT");
            int baud = _source.Configs["Config"].GetInt("BaudRate");
            if (SerialPort.GetPortNames().ToList().Contains(com_port))
            {
                _serialPort = new SerialPort();
            _serialPort.PortName =com_port;
            _serialPort.BaudRate = baud;
            _serialPort.Open();
            Console.WriteLine("ESP32 SNES Reader");
            Console.WriteLine("Com Port: " + com_port + " Opened");
            Console.WriteLine("Baudrate: " + baud.ToString());
            while (true)
            {
                string a = _serialPort.ReadExisting();
                    if (!string.IsNullOrEmpty(a))
                    {
                        switch (a)
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
                    else
                    {
                        throw new Exception("Failed to open COM Port: " + com_port);
                    }
                }
            }
        }
    }
}