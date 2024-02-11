namespace Test;

public class Specification
{
    protected static void Given(Action testAction)
    {
        testAction.Invoke();
    }

    protected static void And(Action testAction)
    {
        testAction.Invoke();
    }

    protected static void When(Action testAction)
    {
        testAction.Invoke();
    }

    protected static void Then(Action testAction)
    {
        testAction.Invoke();
    }
}