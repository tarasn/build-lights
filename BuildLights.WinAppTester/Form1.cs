using System;
using System.Collections;
using System.IO.Ports;
using System.Windows.Forms;
using BuildLights.WinAppTester.Properties;


namespace BuildLights.WinAppTester
{

    public partial class Form1 : Form
    {
        const int RedPosition = 0;
        const int GreenPosition = 1;
        const int YellowPosition = 2;
        SerialPort _serialPort;
        public Form1()
        {
            InitializeComponent();
            _serialPort = new SerialPort();
            _serialPort.PortName = Settings.Default.Port;
            _serialPort.BaudRate = 9600;
            _serialPort.Open();
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            var ba = new BitArray(3);
            ba.Set(GreenPosition, checkBoxGreen.Checked);
            ba.Set(RedPosition, checkBoxRed.Checked);
            ba.Set(YellowPosition, checkBoxYellow.Checked);
            var lightFlags = getIntFromBitArray(ba).ToString();
            _serialPort.WriteLine(lightFlags);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_serialPort != null && _serialPort.IsOpen)
            {
                _serialPort.Close();
            }
        }

        private int getIntFromBitArray(BitArray bitArray)
        {
            if (bitArray.Length > 32)
                throw new ArgumentException("Argument length shall be at most 32 bits.");

            int[] array = new int[1];
            bitArray.CopyTo(array, 0);
            return array[0];
        }
    }
}
