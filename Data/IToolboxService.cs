using F20ITONK.ASPNETCore.MicroService.ClassLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ONKDelprojekt1Frontend.Data
{
    public interface IToolboxService
    {
        Task<List<Vaerktoejskasse>> GetToolboxes();

        Task<Vaerktoejskasse> GetToolbox(int id);

        Task<bool> PutToolbox(int id, Vaerktoejskasse toolbox);

        Task<bool> DeleteToolbox(int id);

        Task<bool> PostToolbox(Vaerktoejskasse toolbox);
    }
}
