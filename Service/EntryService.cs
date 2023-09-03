using Newtonsoft.Json;
using WebClient.Interface;

namespace WebClient.Service
{
    public class EntryService : IEntryInterface
    {
        HttpClient client;
        public EntryService()
        {
            client = new HttpClient();
            client.BaseAddress = client.BaseAddress = new Uri("https://api.publicapis.org/");
        }
        public async Task<T> GetData<T>()
        {
            T data = default(T);
            var response = client.GetAsync(client.BaseAddress+"entries").Result;
            if (response.IsSuccessStatusCode)
            {

                //var content = response.Content.ReadAsStringAsync().Result;
                data = await response.Content.ReadFromJsonAsync<T>().ConfigureAwait(false);
            }
            
            return data;
        }
    }
}
