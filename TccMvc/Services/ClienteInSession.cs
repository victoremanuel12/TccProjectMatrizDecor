using TccMvc.Models;
using TccMvc.ViewModel;

namespace TccMvc.Services
{
    public static class ClienteInSession
    {
        public static int GetClienteIdFromSession(HttpContext httpContext)
        {
            var clienteIdStr = httpContext.Session.GetString("UserId");
            return int.Parse(clienteIdStr);
        }
        public static void SetClienteInSession(HttpContext httpContext, Cliente cliente)
        {
            httpContext.Session.SetString("UserId", cliente.Id.ToString());
            httpContext.Session.SetString("EmailUser", cliente.Email);
        }

    }
}
