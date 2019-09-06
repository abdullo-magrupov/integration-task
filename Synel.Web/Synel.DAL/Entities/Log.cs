using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synel.DAL.Entities
{
    [Table("Logs")]
    public partial class Log
    {
        [Key]
        public int Id { get; set; }
        public string Level { get; set; }

        [DisplayName("Date")]
        public DateTime LogDate { get; set; }
        public string Logger { get; set; }
        public string RequestIP { get; set; }

        [DisplayName("Controller")]
        public string ControllerName { get; set; }

        [DisplayName("Action")]
        public string ActionName { get; set; }

        [DisplayName("Request Type")]
        public string RequestType { get; set; }
        public string Message { get; set; }
    }
}
