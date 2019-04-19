# Movies - The app

## Build instructions
1. Clone the source code of project
2. Open on Visual Studio for Windows or For mac
3. Restore the NuGet Packages
4. Run on Android/iOS device or simulator/emulator

## Third-party libraries
0. Prims as MVVM Framework - https://prismlibrary.github.io/index.html
Used to accelerate the development, abstracting a lot of code that I did not need implement (like navigation service, view model base, etc)

1. Flow List View - https://github.com/daniel-luberda/DLToolkit.Forms.Controls/tree/master/FlowListView
Used to make a list with two columns or more (how you can see in the screen shots of landscape orientation).

2. Fody and PropertyChanged.Fody - https://github.com/Fody/PropertyChanged
Used to acelerate the creation of bindable properties (two way) in the view models

3. Xamarin.Essentials - https://docs.microsoft.com/pt-br/xamarin/essentials/
Used to get some device configurations like orientation, etc..

4. RestSharp - http://restsharp.org/ (I can do this using native .NET HttpClient also but I prefer RestSharp)
Used to make http requests to get the movies

5. SQLite as Local Database - https://www.sqlite.org/index.html
Used to save all the genres, because the upcoming endpoint not send to us the object array... only an array of interger (Ids)

6. Xamarin.HotReload - https://github.com/AndreiMisiukevich/HotReload
Used to make my development more easy, updating the screen when I changed my XAML file.

7. NewtonSoft.Json - https://www.newtonsoft.com/json
Used to serialize the json object returned by the IMDb API
