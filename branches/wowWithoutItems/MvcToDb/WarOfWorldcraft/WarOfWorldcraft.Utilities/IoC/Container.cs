namespace WarOfWorldcraft.Utilities.IoC
{
    public static class Container
    {
        private static IContainer container;

        public static void Initialize(IContainer container)
        {
            Container.container = container;
        }

        public static T GetImplementationOf<T>()
        {
            return container.GetImplementationOf<T>();
        }
    }
}