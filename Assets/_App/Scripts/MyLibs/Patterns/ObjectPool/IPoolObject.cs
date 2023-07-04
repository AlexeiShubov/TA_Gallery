namespace MyLibs
{
    public interface IPoolObject
    {
        public abstract void Initialize(IPool<IPoolObject> pool);
        public abstract void Return();
    }
}
