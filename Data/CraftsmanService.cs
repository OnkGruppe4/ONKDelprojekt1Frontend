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
    public class CraftsmanService : ICraftsManService
    {
        private HttpClient Client;
        public CraftsmanService(HttpClient client)
        {
            Client = client;
        }

        public async Task<List<Haandvaerker>> GetCraftsmen()
        {

            var response = await Client.GetAsync("CraftsMan");

            var result = JsonConvert.DeserializeObject<Haandvaerker[]>(
            await response.Content.ReadAsStringAsync());

            return result.ToList();

            //return Task.FromResult(Enumerable.Range(1, 5).Select(index => new CraftsMan
            //{
            //    DateOfEmployment = DateTime.Now,
            //    FieldOfWork = "IDK",
            //    FirstName = "Morten",
            //    SurName = "Morten Rosenquist",
            //    Id = Guid.Empty
            //}).ToArray());
        }

        public async Task<Haandvaerker> GetCraftsman(int id)
        {
            var response = await Client.GetAsync($"CraftsMan/{id}");

            var result = JsonConvert.DeserializeObject<Haandvaerker>(
            await response.Content.ReadAsStringAsync());

            return result;
        }

        public async Task<bool> PutCraftsman(int id, Haandvaerker craftsman)
        {
            var content = new StringContent(JsonConvert.SerializeObject(craftsman), Encoding.UTF8, "application/json");

            var response = await Client.PutAsync($"CraftsMan/{id}", content);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                return false;

            return true;
        }

        public async Task<bool> DeleteCraftsman(int id)
        {
            var response = await Client.DeleteAsync($"CraftsMan/{id}");

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                return false;

            return true;
        }
            
        public async Task<bool> PostCraftsman(Haandvaerker craftsman)
        {
            var content = new StringContent(JsonConvert.SerializeObject(craftsman), Encoding.UTF8, "application/json");

            var response = await Client.PostAsync($"CraftsMan", content);   

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                return false;

            return true;
        }
    }
}
