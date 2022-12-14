/*  Состояние
    Позволяет объекту изменять
    своё поведение в зависимости от 
    внутреннего состояния
 */
class Program
{
    static void Main()
    {
        var context = new Context(new StateA());
        context.Request();
        Console.ReadKey();
    }
}

abstract class State
{
    public abstract void Handle(Context context);
}

class StateA : State
{
    public StateA()
    {
        Console.WriteLine("State-A Create...");
    }

    public override void Handle(Context context)
    {
        context.State = new StateB();
    }
}

class StateB : State
{
    public StateB()
    {
        Console.WriteLine("State-B Create...");
    }

    public override void Handle(Context context)
    {
        context.State = new StateA();
    }
}

class Context
{
    public State State { get; set; }

    public Context(State state)
    {
        State = state;
    }

    public void Request()
    {
        State.Handle(this);
    }
}