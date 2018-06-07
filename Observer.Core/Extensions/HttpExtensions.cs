using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Threading.Tasks;

namespace Observer.Core.Extensions
{
    public static class HttpExtensions
    {
        public static StringContent ToStringContent(this string content) => new StringContent(content);

        public static Task<T> DeserializeRequestBodyAsync<T>(this HttpContext httpContext)
            => httpContext.Request.Body.ReadAllAsync()
            .ContinueWith(task => task.Result.Deserialize<T>());
    }
}
