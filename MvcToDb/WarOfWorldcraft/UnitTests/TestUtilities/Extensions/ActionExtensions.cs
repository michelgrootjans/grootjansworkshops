using System;
using NUnit.Framework;

namespace UnitTests.TestUtilities.Extensions
{
    public static class ActionExtensions
    {
        public static Exception ShouldThrowAn<T>(this Action action) where T : Exception
        {
            try
            {
                action();
            }
            catch (T e)
            {
                return e;
            }
            catch(Exception e)
            {
                throw new AssertionException(string.Format("Expected an {0}, but got a {1}", typeof(T), e.GetType()), e);
            }
            throw new AssertionException(string.Format("Expected an exception of type {0}", typeof(T)));
        }
    }
}