using F20ITONK.ASPNETCore.MicroService.ClassLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ONKDelprojekt1Frontend.Data
{
    public interface IToolService
    {
        Task<List<Vaerktoej>> GetTools();

        Task<Vaerktoej> GetTool(long id);

        Task<bool> PutTool(long id, Vaerktoej tool);

        Task<bool> DeleteTool(long id);

        Task<bool> PostTool(Vaerktoej tool);
    }
}
