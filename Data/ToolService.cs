using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using F20ITONK.ASPNETCore.MicroService.ClassLib.Models;
using Newtonsoft.Json;

namespace ONKDelprojekt1Frontend.Data
{
    public class ToolService : IToolService
    {
        private HttpClient Client;
        public ToolService(HttpClient client)
        {
            Client = client;
        }

        public async Task<List<Vaerktoej>> GetTools()
        {
            var response = await Client.GetAsync("Tool");

            var result = JsonConvert.DeserializeObject<Vaerktoej[]>(
            await response.Content.ReadAsStringAsync());

            return result.ToList();            
        }

        public async Task<Vaerktoej> GetTool(long id)
        {
            var response = await Client.GetAsync($"Tool/{id}");

            var result = JsonConvert.DeserializeObject<Vaerktoej>(
            await response.Content.ReadAsStringAsync());

            return result;
        }

        public async Task<bool> PutTool(long id, Vaerktoej tool)
        {
            var response = await Client.PutAsync($"Tool/{id}", new StringContent(JsonConvert.SerializeObject(tool), Encoding.UTF8, "application/json"));

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                return false;

            return true;
        }

        public async Task<bool> DeleteTool(long id)
        {
            var response = await Client.DeleteAsync($"Tool/{id}");

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                return false;

            return true;
        }

        public async Task<bool> PostTool(Vaerktoej tool)
        {
            var content = new StringContent(JsonConvert.SerializeObject(tool), Encoding.UTF8, "application/json");

            var response = await Client.PostAsync($"Tool", content);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                return false;

            return true;
        }
    }
}
