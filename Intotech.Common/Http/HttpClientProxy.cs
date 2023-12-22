using Newtonsoft.Json.Linq;
using System.Net.Http.Json;

namespace Intotech.Common.Http
{
    public abstract class HttpClientProxy
    {
        protected string BaseUrl = "http://127.0.0.1:8642/";
        protected string AuthorizationToken;

        public virtual T ApiGet<T>(string url, bool isResponseArray)
        {
            using (HttpClient hc = new HttpClient())
            {
                hc.BaseAddress = new Uri(BaseUrl);

                if (!string.IsNullOrEmpty(AuthorizationToken))
                {
                    hc.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", AuthorizationToken);
                }

                HttpResponseMessage response = hc.GetAsync(url).Result;

                string responseContent = response.Content.ReadAsStringAsync().Result;

                if (responseContent == string.Empty)
                {
                    return default(T);
                }

                if (typeof(T).IsValueType)
                {
                    return (T)Convert.ChangeType(responseContent, typeof(T));
                }

                return isResponseArray ? JArray.Parse(responseContent).ToObject<T>() : JObject.Parse(responseContent).ToObject<T>();
            }
        }

        public virtual T ApiPost<T, TDto>(string url, TDto dto, bool isResponseArray)
        {
            using (HttpClient hc = new HttpClient())
            {
                hc.BaseAddress = new Uri(BaseUrl);

                if (!string.IsNullOrEmpty(AuthorizationToken))
                {
                    hc.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", AuthorizationToken);
                }

                HttpContent content = JsonContent.Create<TDto>(dto);

                HttpResponseMessage response = hc.PostAsync(url, content).Result;

                string responseContent = response.Content.ReadAsStringAsync().Result;

                if (responseContent == string.Empty)
                {
                    return default(T);
                }

                if (typeof(T).IsValueType)
                {
                    return (T)Convert.ChangeType(responseContent, typeof(T));
                }

                return isResponseArray ? JArray.Parse(responseContent).ToObject<T>() : JObject.Parse(responseContent).ToObject<T>();
            }
        }

        public virtual T ApiPut<T, TDto>(string url, TDto dto, bool isResponseArray)
        {
            using (HttpClient hc = new HttpClient())
            {
                hc.BaseAddress = new Uri(BaseUrl);

                if (!string.IsNullOrEmpty(AuthorizationToken))
                {
                    hc.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", AuthorizationToken);
                }

                HttpContent content = JsonContent.Create<TDto>(dto);

                HttpResponseMessage response = hc.SendAsync(new HttpRequestMessage()
                { Method = HttpMethod.Put, RequestUri = new Uri(url, UriKind.Relative), Content = content }).Result;

                string responseContent = response.Content.ReadAsStringAsync().Result;

                if (responseContent == string.Empty)
                {
                    return default(T);
                }

                if (typeof(T).IsValueType)
                {
                    return (T)Convert.ChangeType(responseContent, typeof(T));
                }

                return isResponseArray ? JArray.Parse(responseContent).ToObject<T>() : JObject.Parse(responseContent).ToObject<T>();
            }
        }

        public virtual T ApiPatch<T, TDto>(string url, TDto dto, bool isResponseArray)
        {
            using (HttpClient hc = new HttpClient())
            {
                hc.BaseAddress = new Uri(BaseUrl);

                if (!string.IsNullOrEmpty(AuthorizationToken))
                {
                    hc.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", AuthorizationToken);
                }

                HttpContent content = JsonContent.Create<TDto>(dto);

                HttpResponseMessage response = hc.SendAsync(new HttpRequestMessage()
                { Method = HttpMethod.Patch, RequestUri = new Uri(url, UriKind.Relative), Content = content }).Result;

                string responseContent = response.Content.ReadAsStringAsync().Result;

                if (responseContent == string.Empty)
                {
                    return default(T);
                }

                if (typeof(T).IsValueType)
                {
                    return (T)Convert.ChangeType(responseContent, typeof(T));
                }

                return isResponseArray ? JArray.Parse(responseContent).ToObject<T>() : JObject.Parse(responseContent).ToObject<T>();
            }
        }

        public virtual T ApiDelete<T, TDto>(string url, TDto dto, bool isResponseArray)
        {
            using (HttpClient hc = new HttpClient())
            {
                hc.BaseAddress = new Uri(BaseUrl);

                if (!string.IsNullOrEmpty(AuthorizationToken))
                {
                    hc.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", AuthorizationToken);
                }

                //  HttpContent content = JsonContent.Create<TDto>(dto);

                HttpResponseMessage response = hc.SendAsync(new HttpRequestMessage()
                { Method = HttpMethod.Delete, RequestUri = new Uri(url, UriKind.Relative) }).Result;

                string responseContent = response.Content.ReadAsStringAsync().Result;

                if (responseContent == string.Empty)
                {
                    return default(T);
                }

                if (typeof(T).IsValueType)
                {
                    return (T)Convert.ChangeType(responseContent, typeof(T));
                }

                return isResponseArray ? JArray.Parse(responseContent).ToObject<T>() : JObject.Parse(responseContent).ToObject<T>();
            }
        }

        protected abstract void CreateBearerTokenAuthorization(string email, string name, string surname, string roleName);
    }
}