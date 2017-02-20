using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyUrl.Models
{
    public class TinyUrlMap
    {
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// The short string appended to url to map to real url in db
        /// </summary>
        [Display(Name ="Tiny Url")]
        public string UrlToken { get; set; }

        [Display(Name ="Original Url")]
        [Required(ErrorMessage = "Required Field")]
        [Url(ErrorMessage = "Please enter a valid url")]
     
        public string OriginalUrl { get; set; }
     

    }
}
