namespace MyLibs
{
    public interface IFactory<out T>
    {
        public abstract T Create();
    }
}
