using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Observer.Core.Extensions
{
    public static class StreamExtensions
    {
        public static Task<string> ReadAllAsync(this Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                return reader.ReadToEndAsync();
        }
    }
}
