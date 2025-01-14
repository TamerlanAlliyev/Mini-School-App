﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using ExamApp.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ExamApp.Application.ViewModels.SchoolClass;

public class SchoolClassVM
{
    public int TeacherId { get; set; }
    public int Class { get; set; }
    public IEnumerable<SelectListItem>? Teachers { get; set; }
    public int? StudentCount { get; set; }
}
