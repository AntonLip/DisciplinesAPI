using DisciplinesAPI.DataAccess;
using DisciplinesAPI.Models.Interfaces;
using DisciplinesAPI.Models.Interfaces.Repository;
using DisciplinesAPI.Models.Interfaces.Services;
using DisciplinesAPI.Services;
using Microsoft.Extensions.DependencyInjection;


namespace DisciplinesAPI
{
    public static class IServiceCollectionExtensions
    {
        public static void AddDisciplinesTransient(this IServiceCollection services)
        {
            services.AddTransient<IDisciplinesRepository, DisciplinesRepository>();
            services.AddTransient<IDisciplinesService, DisciplinesService>();
        }

        public static void AddLessonTypeTransient(this IServiceCollection services)
        {
            services.AddTransient<ILessonTypeRepository, LessonTypeRepository>();
            services.AddTransient<ILessonTypeService, LessonTypeService>();
        }

        public static void AddLessonTransient(this IServiceCollection services)
        {
            services.AddTransient<ILessonRepository, LessonRepository>();
            services.AddTransient<ILessonService, LessonService>();
        }
    }
}

