namespace UnitTests.TestUtilities.Extensions
{
    public static class ObjectExtensions
    {
        public static T ShouldBeOfType<T>(this object target)
        {
            typeof (T).IsAssignableFrom(target.GetType()).ShouldBeTrue();
            return (T) target;
        }
    }
}