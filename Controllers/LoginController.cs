using EstudiantesAPP.Persistencia.Context;
using EstudiantesAPP.Transporte;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace EstudiantesAPP.Controllers
{
    public class LoginController : Controller
    {
        private readonly AplicationDBContext _context;

        public LoginController(AplicationDBContext context)
        {
            _context = context;
        }

        public IActionResult Enter()
        {
            ClaimsPrincipal c = HttpContext.User;
            if (c.Identity != null)
            {
                if (c.Identity.IsAuthenticated)
                {
                    return RedirectToAction("Index", "Estudiante");
                }
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Enter(AccesoDTO u)
        {
            try
            {
                var acceso = await (from t in _context.Acceso
                                    where t.Email == u.Email && t.Password == u.Password
                                    select t).FirstOrDefaultAsync();
                if (acceso != null)
                {
                    if (u.Email != null && u.Password != null)
                    {
                        List<Claim> c = new List<Claim>()
                                {
                                    new Claim(ClaimTypes.NameIdentifier, u.Email)
                                };
                        ClaimsIdentity ci = new(c, CookieAuthenticationDefaults.AuthenticationScheme);
                        AuthenticationProperties p = new();

                        p.AllowRefresh = true;
                        p.IsPersistent = u.MantenerActivo;

                        if (!u.MantenerActivo)
                            p.ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(5);
                        else
                            p.ExpiresUtc = DateTimeOffset.UtcNow.AddDays(1);

                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(ci), p);
                        return RedirectToAction("Index", "Estudiante");
                    }
                }
                else
                {
                    ViewBag.Error = "Datos incorrectos por favor verifique sus datos";
                }

                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        public async Task<IActionResult> Enter2(AccesoDTO u)
        {
            try
            {
                var acceso = await (from t in _context.Acceso
                                        where t.Email == u.Email && t.Password== u.Password
                                        select t).FirstOrDefaultAsync();
                if (acceso != null)
                {
                    if (u.Email!=null && u.Password!=null)
                    {
                        List<Claim> c = new List<Claim>()
                                {
                                    new Claim(ClaimTypes.NameIdentifier, u.Email)
                                };
                        ClaimsIdentity ci = new(c, CookieAuthenticationDefaults.AuthenticationScheme);
                        AuthenticationProperties p = new();

                        p.AllowRefresh = true;
                        p.IsPersistent = u.MantenerActivo;

                        if (!u.MantenerActivo)
                            p.ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(1);
                        else
                            p.ExpiresUtc = DateTimeOffset.UtcNow.AddDays(1);

                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(ci), p);
                        return RedirectToAction("Index", "Estudiante");
                    }
                }
                else
                {
                    ViewBag.Error = "Cuenta no registrada o datos incorrectos";
                }

                return View();
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
