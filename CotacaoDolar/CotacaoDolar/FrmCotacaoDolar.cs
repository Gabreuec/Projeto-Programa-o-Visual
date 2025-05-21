using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CotacaoDolar
{
    public partial class FrmCotacaoDolar: Form
    {
        public FrmCotacaoDolar()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string strURL = "https://api.hgbrasil.com/finance?array_limit=1&fields=only_results,USD&key=67e522f2";

            using (HttpClient client = new HttpClient())
            {
                var response = client.GetAsync(strURL).Result;
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;


                    Market market = JsonConvert.DeserializeObject<Market>(result);


                    decimal buy = Convert.ToDecimal(market.Currency.Buy, CultureInfo.InvariantCulture);
                    decimal Sell = Convert.ToDecimal(market.Currency.Sell, CultureInfo.InvariantCulture);
                    decimal Variation = Convert.ToDecimal(market.Currency.Variation, CultureInfo.InvariantCulture);

                    lblBuy.Text = string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", buy);
                    lblSell.Text = string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", Sell);
                    lblVar.Text = string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:P}", Variation / 100);

                }
                else {
                    lblBuy.Text = "-";
                    lblSell.Text = "-";
                    lblVar.Text = "-";
                }

            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
