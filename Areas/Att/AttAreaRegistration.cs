using System.Web.Mvc;

namespace AlphaTechMIS.Areas.Att
{
    public class AttAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Att";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Att_default",
                "Att/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}