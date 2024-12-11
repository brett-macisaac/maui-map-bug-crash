
# Problem 

When a page that contains a map component is navigated to more than once, an InvalidOperationException ("Virtual View cannot be null here") is thrown. 

It's important to note that I've only noticed the issue occur when the map's 'MapElements.Add' method is called during the page's OnAppearing event.

This might be somewhat related to a previous [issue](https://github.com/dotnet/maui/issues/22035) that affected the CarouselView, which itself is similar to an older [issue](https://github.com/dotnet/maui/issues/12219) that affected the CollectionView. It's worth noting that these were both Android-specific, whereas I've only seen this issue on iOS, not Android.

# Expected Behaviour

There shouldn't be an exception thrown. This is what I observe on Android.

# Environment

## Platform

### iOS

- iOS 18.1.1 (.NET 9) (physical device using Hot Reload)

## Maui Version
9.0.0 (VS 17.13.35605.110)

# How To Replicate

1. Click on the "Go to Map Page' button. You should successfully navigate to the map page, which shows a map with several polygons.
2. Click the back button in the top left.
3. Click on the "Go to Map Page' button again. You will notice a pop-up appears notifying you of the error that occurred when attempting to navigate to the map page.
4. Click on the "Go to Map Page' button again. You should successfully navigate to the map page.
5. Click the back button in the top left again. You will notice several error messages appear. The source of these errors is the 'MapElements.Add' call in the 'DrawPolygon' method in 'MapPage.xaml.cs'.
6. Comment out the call to 'DrawAll' in the OnAppearing method of 'MapPage.xaml.cs' and re-run the application. You should notice that no errors occur. This is because the 'MapElements.Add' method is no longer called.

# Workaround

I haven't been able to find any workarounds.