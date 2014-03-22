using System;

using PatternLibrary;

namespace TestGenericPersonne
{
    class InitialState : State
    {
        public override void Handle()
        {
            Console.WriteLine("Initial");
        }
    }

    class BusyState : State
    {
        public override void Handle()
        {
            Console.WriteLine("Busy");
        }
    }

    class TerminatedState : State
    {
        public override void Handle()
        {
            Console.WriteLine("Terminated");
        }
    }

    class ConcreteContext : Context
    {
        public ConcreteContext(IState state)
        {
            m_state = state;
        }
    }

    internal static class TestGenericState
    {
        public static void Test()
        {
            new Title("Test Generic State");

            ConcreteContext ctx = new ConcreteContext(new InitialState());
            ctx.Request();

            new Title("Fin du Test Generic State");
        }
    }
}
