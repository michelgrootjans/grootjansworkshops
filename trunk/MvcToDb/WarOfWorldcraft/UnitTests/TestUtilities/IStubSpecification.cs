using Rhino.Mocks;
using Rhino.Mocks.Interfaces;

namespace UnitTests.TestUtilities
{
    public interface IStubSpecification<Target>
    {
        IMethodOptions<Result> IsToldTo<Result>(Function<Target, Result> function);
    }

    internal class StubSpecification<Target> : IStubSpecification<Target> where Target : class
    {
        private readonly Target target;

        public StubSpecification(Target target)
        {
            this.target = target;
        }

        public IMethodOptions<Result> IsToldTo<Result>(Function<Target, Result> function)
        {
            return target.Stub(function);
        }
    }

}