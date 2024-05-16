using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace programApplicationMngr.Core.Models
{
    public class Applications
    {
        [JsonProperty("id")]
        public string id { get; set; }
        [JsonProperty("ProgramId")]
        public string ProgramId { get; set; }
        [JsonProperty("ApplicantionId")]
        public string ApplicantionId { get; set; }
        [JsonProperty("FirstName")]
        public string FirstName { get; set; }
        [JsonProperty("LastName")]
        public string LastName { get; set; }
        [JsonProperty("Email")]
        public string Email { get; set; }
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
        [JsonProperty("CustomQuestions")]
        public List<CustomQuestions> CustomQuestions { get; set; }
    
    }

    public class CustomQuestions
    {
        [JsonProperty("Question")]
        public string Question { get; set; }
        [JsonProperty("Answer")]
        public string Answer { get; set; }
    }
}
