namespace Test0704;

class AppShell : Shell
{
    readonly static IReadOnlyDictionary<Type, string> pageRouteMappingDictionary = new Dictionary<Type, string>(new[]
    {
        CreateRoutePageMapping<MainPage, MainViewModel>(),
    });

    public AppShell(MainPage mainPage)
    {
        Items.Add(mainPage);
    }

    public static string GetRoute<TPage, TViewModel>() where TPage : BaseContentPage<TViewModel>
                                                        where TViewModel : BaseViewModel
    {
        if (!pageRouteMappingDictionary.TryGetValue(typeof(TPage), out var route))
        {
            throw new KeyNotFoundException($"No map for ${typeof(TPage)} was found on navigation mappings. Please register your ViewModel in {nameof(AppShell)}.{nameof(pageRouteMappingDictionary)}");
        }

        return route;
    }

    static KeyValuePair<Type, string> CreateRoutePageMapping<TPage, TViewModel>() where TPage : BaseContentPage<TViewModel>
                                                                                    where TViewModel : BaseViewModel
    {
        var route = CreateRoute<TPage>();
        Routing.RegisterRoute(route, typeof(TPage));

        return new KeyValuePair<Type, string>(typeof(TPage), route);
    }

    static string CreateRoute<TPage>() where TPage : Page
    {
        if (typeof(TPage) == typeof(MainPage))
            return $"//{nameof(MainPage)}";

        throw new NotSupportedException($"{typeof(TPage)} Not Implemented in {nameof(pageRouteMappingDictionary)}");
    }
}
