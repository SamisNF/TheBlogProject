using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TheBlogProject.Models
{
    public class Blog
    {
        //Id number for the Blog
        
        public int Id { get; set; }
        //Id number for the Author
        public string BlogUserId { get; set; }

        //Name of the Blog
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at {2} and at most {1} characters long.", MinimumLength = 2)]
        public string Name { get; set; }
        //Description of the Blog
        [Required]
        [StringLength(500, ErrorMessage = "The {0} must be at {2} and at most {1} characters long.", MinimumLength = 2)]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Created Date")]
        public DateTime Created { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Updated Date")]
        public DateTime? Updated { get; set; }

        //Thumbnail and Header image for the Blog
        [Display(Name = "Blog Image")]
        public byte[] ImageData { get; set; }
        //Type of image file (i.e. file extension)
        [Display(Name = "Image Image")]
        public string ContentType { get; set; }

        //The image file that will be converted to byte[] data
        [NotMapped]
        public IFormFile Image { get; set; }

        //Navigation Properties
        //IdentityUser is a parent of Blog
        public virtual BlogUser BlogUser { get; set; }
        //Post is a child of Blog
        public virtual ICollection<Post> Posts { get; set; } = new HashSet<Post>();

    }
}
