using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ötödikhét.MnbServiceReference;

namespace Ötödikhét
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ApiCall();
        }

        private void ApiCall()
        {
            MNBArfolyamServiceSoapClient mnbService = new MNBArfolyamServiceSoapClient();
            var request = new GetExchangeRatesRequestBody();
            request.currencyNames = "EUR";
            request.startDate = "2020-01-01";
            request.endDate = "2020-06-30";

            var response = mnbService.GetExchangeRates(request);
            var result = response.GetExchangeRatesResult;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
