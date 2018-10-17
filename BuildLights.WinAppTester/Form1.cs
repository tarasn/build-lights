using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BuildLights.WinAppTester
{
    public partial class Form1 : Form
    {
        SerialPort _serialPort;
        public Form1()
        {
            InitializeComponent();
            _serialPort = new SerialPort();
            _serialPort.PortName = "COM3";
            _serialPort.BaudRate = 9600;
            _serialPort.Open();
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            var items = checkedListBoxColors.CheckedItems;
            _serialPort.WriteLine("3");
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_serialPort != null && _serialPort.IsOpen)
            {
                _serialPort.Close();
            }
        }
    }
}
