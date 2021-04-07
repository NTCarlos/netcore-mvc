using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Services.DTO
{
    public class SettingDto
    {
        public int? Id { get; set; }

        [Required]
        //[Remote(action:"Duplicated", controller:"Setting", ErrorMessage = "The key already exist")]
        public string Key { get; set; }
        
        [Required]
        public string Value { get; set; }
    }
}
