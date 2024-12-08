using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Intotech.Common.Http
{
    public abstract class HttpClientProxy
    {
        protected string BaseUrl = "http://127.0.0.1:8642/";

        protected virtual T ApiGet<T>(string url, bool isResponseArray)
        {
            using (HttpClient hc = new HttpClient())
            {
                hc.BaseAddress = new Uri(BaseUrl);
                // hc.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", LoggedUserContext.User.Token);

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

        protected virtual T ApiPost<T, TDto>(string url, TDto dto, bool isResponseArray)
        {
            using (HttpClient hc = new HttpClient())
            {
                hc.BaseAddress = new Uri(BaseUrl);

                //if (LoggedUserContext.User != null)
                {
                   // hc.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", LoggedUserContext.User.Token);
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

        protected virtual T ApiPut<T, TDto>(string url, TDto dto, bool isResponseArray)
        {
            using (HttpClient hc = new HttpClient())
            {
                hc.BaseAddress = new Uri(BaseUrl);
                // hc.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", LoggedUserContext.User.Token);

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

        protected virtual T ApiPatch<T, TDto>(string url, TDto dto, bool isResponseArray)
        {
            using (HttpClient hc = new HttpClient())
            {
                hc.BaseAddress = new Uri(BaseUrl);
                // hc.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", LoggedUserContext.User.Token);

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

        protected virtual T ApiDelete<T, TDto>(string url, TDto dto, bool isResponseArray)
        {
            using (HttpClient hc = new HttpClient())
            {
                hc.BaseAddress = new Uri(BaseUrl);
                // hc.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", LoggedUserContext.User.Token);

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

    }
}