using LightInject;

namespace Brackets
{
    public static class IocContainer
    {
        private static ServiceContainer container;

        public static void InitializeContainer()
        {
            container = new ServiceContainer();
            container.Register<ISource, DbSourceManager>();
        }

        public static T Resolve<T>()
        {
            return container.GetInstance<T>();
        }
    }
}
