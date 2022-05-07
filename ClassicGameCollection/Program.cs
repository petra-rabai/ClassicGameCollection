using Autofac;
using ClassicGameCollection.AutofacIoC;

namespace ClassicGameCollection
{
	internal static class Program
	{

		private static void Main()
		{
			IContainer iocContainer = ConfigureContainer();

			ILifetimeScope scope = LifetimeStart(iocContainer);

			IApplication application = ResolveScopeStrat(scope);

			application.Run();
		}

		private static IApplication ResolveScopeStrat(ILifetimeScope scope)
		{
			return scope.Resolve<IApplication>();
		}

		private static ILifetimeScope LifetimeStart(IContainer iocContainer)
		{
			return iocContainer.BeginLifetimeScope();
		}

		private static IContainer ConfigureContainer()
		{
			return AutofacContainer.Configure();
		}
	}
}