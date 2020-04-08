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
            try
            {
                return container.GetInstance<T>();
            }
            catch(Exception) 
            {
                throw new Exception("Container is not initialized");
            }
        }
    }
}
