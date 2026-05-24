using Application.Intrerfaces;
using AutoMapper;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class Service<Tmodel, TDto, TVm> : IService<Tmodel, TDto, TVm> where Tmodel : class
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;
        protected readonly IRepository<Tmodel> _repository;
        public Service(IUnitOfWork unitOfWork, IMapper mapper, IRepository<Tmodel> repository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<List<TVm>> Get()
        {
            var models = await _repository.Get();
            if(models==null|| models.Count<=0)
            {
                return null;
            }
            else
            {
                var vms = _mapper.Map <List <TVm>> (models);
                return vms;
            }
        }

        public async Task<TDto> Get(int Id)
        {
            var model = await _repository.Get(Id);
            if (model == null)
            {
                return default;
            }
            else
            {
                var dto = _mapper.Map<TDto>(model);
                return dto;
            }
        }
        public async Task<TDto> Create(TDto Tdto)
        {
            if(Tdto==null)
            {
                return default;
            }
            var model = _mapper.Map<Tmodel>(Tdto);
            _repository.Create(model);
            var rowsAffected = await _unitOfWork.SaveChanges();
            if(rowsAffected<=0)
            {
                return default;
            }
            var createdDto = _mapper.Map<TDto>(model);
            return createdDto;             
        }
        public async Task<TDto> Update(TDto dto)
        {
            if (dto == null)
            {
                return default;
            }
            var model = _mapper.Map<Tmodel>(dto);
            _repository.Update(model);
            var rowsAffected = await _unitOfWork.SaveChanges();
            if (rowsAffected <= 0)
            {
                return default;
            }
            var updatedDto = _mapper.Map<TDto>(model);
            return updatedDto;
        } 
        public async Task<int> Delete(int Id)
        {
            if(Id<=0)
            {
                return -1;
            }
            var model = await _repository.Get(Id);
            if(model==null)
            {
                return -1;
            }
            else
            {
                _repository.Delete(model);
                var rowsDeleted = await _unitOfWork.SaveChanges();
                return rowsDeleted;
            }
        }
        public async Task<List<TDto>> CreateRange(List<TDto> Tdtos)
        {
            if (Tdtos == null|| Tdtos.Count<=0)
            {
                return null;
            }
            var models = _mapper.Map<List<Tmodel>>(Tdtos);
            _repository.CreateRange(models);
            var rowsAffected = await _unitOfWork.SaveChanges();
            if (rowsAffected <= 0)
            {
                return null;
            }
            var createdDtos = _mapper.Map<List<TDto>>(models);
            return createdDtos;
        }
        public async Task<List<TDto>> UpdateRange(List<TDto> Tdtos)
        {
            if (Tdtos == null || Tdtos.Count <= 0)
            {
                return null;
            }
            var models = _mapper.Map<List<Tmodel>>(Tdtos);
            _repository.UpdateRange(models);
            var rowsAffected = await _unitOfWork.SaveChanges();
            if (rowsAffected <= 0)
            {
                return null;
            }
            var UpdatedDtos = _mapper.Map<List<TDto>>(models); 
            return UpdatedDtos;
        }
        public async Task<int> DeleteRange(List<TDto> Tdtos)
        {
            if (Tdtos == null || Tdtos.Count <= 0)
            {
                return -1;
            }
            var models = _mapper.Map<List<Tmodel>>(Tdtos);
            _repository.DeleteRange(models);
            var rowsDeleted = await _unitOfWork.SaveChanges();
            return rowsDeleted;
        }
          
        
    }
}
