using LightInject;
using System;

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
            if(container != null)
                return container.GetInstance<T>();
            else
                throw new Exception("Container is not initialized");
        }
    }
}
