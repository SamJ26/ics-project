﻿using System;
using System.Windows;
using FilmManagment.GUI.Services;
using FilmManagment.GUI.ViewModels;
using FilmManagment.GUI.ViewModels.Interfaces;
using FilmManagment.GUI.Views;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FilmManagment.GUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost host;

        public App()
        {
            host = new HostBuilder().ConfigureServices((context, services) => { ConfigureServicesToContainer(context.Configuration, services); })
                                    .Build();
        }

        public void ConfigureServicesToContainer(IConfiguration configuration, IServiceCollection services)
        {
            services.AddSingleton<MainWindow>();

            services.AddSingleton<IMediator, Mediator>();

            services.AddSingleton<MainViewModel>();

            services.AddSingleton<IHomeViewModel, HomeViewModel>();
            services.AddSingleton<IFilmListViewModel, FilmListViewModel>();
            services.AddSingleton<IActorListViewModel, ActorListViewModel>();
            services.AddSingleton<IDirectorListViewModel, DirectorListViewModel>();

            // TODO: add rest of ViewModels
            // TODO: add rest of services ( messenger )
            // TODO: add Facade + repository + DbFactory + unitOfWOrk
        }

        private async void Application_start(object sender, StartupEventArgs args)
        {
            await host.StartAsync();

            var mainWindow = host.Services.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        private async void Application_exit(object sender, ExitEventArgs args)
        {
            using (host)
            {
                await host.StopAsync(TimeSpan.FromSeconds(2));
            }
        }
    }
}
