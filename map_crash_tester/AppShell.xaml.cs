namespace map_crash_tester
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(MapPage), typeof(MapPage));
        }
    }
}
