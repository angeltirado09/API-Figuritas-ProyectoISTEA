using Figuritas.Abstractions.Interfaces;
using Figuritas.Abstractions.DTO;
namespace Figuritas.Consumer.Services
{
    public class FiguritaService(HttpClient _client) : IFiguritaService
    {
        public async Task<List<FiguritaDTO>> GetAllFiguritasAsync()
        {
            return await _client.GetFromJsonAsync<List<FiguritaDTO>>("figuritas");
        }

        public async Task<List<FiguritaDTO>> GetFigusByCountry(string country)
        {
            var figus = await GetAllFiguritasAsync();
            return figus.Where(f => f.country.Equals(country, StringComparison.OrdinalIgnoreCase) && !f.isDeleted).ToList();
        }

        public async Task<List<FiguritaDTO>> GetFigusByID(string id)
        {
            var figus = await GetAllFiguritasAsync();
            var result = figus
                .Where(f => f.id.Equals(id, StringComparison.OrdinalIgnoreCase) && !f.isDeleted)
                .Cast<FiguritaDTO>()
                .ToList();

            if (result.Count == 0)
            {
                Console.WriteLine("No se encontró ninguna figurita con el ID introducido");
            }
            return result;
        }


    }
}
