using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizDickTionary.Domain.Dtos
{
    public class VersionDto
    {
        [Key]
        public int Id { get; set; }
        public string Version { get; set; }
        public string Comment { get; set; }
    }
}
