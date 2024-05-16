using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace programApplicationMngr.Core.Models
{
    public class QuestionTypes
    {
        [JsonProperty("id")]
        public string id { get; set; }
        [JsonProperty("QuestionTypeId")]
        public string QuestionTypeId { get; set; }
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("Value")]
        public string Value { get; set; }
    }
}
