using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrmallTeste.AppService.DTO;
using CrmallTeste.AppService.Interface;
using CrmallTeste.AppService.Notification;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrmallTeste.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class PersonalController : MainController
    {
        private IPersonalAppService _personalAppService;

        public PersonalController(IPersonalAppService personalAppService, INotifierAppService notifier) : base(notifier)
        {
            _personalAppService = personalAppService;
        }

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> GetAllAsync()
        {
            
            var result = await _personalAppService.GetAllAsync();
            return CustomResponse(result);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateAsync(PersonalDTO personal)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            try
            {
                await _personalAppService.AddAsync(personal);
                return CustomResponse();
            }
            catch(Exception)
            {
                return CustomResponse();
            }
        }

        [HttpPut]
        [Route("update")]
        
        public async Task<IActionResult> UpdateAsync(PersonalDTO personal)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            
            var model = await _personalAppService.UpdateAsync(personal);

            return CustomResponse(model);
        }

        [HttpGet]
        [Route("get-by-id")]
        public async Task<IActionResult> GetByIdAsync(string Id)
        {
            var result = await _personalAppService.GetByIdAsync(Id);

            return CustomResponse(result);
        }

        [HttpGet]
        [Route("get-by-name")]
        public async Task<IActionResult> GetByNameAsync(string Id)
        {
            var result = await _personalAppService.GetByIdAsync(Id);

            return CustomResponse(result);
        }

        [HttpDelete]
        [Route("delete-soft")]
        public async Task<IActionResult> DeleteSoAsync(PersonalDTO personal)
        {
            try
            {
                await _personalAppService.DeleteSoftAsync(personal);

                return CustomResponse();
            }catch(Exception)
            {
                return CustomResponse();
            }
         
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeletAsync(PersonalDTO personal)
        {
            try
            {
                await _personalAppService.DeleteAsync(personal);

                return CustomResponse();
            }
            catch (Exception)
            {
                return CustomResponse();
            }

        }
    }
}
