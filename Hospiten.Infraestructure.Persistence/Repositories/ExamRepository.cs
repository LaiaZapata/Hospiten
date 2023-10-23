﻿using Hospiten.Core.Application.Interface.Repository;
using Hospiten.Core.Domain.Entities;
using Hospiten.Infrastructure.Persistence.Migrations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Hospiten.Infrastructure.Persistence.Contexts.ApplicationContext;

namespace Hospiten.Infrastructure.Persistence.Repository
{
    public class ExamRepository : GenericRepository<Exams>, IExamRepository
    {
        private readonly ApplicationDBContext _dbContext;

        public ExamRepository(ApplicationDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }


    }
}
