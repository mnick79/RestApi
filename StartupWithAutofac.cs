using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RestApi.Interfaces;
using RestApi.Models;
using RestApi.Repository.Implimentation;
using RestApi.Servises.Implimentations;
using RestApi.Servises.Interfaces;
//using RepositoryDesignPattern.Models;
//using RepositoryDesignPattern.Repository;

namespace RepositoryDesignPattern
{
    public class StartupWithAutofac
    {
        public StartupWithAutofac(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // ConfigureServices - это место рагистрации зависимостей. Этот метод вызвается
        // до вызова метода ConfigureContainer, который задекларирован ниже.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthorization();
            services.AddControllers();
        }

        // ConfigureContainer - это метод в котором регистрируются зависимости
        // непосредственно в Autofac. Этот метод вызывается после метода ConfigureServices,
        // так что услуги указанные здесь надпишут регистрации сделанные в методе
        // ConfigureServices. Не вызывайте метод Build контейнера зависимостей - это
        // будет сделано за вас автоматически.
        public void ConfigureContainer(ContainerBuilder builder)
        {

            // Это аналог строчки services.AddSingleton(typeof(IRepo<Book>), typeof(CollectionBasedRepo));
            // в файле Startup.cs.
            //builder.RegisterType<CollectionBasedRepo>().As<IRepo<Book>>().SingleInstance();


            //builder.RegisterType<IRepo<Customer>>().As<RepoCustomer>().SingleInstance();
            //builder.RegisterType<IBaseService<Customer>>().As<CustomerService>().SingleInstance();
            
            //builder.RegisterType<RepoCustomer>().As<IRepo<Customer>>().
            //builder.RegisterType<CustomerService>().As<IBaseService<Customer>>().SingleInstance();

            builder.RegisterType<RepoProduct>().As<IRepo<Product>>().SingleInstance();
            builder.RegisterType<ProductService>().As<IBaseService<Product>>().SingleInstance();

            builder.RegisterType<RepoCart>().As<IRepo<Cart>>().SingleInstance();
            builder.RegisterType<CartService>().As<IBaseService<Cart>>().SingleInstance();

            builder.RegisterType<RepoDetails>().As<IRepo<Details>>().SingleInstance();
            builder.RegisterType<DetailsService>().As<IBaseService<Details>>().SingleInstance();




            // Это аналог строчки services.AddTransient(typeof(IRepo<Book>), typeof(CollectionBasedRepo));
            // в файле Startup.cs.
            // builder.RegisterType<DataBaseRepo>().As<IRepo<Book>>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
