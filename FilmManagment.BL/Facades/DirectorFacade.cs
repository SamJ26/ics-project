﻿using FilmManagment.DAL.Entities;
using FilmManagment.DAL.Factories;
using FilmManagment.DAL.UnitOfWork;
using FilmManagment.BL.Models.DetailModels;
using FilmManagment.BL.Models.ListModels;
using FilmManagment.BL.Repositories;
using FilmManagment.BL.Mappers;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;

namespace FilmManagment.BL.Facades
{
    public class DirectorFacade : CrudFacadeBase<DirectorEntity, DirectorListModel, DirectorDetailModel>
    {
        public DirectorFacade(UnitOfWork aUnitOfWork,
                              RepositoryBase<DirectorEntity> aRepository,
                              IMapper<DirectorEntity, DirectorListModel, DirectorDetailModel> aMapper,
                              IEntityFactory aEntityFactory)
                              : base(aUnitOfWork, aRepository, aMapper, aEntityFactory)
        {
        }

        protected override Func<IQueryable<DirectorEntity>, IIncludableQueryable<DirectorEntity, object>>[] Includes
        {
            get;
        } = new Func<IQueryable<DirectorEntity>, IIncludableQueryable<DirectorEntity, object>>[]
        {
            entities => entities.Include(i => i.DirectedMovies)
        };
    }
}