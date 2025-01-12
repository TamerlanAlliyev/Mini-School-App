﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamApp.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ExamApp.Application.Repositories;

public interface IExamRepository : IBaseRepository<Exam>
{
    Task<IEnumerable<SelectListItem>> SelectionLessonAsync();
    Task<List<Exam>> GetAllIncludeAsync();

}
