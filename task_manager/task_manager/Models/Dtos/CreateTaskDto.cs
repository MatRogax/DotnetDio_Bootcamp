using System;
using System.Text.Json.Serialization;
using task_manager.Converters;

namespace task_manager.Models.Dtos
{
    public class CreateTaskDto
    {
        [JsonConverter(typeof(TitleCaseStringJsonConverter))]
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Status { get; set; } = default!;
    }
}
