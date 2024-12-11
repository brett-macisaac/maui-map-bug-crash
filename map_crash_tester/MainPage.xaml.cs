using System.Linq.Expressions;

namespace map_crash_tester
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {
            try
            {
                await Shell.Current.GoToAsync($"{nameof(MapPage)}");
            }
            catch (InvalidOperationException ex)
            {
                await App.Current.MainPage.DisplayAlert("Error Navigating", $"An error occurred when navigating to the map page: {ex.Message}.", "OK");
            }
        }
    }

}
