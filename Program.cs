using System;
using System.Net.Http;

namespace HttpConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpClient httpClient = new();
            ReqresQueryClient queryClient = new();

            var usersList = queryClient.GetListUsers(1, httpClient).GetAwaiter().GetResult();

            var singleUser = queryClient.GetSingleUser(88, httpClient).GetAwaiter().GetResult();

            var resourcesList = queryClient.GetListResources(true, httpClient).GetAwaiter().GetResult();

            var singleResource = queryClient.GetSingleResource(82, httpClient).GetAwaiter().GetResult();

            var userCreate = queryClient.CreateUser(httpClient).GetAwaiter().GetResult();

            var userDelete = queryClient.DeleteUser(2, httpClient);

            var putUserUpdate = queryClient.PutUpdateUser(2, httpClient).GetAwaiter().GetResult();

            var delay = queryClient.GetDelayListUsers(httpClient).GetAwaiter().GetResult();

            var patchUserUpdate = queryClient.PatchUpdateUser(2, httpClient).GetAwaiter().GetResult();

            UserRegistration user = new() {Email = "eve.holt@reqres.in", Password = "pistol"};

            var userRegister = queryClient.UserRegister(user, httpClient).GetAwaiter().GetResult();

            UserRegistration failReg = new() {Email = "sydney@fife"};

            var userRegister1 = queryClient.UserRegister(failReg, httpClient).GetAwaiter().GetResult();

            var userLogin = queryClient.UserLogin(user, httpClient).GetAwaiter().GetResult();
        }
    }
}