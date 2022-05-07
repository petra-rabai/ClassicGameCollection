using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using System.IO.Abstractions;

namespace ClassicGameCollection.AutofacIoC
{
	public static class AutofacContainer
	{
		public static IContainer Configure()
		{
			ContainerBuilder dependencyBuilder = new();
			CollectDependencies(dependencyBuilder);

			return dependencyBuilder.Build();
		}

		private static void CollectDependencies(ContainerBuilder dependencyBuilder)
		{
			dependencyBuilder.RegisterType<FileSystem>()
				.As<IFileSystem>()
				.SingleInstance();

			Assembly dependencyCollection = Assembly.GetExecutingAssembly();
			dependencyBuilder.RegisterAssemblyTypes(dependencyCollection)
				.SingleInstance()
				.InNamespace("ClassicGameCollection")
				.AsImplementedInterfaces();
		}
	}
}
