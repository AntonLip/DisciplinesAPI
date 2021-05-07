using System;

namespace DisciplinesAPI.Models.DBModels
{
    public class VideoCourses
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }


        public Video Video { get; set; }
    }
}
