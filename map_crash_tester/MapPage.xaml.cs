using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;

namespace map_crash_tester;

public partial class MapPage : ContentPage
{
    // The geopaths of the four polygons.
    private static List<List<Location>> sPolygonLocations = new List<List<Location>>()
    {
        new List<Location>()
        {
            new Location(20.712375, -156.320040),
            new Location(20.829862, -156.378034),
            new Location(20.854212, -156.208255),
            new Location(20.739103, -156.085123),
        },
        new List<Location>()
        {
            new Location(20.661401, -156.351765),
            new Location(20.633685, -156.495082),
            new Location(20.527053, -156.357533),
        },
        new List<Location>()
        {
            new Location(20.890011, -156.500872),
            new Location(20.740002, -156.422627),
            new Location(20.742242, -156.360350),
        },
        new List<Location>()
        {
            new Location(20.973242, -156.327125),
            new Location(20.918796, -156.125792),
            new Location(20.902331, -156.316957),
        }
    };

    public MapPage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await DrawAll();
        //xMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Location(20.815204, -156.444899), Distance.FromKilometers(10)));
    }

    /// <summary>
    /// Prints the coordinate of a map click. Might be useful for constructing additional polygons.
    /// </summary>
    public async void OnMapClicked(object sender, MapClickedEventArgs e)
    {
        await App.Current.MainPage.DisplayAlert("Hello", $"Coords: {e.Location.Latitude}, {e.Location.Longitude}", "OK"); // 20.7451, -156.2969
    }

    /// <summary>
    /// Draws all four polygons.
    /// </summary>
    private async Task DrawAll(bool pAddDelayBetween = false, int pDelayAmount = 20)
    {
        DrawPolygonA();
        if (pAddDelayBetween) await Task.Delay(pDelayAmount);
        DrawPolygonB();
        if (pAddDelayBetween) await Task.Delay(pDelayAmount);
        DrawPolygonC();
        if (pAddDelayBetween) await Task.Delay(pDelayAmount);
        DrawPolygonD();
    }

    /// <summary>
    /// Draws the first polygon.
    /// </summary>
    private void DrawPolygonA()
    {
        DrawPolygon(GetPolygon(0));
    }

    /// <summary>
    /// Draws the second polygon.
    /// </summary>
    private void DrawPolygonB()
    {
        DrawPolygon(GetPolygon(1));
    }

    /// <summary>
    /// Draws the third polygon.
    /// </summary>
    private void DrawPolygonC()
    {
        DrawPolygon(GetPolygon(2));
    }

    /// <summary>
    /// Draws the fourth polygon.
    /// </summary>
    private void DrawPolygonD()
    {
        DrawPolygon(GetPolygon(3));
    }

    /// <summary>
    /// Draws the given polygon.
    /// </summary>
    /// <param name="pPolygon"></param>
    private void DrawPolygon(Polygon? pPolygon)
    {
        if (pPolygon == null)
            return;

        try
        {
            xMap.MapElements.Add(pPolygon);
        }
        catch (InvalidOperationException ex)
        {
            _ = App.Current.MainPage.DisplayAlert("Error Adding Polygon", $"An error occurred when adding a polygon to the map: {ex.Message}.", "OK");
        }
    }

    /// <summary>
    /// Constructs a polygon given an index of the sPolygonLocations array.
    /// </summary>
    /// <param name="pIndex">The index of sPolygonLocations corresponding to the polygon to draw.</param>
    /// <returns>A polygon that corresponds to the goepath at index pIndex of sPolygonLocations.</returns>
    private Polygon? GetPolygon(int pIndex = 0)
    {
        if (pIndex >= sPolygonLocations.Count || pIndex < 0)
            return null;

        Color lColor = Colors.Orange;

        Polygon lPolygon = new Polygon()
        {
            StrokeColor = lColor,
            StrokeWidth = 10,
            FillColor = lColor.WithAlpha((float)0.25),
        };

        foreach (Location coord in sPolygonLocations[pIndex])
        {
            lPolygon.Geopath.Add(coord);
        }

        return lPolygon;
    }
}