using DisciplinesAPI.Models.DBModels;
using DisciplinesAPI.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DisciplinesAPI.DataAccess
{
    public class LessonRepository : BaseRepository<Lesson>, ILessonRepository
    {
        public LessonRepository(AppDbContext context) 
            : base(context)
        {

        }


    }
}
