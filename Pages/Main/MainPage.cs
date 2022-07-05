using CommunityToolkit.Maui.Markup;

namespace Test0704;

class MainPage : BaseContentPage<MainViewModel>
{
    public MainPage(MainViewModel mainViewModel) : base(mainViewModel)
    {
        Content = new ScrollView
        {
            Content = new VerticalStackLayout
            {
                Spacing = 25,
                Padding = 30,

                Children =
                {
                    new Image()
                        .Source("dotnet_bot.png")
                        .Size(250, 310)
                        .CenterHorizontal(),

                    new Label()
                        .Text("Hello World")
                        .Font(size: 32)
                        .CenterHorizontal(),

                    new Label()
                        .Text("Welcome to .NET MAUI Markup Community Toolkit Sample")
                        .Font(size: 18)
                        .CenterHorizontal(),

                    new Label()
                        .Font(size: 18, bold: true)
                        .CenterHorizontal()
                        .Bind<Label, int, string>(Label.TextProperty, nameof(mainViewModel.ClickCount), convert: count => $"Current Count: {count}"),

                    new Button()
                        .Text("Click Me")
                        .Font(bold: true)
                        .BindCommand(nameof(MainViewModel.IncrementClickMeButtonCommand))
                        .CenterHorizontal(),
                }
            }.CenterVertical()
        };
    }
}

