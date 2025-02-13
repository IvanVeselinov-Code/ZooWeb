using ZooWeb.Service.Community;
using ZooWeb.Service.Models;
using ZooWeb.Service.Thread;
using ZooWeb.Web.Models.Comment;
using ZooWeb.Web.Models.Community;
using ZooWeb.Web.Models.Thread;
using Microsoft.AspNetCore.Mvc;

namespace ZooWeb.Web.Controllers
{
    public class ThreadController : Controller
    {
        private readonly IZooWebCommunityService _ZooWebCommunityService;

        private readonly IZooWebThreadService _ZooWebThreadService;

        public ThreadController(IZooWebCommunityService ZooWebCommunityService, IZooWebThreadService ZooWebThreadService)
        {
            _ZooWebCommunityService = ZooWebCommunityService;
            _ZooWebThreadService = ZooWebThreadService;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            this.ViewData["Communities"] = this._ZooWebCommunityService.GetAll().ToList();

            return View("~/Views/Shared/ThreadCommunityCreate.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> CreateConfirm(CreateThreadModel createThreadModel)
        {
            await this._ZooWebThreadService.CreateAsync(new ZooWebThreadServiceModel
            {
                Title = createThreadModel.Title,
                Content = createThreadModel.Content,
                Tags = createThreadModel.Tags.Select(tag => new ZooWebTagServiceModel { Label = tag }).ToList(),
                Community = new ZooWebCommunityServiceModel
                {
                    Id = createThreadModel.CommunityId
                }
            });

            // TODO: Redirect to Thread Page
            return Redirect("/");
        }

        [HttpGet]
        public async Task<IActionResult> Details(string threadId)
        {
            ZooWebThreadServiceModel thread = await this._ZooWebThreadService.GetByIdAsync(threadId);

            if(thread == null)
            {
                return NotFound("Thread not found...");
            }

            return View(thread);
        }

        [HttpPost]
        [Consumes("application/json")]
        public async Task<IActionResult> Comment(
            [FromBody] CreateCommentModel model,
            [FromQuery] string threadId,
            [FromQuery] string? parentId = null)
        {
            var result = await this._ZooWebThreadService.CreateCommentOnThread(new CommentServiceModel
            {
                Content = model.Content,
                //Attachments
            }, threadId, parentId);

            return Ok(result);
        }
    }
}
