namespace Driver.Infrastructure
{
    public interface IFactory<out T>
    {
        T Create();
    }
}