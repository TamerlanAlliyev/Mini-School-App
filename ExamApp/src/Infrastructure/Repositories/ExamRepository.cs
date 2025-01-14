﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamApp.Application.Repositories;
using ExamApp.Application.ViewModels.ExamResul;
using ExamApp.Domain.Entities;
using Infrastructure.Persistance;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ExamApp.Infrastructure.Repositories;

public class ExamRepository : BaseRepository<Exam>, IExamRepository
{
    private readonly ApplicationDbContext _context;

    public ExamRepository(ApplicationDbContext context):base(context)
    {
        _context = context;
    }

    public async Task<List<Exam>> GetAllIncludeAsync()
    {
        return await _context.Exams.Include(x=>x.Lesson)
                                   .ThenInclude(x=>x.SchoolClass)
                                   .ThenInclude(x=>x.Students)
                                   .Include(x=>x.Lesson.SchoolClass.Teacher)
                                   .ToListAsync();
    }

    public async Task<Exam?> GetIncludeAsync(int id)
    {
        return await _context.Exams.Include(x => x.Lesson)
                                   .ThenInclude(x => x.SchoolClass)
                                   .ThenInclude(x => x.Students)
                                   .Include(x => x.Lesson.SchoolClass.Teacher)
                                              .Include(x => x.ExamResult)
                                   .ThenInclude(x => x.Student)
                                   .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<SelectListItem>> SelectionLessonAsync()
    {
        return await _context.Lessons.Select(t => new SelectListItem
        {
            Value = t.Id.ToString(),
            Text = t.LessonCode.ToString()
        }).ToListAsync();
    }


    public async Task CreateRangeAsync(List<ExamResult> entity)
    {
        await _context.AddRangeAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateExam()
    {
        //_context.Exams.Update(exam);
        await _context.SaveChangesAsync();
    }


}
