using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogicLayer.Entities;
using DataAccessLayer;
using DataAccessLayer.Database;

namespace BusinessLogicLayer.Services
{
    public class CategoryService
    {
        public static List<CategoryModel> CategoryList()
        {
            var config = new MapperConfiguration(c => { c.CreateMap<Category, CategoryModel>(); });
            var mapper = new Mapper(config);
            var data = mapper.Map<List<CategoryModel>>(DataAccessFactory.CategoryDataAccess().Get());

            return data;
        }
        public static void Add(CategoryModel e)
        {
            var data = new Mapper(new MapperConfiguration(cfg =>
                cfg.CreateMap<CategoryModel, Category>())).Map<Category>(e);
            DataAccessFactory.CategoryDataAccess().Add(data);
        }
        public static void Edit(CategoryModel e)
        {
            var data = new Mapper(new MapperConfiguration(cfg =>
                cfg.CreateMap<CategoryModel, Category>())).Map<Category>(e);
            DataAccessFactory.CategoryDataAccess().Edit(data);
        }
        public static void Delete(int id)
        {
            DataAccessFactory.CategoryDataAccess().Delete(id);
        }

    }
}
