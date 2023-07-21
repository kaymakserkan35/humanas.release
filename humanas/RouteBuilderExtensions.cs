namespace ui
{
    public static class RouteBuilderExtensions
    {


        public static void RegisterMyRoutes(this IEndpointRouteBuilder routes)
        {

            /*------------------------------------------------------------------*/
            routes.MapControllerRoute(
               name: "default",
               pattern: "{controller=Auth}/{action=Auth}/{id?}");
            /*-------------------------------------------------------------------------*/
            routes.MapControllerRoute(
              name: "Auth_Auth",
              pattern: "{controller=Home}/{action=Index}/{id?}");
            /*-------------------------------------------------------------------------*/
            routes.MapControllerRoute(
             name: "default",
             pattern: "{controller=Home}/{action=Search}/{id?}");
            /*-------------------------------------------------------------------------*/
           

        }
    }
}
