using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace programApplicationMngr.Core.Models
{
    public class Programs
    {
        [JsonProperty("id")]
        public string id { get; set; }
        [JsonProperty("ProgramId")]
        public string ProgramId { get; set; }
        [JsonProperty("Title")]
        public string Title { get; set; } = "Mandatory Field";
        [JsonProperty("Description")]
        public string Description { get; set; } = "Mandatory Field";
        [JsonProperty("FirstName")]
        public string FirstName { get; set; } = "Mandatory Field";
        [JsonProperty("LastName")]
        public string LastName { get; set; } = "Mandatory Field";
        [JsonProperty("Email")]
        public string Email { get; set; } = "Mandatory Field";
        [JsonProperty("Phone")]
        public string Phone { get; set; }
        [JsonProperty("Nationality")]
        public string Nationality { get; set; }
        [JsonProperty("CurrentResidence")]
        public string CurrentResidence { get; set; }
        [JsonProperty("IdNumber")]
        public string IdNumber { get; set; }
        [JsonProperty("DOB")]
        public string DOB { get; set; }
        [JsonProperty("Gender")]
        public string Gender { get; set; }    
        [JsonProperty("Questions")]
        public List<Questions> Questions { get; set; }
    }

    public class Questions
    {
        [JsonProperty("QuestionType")]
        public string QuestionType { get; set; }
        [JsonProperty("Question")]
        public string Question { get; set; }
        [JsonProperty("Options")]
        public string[]? Options { get; set; }
    }
}
