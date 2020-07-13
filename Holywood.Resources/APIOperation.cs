using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Holywood.Resources
{
    public class APIOperation
    {
        public struct APIData
        {
            public string APIUrl { get; set; }
            public HttpClient Client { get; set; }
        }

        public static T GetData<T>(APIData data)
        {
            try
            { 
                var responseMessage = data.Client.GetAsync(data.APIUrl).Result;

                if (responseMessage.IsSuccessStatusCode)
                {
                    var res = responseMessage.Content.ReadAsStringAsync().Result;

                    return JsonConvert.DeserializeObject<T>(res);
                }
            }
            catch (Exception ex)
            {
                //Log exception
            }

            return default;
        }

        /// <summary>
        /// Returns integer
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int PostData<T>(APIData data, T value)
        {
            try
            {
                var responseMessage = data.Client.PostAsJsonAsync(data.APIUrl, value).Result;

                if (responseMessage.IsSuccessStatusCode)
                {
                    var res = responseMessage.Content.ReadAsStringAsync().Result;

                    return JsonConvert.DeserializeObject<int>(res);
                }
            }
            catch (Exception ex)
            {
                //Log exception
            }

            return 0;
        }

        /// <summary>
        /// Returns integer
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int PutData<T>(APIData data, T value)
        {
            try
            {
                var responseMessage = data.Client.PutAsJsonAsync(data.APIUrl, value).Result;

                if (responseMessage.IsSuccessStatusCode)
                {
                    var res = responseMessage.Content.ReadAsStringAsync().Result;

                    return JsonConvert.DeserializeObject<int>(res);
                }
            }
            catch (Exception ex)
            {
                //Log exception
            }

            return 0;
        }

        public static T DeleteData<T>(APIData data)
        {
            try
            {
                data.Client.Timeout = TimeSpan.FromMinutes(5);

                var responseMessage = data.Client.DeleteAsync(data.APIUrl).Result;

                if (responseMessage.IsSuccessStatusCode)
                {
                    var res = responseMessage.Content.ReadAsStringAsync().Result;

                    return JsonConvert.DeserializeObject<T>(res);
                }
            }
            catch (Exception ex)
            {
                //Log exception
            }

            return default;
        }
    }
}
