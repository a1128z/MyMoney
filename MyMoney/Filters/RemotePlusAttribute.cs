using System.Web.Mvc;

namespace MyMoney.Filters
{
    public class RemotePlusAttribute : RemoteAttribute
    {
        public RemotePlusAttribute(string action, string controller, string area)
            : base(action, controller, area)
        {
            this.RouteData["area"] = area;
        }
    }
}