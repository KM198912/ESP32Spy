using System.IO.Ports;
using System.Threading;
using System;
using Nini.Config;
using System.Linq;
using System.IO;
namespace SESP32SpySNES
{
    class Program
    {
        static SerialPort _serialPort;
        static IConfigSource _source;
        public static void Main()
        {
            string dir = Directory.GetCurrentDirectory();
            string file = "ESP32Spy.ini";
            bool portExists = false;
            string com_port = "";
            int baud = 0;
            if (@File.Exists(dir + @"\" + file))
            {
                _source = new IniConfigSource(file);

                com_port = _source.Configs["Config"].Get("COM_PORT");
                baud = _source.Configs["Config"].GetInt("BaudRate");
               portExists = SerialPort.GetPortNames().Any(x => x == com_port);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(file + " not found in " + dir);
                Console.WriteLine("Did you forget to Copy it?");
                while(true) { }
            }
            if (portExists)
            {
                _serialPort = new SerialPort();
            _serialPort.PortName =com_port;
            _serialPort.BaudRate = baud;
            _serialPort.Open();
            Console.WriteLine("ESP32 SNES Reader v0.2");
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

                }
            }
            else
            {
                throw new Exception("Failed to open COM Port: " + com_port);
            }
        }
    }
}