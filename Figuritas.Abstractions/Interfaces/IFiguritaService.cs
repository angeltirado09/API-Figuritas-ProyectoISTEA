using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Figuritas.Abstractions.DTO;

namespace Figuritas.Abstractions.Interfaces
{
    public interface IFiguritaService
    {
        Task<List<FiguritaDTO>> GetAllFiguritasAsync();
        Task<List<FiguritaDTO?>> GetFigusByCountry(string country);
        Task<List<FiguritaDTO>> GetFigusByID(string id);
    }
}
