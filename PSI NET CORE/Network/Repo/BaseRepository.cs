using Newtonsoft.Json;
using PSI_NET_CORE.Network.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PSI_NET_CORE.Network
{
    public class BaseRepository<TEntity > : IBase<TEntity> where TEntity : class 
    {
        HttpClient _client;
        String END_POINT;
        public BaseRepository(String END_POINT)
        {
            _client = new HttpClient();
            new HttpClientHandler { ClientCertificateOptions = ClientCertificateOption.Automatic };
             _client.BaseAddress = new Uri(Constants.BASE_URL);
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            this.END_POINT = END_POINT;
        }
        public int delete(TEntity T)
        {
            var url = Constants.BASE_URL +END_POINT+ Constants.URL_DELETE;
            HttpResponseMessage res = _client.DeleteAsync(url + T).Result;
            if (res.IsSuccessStatusCode)
            {
                //result = JsonConvert.DeserializeObject<int>(res.Content.ReadAsStringAsync().Result);
                return 1;
            }
            return 0;
        }

        public int delete(object id)
        {
            var url = Constants.BASE_URL + END_POINT + Constants.URL_DELETE;
            HttpResponseMessage res = _client.DeleteAsync(url + id).Result;
            
            if (res.IsSuccessStatusCode)
            {
               // result= JsonConvert.DeserializeObject<int>(res.Content.ReadAsStringAsync().Result);
                return 1;
            }
            return 0;
        }

        public async Task<List<TEntity>> get()
        {
            var url = Constants.BASE_URL + END_POINT;
            var list = new List<TEntity>();

            await Task.Run(async () => {
                try
                {
                    HttpResponseMessage res = _client.GetAsync(url).Result;
                    if (res.IsSuccessStatusCode)
                    {
                        var results = res.Content.ReadAsStringAsync().Result;
                        list = JsonConvert.DeserializeObject<List<TEntity>>(results);
                    }
                }
                catch (Exception ex)
                {
                    await get();
                }
            });
            
            return list;
        }

        public TEntity get(object id)
        {
            var url = Constants.BASE_URL + END_POINT;
            TEntity item = default(TEntity);
            HttpResponseMessage res = _client.GetAsync(url+id).Result;
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                 var items = JsonConvert.DeserializeObject<List<TEntity>>(results);
                foreach(var t in items)
                {
                    item = t;
                }
            }
            return item;
        }

        public int insert(TEntity T)
        {
            var url = Constants.BASE_URL + END_POINT + Constants.URL_INSERT;
            string data = JsonConvert.SerializeObject(T);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage res = _client.PostAsync(url, content).Result;
            
            if (res.IsSuccessStatusCode)
            {
                //result = JsonConvert.DeserializeObject<int>(res.Content.ReadAsStringAsync().Result);
                return 1;
            }
            return 0;
        }
        public int insertUser(TEntity T)
        {
            var url = Constants.BASE_URL + "lg/add";
            string data = JsonConvert.SerializeObject(T);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage res = _client.PostAsync(url, content).Result;

            if (res.IsSuccessStatusCode)
            {
                //result = JsonConvert.DeserializeObject<int>(res.Content.ReadAsStringAsync().Result);
                return 1;
            }
            return 0;
        }
        public int update(Guid Id,TEntity T)
        {
            var url = Constants.BASE_URL + END_POINT + Constants.URL_UPDATE;
            string data = JsonConvert.SerializeObject(T);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage res = _client.PutAsync(url+Id, content).Result;
           
            if (res.IsSuccessStatusCode)
            {
                // result = JsonConvert.DeserializeObject<int>(res.Content.ReadAsStringAsync().Result);
                return 1;
            }
            return 0;
        }
        public async Task<int> Validate(TEntity t)
        {
            var url = Constants.BASE_URL + "validate/";
            var code = 0;

            await Task.Run(async () => {
                try
                {
                    HttpResponseMessage res = _client.GetAsync(url).Result;
                    if (res.IsSuccessStatusCode)
                    {
                        var results = res.Content.ReadAsStringAsync().Result;
                        code = JsonConvert.DeserializeObject<int>(results);
                    }
                }
                catch (Exception ex)
                {
                    await get();
                }
            });

            return code;
        }
    }
}
