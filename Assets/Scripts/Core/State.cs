namespace Core
{
    public abstract class State<T>
    {
        public abstract void EnterState(T stateHolder);
        public abstract void UpdateState(T stateHolder);
    }

    public abstract class StateNoUpdate<T> {
        public abstract void EnterState(T stateHolder);
    }
}