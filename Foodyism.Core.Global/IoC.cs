using Autofac;

namespace Foodyism.Core.Global
{

	public static class IoC
	{
		static IContainer _container;
		static ContainerBuilder _builder;

		public static IContainer Container { get { return _container ?? (_container = BuildContainer()); } }

		public static ContainerBuilder Builder
		{
			get
			{
				if (_builder != null) return _builder;
				_builder = new ContainerBuilder();
				return _builder;
			}
		}

		public static IContainer BuildContainer()
		{
			if (_container != null) return _container;
			_container = Builder.Build();
			return _container;
		}
	}
}
