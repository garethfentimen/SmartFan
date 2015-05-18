namespace SmartFan
{
    using System.Reflection;
    using System.Web.Http;
    using System.Web.Mvc;

    using Autofac;
    using Autofac.Integration.Mvc;

    using Model.Persistence;

    public class AutoFacMvcStart
    {
        public static void InitialiseMvc()
        {
            var builder = new ContainerBuilder();
            RegisterDependencies(builder);
            // Set the dependency resolver to be Autofac.
            var container = builder.Build();

            // set the dependency resolver for MVC
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        private static void RegisterDependencies(ContainerBuilder builder)
        {
            // Register your MVC controllers.
            builder.RegisterControllers(typeof(SmartFan.Global).Assembly);

            builder.RegisterType<TeamRepository>().As<ITeamRepository>();

            // OPTIONAL: Register model binders that require DI.
            builder.RegisterModelBinders(Assembly.GetExecutingAssembly());
            builder.RegisterModelBinderProvider();

            // OPTIONAL: Register web abstractions like HttpContextBase.
            builder.RegisterModule<AutofacWebTypesModule>();

            // OPTIONAL: Enable property injection in view pages.
            builder.RegisterSource(new ViewRegistrationSource());

            // OPTIONAL: Enable property injection into action filters.
            builder.RegisterFilterProvider();
        } 
    }
}