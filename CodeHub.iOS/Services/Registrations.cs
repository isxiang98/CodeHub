﻿using Splat;
using CodeHub.Core.Services;
using Xamarin.Utilities.Services;

namespace CodeHub.iOS.Services
{
    public static class Registrations
    {
        public static void InitializeServices(this IMutableDependencyResolver resolverToUse)
        {
            resolverToUse.RegisterLazySingleton(() => new ViewModelViewService(), typeof(IViewModelViewService));
            resolverToUse.RegisterLazySingleton(() => new DefaultValueService(), typeof(IDefaultValueService));
            resolverToUse.RegisterLazySingleton(() => new MarkdownService(), typeof(IMarkdownService));
            resolverToUse.RegisterLazySingleton(() => new ServiceConstructor(), typeof(IServiceConstructor));
            resolverToUse.RegisterLazySingleton(() => NetworkActivityService.Instance, typeof(INetworkActivityService));
            resolverToUse.RegisterLazySingleton(() => new FilesystemService(), typeof(IFilesystemService));
            resolverToUse.RegisterLazySingleton(() => new EnvironmentalService(), typeof(IEnvironmentalService));
            resolverToUse.RegisterLazySingleton(() => new UrlRouterService(resolverToUse.GetService<ISessionService>()), typeof(IUrlRouterService));
            resolverToUse.RegisterLazySingleton(() => new InAppPurchaseNetworkDecorator(new InAppPurchaseService(), resolverToUse.GetService<INetworkActivityService>()), typeof(IInAppPurchaseService));

            resolverToUse.RegisterLazySingleton(() => new FeaturesService(resolverToUse.GetService<IDefaultValueService>()), typeof(IFeaturesService));
            resolverToUse.RegisterLazySingleton(() => new PushNotificationsService(), typeof(IPushNotificationsService));
        }
    }
}

