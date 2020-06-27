using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using AutoMapper;
using Domain;
using WebAPI.Models;

namespace WebAPI.Repository
{
    public class EntityMapper<TSource, TDestination> where TSource : class
    {
        public EntityMapper()
        {
            Mapper.CreateMap<StudentModel, Student>();
            Mapper.CreateMap<Student, StudentModel>();
        }

        public TDestination Translate(TSource obj)
        {
            return Mapper.Map<TDestination>(obj);
        }
    }
}