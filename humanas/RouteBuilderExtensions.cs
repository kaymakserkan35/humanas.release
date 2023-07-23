namespace ui
{
    public static class RouteBuilderExtensions
    {


        public static void RegisterMyRoutes(this IEndpointRouteBuilder routes)
        {

            /*------------------------------------------------------------------*/
            routes.MapControllerRoute(
               name: "default",
               pattern: "{controller=Auth}/{action=Auth}/{*rest...}");


            routes.MapControllerRoute(
            name: "Auth_Login",
            pattern: "{controller=Auth}/{action=Login}/{*rest...}");
            /*-------------------------------------------------------------------------*/
            /*-------------------------------------------------------------------------*/
            routes.MapControllerRoute(
             name: "default",
             pattern: "{controller=Home}/{action=Search}/{id?}");
            /*-------------------------------------------------------------------------*/


        }
    }
}
