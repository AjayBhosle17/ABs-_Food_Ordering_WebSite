﻿using AutoMapper;
using Data.Entities;
using DTO;
using InfraStructure.Interface;
using Service.Interface;

namespace Service.Implementation
{
    public class ProductService :IProductService
    {
        IProductRepository _repo;
        IMapper _mapper;

        public ProductService(IProductRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public void Create(ProductModel model)
        {
            var product = _mapper.Map<Product>(model);
            _repo.Create(product);
        }

        public void Delete(int? id)
        {
            _repo.Delete(id);
        }

        public void Edit(ProductModel model)
        {
            _repo.Edit(_mapper.Map<Product>(model));
        }

        public List<ProductModel> GetAll()
        {
            var productsModel = _mapper.Map<List<ProductModel>>(_repo.GetAll());

            return productsModel;
        }

        public ProductModel GetById(int? id)
        {
            return _mapper.Map<ProductModel>(_repo.GetById(id));
        }
    }
}
