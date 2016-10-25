using System.IO;

namespace Driver.Comon.Serialization
{
    public interface ISerializer<TFormat>
    {
        TFormat Serialize(object obj);
        T Deserialize<T>(TFormat value);
        T Deserialize<T>(Stream stream);
    }
}