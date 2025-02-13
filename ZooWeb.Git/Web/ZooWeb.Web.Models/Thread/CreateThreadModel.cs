using ZooWeb.Web.Models.Utilities.Binding;
using Microsoft.AspNetCore.Mvc;

namespace ZooWeb.Web.Models.Thread
{
    public class CreateThreadModel
    {
        public string CommunityId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        [BindProperty(BinderType = typeof(TagsModelBinder))]
        public List<string> Tags { get; set; }
    }
}