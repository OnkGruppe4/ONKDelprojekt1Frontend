using F20ITONK.ASPNETCore.MicroService.ClassLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ONKDelprojekt1Frontend.Data
{
    public interface ICraftsManService
    {
        Task<List<Haandvaerker>> GetCraftsmen();

        Task<Haandvaerker> GetCraftsman(int id);

        Task<bool> PutCraftsman(int id, Haandvaerker craftsman);

        Task<bool> DeleteCraftsman(int id);

        Task<bool> PostCraftsman(Haandvaerker craftsman);
    }
}
