using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HttpConsoleApp
{
    public class ReqresQueryClient
    {
        private readonly string BASE_URL = "https://reqres.in/api/";
        private string uri;

        public async Task<BaseReqresInfo<User>> GetListUsers(int? page, HttpClient httpClient)
        {
            if (page.HasValue)
            {
                uri = $"{BASE_URL}users?page={page}";
            }
            else
            {
                uri = $"{BASE_URL}users";
            }

            var response = await httpClient.GetAsync(uri);

            var payload = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<BaseReqresInfo<User>>(payload);
        }

        public async Task<SingleObjectReqres<User>> GetSingleUser(int? id, HttpClient httpClient)
        {

            if (id.HasValue)
            {
                uri = $"{BASE_URL}users/{id}";
                
                var response = await httpClient.GetAsync(uri);
                
                var payload = await response.Content.ReadAsStringAsync();
                
                return JsonConvert.DeserializeObject<SingleObjectReqres<User>>(payload);
            }
            else
            {
                uri = $"{BASE_URL}users/{id}";
                var response = httpClient.GetAsync(uri).Exception;
                return null;
            }
        }

        public async Task<BaseReqresInfo<Resource>> GetListResources(bool st, HttpClient httpClient)
        {
                if (st)
                {
                    uri = $"{BASE_URL}unknown";
                }
                else
                {
                    uri = BASE_URL;
                }

                var response = await httpClient.GetAsync(uri);
                
                var payload = await response.Content.ReadAsStringAsync();
                
                return JsonConvert.DeserializeObject<BaseReqresInfo<Resource>>(payload);
        }
        
        public async Task<SingleObjectReqres<Resource>> GetSingleResource(int? id, HttpClient httpClient)
        {

            if (id.HasValue)
            {
                uri = $"{BASE_URL}unknown/{id}";
                
                var response = await httpClient.GetAsync(uri);
                
                var payload = await response.Content.ReadAsStringAsync();
                
                return JsonConvert.DeserializeObject<SingleObjectReqres<Resource>>(payload);
            }
            else
            {
                uri = $"{BASE_URL}unknown/{id}";
                var response = httpClient.GetAsync(uri).Exception;
                return null;
            }
        }

        public async Task<SingleObjectReqres<Response>> CreateUser(HttpClient httpClient)
        {
            var payload = new
            {
                name = "morpheus",
                job = "leader"
            };

            var httpContent = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8);
            var httpMessage = new HttpRequestMessage();
            httpMessage.Content = httpContent;
            httpMessage.RequestUri = new Uri(@"https://reqres.in/api/users");
            httpMessage.Method = HttpMethod.Post;

            var result = await httpClient.SendAsync(httpMessage);
            var content = await result.Content.ReadAsStringAsync();
            
            return JsonConvert.DeserializeObject<SingleObjectReqres<Response>>(content);
        }

        public Task DeleteUser(int? id, HttpClient httpClient)
        {
            object response;
            if (id.HasValue)
            {
                uri = $"{BASE_URL}users/{id}";
                
                response = httpClient.DeleteAsync(uri);
            }
            else
            {
                uri = $"{BASE_URL}users/{id}";
                
                response = httpClient.DeleteAsync(uri).Exception;
            }

            return (Task)response;
        }

        public async Task<UpdateReqresService> PutUpdateUser(int? id, HttpClient httpClient)
        {
            if (id.HasValue)
            {
                uri = $"{BASE_URL}users/{id}";
                var query = await httpClient.GetAsync(uri);
                
                var payload = query.Content.ToString();
                
                var response = await httpClient.PutAsync(uri, new StringContent(payload));

                return JsonConvert.DeserializeObject<UpdateReqresService>(payload);
            }
            else
            {
                uri = $"{BASE_URL}users/{id}";
                var response = httpClient.GetAsync(uri).Exception;
                return null;
            }
        }
        
        public async Task<BaseReqresInfo<User>> GetDelayListUsers(HttpClient httpClient)
        {
            uri = $"{BASE_URL}users?delay=3";

            var response = await httpClient.GetAsync(uri);

            var payload = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<BaseReqresInfo<User>>(payload);
        }
        
        public async Task<UpdateReqresService> PatchUpdateUser(int? id, HttpClient httpClient)
        {
            if (id.HasValue)
            {
                uri = $"{BASE_URL}users/{id}";
                var query = await httpClient.GetAsync(uri);
                var payloading = await query.Content.ReadAsStringAsync();

                var response = await httpClient.PatchAsync(uri, new StringContent("morpheus, leader"));

                return JsonConvert.DeserializeObject<UpdateReqresService>(payloading);
            }
            else
            {
                uri = $"{BASE_URL}users";
                var response = httpClient.GetAsync(uri).Exception;
                return null;
            }
        }

        public async Task<RegisterReqresService> UserRegister(UserRegistration user, HttpClient httpClient)
        {
            uri = $"{BASE_URL}register";
            if (user.Password.Equals(null))
            {
                var response = await httpClient.GetAsync(uri);
                var payloading = response.Content.ReadAsStringAsync();
            }

            var query = await httpClient.PostAsync(uri, new StringContent(uri));
            
            var payload = await query.Content.ReadAsStringAsync();
            
            return JsonConvert.DeserializeObject<RegisterReqresService>(payload);
        }
        
        public async Task<LoginToken> UserLogin(UserRegistration user, HttpClient httpClient)
        {
            uri = $"{BASE_URL}login";
            if (user.Password.Equals(null))
            {
                var response = await httpClient.GetAsync(uri);
                var payloading = response.Content.ReadAsStringAsync();
            }

            var query = await httpClient.PostAsync(uri, new StringContent(uri));
            
            var payload = await query.Content.ReadAsStringAsync();
            
            return JsonConvert.DeserializeObject<LoginToken>(payload);
        }
    }
}