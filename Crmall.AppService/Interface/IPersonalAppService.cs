using CrmallTeste.AppService.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CrmallTeste.AppService.Interface
{
    public interface IPersonalAppService
    {
        Task AddAsync(PersonalDTO personalDTO);

        Task DeleteSoftAsync(PersonalDTO personalDTO);

        Task DeleteAsync(PersonalDTO personalDTO);

        
        Task<List<PersonalDTO>> GetAllAsync();

        Task<PersonalDTO> GetByIdAsync(string Id);

        Task<PersonalDTO> GetByNameAsync(string Name);

        Task<PersonalDTO> UpdateAsync(PersonalDTO personalDTO);




    }
}
