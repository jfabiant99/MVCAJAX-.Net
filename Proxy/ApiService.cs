using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Net.Http.Headers;

namespace MVCAJAX_.Net.Proxy
{
    public class ApiService
    {
        public async Task<Response> GetList<T>(string urlBase, string prefijo, string control)
        {
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(urlBase);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var url = $"{prefijo}{control}";
                var response = await client.GetAsync(url);
                var answer = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        Estado = false,
                        Mensaje = answer
                    };
                }

                var list = JsonConvert.DeserializeObject<List<T>>(answer);
                return new Response
                {
                    Estado = true,
                    Resultado = list
                };

            }
            catch (Exception ex)
            {
                return new Response
                {
                    Estado = false,
                    Mensaje = ex.Message
                };
            }
        }

        public async Task<Response> Get<T>(string urlBase, string prefijo, string control, int id)
        {
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(urlBase);
                var url = $"{prefijo}{control}/{id}";
                var response = await client.GetAsync(url);
                var answer = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        Estado = false,
                        Mensaje = answer
                    };
                }

                var list = JsonConvert.DeserializeObject<T>(answer);
                return new Response
                {
                    Estado = true,
                    Resultado = list
                };

            }
            catch (Exception ex)
            {
                return new Response
                {
                    Estado = false,
                    Mensaje = ex.Message
                };
            }
        }

        public async Task<Response> Post<T>(string urlBase, string prefix, string controller, T model)
        {
            try
            {
                var request = JsonConvert.SerializeObject(model);
                var content = new StringContent(request, Encoding.UTF8, "application/json");
                var client = new HttpClient();
                client.BaseAddress = new Uri(urlBase);
                var url = $"{prefix}{controller}";
                var response = await client.PostAsync(url, content);
                var answer = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        Estado = false,
                        Mensaje = answer,
                    };
                }

                // var obj = JsonConvert.DeserializeObject<T>(answer);
                return new Response
                {
                    Estado = true,
                    Resultado = null,
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    Estado = false,
                    Mensaje = ex.Message,
                };
            }
        }

        public async Task<Response> Put<T>(string urlBase, string prefix, string controller, T model)
        {
            try
            {
                var request = JsonConvert.SerializeObject(model);
                var content = new StringContent(request, Encoding.UTF8, "application/json");
                var client = new HttpClient();
                client.BaseAddress = new Uri(urlBase);
                var url = $"{prefix}{controller}";
                var response = await client.PutAsync(url, content);
                var answer = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        Estado = false,
                        Mensaje = answer,
                    };
                }

                // var obj = JsonConvert.DeserializeObject<T>(answer);
                return new Response
                {
                    Estado = true,
                    Resultado = null,
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    Estado = false,
                    Mensaje = ex.Message,
                };
            }
        }

        public async Task<Response> Delete(string urlBase, string prefijo, string control, int id)
        {
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(urlBase);
                var url = $"{prefijo}{control}/{id}";
                var response = await client.DeleteAsync(url);
                var answer = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        Estado = false,
                        Mensaje = answer
                    };
                }

                //var list = JsonConvert.DeserializeObject<T>(answer);
                return new Response
                {
                    Estado = true,
                    Resultado = null
                };

            }
            catch (Exception ex)
            {
                return new Response
                {
                    Estado = false,
                    Mensaje = ex.Message
                };
            }
        }

    }
}