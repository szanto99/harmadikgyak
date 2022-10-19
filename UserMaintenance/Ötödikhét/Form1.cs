using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml;
using Ötödikhét.Entities;
using Ötödikhét.MnbServiceReference;

namespace Ötödikhét
{
    public partial class Form1 : Form
    {
        BindingList<RateData> Rates = new BindingList<RateData>();
        BindingList<string> Currencies = new BindingList<string>();
        public Form1()
        {
            InitializeComponent();
            Api_GetCurrencies();
            //Currencies = Api_GetCurrencies();
            comboBox1.DataSource = Currencies;
            RefreshData();

        }


        private void RefreshData()
        {
            Rates.Clear();
            dataGridView1.DataSource = Rates;
            XmlRead();
            Diagram();
        }

        private void Diagram()
        {
            var series = chartRateData.Series[0];
            chartRateData.DataSource = Rates;
            series.ChartType = SeriesChartType.Line;
            series.XValueMember = "Date";
            series.YValueMembers = "Value";
            series.BorderWidth = 2;

            var legend = chartRateData.Legends[0];
            legend.Enabled = false;

            var chartArea = chartRateData.ChartAreas[0];
            chartArea.AxisX.MajorGrid.Enabled = false;
            chartArea.AxisY.MajorGrid.Enabled = false;
            chartArea.AxisY.IsStartedFromZero = false;
        }

        private void XmlRead()
        {
            XmlDocument exchange_xml = new XmlDocument();

            exchange_xml.LoadXml(Api_GetExchangeRates());

            foreach (XmlElement element in exchange_xml.DocumentElement)
            {
                var rate = new RateData();
                Rates.Add(rate);

                rate.Date = DateTime.Parse(element.GetAttribute("date"));

                var childElement = (XmlElement)element.ChildNodes[0];
                rate.Currency = childElement.GetAttribute("curr");

                var unit = decimal.Parse(childElement.GetAttribute("unit"));
                var value = decimal.Parse(childElement.InnerText);
                if (unit != 0)
                    rate.Value = value / unit;
            }

            /*XmlDocument currency_xml = new XmlDocument();

            currency_xml.LoadXml(Api_GetCurrencies());

            foreach (XmlElement element in currency_xml.DocumentElement)
            {

                var currency = new ();
                Currencies.Add(currency);
            }*/

        }

        private string Api_GetExchangeRates()
        {
            MNBArfolyamServiceSoapClient mnbService = new MNBArfolyamServiceSoapClient();
            var request = new GetExchangeRatesRequestBody();

            request.currencyNames = "EUR"; //comboBox1.SelectedItem.ToString();
            request.startDate = "2020-01-01"; //dateTimePicker1.ToString();
            request.endDate = "2020-06-30";//dateTimePicker2.ToString();

            var response = mnbService.GetExchangeRates(request);
            var result = response.GetExchangeRatesResult;
            return result;
        }

        private string Api_GetCurrencies()
        {
            MNBArfolyamServiceSoapClient mnbService = new MNBArfolyamServiceSoapClient();
            var request = new GetCurrenciesRequestBody();

            var response = mnbService.GetCurrencies(request);
            var result = response.GetCurrenciesResult;

            return result;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshData();
        }
    }
}
