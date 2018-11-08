using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebCore.Test.Models
{
    public class User
    {
        [Display(Name = "名称")]
        [Required(ErrorMessage = "{0}是必须的")]
        public string Name { set; get; }
        public DateTime? Ts { set; get; } = DateTime.Now;
    }
}
