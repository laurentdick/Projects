
namespace PatternLibrary
{
    public interface IState
    {
        void Handle();
    }

    public interface IContext
    {
        void Request();
    }

    public abstract class State : IState
    {
        protected IContext m_context;

        public abstract void Handle();
    }

    public abstract class Context : IContext
    {
        protected IState m_state;

        public virtual void Request()
        {
            m_state.Handle();
        }
    }
}
