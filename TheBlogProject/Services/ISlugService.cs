using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheBlogProject.Services
{
    public interface ISlugService
    {
        public string UrlFriendly(string title);
        public bool IsUnique(string slug);
    }
}
