using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using NewsTagsApp.Models;
using NewsTagsApp.ViewModels;

namespace NewsTagsApp.App_Start
{
    public class MapperProfile: Profile
    {
        public MapperProfile() 
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<News, NewsTagsViewModel>();
                cfg.CreateMap<Tags, NewsTagsViewModel>();
            });
        }
    }
}