using System;
using StudentSystem.Models.Enums;

namespace StudentSystem.Models
{
    public class Resource
    {
        public Guid ResourceId { get; set; }
        public Guid CourseId { get; set; }
        public string Name { get; set; }
        public ResourceType ResourceType { get; set; }
        public string Url { get; set; }
    }
}