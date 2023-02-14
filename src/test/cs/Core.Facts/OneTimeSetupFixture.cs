namespace RI.Novus.Core.Facts;

[SetUpFixture]
[Parallelizable(scope: ParallelScope.All)]
internal class OneTimeSetupFixture
{
    [OneTimeSetUp]
    public void RunBeforeAnyTests() { }

    [OneTimeTearDown]
    public void RunAfterAllTests()
    {
    }
}
