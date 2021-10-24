using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using ZXing.Net.Mobile.Forms;

namespace barcode
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        void OnButtonClicked(object sender, EventArgs e)
        {

            Button btn = sender as Button;
            btn.IsEnabled = false;

            ZXingScannerPage scanPage = new ZXingScannerPage();
            scanPage.Disappearing += (sender_, e_) =>
            {
                btn.IsEnabled = true;
            };
            scanPage.OnScanResult += (result) =>
            {
                scanPage.IsScanning = false;

                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Navigation.PopModalAsync();
                    await DisplayAlert("Scannend Barcode : ", result.Text + " , " + result.BarcodeFormat + " , " + result.ResultPoints[0].ToString(), "OK");
                });
            };

            Navigation.PushModalAsync(scanPage);
        }
 
    }
}
