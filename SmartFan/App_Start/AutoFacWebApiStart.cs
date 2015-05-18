namespace SmartFan
{
    using System.Reflection;
    using System.Web.Http;

    using Autofac;
    using Autofac.Integration.WebApi;

    using Model.Persistence;

    public class AutoFacWebApiStart
    {
        public static void InitialiseWebApi(HttpConfiguration configuration)
        {
            var webApiBuilder = new ContainerBuilder();
            RegisterDependencies(webApiBuilder);
            webApiBuilder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            var container = webApiBuilder.Build();
            configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static void RegisterDependencies(ContainerBuilder builder)
        {
            // You can register controllers all at once using assembly scanning...
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // ...or you can register individual controlllers manually.
            builder.RegisterType<TeamRepository>().As<ITeamRepository>();
        }
    }
}