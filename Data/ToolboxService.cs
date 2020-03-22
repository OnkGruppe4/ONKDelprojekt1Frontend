using F20ITONK.ASPNETCore.MicroService.ClassLib.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ONKDelprojekt1Frontend.Data
{
    public class ToolboxService : IToolboxService
    {
        private HttpClient Client;
        public ToolboxService(HttpClient client)
        {
            Client = client;
        }
        public async Task<List<Vaerktoejskasse>> GetToolboxes()
        {

            var response = await Client.GetAsync("ToolBox");

            var result = JsonConvert.DeserializeObject<Vaerktoejskasse[]>(
            await response.Content.ReadAsStringAsync());

            return result.ToList();
        }

        public async Task<Vaerktoejskasse> GetToolbox(int id)
        {
            var response = await Client.GetAsync($"ToolBox/{id}");

            var result = JsonConvert.DeserializeObject<Vaerktoejskasse>(
            await response.Content.ReadAsStringAsync());

            return result;
        }

        public async Task<bool> PutToolbox(int id, Vaerktoejskasse toolbox)
        {
            var response = await Client.PutAsync($"ToolBox/{id}", new StringContent(JsonConvert.SerializeObject(toolbox), Encoding.UTF8, "application/json"));

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                return false;

            return true;
        }

        public async Task<bool> DeleteToolbox(int id)
        {
            var response = await Client.DeleteAsync($"ToolBox/{id}");

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                return false;

            return true;
        }

        public async Task<bool> PostToolbox(Vaerktoejskasse toolbox)
        {
            var content = new StringContent(JsonConvert.SerializeObject(toolbox), Encoding.UTF8, "application/json");

            var response = await Client.PostAsync($"ToolBox", content);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                return false;

            return true;
        }
    }
}
