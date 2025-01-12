﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamApp.Application.ViewModels.Exam;
using ExamApp.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ExamApp.Application.Services;

public interface IExamService
{
    Task<List<Exam>> GetAllExamAsync();

    Task CreateExamAsync(ExamCreateVM vm);
    Task<IEnumerable<SelectListItem>> GetSelectionLessonAsync();
    Task DeleteExamAsync(int id);
}
