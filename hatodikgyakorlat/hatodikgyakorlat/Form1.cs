using hatodikgyakorlat.Abstractions;
using hatodikgyakorlat.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hatodikgyakorlat
{
    public partial class Form1 : Form
    {
        List<Toy> _toys = new List<Toy>();

        private Toy _nextToy;

        private IToyFactory _factory;

        public IToyFactory Factory
        {
            get { return _factory; }
            set 
            { 
                _factory = value;
                DisplayNext();
            }
        }

        private void DisplayNext()
        {
            if (_nextToy != null)
                Controls.Remove(_nextToy);
            _nextToy = Factory.CreateNew();
            _nextToy.Top = label1.Top + label1.Height + 20;
            _nextToy.Left = label1.Left;
            Controls.Add(_nextToy);
        }

        public Form1()
        {
            InitializeComponent();
            Factory = new BallFactory();//nem volt meg
            button1.Text = Resource1.BallButton;
            button3.Text = Resource1.CarButton;
            label1.Text = Resource1.Cmg;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void createTimer_Tick(object sender, EventArgs e)
        {
            var toy = Factory.CreateNew(); //nem volt meg
            _toys.Add(toy);
            toy.Left = toy.Width * -1;
            mainPanel.Controls.Add(toy); //nem volt meg
        }

        private void conveyorTimer_Tick(object sender, EventArgs e)
        {
            var maxPosition = 0;
            foreach (var toy in _toys)
            {
                toy.MoveToy();
                if (toy.Left > maxPosition)
                    maxPosition = toy.Left;
            }

            if (maxPosition > 1000)
            {
                var oldestToy = _toys[0];
                mainPanel.Controls.Remove(oldestToy);
                _toys.Remove(oldestToy);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Factory = new BallFactory();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Factory = new CarFactory();
        }
    }
}
