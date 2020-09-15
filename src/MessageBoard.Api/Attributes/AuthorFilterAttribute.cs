using Microsoft.AspNetCore.Mvc.Filters;

namespace MessageBoard.Api.Attributes
{
    public sealed class AuthorFilterAttribute : ActionFilterAttribute
    {
        private readonly AuthorHelper _authorHelper;

        public AuthorFilterAttribute(AuthorHelper authorHelper)
        {
            _authorHelper = authorHelper;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            _authorHelper.RequesterIp = context.HttpContext.Connection.RemoteIpAddress.ToString();
            base.OnActionExecuting(context);
        }
    }
}
