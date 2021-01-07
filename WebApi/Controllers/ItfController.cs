using Entidades;
using Negocio;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace WebApi.Controllers
{
    [RoutePrefix("api/ITF")]
    public class ItfController : ApiController
    {
        private static string path = ConfigurationManager.AppSettings["uploadFile"];

        [HttpPost]
        [Route("Login")]
        public IHttpActionResult GetLogin(Query q)
        {
            Usuario u = NegocioDao.GetOne(q);

            if (u != null)
            {
                if (u.mensaje == "Pass")
                    return BadRequest("Contraseña Incorrecta");
                else
                    return Ok(u);
            }
            else return BadRequest("Usuario no existe");

        }

        [HttpGet]
        [Route("Perfiles")]
        public IHttpActionResult GetPerfil()
        {
            List<Perfil> p = NegocioDao.GetPerfiles();

            if (p != null)
            {
                return Ok(p);
            }
            else return BadRequest("No hay datos");
        }

        [HttpGet]
        [Route("Monedas")]
        public IHttpActionResult GetMonedas()
        {
            List<Moneda> p = NegocioDao.GetMonedas();

            if (p != null)
            {
                return Ok(p);
            }
            else return BadRequest("No hay datos");
        }

        [HttpGet]
        [Route("Feriados")]
        public IHttpActionResult GetFeriados()
        {
            List<Feriado> p = NegocioDao.GetFeriados();

            if (p != null)
            {
                return Ok(p);
            }
            else return BadRequest("No hay datos");
        }

        [HttpGet]
        [Route("Categorias")]
        public IHttpActionResult GetCategorias()
        {
            List<Categoria> p = NegocioDao.GetCategorias();

            if (p != null)
            {
                return Ok(p);
            }
            else return BadRequest("No hay datos");
        }

        [HttpGet]
        [Route("Especialidades")]
        public IHttpActionResult GetEspecialidades()
        {
            List<Especialidad> p = NegocioDao.GetEspecialidades();

            if (p != null)
            {
                return Ok(p);
            }
            else return BadRequest("No hay datos");
        }

        [HttpGet]
        [Route("Productos")]
        public IHttpActionResult GetProductos()
        {
            List<Producto> p = NegocioDao.GetProductos();

            if (p != null)
            {
                return Ok(p);
            }
            else return BadRequest("No hay datos");
        }

        [HttpGet]
        [Route("Visitas")]
        public IHttpActionResult GetVisitas()
        {
            List<Visita> p = NegocioDao.GetVisitas();

            if (p != null)
            {
                return Ok(p);
            }
            else return BadRequest("No hay datos");
        }

        [HttpGet]
        [Route("TipoProductos")]
        public IHttpActionResult GetTipoProductos()
        {
            List<TipoProducto> p = NegocioDao.GetTipoProductos();

            if (p != null)
            {
                return Ok(p);
            }
            else return BadRequest("No hay datos");

        }

        [HttpGet]
        [Route("Control")]
        public IHttpActionResult GetControls()
        {
            List<Control> p = NegocioDao.GetControl();

            if (p != null)
            {
                return Ok(p);
            }
            else return BadRequest("No hay datos");
        }

        [HttpGet]
        [Route("Personals")]
        public IHttpActionResult GetPersonal()
        {
            List<Personal> p = NegocioDao.GetPersonal();

            if (p != null)
            {
                return Ok(p);
            }
            else return BadRequest("No hay datos");
        }

        [HttpGet]
        [Route("Ciclos")]
        public IHttpActionResult GetCiclos()
        {
            List<Ciclo> p = NegocioDao.GetCiclos();

            if (p != null)
            {
                return Ok(p);
            }
            else return BadRequest("No hay datos");
        }

        [HttpGet]
        [Route("Actividades")]
        public IHttpActionResult GetActividad(int u, int c, int e, int t,int ul)
        {
            List<Actividad> p = NegocioDao.GetActividad(u, c, e, t,ul);

            if (p != null)
            {
                return Ok(p);
            }
            else return BadRequest("No hay datos");
        }

        [HttpGet]
        [Route("Medicos")]
        public IHttpActionResult GetMedicos(int u, string fi, string ff, int e, int t)
        {
            List<SolMedico> p = NegocioDao.GetMedico(u, fi, ff, e, t);

            if (p != null)
            {
                return Ok(p);
            }
            else return BadRequest("No hay datos");
        }

        [HttpGet]
        [Route("Targets")]
        public IHttpActionResult GetTargets(int u, int c, int e, int n, string s)
        {
            List<Target> p = NegocioDao.GetTargets(u, c, e, n, s);

            if (p != null)
            {
                return Ok(p);
            }
            else return BadRequest("No hay datos");
        }

        [HttpGet]
        [Route("TargetsCab")]
        public IHttpActionResult GetTargetsCab(int u, string fi, string ff, int e, string tt, int t,int ul)
        {
            List<TargetCab> p = NegocioDao.GetTargetsCab(u, fi, ff, e, tt, t,ul);

            if (p != null)
            {
                return Ok(p);
            }
            else return BadRequest("No hay datos");
        }

        [HttpGet]
        [Route("Programacion")]
        public IHttpActionResult GetProgramacion(int u, int c)
        {
            List<Programacion> p = NegocioDao.GetProgramacion(u, c);
            if (p != null)
            {
                return Ok(p);
            }
            else return BadRequest("No hay datos");
        }

        [HttpGet]
        [Route("NuevaDireccion")]
        public IHttpActionResult GetNuevaVisita(int u, string fi, string ff, int e, int t)
        {
            List<NuevaDireccion> p = NegocioDao.GetNuevaDireccion(u, fi, ff, e, t);
            if (p != null)
            {
                return Ok(p);
            }
            else return BadRequest("No hay datos");
        }

        [HttpGet]
        [Route("Stock")]
        public IHttpActionResult GetStock(int u)
        {
            List<Stock> p = NegocioDao.GetStocks(u);
            if (p != null)
            {
                return Ok(p);
            }
            else return BadRequest("No hay datos");
        }

        [HttpGet]
        [Route("StockMantenimiento")]
        public IHttpActionResult GetStockMantenimiento(int u, int c)
        {
            List<StockMantenimiento> p = NegocioDao.GetStockMantenimientos(u, c);
            if (p != null)
            {
                return Ok(p);
            }
            else return BadRequest("No hay datos");
        }

        [HttpGet]
        [Route("Sync")]
        public IHttpActionResult Sync(int usuarioId)
        {
            Sync p = NegocioDao.GetSync(usuarioId);
            if (p != null)
                return Ok(p);
            else return BadRequest("No hay datos");
        }

        [HttpGet]
        [Route("ProgramacionPerfil")]
        public IHttpActionResult GetProgramacionPerfil(int m)
        {
            List<ProgramacionPerfil> p = NegocioDao.GetProgramacionPerfil(m);
            if (p != null)
                return Ok(p);
            else return BadRequest("No hay datos");
        }

        [HttpGet]
        [Route("ProgramacionPerfilDetalle")]
        public IHttpActionResult GetProgramacionPerfilDetalle(int m, string p)
        {
            List<ProgramacionPerfilDetalle> d = NegocioDao.GetProgramacionPerfilDetalle(m, p);
            if (d != null)
                return Ok(d);
            else return BadRequest("No hay datos");
        }

        [HttpGet]
        [Route("ProgramacionReja")]
        public IHttpActionResult GetProgramacionReja(int e)
        {
            List<ProgramacionReja> p = NegocioDao.GetProgramacionReja(e);
            if (p != null)
                return Ok(p);
            else return BadRequest("No hay datos");
        }

        [HttpGet]
        [Route("PuntoContacto")]
        public IHttpActionResult GetPuntoContacto(int u, string fi, string ff)
        {
            List<PuntoContacto> p = NegocioDao.GetPuntoContactos(u, fi, ff);
            if (p != null)
                return Ok(p);
            else return BadRequest("No hay datos");
        }


        [HttpGet]
        [Route("AlertaActividad")]
        public IHttpActionResult GetAlertaActividad(int c, int m, int u)
        {
            Mensaje p = NegocioDao.GetAlertaActividades(c, m, u);
            if (p != null)
                return Ok(p);
            else return BadRequest("No hay datos");
        }

        [HttpGet]
        [Route("BirthDay")]
        public IHttpActionResult GetBirthDay(int u, int m)
        {
            List<BirthDay> b = NegocioDao.GetBirthDay(u,m);
            if (b != null)
                return Ok(b);
            else return BadRequest("No hay datos");
        }



        // insert

        [HttpPost]
        [Route("SavePerfil")]
        public IHttpActionResult SavePerfil(Perfil p)
        {
            Mensaje m = NegocioDao.SavePerfil(p);

            if (m != null)
            {
                return Ok(m);
            }
            else return BadRequest("Error");
        }

        [HttpPost]
        [Route("SaveMoneda")]
        public IHttpActionResult SaveMoneda(Moneda p)
        {
            Mensaje m = NegocioDao.SaveMoneda(p);

            if (m != null)
            {
                return Ok(m);
            }
            else return BadRequest("Error");
        }

        [HttpPost]
        [Route("SaveFeriado")]
        public IHttpActionResult SaveFeriado(Feriado p)
        {
            Mensaje m = NegocioDao.SaveFeriado(p);

            if (m != null)
            {
                return Ok(m);
            }
            else return BadRequest("Error");
        }

        [HttpPost]
        [Route("SaveCategoria")]
        public IHttpActionResult SaveCategoria(Categoria p)
        {
            Mensaje m = NegocioDao.SaveCategoria(p);

            if (m != null)
            {
                return Ok(m);
            }
            else return BadRequest("Error");
        }

        [HttpPost]
        [Route("SaveEspecialidades")]
        public IHttpActionResult SaveEspecialidades(Especialidad p)
        {
            Mensaje m = NegocioDao.SaveEspecialidades(p);

            if (m != null)
            {
                return Ok(m);
            }
            else return BadRequest("Error");
        }

        [HttpPost]
        [Route("SaveProductos")]
        public IHttpActionResult SaveProductos(Producto p)
        {
            Mensaje m = NegocioDao.SaveProductos(p);

            if (m != null)
            {
                return Ok(m);
            }
            else return BadRequest("Error");
        }

        [HttpPost]
        [Route("SaveVisita")]
        public IHttpActionResult SaveVisita(Visita p)
        {
            Mensaje m = NegocioDao.SaveVisita(p);

            if (m != null)
            {
                return Ok(m);
            }
            else return BadRequest("Error");
        }

        [HttpPost]
        [Route("SaveTipoProducto")]
        public IHttpActionResult SaveTipoProducto(TipoProducto p)
        {
            Mensaje m = NegocioDao.SaveTipoProducto(p);

            if (m != null)
            {
                return Ok(m);
            }
            else return BadRequest("Error");
        }

        [HttpPost]
        [Route("SaveUsuario")]
        public IHttpActionResult SaveUsuario(Personal u)
        {
            if (u.personalId == 0)
            {
                Mensaje m = NegocioDao.VerificateLogin(u.login);
                if (m != null)
                {
                    Mensaje e = NegocioDao.SaveUsuario(u);
                    if (e != null)
                    {
                        return Ok(e);
                    }
                    else return BadRequest("Error");

                }
                else return BadRequest("Usuario Existe");
            }
            else
            {
                Mensaje e = NegocioDao.SaveUsuario(u);
                if (e != null)
                {
                    return Ok(e);
                }
                else return BadRequest("Error");
            }

        }

        [HttpPost]
        [Route("SaveCiclo")]
        public IHttpActionResult SaveCiclo(Ciclo c)
        {
            Mensaje e = NegocioDao.SaveCiclo(c);
            if (e != null)
            {
                return Ok(e);
            }
            else return BadRequest("Error");
        }

        [HttpPost]
        [Route("SaveActividad")]
        public async Task<IHttpActionResult> SaveActividad(Actividad a)
        {
            Mensaje e = NegocioDao.SaveActividad(a);
            if (e != null)
            {
                var estado = (a.estado == 9) ? "A" : "B";
                Email m = NegocioDao.GetEmail(e.codigoRetorno, a.usuarioId, a.tipo, estado);
                if (m != null)
                {
                    await Email(m);
                }
                return Ok(e);
            }
            else return BadRequest("Error");
        }

        [HttpPost]
        [Route("SaveMedico")]
        public async Task<IHttpActionResult> SaveMedico(SolMedico a)
        {
            Mensaje e = NegocioDao.SaveMedico(a);
            if (e != null)
            {
                var tipo = (a.tipo == 1) ? 3 : 4;
                Email m = NegocioDao.GetEmail(e.codigoRetorno, a.usuarioId, tipo, "");
                if (m != null)
                {
                    await Email(m);
                }
                return Ok(e);
            }
            else return BadRequest("Error");
        }

        [HttpPost]
        [Route("SaveMedicoCabecera")]
        public IHttpActionResult SaveMedicoCabecera(Medico a)
        {
            Mensaje e = NegocioDao.SaveMedicoCabecera(a);
            if (e != null)
            {
                if (e.codigoRetorno == 0)
                {
                    return BadRequest(e.mensaje);
                }
                else return Ok(e);
            }
            else return BadRequest("Error");
        }

        [HttpPost]
        [Route("SaveMedicoDireccion")]
        public IHttpActionResult SaveMedicoDireccion(MedicoDireccion a)
        {
            Mensaje e = NegocioDao.SaveMedicoDireccion(a);
            if (e != null)
            {
                return Ok(e);
            }
            else return BadRequest("Error");
        }

        [HttpPost]
        [Route("SaveProgramacion")]
        public IHttpActionResult SaveProgramacion(Programacion p)
        {
            Mensaje e = NegocioDao.SaveProgramacion(p);
            if (e != null)
            {
                return Ok(e);
            }
            else return BadRequest("Error");
        }

        [HttpPost]
        [Route("SaveProgramacionDet")]
        public IHttpActionResult SaveProgramacionDet(ProgramacionDet p)
        {
            Mensaje e = NegocioDao.SaveProgramacionDet(p);
            if (e != null)
            {
                return Ok(e);
            }
            else return BadRequest("Error");
        }

        [HttpPost]
        [Route("DeleteProgramacionDet")]
        public IHttpActionResult DeleteProgramacionDet(int id)
        {
            Mensaje e = NegocioDao.DeleteProgramacionDet(id);
            if (e != null)
            {
                return Ok(e);
            }
            else return BadRequest("Error");
        }

        [HttpPost]
        [Route("SaveNuevaDireccion")]
        public async Task<IHttpActionResult> SaveNuevaDireccion(NuevaDireccion n)
        {
            Mensaje e = NegocioDao.SaveNuevaDireccion(n);
            if (e != null)
            {
                var tipo = (n.tipo == 1) ? 5 : 6;
                Email m = NegocioDao.GetEmail(e.codigoRetorno, n.usuarioId, tipo, "");
                if (m != null)
                {
                    await Email(m);
                }
                return Ok(e);
            }
            else return BadRequest("Error");
        }

        [HttpPost]
        [Route("SaveTarget")]
        public async Task<IHttpActionResult> SaveTarget(TargetCab a)
        {
            Mensaje e = NegocioDao.SaveTargetAltaBaja(a);
            if (e != null)
            {
                var tipo = (a.tipo == 1) ? 7 : 8;
                Email m = NegocioDao.GetEmail(e.codigoRetorno, a.usuarioId, tipo, a.tipoTarget);
                if (m != null)
                {
                    await Email(m);
                }
                return Ok(e);
            }
            else return BadRequest("Error");
        }

        [HttpPost]
        [Route("SavePuntoContacto")]
        public IHttpActionResult SavePuntoContacto(PuntoContacto p)
        {
            Mensaje e = NegocioDao.SavePuntoContacto(p);
            if (e != null)
            {
                return Ok(e);
            }
            else return BadRequest("Error");
        }

        [HttpPost]
        [Route("UpdateUsuario")]
        public IHttpActionResult UpdateUsuario()
        {
            try
            {
                //string path = HttpContext.Current.Server.MapPath("~/Imagen/");
                var files = HttpContext.Current.Request.Files;
                var testValue = HttpContext.Current.Request.Form["data"];
                Usuario u = JsonConvert.DeserializeObject<Usuario>(testValue);
                Mensaje m = NegocioDao.UpdateUsuario(u);
                if (u != null)
                {
                    for (int i = 0; i < files.Count; i++)
                    {
                        string fileName = Path.GetFileName(files[i].FileName);
                        files[i].SaveAs(path + fileName);
                    }

                    return Ok(m);
                }
                else
                    return BadRequest("Error");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task Email(Email e)
        {
            try
            {
                var message = new MailMessage();
                message.To.Add(new MailAddress(e.destinatario));
                //var to = "irvin.dsige@gmail.com";
                //foreach (var curr_address in to.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries))
                //{
                //    message.To.Add(new MailAddress(curr_address));
                //}
                message.From = new MailAddress(e.remitente);
                message.Subject = e.asunto;
                message.Body = e.cuerpoMensaje;
                message.IsBodyHtml = true;
                message.Priority = MailPriority.Normal;
                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential(e.remitente, e.remitentePass);
                    smtp.Credentials = credential;
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(message);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //verificaciones
        [HttpGet]
        [Route("GetVerificateVisitaMedico")]
        public IHttpActionResult GetRRMMGeneral(int m, string f)
        {
            Mensaje g = NegocioDao.GetVerificateVisitaMedico(m, f);
            if (g != null)
            {
                return Ok(g);
            }
            else return BadRequest("No hay datos");
        }


        // reporte
        [HttpGet]
        [Route("GetRRMMGeneral")]
        public IHttpActionResult GetRRMMGeneral(int c, int u)
        {
            List<RptGeneral> g = NegocioDao.Rpt_RRMM_RESUMEN_GENERAL(c, u);
            if (g != null)
            {
                return Ok(g);
            }
            else return BadRequest("No hay datos");
        }

        [HttpGet]
        [Route("GetRRMMDiario")]
        public IHttpActionResult GetRRMMDiario(int c, int u)
        {
            List<RptDiario> g = NegocioDao.Rpt_RRMM_RESUMEN_DIARIO(c, u);
            if (g != null)
            {
                return Ok(g);
            }
            else return BadRequest("No hay datos");
        }

        [HttpGet]
        [Route("GetSUPGeneral")]
        public IHttpActionResult GetSUPGeneral(int c, int u)
        {
            List<RptGeneral> g = NegocioDao.Rpt_SUP_RESUMEN_GENERAL(c, u);
            if (g != null)
            {
                return Ok(g);
            }
            else return BadRequest("No hay datos");
        }

        [HttpGet]
        [Route("GetSUPDiario")]
        public IHttpActionResult GetSUPDiario(int c, int u)
        {
            List<RptDiario> g = NegocioDao.Rpt_SUP_RESUMEN_DIARIO(c, u);
            if (g != null)
            {
                return Ok(g);
            }
            else return BadRequest("No hay datos");
        }
    }
}
