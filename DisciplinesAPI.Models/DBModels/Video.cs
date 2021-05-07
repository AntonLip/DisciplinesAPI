using System;
using System.Collections.Generic;
using System.Text;

namespace DisciplinesAPI.Models.DBModels
{
    public class Video
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public VideoCourses VideoCourses { get; set; }
    }
}
