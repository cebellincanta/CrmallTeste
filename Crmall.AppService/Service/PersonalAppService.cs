using AutoMapper;
using CrmallTeste.AppService.DTO;
using CrmallTeste.AppService.Interface;
using CrmallTeste.AppService.Notification;
using CrmallTeste.Domain.Entities;
using CrmallTeste.Domain.Enum;
using CrmallTeste.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CrmallTeste.AppService.Service
{
    public class PersonalAppService : IPersonalAppService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly INotifierAppService _notifier;

        public PersonalAppService(IUnitOfWork unitOfWork, IMapper mapper, INotifierAppService notifier)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _notifier = notifier;
        }

        public async Task AddAsync(PersonalDTO personalDTO)
        {
            try
            {
                var personal = await _unitOfWork.IPersonRepository.GetByAsync(x => x.Cpf.Equals(personalDTO.Cpf));

                if(personal != null)
                {
                    _notifier.Handle(new NotificationMessage("Erro", "Pessoa já cadastrada com esse CPF."));
                    throw new Exception();
                }


                await _unitOfWork.IPersonRepository.AddAsync(_mapper.Map<Personal>(personalDTO));
                await _unitOfWork.CommitAsync();
            }
            catch(Exception e)
            {
                _notifier.Handle(new NotificationMessage("Erro", e.Message));
            }
            
        }

        public async Task DeleteAsync(PersonalDTO personalDTO)
        {
            try
            {
                await _unitOfWork.IPersonRepository.DeleteAsync(_mapper.Map<Personal>(personalDTO));
                await _unitOfWork.CommitAsync();
            }
            catch (Exception e)
            {
                _notifier.Handle(new NotificationMessage("Erro", e.Message));
            }

        }

        public async Task DeleteSoftAsync(PersonalDTO personalDTO)
        {
            try
            {
                var result  = await _unitOfWork.IPersonRepository.GetByIdAsync(x => x.Id.Equals(personalDTO.Id));
                result.RecordSituation = RecordSituation.INACTIVE;
                await _unitOfWork.CommitAsync();
            }
            catch (Exception e)
            {
                _notifier.Handle(new NotificationMessage("Erro", e.Message));
            }
        }

        public  async Task<List<PersonalDTO>> GetAllAsync()
        {
            try
            {
                 return _mapper.Map<List<PersonalDTO>>(await _unitOfWork.IPersonRepository.GetByAsync(x => x.RecordSituation == RecordSituation.ACTIVE));
            }
            catch (Exception e)
            {
                _notifier.Handle(new NotificationMessage("Erro", e.Message));
                throw new Exception();
            }
        }

        public async Task<PersonalDTO> GetByIdAsync(string Id)
        {
            var result = await _unitOfWork.IPersonRepository.GetByIdAsync(x => x.Id.Equals(Id));

            return _mapper.Map<PersonalDTO>(result);
        }

        public async Task<PersonalDTO> GetByNameAsync(string Name)
        {
            var result = await _unitOfWork.IPersonRepository.GetByAsync(x => x.Name.Contains(Name));

            return _mapper.Map<PersonalDTO>(result);
        }

        public async Task<PersonalDTO> UpdateAsync(PersonalDTO personalDTO)
        {
            try
            {
                _unitOfWork.IPersonRepository.Update(_mapper.Map<Personal>(personalDTO));
                await _unitOfWork.CommitAsync();

                var result = await GetByIdAsync(personalDTO.Id);

                return result;
            }
            catch (Exception e)
            {
                _notifier.Handle(new NotificationMessage("Erro", e.Message));
                throw new Exception();
            }

        }
    }
}
