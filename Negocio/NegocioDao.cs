using Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Negocio
{
    public class NegocioDao
    {
        private static string db = ConfigurationManager.ConnectionStrings["conexionItf"].ConnectionString;

        public static Usuario GetOne(Query q)
        {
            try
            {
                Usuario u = null;
                using (SqlConnection cn = new SqlConnection(db))
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_PROY_M_LOGIN", cn))
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@USUARIO", SqlDbType.VarChar).Value = q.login;

                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            u = new Usuario();
                            if (q.pass == dr.GetString(14))
                            {
                                u.usuarioId = dr.GetInt32(0);
                                u.nroDoc = dr.GetString(1);
                                u.email = dr.GetString(2);
                                u.perfilId = dr.GetInt32(3);
                                u.apellidoP = dr.GetString(4);
                                u.apellidoM = dr.GetString(5);
                                u.nombre = dr.GetString(6);
                                u.celular = dr.GetString(7);
                                u.fechaNacimiento = dr.GetDateTime(8).ToString("dd/MM/yyyy");
                                u.sexo = dr.GetString(9);
                                u.supervisorId = dr.GetInt32(10);
                                u.esSupervisorId = dr.GetInt32(11);
                                u.estado = dr.GetInt32(12);
                                u.foto = dr.GetString(13);
                                u.pass = dr.GetString(14);
                                u.login = dr.GetString(15);
                                u.mensaje = "Go";
                                u.nombreSupervisor = dr.GetString(16);
                                u.nombreEstado = dr.GetString(17);
                                u.nombrePerfil = dr.GetString(18);

                                // Accesos
                                SqlCommand cmdA = cn.CreateCommand();
                                cmdA.CommandTimeout = 0;
                                cmdA.CommandType = CommandType.StoredProcedure;
                                cmdA.CommandText = "SP_PROY_M_LISTA_ACCESOS_MENU";
                                cmdA.Parameters.Add("@id_Usuario", SqlDbType.Int).Value = u.usuarioId;
                                SqlDataReader drV = cmdA.ExecuteReader();
                                if (drV.HasRows)
                                {
                                    List<Accesos> a = new List<Accesos>();
                                    while (drV.Read())
                                    {
                                        a.Add(new Accesos()
                                        {
                                            opcionId = drV.GetInt32(0),
                                            nombre = drV.GetString(1),
                                            tipo = drV.GetInt32(2),
                                            usuarioId = u.usuarioId
                                        });
                                    }
                                    u.accesos = a;
                                }
                            }
                            else
                            {
                                u.mensaje = "Pass";
                            }
                        }
                    }
                    cn.Close();
                }
                return u;

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static List<Perfil> GetPerfiles()
        {
            try
            {
                List<Perfil> f = null;
                using (SqlConnection cn = new SqlConnection(db))
                {
                    cn.Open();
                    SqlCommand cmd = cn.CreateCommand();
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_PROY_M_LISTA_PERFIL";
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        f = new List<Perfil>();
                        while (dr.Read())
                        {
                            f.Add(new Perfil()
                            {
                                perfilId = dr.GetInt32(0),
                                codigo = dr.GetString(1),
                                descripcion = dr.GetString(2),
                                estado = dr.GetString(3),
                                estadoId = dr.GetInt32(4),
                                usuarioId = 0,
                                cuotaFrecuencia = dr.GetInt32(5),
                                cuotaCobertura = dr.GetInt32(6)
                            });
                        }
                    }
                    cn.Close();
                }

                return f;

            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static List<Moneda> GetMonedas()
        {
            try
            {
                List<Moneda> f = null;
                using (SqlConnection cn = new SqlConnection(db))
                {
                    cn.Open();
                    SqlCommand cmd = cn.CreateCommand();
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_PROY_M_LISTA_MONEDAS";
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        f = new List<Moneda>();
                        while (dr.Read())
                        {
                            f.Add(new Moneda()
                            {
                                monedaId = dr.GetInt32(0),
                                codigo = dr.GetString(1),
                                descripcion = dr.GetString(2),
                                simbolo = dr.GetString(3),
                                estado = dr.GetString(4),
                                estadoId = dr.GetInt32(5),
                                usuarioId = 0
                            });
                        }
                    }
                    cn.Close();
                }

                return f;

            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static List<Feriado> GetFeriados()
        {
            try
            {
                List<Feriado> f = null;
                using (SqlConnection cn = new SqlConnection(db))
                {
                    cn.Open();
                    SqlCommand cmd = cn.CreateCommand();
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_PROY_M_LISTA_FERIADO";
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        f = new List<Feriado>();
                        while (dr.Read())
                        {
                            f.Add(new Feriado()
                            {
                                feriadoId = dr.GetInt32(0),
                                fecha = dr.GetDateTime(1).ToString("dd/MM/yyyy"),
                                descripcion = dr.GetString(2),
                                estado = dr.GetString(3),
                                estadoId = dr.GetInt32(4),
                                usuarioId = 0
                            });
                        }
                    }
                    cn.Close();
                }

                return f;

            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static List<Categoria> GetCategorias()
        {
            try
            {
                List<Categoria> c = null;
                using (SqlConnection cn = new SqlConnection(db))
                {
                    cn.Open();
                    SqlCommand cmd = cn.CreateCommand();
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_PROY_M_LISTA_CATEGORIAS";
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        c = new List<Categoria>();
                        while (dr.Read())
                        {
                            c.Add(new Categoria()
                            {
                                categoriaId = dr.GetInt32(0),
                                codigo = dr.GetString(1),
                                descripcion = dr.GetString(2),
                                estado = dr.GetString(3),
                                estadoId = dr.GetInt32(4),
                                usuarioId = 0
                            });
                        }
                    }
                    cn.Close();
                }

                return c;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static List<Especialidad> GetEspecialidades()
        {
            try
            {
                List<Especialidad> c = null;
                using (SqlConnection cn = new SqlConnection(db))
                {
                    cn.Open();
                    SqlCommand cmd = cn.CreateCommand();
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_PROY_M_LISTA_ESPECIALIDADES";
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        c = new List<Especialidad>();
                        while (dr.Read())
                        {
                            c.Add(new Especialidad()
                            {
                                especialidadId = dr.GetInt32(0),
                                codigo = dr.GetString(1),
                                descripcion = dr.GetString(2),
                                estado = dr.GetString(3),
                                estadoId = dr.GetInt32(4),
                                usuarioId = 0
                            });
                        }
                    }
                    cn.Close();
                }

                return c;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static List<Producto> GetProductos()
        {
            try
            {
                List<Producto> c = null;
                using (SqlConnection cn = new SqlConnection(db))
                {
                    cn.Open();
                    SqlCommand cmd = cn.CreateCommand();
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_PROY_M_LISTA_PRODUCTOS";
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        c = new List<Producto>();
                        while (dr.Read())
                        {
                            c.Add(new Producto()
                            {
                                productoId = dr.GetInt32(0),
                                codigo = dr.GetString(1),
                                descripcion = dr.GetString(2),
                                tipoProductoId = dr.GetInt32(3),
                                abreviatura = dr.GetString(4),
                                tipo = dr.GetString(5),
                                control = dr.GetString(6),
                                controlId = dr.GetInt32(7),
                                estado = dr.GetString(8),
                                estadoId = dr.GetInt32(9),
                                descripcionTipoProducto = dr.GetString(10),
                                usuarioId = 0
                            });
                        }
                    }
                    cn.Close();
                }

                return c;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static List<Visita> GetVisitas()
        {
            try
            {
                List<Visita> c = null;
                using (SqlConnection cn = new SqlConnection(db))
                {
                    cn.Open();
                    SqlCommand cmd = cn.CreateCommand();
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_PROY_M_LISTA_RESULTADOS_VISITAS";
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        c = new List<Visita>();
                        while (dr.Read())
                        {
                            c.Add(new Visita()
                            {
                                visitaId = dr.GetInt32(0),
                                descripcion = dr.GetString(1),
                                resultado = dr.GetString(2),
                                estado = dr.GetString(3),
                                estadoId = dr.GetInt32(4),
                                usuarioId = 0
                            });
                        }
                    }
                    cn.Close();
                }

                return c;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static List<TipoProducto> GetTipoProductos()
        {
            try
            {
                List<TipoProducto> c = null;
                using (SqlConnection cn = new SqlConnection(db))
                {
                    cn.Open();
                    SqlCommand cmd = cn.CreateCommand();
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_PROY_M_LISTA_TIPOS_PRODUCTOS";
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        c = new List<TipoProducto>();
                        while (dr.Read())
                        {
                            c.Add(new TipoProducto()
                            {
                                tipoProductoId = dr.GetInt32(0),
                                codigo = dr.GetString(1),
                                descripcion = dr.GetString(2),
                                estado = dr.GetString(3),
                                estadoId = dr.GetInt32(4),
                                usuarioId = 0
                            });
                        }
                    }
                    cn.Close();
                }

                return c;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static List<Control> GetControl()
        {
            try
            {
                List<Control> c = null;
                using (SqlConnection cn = new SqlConnection(db))
                {
                    cn.Open();
                    SqlCommand cmd = cn.CreateCommand();
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_PROY_M_LISTA_CONTROL_STOCK";
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        c = new List<Control>();
                        while (dr.Read())
                        {
                            c.Add(new Control()
                            {
                                controlId = dr.GetInt32(0),
                                descripcion = dr.GetString(1)
                            });
                        }
                    }
                    cn.Close();
                }

                return c;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static List<Personal> GetPersonal()
        {
            try
            {
                List<Personal> c = null;
                using (SqlConnection cn = new SqlConnection(db))
                {
                    cn.Open();
                    SqlCommand cmd = cn.CreateCommand();
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_PROY_M_LISTA_USUARIOS";
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        c = new List<Personal>();
                        while (dr.Read())
                        {
                            c.Add(new Personal()
                            {
                                personalId = dr.GetInt32(0),
                                nroDoc = dr.GetString(1),
                                email = dr.GetString(2),
                                perfilId = dr.GetInt32(3),
                                apellidoP = dr.GetString(4),
                                apellidoM = dr.GetString(5),
                                nombre = dr.GetString(6),
                                celular = dr.GetString(7),
                                fechaNacimiento = dr.GetDateTime(8).ToString("dd/MM/yyyy"),
                                sexo = dr.GetString(9),
                                supervisorId = dr.GetInt32(10),
                                esSupervisorId = dr.GetInt32(11),
                                estado = dr.GetInt32(12),
                                foto = dr.GetString(13),
                                login = dr.GetString(14),
                                nombreSupervisor = dr.GetString(15),
                                nombreEstado = dr.GetString(16),
                                nombrePerfil = dr.GetString(17),
                                pass = dr.GetString(18),
                                usuarioId = 0
                            });
                        }
                    }
                    cn.Close();
                }

                return c;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static List<Ciclo> GetCiclos()
        {
            try
            {
                List<Ciclo> c = null;
                using (SqlConnection cn = new SqlConnection(db))
                {
                    cn.Open();
                    SqlCommand cmd = cn.CreateCommand();
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_PROY_M_LISTA_CICLOS";
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        c = new List<Ciclo>();
                        while (dr.Read())
                        {
                            c.Add(new Ciclo()
                            {
                                cicloId = dr.GetInt32(0),
                                nombre = dr.GetString(1),
                                desde = dr.GetDateTime(2).ToString("dd/MM/yyyy"),
                                hasta = dr.GetDateTime(3).ToString("dd/MM/yyyy"),
                                nombreEstado = dr.GetString(4),
                                estado = dr.GetInt32(5),
                                usuarioId = 0
                            });
                        }
                    }
                    cn.Close();
                }

                return c;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static List<Actividad> GetActividad(int usuarioId, int cicloId, int estadoId, int tipo, int user)
        {
            try
            {
                List<Actividad> c = null;
                using (SqlConnection cn = new SqlConnection(db))
                {
                    cn.Open();
                    SqlCommand cmd = cn.CreateCommand();
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_PROY_M_LISTA_ACTIVIDADES";
                    cmd.Parameters.Add("@idUsuario", SqlDbType.Int).Value = usuarioId;
                    cmd.Parameters.Add("@idCiclo", SqlDbType.Int).Value = cicloId;
                    cmd.Parameters.Add("@idEstado", SqlDbType.Int).Value = estadoId;
                    cmd.Parameters.Add("@tipo", SqlDbType.Int).Value = tipo;
                    cmd.Parameters.Add("@idUsuario_logueado", SqlDbType.Int).Value = user;
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        c = new List<Actividad>();
                        while (dr.Read())
                        {
                            c.Add(new Actividad()
                            {
                                actividadId = dr.GetInt32(0),
                                identity = dr.GetInt32(0),
                                cicloId = dr.GetInt32(1),
                                fechaActividad = dr.GetDateTime(2).ToString("dd/MM/yyyy"),
                                fecha = dr.GetString(3),
                                duracionId = dr.GetInt32(4),
                                descripcionDuracion = dr.GetString(5),
                                detalle = dr.GetString(6),
                                estado = dr.GetInt32(7),
                                descripcionEstado = dr.GetString(8),
                                aprobador = dr.GetString(9),
                                observacion = dr.GetString(10),
                                usuario = dr.GetString(11),
                                usuarioId = user,
                                fechaRespuesta = "",
                                tipoInterfaz = "",
                                tipo = tipo,
                                nombreCiclo = dr.GetString(12),
                                medicoId = dr.GetInt32(13),
                                nombreMedico = dr.GetString(14)
                            });
                        }
                    }
                    cn.Close();
                }

                return c;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static List<Target> GetTargets(int u, int c, int es, int n, string s)
        {
            try
            {
                List<Target> t = null;
                using (SqlConnection cn = new SqlConnection(db))
                {
                    cn.Open();
                    SqlCommand cmd = cn.CreateCommand();
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_PROY_M_LISTA_TARGET";
                    cmd.Parameters.Add("@idUsuario", SqlDbType.Int).Value = u;
                    cmd.Parameters.Add("@idcategoria", SqlDbType.Int).Value = c;
                    cmd.Parameters.Add("@id_especialidad", SqlDbType.Int).Value = es;
                    cmd.Parameters.Add("@n_contactos", SqlDbType.Int).Value = n;
                    cmd.Parameters.Add("@medico", SqlDbType.VarChar).Value = s;
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        t = new List<Target>();
                        while (dr.Read())
                        {
                            Target a = new Target()
                            {
                                targetId = dr.GetInt32(0),
                                usuarioId = dr.GetInt32(1),
                                nombreUsuario = dr.GetString(2),
                                cmpMedico = dr.GetString(3),
                                medicoId = dr.GetInt32(4),
                                nombreMedico = dr.GetString(5),
                                categoriaId = dr.GetInt32(6),
                                descripcionCategoria = dr.GetString(7),
                                especialidadId = dr.GetInt32(8),
                                descripcionEspecialidad = dr.GetString(9),
                                numeroContactos = dr.GetInt32(10),
                                estado = dr.GetString(11)
                            };

                            SqlCommand cmdM = cn.CreateCommand();
                            cmdM.CommandTimeout = 0;
                            cmdM.CommandType = CommandType.StoredProcedure;
                            cmdM.CommandText = "SP_PROY_M_LISTA_GET_MEDICO";
                            cmdM.Parameters.Add("@medicoId", SqlDbType.Int).Value = a.medicoId;

                            SqlDataReader drDo = cmdM.ExecuteReader();
                            if (drDo.HasRows)
                            {
                                List<Medico> medicos = new List<Medico>();
                                while (drDo.Read())
                                {
                                    Medico e = new Medico
                                    {
                                        medicoId = drDo.GetInt32(0),
                                        identity = drDo.GetInt32(0),
                                        identificadorId = drDo.GetInt32(1),
                                        cpmMedico = drDo.GetString(2),
                                        nombreMedico = drDo.GetString(3),
                                        apellidoP = drDo.GetString(4),
                                        apellidoM = drDo.GetString(5),
                                        categoriaId = drDo.GetInt32(6),
                                        especialidadId = drDo.GetInt32(7),
                                        especialidadId2 = drDo.GetInt32(8),
                                        email = drDo.GetString(9),
                                        fechaNacimiento = drDo.GetString(10),
                                        sexo = drDo.GetString(11),
                                        telefono = drDo.GetString(12),
                                        estado = drDo.GetInt32(13),
                                        nombreIdentificador = drDo.GetString(14),
                                        nombreCategoria = drDo.GetString(15),
                                        nombreEspecialidad = drDo.GetString(16),
                                        nombreEspecialidad2 = drDo.GetString(17),
                                        visitadoPor = drDo.GetString(18),
                                        direccion = drDo.GetString(19),
                                        usuarioId = drDo.GetInt32(20),
                                        nombreCompleto = drDo.GetString(21),
                                        tipoVisitaId = drDo.GetInt32(22),
                                        medicoSolId = 0,
                                    };


                                    SqlCommand cmdD = cn.CreateCommand();
                                    cmdD.CommandTimeout = 0;
                                    cmdD.CommandType = CommandType.StoredProcedure;
                                    cmdD.CommandText = "SP_PROY_M_LISTA_GET_MEDICO_DIRECCIONES";
                                    cmdD.Parameters.Add("@medicoId", SqlDbType.Int).Value = e.medicoId;

                                    SqlDataReader drD = cmdD.ExecuteReader();
                                    if (drD.HasRows)
                                    {
                                        List<MedicoDireccion> direcciones = new List<MedicoDireccion>();
                                        while (drD.Read())
                                        {
                                            direcciones.Add(new MedicoDireccion()
                                            {
                                                medicoDireccionId = drD.GetInt32(0),
                                                identityDetalle = drD.GetInt32(0),
                                                identity = e.identity,
                                                medicoId = drD.GetInt32(1),
                                                codigoDepartamento = drD.GetString(2),
                                                codigoProvincia = drD.GetString(3),
                                                codigoDistrito = drD.GetString(4),
                                                direccion = drD.GetString(5),
                                                referencia = drD.GetString(6),
                                                estado = drD.GetInt32(7),
                                                usuarioId = drD.GetInt32(8),
                                                institucion = drD.GetString(9),
                                                nombreDepartamento = drD.GetString(10),
                                                nombreProvincia = drD.GetString(11),
                                                nombreDistrito = drD.GetString(12)
                                            });
                                        }
                                        e.direcciones = direcciones;
                                    }
                                    medicos.Add(e);
                                }
                                a.medicos = medicos;
                            }
                            t.Add(a);
                        }
                    }
                    cn.Close();
                }

                return t;
            }
            catch (Exception h)
            {
                throw h;
            }
        }
        public static List<TargetCab> GetTargetsCab(int u, string fi, string ff, int e, string tt, int t, int ul)
        {
            try
            {
                List<TargetCab> c = null;
                using (SqlConnection cn = new SqlConnection(db))
                {
                    cn.Open();
                    SqlCommand cmd = cn.CreateCommand();
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_PROY_M_LISTA_ALTAS_BAJAS";
                    cmd.Parameters.Add("@idUsuario", SqlDbType.Int).Value = u;
                    cmd.Parameters.Add("@fecha_inicial", SqlDbType.VarChar).Value = fi;
                    cmd.Parameters.Add("@fecha_final", SqlDbType.VarChar).Value = ff;
                    cmd.Parameters.Add("@idEstado", SqlDbType.Int).Value = e;
                    cmd.Parameters.Add("@tipo_target", SqlDbType.VarChar).Value = tt;
                    cmd.Parameters.Add("@tipo", SqlDbType.Int).Value = t;
                    cmd.Parameters.Add("@idUsuario_logueado", SqlDbType.Int).Value = ul;
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        c = new List<TargetCab>();
                        while (dr.Read())
                        {
                            var target = new TargetCab
                            {
                                targetCabId = dr.GetInt32(0),
                                identity = dr.GetInt32(0),
                                fechaSolicitud = dr.GetString(1),
                                aprobador = dr.GetString(2),
                                estado = dr.GetInt32(3),
                                nombreEstado = dr.GetString(4),
                                tipoTarget = dr.GetString(5),
                                usuarioSolicitante = dr.GetString(6),
                                cmpMedico = dr.GetString(7),
                                nombresMedico = dr.GetString(8),
                                descripcionCategoria = dr.GetString(9),
                                descripcionEspecialidad = dr.GetString(10),
                                numeroContactos = dr.GetInt32(11),
                                tipo = t,
                                fechaInicio = fi,
                                fechaFinal = ff,
                                usuarioId = u
                            };

                            SqlCommand cmdM = cn.CreateCommand();
                            cmdM.CommandTimeout = 0;
                            cmdM.CommandType = CommandType.StoredProcedure;
                            cmdM.CommandText = "SP_PROY_M_LISTA_GET_TARGET_DET";
                            cmdM.Parameters.Add("@targetCabId", SqlDbType.Int).Value = dr.GetInt32(0);

                            SqlDataReader drDo = cmdM.ExecuteReader();
                            if (drDo.HasRows)
                            {
                                List<TargetDet> detalles = new List<TargetDet>();
                                while (drDo.Read())
                                {
                                    var det = new TargetDet
                                    {
                                        targetDetId = drDo.GetInt32(0),
                                        identity = drDo.GetInt32(0),
                                        targetCabId = drDo.GetInt32(1),
                                        medicoId = drDo.GetInt32(2),
                                        cmp = drDo.GetString(3),
                                        categoriaId = drDo.GetInt32(4),
                                        especialidadId = drDo.GetInt32(5),
                                        nroContacto = drDo.GetInt32(6),
                                        mensajeRespuesta = drDo.GetString(7),
                                        nombreMedico = drDo.GetString(8),
                                        nombreCategoria = drDo.GetString(9),
                                        nombreEspecialidad = drDo.GetString(10),
                                        estadoTarget = drDo.GetInt32(11),
                                        visitadoPor = drDo.GetString(12),
                                        visitado = drDo.GetInt32(13),
                                        nrovisita = drDo.GetInt32(14),
                                        mensajeNrovisita = drDo.GetString(15),
                                        estado = 1
                                    };


                                    SqlCommand cmdI = cn.CreateCommand();
                                    cmdI.CommandTimeout = 0;
                                    cmdI.CommandType = CommandType.StoredProcedure;
                                    cmdI.CommandText = "SP_PROY_M_LISTA_APROBACION_ALTAS_BAJAS_INFORMACION_MEDICO";
                                    cmdI.Parameters.Add("@id_Medico", SqlDbType.Int).Value = det.medicoId;
                                    SqlDataReader drI = cmdI.ExecuteReader();
                                    if (drI.HasRows)
                                    {
                                        List<TargetInfo> info = new List<TargetInfo>();
                                        while (drI.Read())
                                        {
                                            info.Add(new TargetInfo
                                            {
                                                targetId = drI.GetInt32(0),
                                                usuario = drI.GetString(1),
                                                nroContacto = drI.GetInt32(2),
                                                targetDetId = det.targetDetId
                                            });
                                        }
                                        det.infos = info;
                                    }

                                    detalles.Add(det);
                                }
                                target.detalle = detalles;
                            }

                            c.Add(target);
                        }
                    }
                    cn.Close();
                }

                return c;
            }
            catch (Exception h)
            {
                throw h;
            }
        }
        public static List<SolMedico> GetMedico(int usuarioId, string finicio, string ffin, int estadoId, int tipo)
        {
            try
            {
                List<SolMedico> c = null;
                using (SqlConnection cn = new SqlConnection(db))
                {
                    cn.Open();
                    SqlCommand cmd = cn.CreateCommand();
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_PROY_M_LISTA_SOLICITUD_NUEVOS_MEDICOS";
                    cmd.Parameters.Add("@idUsuario", SqlDbType.Int).Value = usuarioId;
                    cmd.Parameters.Add("@fecha_inicio", SqlDbType.VarChar).Value = finicio;
                    cmd.Parameters.Add("@fecha_fin", SqlDbType.VarChar).Value = ffin;
                    cmd.Parameters.Add("@idEstado", SqlDbType.Int).Value = estadoId;
                    cmd.Parameters.Add("@tipo", SqlDbType.Int).Value = tipo;
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        c = new List<SolMedico>();
                        while (dr.Read())
                        {
                            SolMedico s = new SolMedico
                            {
                                solMedicoId = dr.GetInt32(0),
                                identity = dr.GetInt32(0),
                                mensajeSol = dr.GetString(1),
                                usuario = dr.GetString(2),
                                fecha = dr.GetString(3),
                                usuarioAprobador = dr.GetString(4),
                                estadoSol = dr.GetInt32(5),
                                descripcionEstado = dr.GetString(6),
								respuestaAprobador = dr.GetString(7),
                                usuarioId = usuarioId,
                                fechaInicio = finicio,
                                fechaFinal = ffin,
                                tipo = tipo
                            };

                            SqlCommand cmdE = cn.CreateCommand();
                            cmdE.CommandTimeout = 0;
                            cmdE.CommandType = CommandType.StoredProcedure;
                            cmdE.CommandText = "SP_PROY_M_LISTA_MEDICOS_DET";
                            cmdE.Parameters.Add("@cabId", SqlDbType.Int).Value = s.solMedicoId;

                            SqlDataReader drE = cmdE.ExecuteReader();
                            if (drE.HasRows)
                            {
                                List<Medico> medicos = new List<Medico>();
                                while (drE.Read())
                                {
                                    SqlCommand cmdM = cn.CreateCommand();
                                    cmdM.CommandTimeout = 0;
                                    cmdM.CommandType = CommandType.StoredProcedure;
                                    cmdM.CommandText = "SP_PROY_M_LISTA_GET_MEDICO";
                                    cmdM.Parameters.Add("@medicoId", SqlDbType.Int).Value = drE.GetInt32(0);

                                    SqlDataReader drDo = cmdM.ExecuteReader();
                                    if (drDo.HasRows)
                                    {
                                        while (drDo.Read())
                                        {
                                            Medico e = new Medico();
                                            e.medicoId = drDo.GetInt32(0);
                                            e.identity = drDo.GetInt32(0);
                                            e.identificadorId = drDo.GetInt32(1);
                                            e.cpmMedico = drDo.GetString(2);
                                            e.nombreMedico = drDo.GetString(3);
                                            e.apellidoP = drDo.GetString(4);
                                            e.apellidoM = drDo.GetString(5);
                                            e.categoriaId = drDo.GetInt32(6);
                                            e.especialidadId = drDo.GetInt32(7);
                                            e.especialidadId2 = drDo.GetInt32(8);
                                            e.email = drDo.GetString(9);
                                            e.fechaNacimiento = drDo.GetString(10);
                                            e.sexo = drDo.GetString(11);
                                            e.telefono = drDo.GetString(12);
                                            e.estado = drDo.GetInt32(13);
                                            e.nombreIdentificador = drDo.GetString(14);
                                            e.nombreCategoria = drDo.GetString(15);
                                            e.nombreEspecialidad = drDo.GetString(16);
                                            e.nombreEspecialidad2 = drDo.GetString(17);
                                            e.visitadoPor = drDo.GetString(18);
                                            e.direccion = drDo.GetString(19);
                                            e.usuarioId = drDo.GetInt32(20);
                                            e.nombreCompleto = drDo.GetString(21);
                                            e.tipoVisitaId = drDo.GetInt32(22);
                                            e.medicoSolId = s.solMedicoId;


                                            SqlCommand cmdD = cn.CreateCommand();
                                            cmdD.CommandTimeout = 0;
                                            cmdD.CommandType = CommandType.StoredProcedure;
                                            cmdD.CommandText = "SP_PROY_M_LISTA_GET_MEDICO_DIRECCIONES";
                                            cmdD.Parameters.Add("@medicoId", SqlDbType.Int).Value = drE.GetInt32(0);

                                            SqlDataReader drD = cmdD.ExecuteReader();
                                            if (drD.HasRows)
                                            {
                                                List<MedicoDireccion> direcciones = new List<MedicoDireccion>();
                                                while (drD.Read())
                                                {
                                                    direcciones.Add(new MedicoDireccion()
                                                    {
                                                        medicoDireccionId = drD.GetInt32(0),
                                                        identityDetalle = drD.GetInt32(0),
                                                        identity = e.identity,
                                                        medicoId = drD.GetInt32(1),
                                                        codigoDepartamento = drD.GetString(2),
                                                        codigoProvincia = drD.GetString(3),
                                                        codigoDistrito = drD.GetString(4),
                                                        direccion = drD.GetString(5),
                                                        referencia = drD.GetString(6),
                                                        estado = drD.GetInt32(7),
                                                        usuarioId = drD.GetInt32(8),
                                                        institucion = drD.GetString(9),
                                                        nombreDepartamento = drD.GetString(10),
                                                        nombreProvincia = drD.GetString(11),
                                                        nombreDistrito = drD.GetString(12)
                                                    });
                                                }
                                                e.direcciones = direcciones;
                                            }

                                            medicos.Add(e);
                                        }
                                    }
                                }

                                s.medicos = medicos;
                            }

                            c.Add(s);
                        }
                    }
                    cn.Close();
                }

                return c;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static List<Programacion> GetProgramacion(int u, int c)
        {
            try
            {
                List<Programacion> t = null;
                using (SqlConnection cn = new SqlConnection(db))
                {
                    cn.Open();
                    SqlCommand cmd = cn.CreateCommand();
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_PROY_M_LISTA_PROGRAMACION";
                    cmd.Parameters.Add("@idUsuario", SqlDbType.Int).Value = u;
                    cmd.Parameters.Add("@idCiclo", SqlDbType.Int).Value = c;
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        t = new List<Programacion>();
                        while (dr.Read())
                        {
                            Programacion p = new Programacion
                            {
                                programacionId = dr.GetInt32(0),
                                identity = dr.GetInt32(0),
                                cicloId = dr.GetInt32(1),
                                nombreCiclo = dr.GetString(2),
                                numeroVisita = dr.GetString(3),
                                usuarioId = dr.GetInt32(4),
                                nombreUsuario = dr.GetString(5),
                                medicoId = dr.GetInt32(6),
                                cmpMedico = dr.GetString(7),
                                nombreMedico = dr.GetString(8),
                                categoria = dr.GetString(9),
                                especialidad = dr.GetString(10),
                                fechaProgramacion = dr.GetDateTime(11).ToString("dd/MM/yyyy"),
                                horaProgramacion = dr.GetDateTime(12).ToString("hh:mm tt"),
                                fechaReporteProgramacion = dr.GetDateTime(13).ToString("dd/MM/yyyy"),
                                horaReporteProgramacion = dr.GetDateTime(14).ToString("hh:mm tt"),
                                visitaAcompanada = dr.GetString(15),
                                dataAcompaniante = dr.GetString(16),
                                latitud = dr.GetString(17),
                                longitud = dr.GetString(18),
                                estadoProgramacion = dr.GetInt32(19),
                                descripcionEstado = dr.GetString(20),
                                resultadoVisitaId = dr.GetInt32(21),
                                descripcionResultado = dr.GetString(22),
                                direccionId = dr.GetInt32(23),
                                direccion = dr.GetString(24),
                                especialidadId = dr.GetInt32(25)
                            };


                            SqlCommand cmdM = cn.CreateCommand();
                            cmdM.CommandTimeout = 0;
                            cmdM.CommandType = CommandType.StoredProcedure;
                            cmdM.CommandText = "SP_PROY_M_LISTA_PROGRAMACION_DET";
                            cmdM.Parameters.Add("@programacionId", SqlDbType.Int).Value = p.programacionId;

                            SqlDataReader drDo = cmdM.ExecuteReader();
                            if (drDo.HasRows)
                            {
                                List<ProgramacionDet> productos = new List<ProgramacionDet>();
                                while (drDo.Read())
                                {
                                    var det = new ProgramacionDet
                                    {
                                        programacionDetId = drDo.GetInt32(0),
                                        identity = drDo.GetInt32(0),
                                        programacionId = drDo.GetInt32(1),
                                        productoId = drDo.GetInt32(2),
                                        ordenProgramacion = drDo.GetInt32(3),
                                        codigoProducto = drDo.GetString(4),
                                        descripcionProducto = drDo.GetString(5),
                                        lote = drDo.GetString(6),
                                        cantidad = drDo.GetInt32(7),
                                        stock = drDo.GetInt32(8)
                                    };

                                    productos.Add(det);
                                }
                                p.productos = productos;
                            }
                            t.Add(p);
                        }
                    }
                    cn.Close();
                }

                return t;
            }
            catch (Exception h)
            {
                throw h;
            }
        }
        public static List<ProgramacionPerfil> GetProgramacionPerfil(int m)
        {
            try
            {
                List<ProgramacionPerfil> t = null;
                using (SqlConnection cn = new SqlConnection(db))
                {
                    cn.Open();
                    SqlCommand cmd = cn.CreateCommand();
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_PROY_M_LISTA_PROGRAMACION_PERFIL_MEDICO_AGRUPADO";
                    cmd.Parameters.Add("@idMedico", SqlDbType.Int).Value = m;
                    SqlDataReader dr1 = cmd.ExecuteReader();
                    if (dr1.HasRows)
                    {
                        t = new List<ProgramacionPerfil>();
                        while (dr1.Read())
                        {
                            t.Add(new ProgramacionPerfil()
                            {
                                medicoId = m,
                                nombreMedico = dr1.GetString(0),
                                matricula = dr1.GetString(1),
                                especialidad = dr1.GetString(2),
                                direccion = dr1.GetString(3),
                                mercadoProducto = dr1.GetString(4),
                                doceUltimosMeses = dr1.GetString(5),
                                tresUltimosMeses = dr1.GetString(6),
                                ultimoMeses = dr1.GetString(7)
                            });
                        }
                    }
                    cn.Close();
                }

                return t;
            }
            catch (Exception h)
            {
                throw h;
            }
        }
        public static List<ProgramacionPerfilDetalle> GetProgramacionPerfilDetalle(int m, string n)
        {
            try
            {
                List<ProgramacionPerfilDetalle> t = null;
                using (SqlConnection cn = new SqlConnection(db))
                {
                    cn.Open();
                    SqlCommand cmd = cn.CreateCommand();
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_PROY_M_LISTA_PROGRAMACION_PERFIL_MEDICO_DETALLADO";
                    cmd.Parameters.Add("@idMedico", SqlDbType.Int).Value = m;
                    cmd.Parameters.Add("@nombreProducto", SqlDbType.VarChar).Value = n;
                    SqlDataReader dr1 = cmd.ExecuteReader();
                    if (dr1.HasRows)
                    {
                        t = new List<ProgramacionPerfilDetalle>();
                        while (dr1.Read())
                        {
                            t.Add(new ProgramacionPerfilDetalle()
                            {
                                medicoId = m,
                                producto = n,
                                mercadoProducto = dr1.GetString(0),
                                doceUltimosMeses = dr1.GetString(1),
                                tresUltimosMeses = dr1.GetString(2),
                                ultimoMeses = dr1.GetString(3)
                            });
                        }
                    }
                    cn.Close();
                }

                return t;
            }
            catch (Exception h)
            {
                throw h;
            }
        }
        public static List<ProgramacionReja> GetProgramacionReja(int e)
        {
            try
            {
                List<ProgramacionReja> t = null;
                using (SqlConnection cn = new SqlConnection(db))
                {
                    cn.Open();
                    SqlCommand cmd = cn.CreateCommand();
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_PROY_W_PROC_PROGRAMACION_REJA_PROMOCIONAL";
                    cmd.Parameters.Add("@id_especialidad", SqlDbType.Int).Value = e;
                    SqlDataReader dr1 = cmd.ExecuteReader();
                    if (dr1.HasRows)
                    {
                        t = new List<ProgramacionReja>();
                        while (dr1.Read())
                        {
                            ProgramacionReja p = new ProgramacionReja
                            {
                                especialidadId = e,
                                especialidad = dr1.GetString(0),
                                producto = dr1.GetString(1),
                                material = dr1.GetString(2)
                            };

                            t.Add(p);
                        }
                    }
                    cn.Close();
                }

                return t;
            }
            catch (Exception h)
            {
                throw h;
            }
        }
        public static List<NuevaDireccion> GetNuevaDireccion(int usuarioId, string finicio, string ffin, int estadoId, int tipo)
        {
            try
            {
                List<NuevaDireccion> t = null;
                using (SqlConnection cn = new SqlConnection(db))
                {
                    cn.Open();
                    SqlCommand cmd = cn.CreateCommand();
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_PROY_M_LISTA_SOLICITUD_NUEVAS_DIRECCIONES";
                    cmd.Parameters.Add("@idUsuario", SqlDbType.Int).Value = usuarioId;
                    cmd.Parameters.Add("@fecha_inicio", SqlDbType.VarChar).Value = finicio;
                    cmd.Parameters.Add("@fecha_fin", SqlDbType.VarChar).Value = ffin;
                    cmd.Parameters.Add("@idEstado", SqlDbType.Int).Value = estadoId;
                    cmd.Parameters.Add("@tipo", SqlDbType.Int).Value = tipo;
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        t = new List<NuevaDireccion>();
                        while (dr.Read())
                        {
                            t.Add(new NuevaDireccion
                            {
                                solDireccionId = dr.GetInt32(0),
                                identity = dr.GetInt32(0),
                                medicoId = dr.GetInt32(1),
                                nombreMedico = dr.GetString(2),
                                medicoDireccionId = dr.GetInt32(3),
                                solicitante = dr.GetString(4),
                                fechaSolicitud = dr.GetString(5),
                                fechaRespuesta = dr.GetString(6),
                                comentarioRespuesta = dr.GetString(7),
                                aprobador = dr.GetString(8),
                                estadoId = dr.GetInt32(9),
                                descripcionEstado = dr.GetString(10),
                                codigoDepartamento = dr.GetString(11),
                                nombreDepartamento = dr.GetString(12),
                                codigoProvincia = dr.GetString(13),
                                nombreProvincia = dr.GetString(14),
                                codigoDistrito = dr.GetString(15),
                                nombreDistrito = dr.GetString(16),
                                nombreDireccion = dr.GetString(17),
                                referencia = dr.GetString(18),
                                nombreInstitucion = dr.GetString(19),

                                usuarioId = usuarioId,
                                fechaInicio = finicio,
                                fechaFinal = ffin,
                                tipo = tipo,
                                observacion = ""
                            });
                        }
                    }
                    cn.Close();
                }

                return t;
            }
            catch (Exception h)
            {
                throw h;
            }
        }
        public static List<PuntoContacto> GetPuntoContactos(int usuarioId, string finicio, string ffin)
        {
            try
            {
                List<PuntoContacto> t = null;
                using (SqlConnection cn = new SqlConnection(db))
                {
                    cn.Open();
                    SqlCommand cmd = cn.CreateCommand();
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_PROY_M_LISTA_PUNTOS_CONTACTO";
                    cmd.Parameters.Add("@idUsuario", SqlDbType.Int).Value = usuarioId;
                    cmd.Parameters.Add("@fecha_inicial", SqlDbType.VarChar).Value = finicio;
                    cmd.Parameters.Add("@fecha_final", SqlDbType.VarChar).Value = ffin;
                    SqlDataReader dr1 = cmd.ExecuteReader();
                    if (dr1.HasRows)
                    {
                        t = new List<PuntoContacto>();
                        while (dr1.Read())
                        {
                            t.Add(new PuntoContacto()
                            {
                                puntoContactoId = dr1.GetInt32(0),
                                usuarioId = dr1.GetInt32(1),
                                fechaPuntoContacto = dr1.GetString(2),
                                descripcion = dr1.GetString(3),
                                estadoId = dr1.GetInt32(4),
                                descripcionEstado = dr1.GetString(5),
                                latitud = dr1.GetString(6),
                                longitud = dr1.GetString(7),
                            });
                        }
                    }
                    cn.Close();
                }

                return t;
            }
            catch (Exception h)
            {
                throw h;
            }
        }
        public static List<Stock> GetStocks(int usuarioId)
        {
            try
            {
                List<Stock> e = null;
                using (SqlConnection con = new SqlConnection(db))
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_PROY_M_LISTA_PROGRAMACION_STOCK";
                    cmd.Parameters.Add("@idUsuario", SqlDbType.Int).Value = usuarioId;
                    SqlDataReader dr6 = cmd.ExecuteReader();
                    if (dr6.HasRows)
                    {
                        e = new List<Stock>();
                        while (dr6.Read())
                        {
                            e.Add(new Stock()
                            {
                                productoId = dr6.GetInt32(0),
                                codigoProducto = dr6.GetString(1),
                                descripcion = dr6.GetString(2),
                                lote = dr6.GetString(3),
                                stock = dr6.GetInt32(4)
                            });
                        }
                    }
                    con.Close();
                }
                return e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static List<StockMantenimiento> GetStockMantenimientos(int usuarioId, int cicloId)
        {
            try
            {
                List<StockMantenimiento> e = null;
                using (SqlConnection con = new SqlConnection(db))
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_PROY_M_LISTA_STOCK";
                    cmd.Parameters.Add("@idUsuario", SqlDbType.Int).Value = usuarioId;
                    cmd.Parameters.Add("@idCiclo", SqlDbType.VarChar).Value = cicloId;
                    SqlDataReader dr6 = cmd.ExecuteReader();
                    if (dr6.HasRows)
                    {
                        e = new List<StockMantenimiento>();
                        while (dr6.Read())
                        {
                            e.Add(new StockMantenimiento()
                            {
                                productoId = dr6.GetInt32(0),
                                codigoProducto = dr6.GetString(1),
                                descripcion = dr6.GetString(2),
                                lote = dr6.GetString(3),
                                cantidadAsignada = dr6.GetInt32(4),
                                stock = dr6.GetInt32(5)
                            });
                        }
                    }
                    con.Close();
                }
                return e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static List<BirthDay> GetBirthDay(int usuarioId, int mes)
        {
            try
            {
                List<BirthDay> e = null;
                using (SqlConnection con = new SqlConnection(db))
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_PROY_M_RPT_CUMPLEANOS_MEDICOS";
                    cmd.Parameters.Add("@idUsuario", SqlDbType.Int).Value = usuarioId;
                    cmd.Parameters.Add("@id_mes", SqlDbType.Int).Value = mes;
                    SqlDataReader dr6 = cmd.ExecuteReader();
                    if (dr6.HasRows)
                    {
                        e = new List<BirthDay>();
                        while (dr6.Read())
                        {
                            e.Add(new BirthDay()
                            {
                                targetId = dr6.GetInt32(0),
                                usuarioId = dr6.GetInt32(1),
                                nombreMedico = dr6.GetString(2),
                                cmpMedico = dr6.GetString(3),
                                medicoId = dr6.GetInt32(4),
                                categoriaId = dr6.GetInt32(5),
                                descripcionCategoria = dr6.GetString(6),
                                especialidad = dr6.GetInt32(7),
                                descripcionEspecialidad = dr6.GetString(8),
                                numeroContacto = dr6.GetInt32(9),
                                nombreEstado = dr6.GetString(10),
                                fechaNacimiento = dr6.GetString(11),
                                mesId = mes
                            });
                        }
                    }
                    con.Close();
                }
                return e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public static Sync GetSync(int usuarioId)
        {
            try
            {
                Sync s = new Sync
                {
                    ciclos = GetCiclos(),
                    personals = GetPersonal(),
                    especialidads = GetEspecialidades(),
                    categorias = GetCategorias(),
                    visitas = GetVisitas()
                };

                using (SqlConnection con = new SqlConnection(db))
                {
                    con.Open();

                    SqlCommand cmdE = con.CreateCommand();
                    cmdE.CommandTimeout = 0;
                    cmdE.CommandType = CommandType.StoredProcedure;
                    cmdE.CommandText = "SP_PROY_M_LISTA_ESTADOS";
                    SqlDataReader drE = cmdE.ExecuteReader();
                    if (drE.HasRows)
                    {
                        List<Estado> e = new List<Estado>();
                        while (drE.Read())
                        {
                            e.Add(new Estado()
                            {
                                estadoId = drE.GetInt32(0),
                                grupo = drE.GetString(1),
                                descripcion = drE.GetString(2)
                            });
                        }
                        s.estados = e;
                    }

                    SqlCommand cmdD = con.CreateCommand();
                    cmdD.CommandTimeout = 0;
                    cmdD.CommandType = CommandType.StoredProcedure;
                    cmdD.CommandText = "SP_PROY_M_LISTA_ACTIVIDADES_DURACION";
                    SqlDataReader drD = cmdD.ExecuteReader();
                    if (drD.HasRows)
                    {
                        List<Duracion> e = new List<Duracion>();
                        while (drD.Read())
                        {
                            e.Add(new Duracion()
                            {
                                duracionId = drD.GetInt32(0),
                                descripcion = drD.GetString(1)
                            });
                        }
                        s.duracions = e;
                    }

                    SqlCommand cmdI = con.CreateCommand();
                    cmdI.CommandTimeout = 0;
                    cmdI.CommandType = CommandType.StoredProcedure;
                    cmdI.CommandText = "SP_PROY_M_LISTA_SOLICITUD_NUEVOS_MEDICOS_IDENTIFICADOR";
                    SqlDataReader drI = cmdI.ExecuteReader();
                    if (drI.HasRows)
                    {
                        List<Identificador> e = new List<Identificador>();
                        while (drI.Read())
                        {
                            e.Add(new Identificador()
                            {
                                identificadorId = drI.GetInt32(0),
                                descripcion = drI.GetString(1)
                            });
                        }
                        s.identificadors = e;
                    }

                    SqlCommand cmdDe = con.CreateCommand();
                    cmdDe.CommandTimeout = 0;
                    cmdDe.CommandType = CommandType.StoredProcedure;
                    cmdDe.CommandText = "SP_PROY_M_UBIGEO";
                    SqlDataReader drDe = cmdDe.ExecuteReader();
                    if (drDe.HasRows)
                    {
                        List<Ubigeo> e = new List<Ubigeo>();
                        while (drDe.Read())
                        {
                            e.Add(new Ubigeo()
                            {
                                id = drDe.GetInt32(0),
                                codDepartamento = drDe.GetString(1),
                                nombreDepartamento = drDe.GetString(2),
                                codProvincia = drDe.GetString(3),
                                provincia = drDe.GetString(4),
                                codDistrito = drDe.GetString(5),
                                nombreDistrito = drDe.GetString(6)
                            });
                        }
                        s.ubigeos = e;
                    }

                    SqlCommand cmdDo = con.CreateCommand();
                    cmdDo.CommandTimeout = 0;
                    cmdDo.CommandType = CommandType.StoredProcedure;
                    cmdDo.CommandText = "SP_PROY_M_LISTA_MEDICOS";
                    cmdDo.Parameters.Add("@id_Usuario", SqlDbType.Int).Value = usuarioId;
                    SqlDataReader drDo = cmdDo.ExecuteReader();
                    if (drDo.HasRows)
                    {
                        List<Medico> e = new List<Medico>();
                        while (drDo.Read())
                        {
                            Medico m = new Medico
                            {
                                medicoId = drDo.GetInt32(0),
                                identity = drDo.GetInt32(0),
                                identificadorId = drDo.GetInt32(1),
                                cpmMedico = drDo.GetString(2),
                                nombreMedico = drDo.GetString(3),
                                apellidoP = drDo.GetString(4),
                                apellidoM = drDo.GetString(5),
                                categoriaId = drDo.GetInt32(6),
                                especialidadId = drDo.GetInt32(7),
                                especialidadId2 = drDo.GetInt32(8),
                                email = drDo.GetString(9),
                                fechaNacimiento = drDo.GetString(10),
                                sexo = drDo.GetString(11),
                                telefono = drDo.GetString(12),
                                estado = drDo.GetInt32(13),
                                nombreIdentificador = drDo.GetString(14),
                                nombreCategoria = drDo.GetString(15),
                                nombreEspecialidad = drDo.GetString(16),
                                nombreEspecialidad2 = drDo.GetString(17),
                                visitadoPor = drDo.GetString(18),
                                usuarioId = drDo.GetInt32(19),
                                direccion = drDo.GetString(20),
                                nombreCompleto = drDo.GetString(21),
                                tipoVisitaId = drDo.GetInt32(22),
                                medicoSolId = 0
                            };


                            SqlCommand cmd2 = con.CreateCommand();
                            cmd2.CommandTimeout = 0;
                            cmd2.CommandType = CommandType.StoredProcedure;
                            cmd2.CommandText = "SP_PROY_M_LISTA_GET_MEDICO_DIRECCIONES";
                            cmd2.Parameters.Add("@medicoId", SqlDbType.Int).Value = m.medicoId;

                            SqlDataReader dr2 = cmd2.ExecuteReader();
                            if (dr2.HasRows)
                            {
                                List<MedicoDireccion> direcciones = new List<MedicoDireccion>();
                                while (dr2.Read())
                                {
                                    direcciones.Add(new MedicoDireccion()
                                    {
                                        medicoDireccionId = dr2.GetInt32(0),
                                        identityDetalle = dr2.GetInt32(0),
                                        identity = m.identity,
                                        medicoId = dr2.GetInt32(1),
                                        codigoDepartamento = dr2.GetString(2),
                                        codigoProvincia = dr2.GetString(3),
                                        codigoDistrito = dr2.GetString(4),
                                        direccion = dr2.GetString(5),
                                        referencia = dr2.GetString(6),
                                        estado = dr2.GetInt32(7),
                                        usuarioId = dr2.GetInt32(8),
                                        institucion = dr2.GetString(9),
                                        nombreDepartamento = dr2.GetString(10),
                                        nombreProvincia = dr2.GetString(11),
                                        nombreDistrito = dr2.GetString(12)
                                    });
                                }
                                m.direcciones = direcciones;
                            }
                            e.Add(m);
                        }
                        s.medicos = e;
                    }

                    SqlCommand cmdTV = con.CreateCommand();
                    cmdTV.CommandTimeout = 0;
                    cmdTV.CommandType = CommandType.StoredProcedure;
                    cmdTV.CommandText = "SP_PROY_W_TIPO_VISITA_COMBO";
                    SqlDataReader drTV = cmdTV.ExecuteReader();
                    if (drTV.HasRows)
                    {
                        List<TipoVisita> e = new List<TipoVisita>();
                        while (drTV.Read())
                        {
                            e.Add(new TipoVisita()
                            {
                                tipoVisitaId = drTV.GetInt32(0),
                                descripcion = drTV.GetString(1)                              
                            });
                        }
                        s.tipoVisita = e;
                    }

                    con.Close();
                }
                return s;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        // TODO GUARDAR Y ACTUALIZAR
        public static Mensaje SavePerfil(Perfil p)
        {
            try
            {
                Mensaje m = null;

                using (SqlConnection con = new SqlConnection(db))
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_PROY_M_SAVE_PERFIL";
                    cmd.Parameters.Add("@ID", SqlDbType.Int).Value = p.perfilId;
                    cmd.Parameters.Add("@CODIGO_ROL", SqlDbType.VarChar).Value = p.codigo;
                    cmd.Parameters.Add("@DESCRIPCION_ROL", SqlDbType.VarChar).Value = p.descripcion;
                    cmd.Parameters.Add("@ESTADO", SqlDbType.Int).Value = p.estadoId;
                    cmd.Parameters.Add("@USUARIO_CREACION", SqlDbType.Int).Value = p.usuarioId;
                    cmd.Parameters.Add("@CUOTA_FRECUENCIA", SqlDbType.Int).Value = p.cuotaFrecuencia;
                    cmd.Parameters.Add("@CUOTA_COBERTURA", SqlDbType.Int).Value = p.cuotaCobertura;

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        m = new Mensaje();
                        while (dr.Read())
                        {
                            m.mensaje = "Enviado";
                            m.codigoRetorno = dr.GetInt32(0);
                            m.codigoBase = p.perfilId;
                        }
                    }

                    con.Close();
                    return m;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Mensaje SaveMoneda(Moneda p)
        {
            try
            {
                Mensaje m = null;

                using (SqlConnection con = new SqlConnection(db))
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_PROY_M_SAVE_MONEDAS";
                    cmd.Parameters.Add("@ID_MONEDA", SqlDbType.Int).Value = p.monedaId;
                    cmd.Parameters.Add("@CODIGO_MONEDA", SqlDbType.VarChar).Value = p.codigo;
                    cmd.Parameters.Add("@DESCRIPCION_MONEDA", SqlDbType.VarChar).Value = p.descripcion;
                    cmd.Parameters.Add("@SIMBOLO_MONEDA", SqlDbType.VarChar).Value = p.simbolo;
                    cmd.Parameters.Add("@ESTADO", SqlDbType.Int).Value = p.estadoId;
                    cmd.Parameters.Add("@USUARIO_CREACION", SqlDbType.Int).Value = p.usuarioId;
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        m = new Mensaje();
                        while (dr.Read())
                        {
                            m.mensaje = "Enviado";
                            m.codigoRetorno = dr.GetInt32(0);
                            m.codigoBase = p.monedaId;
                        }
                    }

                    con.Close();
                    return m;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Mensaje SaveFeriado(Feriado f)
        {
            try
            {
                Mensaje m = null;

                using (SqlConnection con = new SqlConnection(db))
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_PROY_M_SAVE_FERIADO";
                    cmd.Parameters.Add("@ID_FERIADO", SqlDbType.Int).Value = f.feriadoId;
                    cmd.Parameters.Add("@FECHA_FERIADO", SqlDbType.VarChar).Value = f.fecha;
                    cmd.Parameters.Add("@DESCRIPCION_FERIADO", SqlDbType.VarChar).Value = f.descripcion;
                    cmd.Parameters.Add("@ESTADO", SqlDbType.Int).Value = f.estadoId;
                    cmd.Parameters.Add("@USUARIO_CREACION", SqlDbType.Int).Value = f.usuarioId;
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        m = new Mensaje();
                        while (dr.Read())
                        {
                            m.mensaje = "Enviado";
                            m.codigoRetorno = dr.GetInt32(0);
                            m.codigoBase = f.feriadoId;
                        }
                    }
                    con.Close();
                    return m;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Mensaje SaveCategoria(Categoria c)
        {
            try
            {
                Mensaje m = null;

                using (SqlConnection con = new SqlConnection(db))
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_PROY_M_SAVE_CATEGORIAS";
                    cmd.Parameters.Add("@ID_CATEGORIA", SqlDbType.Int).Value = c.categoriaId;
                    cmd.Parameters.Add("@CODIGO_CATEGORIA", SqlDbType.VarChar).Value = c.codigo;
                    cmd.Parameters.Add("@DESCRIPCION_CATEGORIA", SqlDbType.VarChar).Value = c.descripcion;
                    cmd.Parameters.Add("@ESTADO", SqlDbType.Int).Value = c.estadoId;
                    cmd.Parameters.Add("@USUARIO_CREACION", SqlDbType.Int).Value = c.usuarioId;
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        m = new Mensaje();
                        while (dr.Read())
                        {
                            m.mensaje = "Enviado";
                            m.codigoRetorno = dr.GetInt32(0);
                            m.codigoBase = c.categoriaId;
                        }
                    }
                    con.Close();
                    return m;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Mensaje SaveEspecialidades(Especialidad e)
        {
            try
            {
                Mensaje m = null;

                using (SqlConnection con = new SqlConnection(db))
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_PROY_M_SAVE_ESPECIALIDADES";
                    cmd.Parameters.Add("@ID_ESPECIALIDAD", SqlDbType.Int).Value = e.especialidadId;
                    cmd.Parameters.Add("@CODIGO_ESPECIALIDAD", SqlDbType.VarChar).Value = e.codigo;
                    cmd.Parameters.Add("@DESCRIPCION_ESPECIALIDAD", SqlDbType.VarChar).Value = e.descripcion;
                    cmd.Parameters.Add("@ESTADO", SqlDbType.Int).Value = e.estadoId;
                    cmd.Parameters.Add("@USUARIO_CREACION", SqlDbType.Int).Value = e.usuarioId;
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        m = new Mensaje();
                        while (dr.Read())
                        {
                            m.mensaje = "Enviado";
                            m.codigoRetorno = dr.GetInt32(0);
                            m.codigoBase = e.especialidadId;
                        }
                    }
                    con.Close();
                    return m;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Mensaje SaveProductos(Producto p)
        {
            try
            {
                Mensaje m = null;

                using (SqlConnection con = new SqlConnection(db))
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_PROY_M_SAVE_PRODUCTOS";
                    cmd.Parameters.Add("@ID_PRODUCTO", SqlDbType.Int).Value = p.productoId;
                    cmd.Parameters.Add("@CODIGO_PRODUCTO", SqlDbType.VarChar).Value = p.codigo;
                    cmd.Parameters.Add("@DESCRIPCION_PRODUCTO", SqlDbType.VarChar).Value = p.descripcion;
                    cmd.Parameters.Add("@ID_TIPO_PRODUCTO", SqlDbType.Int).Value = p.tipoProductoId;
                    cmd.Parameters.Add("@ABREVIATURA_PRODUCTO", SqlDbType.VarChar).Value = p.abreviatura;
                    cmd.Parameters.Add("@ID_CONTROL_STOCK", SqlDbType.Int).Value = p.controlId;
                    cmd.Parameters.Add("@ESTADO", SqlDbType.Int).Value = p.estadoId;
                    cmd.Parameters.Add("@USUARIO_CREACION", SqlDbType.Int).Value = p.usuarioId;
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        m = new Mensaje();
                        while (dr.Read())
                        {
                            m.mensaje = "Enviado";
                            m.codigoRetorno = dr.GetInt32(0);
                            m.codigoBase = p.productoId;
                        }
                    }
                    con.Close();

                    return m;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Mensaje SaveVisita(Visita v)
        {
            try
            {
                Mensaje m = null;

                using (SqlConnection con = new SqlConnection(db))
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_PROY_M_SAVE_RESULTADOS_VISITAS";
                    cmd.Parameters.Add("@ID_RESULTADO_VISITA", SqlDbType.Int).Value = v.visitaId;
                    cmd.Parameters.Add("@DESCRIPCION_RESULTADO_VISITA", SqlDbType.VarChar).Value = v.descripcion;
                    cmd.Parameters.Add("@POR_DEFECTO_RESULTADO_VISITA", SqlDbType.VarChar).Value = v.resultado;
                    cmd.Parameters.Add("@ESTADO", SqlDbType.Int).Value = v.estadoId;
                    cmd.Parameters.Add("@USUARIO_CREACION", SqlDbType.Int).Value = v.usuarioId;
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        m = new Mensaje();
                        while (dr.Read())
                        {
                            m.mensaje = "Enviado";
                            m.codigoRetorno = dr.GetInt32(0);
                            m.codigoBase = v.visitaId;
                        }
                    }
                    con.Close();
                    return m;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Mensaje SaveTipoProducto(TipoProducto t)
        {
            try
            {
                Mensaje m = null;

                using (SqlConnection con = new SqlConnection(db))
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_PROY_M_SAVE_TIPOS_PRODUCTOS";
                    cmd.Parameters.Add("@ID_TIPO_PRODUCTO", SqlDbType.Int).Value = t.tipoProductoId;
                    cmd.Parameters.Add("@CODIGO_TIPO_PRODUCTO", SqlDbType.VarChar).Value = t.codigo;
                    cmd.Parameters.Add("@DESCRIPCION_TIPO_PRODUCTO", SqlDbType.VarChar).Value = t.descripcion;
                    cmd.Parameters.Add("@ESTADO", SqlDbType.Int).Value = t.estadoId;
                    cmd.Parameters.Add("@USUARIO_CREACION", SqlDbType.Int).Value = t.usuarioId;
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        m = new Mensaje();
                        while (dr.Read())
                        {
                            m.mensaje = "Enviado";
                            m.codigoRetorno = dr.GetInt32(0);
                            m.codigoBase = t.tipoProductoId;
                        }
                    }
                    con.Close();
                    return m;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Mensaje SaveCiclo(Ciclo t)
        {
            try
            {
                Mensaje m = null;
                using (SqlConnection con = new SqlConnection(db))
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_PROY_M_SAVE_CICLO";
                    cmd.Parameters.Add("@cicloId", SqlDbType.Int).Value = t.cicloId;
                    cmd.Parameters.Add("@nombre_ciclo", SqlDbType.VarChar).Value = t.nombre;
                    cmd.Parameters.Add("@desde_ciclo", SqlDbType.VarChar).Value = t.desde;
                    cmd.Parameters.Add("@hasta_ciclo", SqlDbType.VarChar).Value = t.hasta;
                    cmd.Parameters.Add("@estado", SqlDbType.Int).Value = t.estado;
                    cmd.Parameters.Add("@usuario", SqlDbType.Int).Value = t.usuarioId;

                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        m = new Mensaje();
                        while (dr.Read())
                        {
                            m.mensaje = "Enviado";
                            m.codigoRetorno = dr.GetInt32(0);
                            m.codigoBase = t.cicloId;
                        }
                    }
                    con.Close();
                    return m;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Mensaje SaveActividad(Actividad a)
        {
            try
            {
                Mensaje m = null;
                using (SqlConnection con = new SqlConnection(db))
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_PROY_M_SAVE_ACTIVIDADES";
                    cmd.Parameters.Add("@ID_ACTIVIDAD", SqlDbType.Int).Value = a.identity;
                    cmd.Parameters.Add("@ID_CICLO", SqlDbType.Int).Value = a.cicloId;
                    cmd.Parameters.Add("@FECHA_ACTIVIDAD", SqlDbType.VarChar).Value = a.fechaActividad;
                    cmd.Parameters.Add("@ID_DURACION", SqlDbType.Int).Value = a.duracionId;
                    cmd.Parameters.Add("@DETALLE_ACTIVIDAD", SqlDbType.VarChar).Value = a.detalle;
                    cmd.Parameters.Add("@ESTADO", SqlDbType.Int).Value = a.estado;
                    cmd.Parameters.Add("@USUARIO_CREACION", SqlDbType.Int).Value = a.usuarioId;
                    cmd.Parameters.Add("@FECHA_RESPUESTA", SqlDbType.VarChar).Value = a.fechaRespuesta;
                    cmd.Parameters.Add("@MENSAJE_RESPUESTA", SqlDbType.VarChar).Value = a.observacion;
                    cmd.Parameters.Add("@TIPO_INTERFAZ", SqlDbType.VarChar).Value = a.tipoInterfaz;
                    cmd.Parameters.Add("@ID_MEDICO", SqlDbType.Int).Value = a.medicoId;
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        m = new Mensaje();
                        while (dr.Read())
                        {
                            m.mensaje = "Enviado";
                            m.codigoRetorno = dr.GetInt32(0);
                            m.codigoBase = a.actividadId;
                        }
                    }
                    con.Close();
                    return m;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Mensaje SaveMedico(SolMedico a)
        {
            try
            {
                Mensaje m = null;
                using (SqlConnection con = new SqlConnection(db))
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_PROY_M_SAVE_SOL_MEDICO_CAB";
                    cmd.Parameters.Add("@ID_SOL_MEDICO_CAB", SqlDbType.Int).Value = a.identity;
                    cmd.Parameters.Add("@MENSAJE_SOL_MEDICO_CAB", SqlDbType.VarChar).Value = a.mensajeSol;
                    cmd.Parameters.Add("@ESTADO", SqlDbType.Int).Value = a.estadoSol;
                    cmd.Parameters.Add("USUARIO_CREACION", SqlDbType.Int).Value = a.usuarioId;
                    cmd.Parameters.Add("@TIPO_INTERFAZ_SOL_MEDICO_CAB", SqlDbType.VarChar).Value = "M";
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        m = new Mensaje();
                        while (dr.Read())
                        {
                            m.mensaje = "Enviado";
                            m.codigoRetorno = dr.GetInt32(0);
                            m.codigoBase = a.solMedicoId;

                            List<MensajeDetalle> detalles = new List<MensajeDetalle>();
                            foreach (var x in a.medicos)
                            {
                                SqlCommand cmdDe2 = con.CreateCommand();
                                cmdDe2.CommandTimeout = 0;
                                cmdDe2.CommandType = CommandType.StoredProcedure;
                                cmdDe2.CommandText = "SP_PROY_M_GET_SOLDETALLE_ID";
                                cmdDe2.Parameters.Add("@solCabId", SqlDbType.Int).Value = m.codigoRetorno;
                                cmdDe2.Parameters.Add("@medicoId", SqlDbType.Int).Value = x.identity;
                                SqlDataReader drD2 = cmdDe2.ExecuteReader();
                                if (drD2.HasRows)
                                {
                                    while (drD2.Read())
                                    {
                                        SqlCommand cmdDe = con.CreateCommand();
                                        cmdDe.CommandTimeout = 0;
                                        cmdDe.CommandType = CommandType.StoredProcedure;
                                        cmdDe.CommandText = "SP_PROY_M_SAVE_SOL_MEDICO_DET";
                                        cmdDe.Parameters.Add("@ID_SOL_MEDICO_DET", SqlDbType.Int).Value = drD2.GetInt32(0);
                                        cmdDe.Parameters.Add("@ID_SOL_MEDICO_CAB", SqlDbType.Int).Value = m.codigoRetorno;
                                        cmdDe.Parameters.Add("@ID_MEDICO", SqlDbType.Int).Value = x.identity;
                                        cmdDe.Parameters.Add("@ESTADO_SOL_MEDICO_DET", SqlDbType.Int).Value = a.estadoSol;
                                        cmdDe.Parameters.Add("@USUARIO_CREACION", SqlDbType.Int).Value = a.usuarioId;
                                        cmdDe.ExecuteNonQuery();
                                    }
                                }
                                else
                                {
                                    SqlCommand cmdDe = con.CreateCommand();
                                    cmdDe.CommandTimeout = 0;
                                    cmdDe.CommandType = CommandType.StoredProcedure;
                                    cmdDe.CommandText = "SP_PROY_M_SAVE_SOL_MEDICO_DET";
                                    cmdDe.Parameters.Add("@ID_SOL_MEDICO_DET", SqlDbType.Int).Value = 0;
                                    cmdDe.Parameters.Add("@ID_SOL_MEDICO_CAB", SqlDbType.Int).Value = m.codigoRetorno;
                                    cmdDe.Parameters.Add("@ID_MEDICO", SqlDbType.Int).Value = x.identity;
                                    cmdDe.Parameters.Add("@ESTADO_SOL_MEDICO_DET", SqlDbType.Int).Value = 11;
                                    cmdDe.Parameters.Add("@USUARIO_CREACION", SqlDbType.Int).Value = a.usuarioId;
                                    cmdDe.ExecuteNonQuery();
                                }
                            }
                        }
                    }

                    con.Close();

                    return m;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Mensaje SaveMedicoCabecera(Medico x)
        {
            try
            {
                Mensaje m = null;
                using (SqlConnection con = new SqlConnection(db))
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_PROY_M_SAVE_MEDICOS";
                    cmd.Parameters.Add("@ID_MEDICO", SqlDbType.Int).Value = x.identity;
                    cmd.Parameters.Add("@ID_IDENTIFICADOR_MEDICO", SqlDbType.Int).Value = x.identificadorId;
                    cmd.Parameters.Add("@CMP_MEDICO", SqlDbType.VarChar).Value = x.cpmMedico;
                    cmd.Parameters.Add("@NOMBRES_MEDICO", SqlDbType.VarChar).Value = x.nombreMedico;
                    cmd.Parameters.Add("@APELLIDO_PATERNO_MEDICO", SqlDbType.VarChar).Value = x.apellidoP;
                    cmd.Parameters.Add("@APELLIDO_MATERNO_MEDICO", SqlDbType.VarChar).Value = x.apellidoM;
                    cmd.Parameters.Add("@ID_CATEGORIA", SqlDbType.Int).Value = x.categoriaId;
                    cmd.Parameters.Add("@ID_ESPECIALIDAD1", SqlDbType.Int).Value = x.especialidadId;
                    cmd.Parameters.Add("@ID_ESPECIALIDAD2", SqlDbType.Int).Value = x.especialidadId2;
                    cmd.Parameters.Add("@EMAIL_MEDICO", SqlDbType.VarChar).Value = x.email;
                    cmd.Parameters.Add("@FECHA_NACIMIENTO_MEDICO", SqlDbType.VarChar).Value = x.fechaNacimiento;
                    cmd.Parameters.Add("@SEXO_MEDICO", SqlDbType.VarChar).Value = x.sexo;
                    cmd.Parameters.Add("@TELEFONO_MEDICO", SqlDbType.VarChar).Value = x.telefono;
                    cmd.Parameters.Add("@ESTADO", SqlDbType.Int).Value = x.estado;
                    cmd.Parameters.Add("@USUARIO_CREACION", SqlDbType.Int).Value = x.usuarioId;
                    cmd.Parameters.Add("@TIPOVISITA", SqlDbType.Int).Value = x.tipoVisitaId;
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        m = new Mensaje();
                        while (dr.Read())
                        {
                            m.mensaje = dr.GetInt32(0) != 0 ? "Enviado" : dr.GetString(1);
                            m.codigoRetorno = dr.GetInt32(0);
                            m.codigoBase = x.medicoId;
                        }
                    }
                    con.Close();
                    return m;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Mensaje SaveMedicoDireccion(MedicoDireccion d)
        {
            try
            {
                Mensaje m = null;
                using (SqlConnection con = new SqlConnection(db))
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_PROY_M_SAVE_MEDICOS_DIRECCION";
                    cmd.Parameters.Add("@ID_MEDICOS_DIRECCION", SqlDbType.Int).Value = d.identityDetalle;
                    cmd.Parameters.Add("@ID_MEDICO", SqlDbType.Int).Value = d.identity;
                    cmd.Parameters.Add("@CODIGO_DEPARTAMENTO", SqlDbType.VarChar).Value = d.codigoDepartamento;
                    cmd.Parameters.Add("@CODIGO_PROVINCIA", SqlDbType.VarChar).Value = d.codigoProvincia;
                    cmd.Parameters.Add("@CODIGO_DISTRITO", SqlDbType.VarChar).Value = d.codigoDistrito;
                    cmd.Parameters.Add("@DIRECCION_MEDICO_DIRECCION", SqlDbType.VarChar).Value = d.direccion;
                    cmd.Parameters.Add("@REFERENCIA_MEDICO_DIRECCION", SqlDbType.VarChar).Value = d.referencia;
                    cmd.Parameters.Add("@ESTADO", SqlDbType.Int).Value = d.estado;
                    cmd.Parameters.Add("@USUARIO_CREACION", SqlDbType.Int).Value = d.usuarioId;
                    cmd.Parameters.Add("@INSTITUCION", SqlDbType.VarChar).Value = d.institucion;
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        m = new Mensaje();
                        while (dr.Read())
                        {
                            m.mensaje = "Enviado";
                            m.codigoRetorno = dr.GetInt32(0);
                            m.codigoBase = d.medicoDireccionId;
                        }
                    }
                    con.Close();
                    return m;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Mensaje SaveTargetAltaBaja(TargetCab a)
        {
            try
            {
                Mensaje m = null;
                using (SqlConnection con = new SqlConnection(db))
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_PROY_M_SAVE_TARGET_CAB";
                    cmd.Parameters.Add("@ID_TARGET_CAB", SqlDbType.Int).Value = a.identity;
                    cmd.Parameters.Add("@MENSAJE_TARGET_CAB", SqlDbType.VarChar).Value = "";
                    cmd.Parameters.Add("@TIPO_TARGET_CAB", SqlDbType.VarChar).Value = a.tipoTarget;
                    cmd.Parameters.Add("@FECHA_RESPUESTA_TARGET_CAB", SqlDbType.VarChar).Value = a.fechaSolicitud;
                    cmd.Parameters.Add("@MENSAJE_RESPUETA_TARGET_CAB", SqlDbType.VarChar).Value = "";
                    cmd.Parameters.Add("@USUARIO_RESPUESTA_TARGET_CAB", SqlDbType.Int).Value = a.usuarioId;
                    cmd.Parameters.Add("@ESTADO_TARGET_CAB", SqlDbType.Int).Value = a.estado;
                    cmd.Parameters.Add("@USUARIO_CREACION", SqlDbType.Int).Value = a.usuarioId;
                    cmd.Parameters.Add("@TIPO_INTERFAZ_TARGET_CAB", SqlDbType.VarChar).Value = "M";
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        m = new Mensaje();
                        while (dr.Read())
                        {
                            m.mensaje = "Enviado";
                            m.codigoRetorno = dr.GetInt32(0);
                            m.codigoBase = a.targetCabId;

                            List<MensajeDetalle> detalle = new List<MensajeDetalle>();
                            foreach (var x in a.detalle)
                            {
                                SqlCommand cmdE = con.CreateCommand();
                                cmdE.CommandTimeout = 0;
                                cmdE.CommandType = CommandType.StoredProcedure;
                                cmdE.CommandText = "SP_PROY_M_SAVE_TARGET_DET";
                                cmdE.Parameters.Add("@ID_TARGET_DET", SqlDbType.Int).Value = x.identity;
                                cmdE.Parameters.Add("@ID_TARGET_CAB", SqlDbType.Int).Value = m.codigoRetorno;
                                cmdE.Parameters.Add("@ID_USUARIO", SqlDbType.Int).Value = a.usuarioId;
                                cmdE.Parameters.Add("@ID_MEDICO", SqlDbType.Int).Value = x.medicoId;
                                cmdE.Parameters.Add("@NUMERO_CONTACTOS_TARGET_DET", SqlDbType.Int).Value = x.nroContacto;
                                cmdE.Parameters.Add("@MENSAJE_RESPUESTA_TARGET_DET", SqlDbType.VarChar).Value = "";
                                cmdE.Parameters.Add("@FECHA_RESPUESTA_TARGET_DET", SqlDbType.VarChar).Value = a.fechaSolicitud;
                                cmdE.Parameters.Add("@USUARIO_RESPUESTA_TARGET_DET", SqlDbType.Int).Value = a.usuarioId;
                                cmdE.Parameters.Add("@ESTADO_TARGET_DET", SqlDbType.Int).Value = x.estadoTarget; //16;
                                cmdE.Parameters.Add("@USUARIO_CREACION", SqlDbType.Int).Value = a.usuarioId;

                                SqlDataReader drE = cmdE.ExecuteReader();
                                if (drE.HasRows)
                                {
                                    while (drE.Read())
                                    {

                                        detalle.Add(new MensajeDetalle()
                                        {
                                            detalleBaseId = x.targetDetId,
                                            detalleRetornoId = drE.GetInt32(0)
                                        });
                                    }
                                }
                            }
                            m.detalle = detalle;
                        }
                    }
                    con.Close();
                }

                return m;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Mensaje SaveProgramacion(Programacion p)
        {
            try
            {
                Mensaje m = null;
                using (SqlConnection con = new SqlConnection(db))
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_PROY_M_SAVE_PROGRAMACION_CAB";
                    cmd.Parameters.Add("@ID_PROGRAMACION_CAB", SqlDbType.Int).Value = p.identity;
                    cmd.Parameters.Add("@ID_MEDICOS_DIRECCION", SqlDbType.Int).Value = p.direccionId;
                    cmd.Parameters.Add("@FECHA_PROGRAMACION_PROGRAMACION_CAB", SqlDbType.VarChar).Value = p.fechaProgramacion;
                    cmd.Parameters.Add("@HORA_PROGRAMACION_PROGRAMACION_CAB", SqlDbType.VarChar).Value = p.horaProgramacion;
                    cmd.Parameters.Add("@FECHA_REPORTE_PROGRAMACION_CAB", SqlDbType.VarChar).Value = p.fechaReporteProgramacion;
                    cmd.Parameters.Add("@HORA_REPORTE_PROGRAMACION_CAB", SqlDbType.VarChar).Value = p.horaReporteProgramacion;
                    cmd.Parameters.Add("@ID_RESULTADO_VISITA", SqlDbType.Int).Value = p.resultadoVisitaId;
                    cmd.Parameters.Add("@VISITA_ACOMPANIADA_PROGRAMACION_CAB", SqlDbType.VarChar).Value = p.visitaAcompanada;
                    cmd.Parameters.Add("@DATOS_ACOMPANIANTE_PROGRAMACION_CAB", SqlDbType.VarChar).Value = p.dataAcompaniante;
                    cmd.Parameters.Add("@LATITUD_PROGRAMACION_CAB", SqlDbType.VarChar).Value = p.latitud;
                    cmd.Parameters.Add("@LONGITUD_PROGRAMACION_CAB", SqlDbType.VarChar).Value = p.longitud;
                    cmd.Parameters.Add("@ESTADO_PROGRAMACION_CAB", SqlDbType.Int).Value = p.estadoProgramacion;
                    cmd.Parameters.Add("@USUARIO_EDICION", SqlDbType.Int).Value = p.usuarioId;
                    cmd.Parameters.Add("@TIPO_INTERFAZ_PROGRAMACION_CAB", SqlDbType.VarChar).Value = "M";
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        m = new Mensaje();
                        while (dr.Read())
                        {
                            m.mensaje = "Enviado";
                            m.codigoRetorno = dr.GetInt32(0);
                            m.codigoBase = p.programacionId;

                            //List<MensajeDetalle> detalle = new List<MensajeDetalle>();
                            //foreach (var x in p.productos)
                            //{
                            //    SqlCommand cmdE = con.CreateCommand();
                            //    cmdE.CommandTimeout = 0;
                            //    cmdE.CommandType = CommandType.StoredProcedure;
                            //    cmdE.CommandText = "SP_PROY_M_SAVE_PROGRAMACION_DET";
                            //    cmdE.Parameters.Add("@ID_PROGRAMACION_DET", SqlDbType.Int).Value = x.identity;
                            //    cmdE.Parameters.Add("@ID_PROGRAMACION_CAB", SqlDbType.Int).Value = m.codigoRetorno;
                            //    cmdE.Parameters.Add("@ID_PRODUCTO", SqlDbType.Int).Value = x.productoId;
                            //    cmdE.Parameters.Add("@LOTE_PROGRAMACION_DET", SqlDbType.VarChar).Value = x.lote;
                            //    cmdE.Parameters.Add("@CANTIDAD_PROGRAMACION_DET", SqlDbType.Int).Value = x.cantidad;
                            //    cmdE.Parameters.Add("@ORDEN_PROGRAMACION_DET", SqlDbType.Int).Value = x.ordenProgramacion;
                            //    SqlDataReader drE = cmdE.ExecuteReader();
                            //    if (drE.HasRows)
                            //    {
                            //        while (drE.Read())
                            //        {
                            //            detalle.Add(new MensajeDetalle()
                            //            {
                            //                detalleBaseId = x.programacionDetId,
                            //                detalleRetornoId = drE.GetInt32(0)
                            //            });
                            //        }
                            //    }
                            //}
                            //m.detalle = detalle;
                        }
                    }
                    con.Close();
                }

                return m;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Mensaje SaveProgramacionDet(ProgramacionDet x)
        {
            try
            {
                Mensaje m = null;
                using (SqlConnection con = new SqlConnection(db))
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_PROY_M_SAVE_PROGRAMACION_DET";
                    cmd.Parameters.Add("@ID_PROGRAMACION_DET", SqlDbType.Int).Value = x.identity;
                    cmd.Parameters.Add("@ID_PROGRAMACION_CAB", SqlDbType.Int).Value = x.programacionId;
                    cmd.Parameters.Add("@ID_PRODUCTO", SqlDbType.Int).Value = x.productoId;
                    cmd.Parameters.Add("@LOTE_PROGRAMACION_DET", SqlDbType.VarChar).Value = x.lote;
                    cmd.Parameters.Add("@CANTIDAD_PROGRAMACION_DET", SqlDbType.Int).Value = x.cantidad;
                    cmd.Parameters.Add("@ORDEN_PROGRAMACION_DET", SqlDbType.Int).Value = x.ordenProgramacion;
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        m = new Mensaje();
                        while (dr.Read())
                        {
                            m.mensaje = "Enviado";
                            m.codigoRetorno = dr.GetInt32(0);
                            m.codigoBase = x.programacionDetId;
                        }
                    }
                    con.Close();
                }

                return m;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Mensaje DeleteProgramacionDet(int id)
        {
            try
            {
                Mensaje m = null;
                using (SqlConnection con = new SqlConnection(db))
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_PROY_M_DELETE_PROGRAMACION_DET";
                    cmd.Parameters.Add("@ID_PROGRAMACION_DET", SqlDbType.Int).Value = id;
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        m = new Mensaje();
                        while (dr.Read())
                        {
                            m.mensaje = "Eliminado";
                            m.codigoBase = id;
                        }
                    }
                    con.Close();
                }

                return m;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Mensaje SavePuntoContacto(PuntoContacto p)
        {
            try
            {
                Mensaje m = null;
                using (SqlConnection con = new SqlConnection(db))
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_PROY_M_SAVE_PUNTOS_CONTACTO";
                    cmd.Parameters.Add("@id_puntos_contacto", SqlDbType.Int).Value = p.puntoContactoId;
                    cmd.Parameters.Add("@latitud_punto_contacto", SqlDbType.VarChar).Value = p.latitud;
                    cmd.Parameters.Add("@longitud_punto_contacto", SqlDbType.VarChar).Value = p.longitud;
                    cmd.Parameters.Add("@usuario_edicion", SqlDbType.Int).Value = p.usuarioId;

                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        m = new Mensaje();
                        while (dr.Read())
                        {
                            m.mensaje = "Actualizado";
                            m.codigoBase = p.puntoContactoId;

                        }
                    }
                    con.Close();
                }

                return m;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Mensaje SaveNuevaDireccion(NuevaDireccion n)
        {
            try
            {
                Mensaje m = null;
                using (SqlConnection con = new SqlConnection(db))
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_PROY_M_SAVE_MEDICOS_DIRECCION";
                    cmd.Parameters.Add("@ID_MEDICOS_DIRECCION", SqlDbType.Int).Value = n.medicoDireccionId;
                    cmd.Parameters.Add("@ID_MEDICO", SqlDbType.Int).Value = n.medicoId;
                    cmd.Parameters.Add("@CODIGO_DEPARTAMENTO", SqlDbType.VarChar).Value = n.codigoDepartamento;
                    cmd.Parameters.Add("@CODIGO_PROVINCIA", SqlDbType.VarChar).Value = n.codigoProvincia;
                    cmd.Parameters.Add("@CODIGO_DISTRITO", SqlDbType.VarChar).Value = n.codigoDistrito;
                    cmd.Parameters.Add("@DIRECCION_MEDICO_DIRECCION", SqlDbType.VarChar).Value = n.nombreDireccion;
                    cmd.Parameters.Add("@REFERENCIA_MEDICO_DIRECCION", SqlDbType.VarChar).Value = n.referencia;
                    cmd.Parameters.Add("@ESTADO", SqlDbType.Int).Value = n.estadoId;
                    cmd.Parameters.Add("@USUARIO_CREACION", SqlDbType.Int).Value = n.usuarioId;
                    cmd.Parameters.Add("@INSTITUCION", SqlDbType.VarChar).Value = n.nombreInstitucion;
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        m = new Mensaje();
                        while (dr.Read())
                        {
                            m.mensaje = "Enviado";
                            m.codigoAlterno = dr.GetInt32(0);
                            SqlCommand cmdE = con.CreateCommand();
                            cmdE.CommandTimeout = 0;
                            cmdE.CommandType = CommandType.StoredProcedure;
                            cmdE.CommandText = "SP_PROY_M_SAVE_SOL_MEDICOS_DIRECCION";
                            cmdE.Parameters.Add("@ID_SOL_MEDICO_DIRECCION", SqlDbType.Int).Value = n.identity;
                            cmdE.Parameters.Add("@ID_MEDICOS_DIRECCION", SqlDbType.Int).Value = m.codigoAlterno;
                            cmdE.Parameters.Add("@ESTADO", SqlDbType.Int).Value = n.estadoId;
                            cmdE.Parameters.Add("@USUARIO_CREACION", SqlDbType.Int).Value = n.usuarioId;
                            cmdE.Parameters.Add("@MENSAJE_RESPUESTA_SOL_MEDICO_DIRECCION", SqlDbType.VarChar).Value = n.observacion;
                            cmdE.Parameters.Add("@TIPO_INTERFAZ", SqlDbType.VarChar).Value = "M";
                            SqlDataReader drE = cmdE.ExecuteReader();
                            if (drE.HasRows)
                            {
                                while (drE.Read())
                                {
                                    m.codigoRetorno = drE.GetInt32(0);
                                    m.codigoBase = n.solDireccionId;
                                }
                            }
                        }
                    }
                    con.Close();
                }

                return m;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Mensaje VerificateLogin(string login)
        {
            try
            {
                Mensaje m = null;

                using (SqlConnection con = new SqlConnection(db))
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_PROY_M_VERIFICATE_USUARIO";
                    cmd.Parameters.Add("@login", SqlDbType.Int).Value = login;
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            if (dr.GetInt32(0) == 0)
                            {
                                m = new Mensaje();
                                m.mensaje = "No existe";
                                m.codigoRetorno = dr.GetInt32(0);
                            }
                        }
                    }
                    con.Close();
                    return m;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Mensaje SaveUsuario(Personal u)
        {
            try
            {
                Mensaje m = null;

                using (SqlConnection con = new SqlConnection(db))
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_PROY_M_SAVE_USUARIOS";
                    cmd.Parameters.Add("@usuarioId", SqlDbType.Int).Value = u.personalId;
                    cmd.Parameters.Add("@nrodoc", SqlDbType.VarChar).Value = u.nroDoc;
                    cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = u.email;
                    cmd.Parameters.Add("@id_perfil", SqlDbType.Int).Value = u.perfilId;

                    cmd.Parameters.Add("@login", SqlDbType.VarChar).Value = u.login;
                    cmd.Parameters.Add("@pass", SqlDbType.VarChar).Value = u.pass;
                    cmd.Parameters.Add("@estado", SqlDbType.Int).Value = u.estado;

                    cmd.Parameters.Add("@usuario_creacion", SqlDbType.Int).Value = u.usuarioId;
                    cmd.Parameters.Add("@apellido_paterno", SqlDbType.VarChar).Value = u.apellidoP;
                    cmd.Parameters.Add("@apellido_materno", SqlDbType.VarChar).Value = u.apellidoM;
                    cmd.Parameters.Add("@nombres", SqlDbType.VarChar).Value = u.nombre;
                    cmd.Parameters.Add("@celular", SqlDbType.VarChar).Value = u.celular;
                    cmd.Parameters.Add("@fecha_nacimiento", SqlDbType.VarChar).Value = u.fechaNacimiento;
                    cmd.Parameters.Add("@sexo", SqlDbType.VarChar).Value = u.sexo;
                    cmd.Parameters.Add("@id_supervisor", SqlDbType.Int).Value = u.supervisorId;
                    cmd.Parameters.Add("@es_supervisor", SqlDbType.Int).Value = u.esSupervisorId;
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        m = new Mensaje();
                        while (dr.Read())
                        {
                            m.mensaje = "Enviado";
                            m.codigoRetorno = dr.GetInt32(0);
                            m.codigoBase = u.personalId;
                        }
                    }
                    con.Close();
                    return m;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Mensaje UpdateUsuario(Usuario u)
        {
            try
            {
                Mensaje m = null;

                using (SqlConnection con = new SqlConnection(db))
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_PROY_M_UPDATE_LOGIN";
                    cmd.Parameters.Add("@usuarioId", SqlDbType.Int).Value = u.usuarioId;
                    cmd.Parameters.Add("@nrodoc", SqlDbType.VarChar).Value = u.nroDoc;
                    cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = u.email;
                    cmd.Parameters.Add("@id_perfil", SqlDbType.Int).Value = u.perfilId;
                    cmd.Parameters.Add("@fotourl", SqlDbType.VarChar).Value = u.foto;

                    cmd.Parameters.Add("@login", SqlDbType.VarChar).Value = u.login;
                    cmd.Parameters.Add("@pass", SqlDbType.VarChar).Value = u.pass;
                    cmd.Parameters.Add("@estado", SqlDbType.Int).Value = u.estado;

                    cmd.Parameters.Add("@usuario_creacion", SqlDbType.Int).Value = u.usuarioId;
                    cmd.Parameters.Add("@apellido_paterno", SqlDbType.VarChar).Value = u.apellidoP;
                    cmd.Parameters.Add("@apellido_materno", SqlDbType.VarChar).Value = u.apellidoM;
                    cmd.Parameters.Add("@nombres", SqlDbType.VarChar).Value = u.nombre;
                    cmd.Parameters.Add("@celular", SqlDbType.VarChar).Value = u.celular;
                    cmd.Parameters.Add("@fecha_nacimiento", SqlDbType.VarChar).Value = u.fechaNacimiento;
                    cmd.Parameters.Add("@sexo", SqlDbType.VarChar).Value = u.sexo;
                    cmd.Parameters.Add("@id_supervisor", SqlDbType.Int).Value = u.supervisorId;
                    cmd.Parameters.Add("@es_supervisor", SqlDbType.Int).Value = u.esSupervisorId;
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        m = new Mensaje();
                        while (dr.Read())
                        {
                            m.mensaje = "Enviado";
                            m.codigoRetorno = dr.GetInt32(0);
                            m.codigoBase = u.usuarioId;
                        }
                    }
                    con.Close();
                    return m;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Mensaje GetAlertaActividades(int cicloId, int medicoId, int usuarioId)
        {
            try
            {
                Mensaje m = null;

                using (SqlConnection con = new SqlConnection(db))
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_PROY_W_MANT_ACTIVIDADES_ALERTAS";
                    cmd.Parameters.Add("@idCiclo", SqlDbType.Int).Value = cicloId;
                    cmd.Parameters.Add("@idMedico", SqlDbType.Int).Value = medicoId;
                    cmd.Parameters.Add("@idUsuario", SqlDbType.Int).Value = usuarioId;
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        m = new Mensaje();
                        while (dr.Read())
                        {
                            m.mensaje = dr.GetString(0);
                        }
                    }
                    con.Close();
                    return m;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*
         tipo 
        1-> actividad
        2-> aprobacion actividad
        3-> solicitud de medico
        4-> aprobacion solicitud de medico
        5-> direccion medico
        6-> aprobacion direccion medico
        7-> altas o bajas
        8-> aprobacion altas o bajas
         */
        public static Email GetEmail(int codigoRetorno, int usuarioId, int tipo, string estado)
        {
            try
            {
                Email m = null;
                using (SqlConnection con = new SqlConnection(db))
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;

                    switch (tipo)
                    {
                        case 1:
                            cmd.CommandText = "SP_PROY_W_PROC_ACTIVIDADES_ENVIAR_CORREO";
                            cmd.Parameters.Add("@idActividad", SqlDbType.Int).Value = codigoRetorno;
                            cmd.Parameters.Add("@idusuario", SqlDbType.Int).Value = usuarioId;
                            break;
                        case 2:
                            cmd.CommandText = "SP_PROY_W_PROC_APROBAR_ACTIVIDADES_ENVIAR_CORREO";
                            cmd.Parameters.Add("@idActividad", SqlDbType.Int).Value = codigoRetorno;
                            cmd.Parameters.Add("@idusuario", SqlDbType.Int).Value = usuarioId;
                            cmd.Parameters.Add("@proceso ", SqlDbType.VarChar).Value = estado;
                            break;
                        case 3:
                            cmd.CommandText = "SP_PROY_W_PROC_SOLICITUD_MEDICO_ENVIAR_CORREO";
                            cmd.Parameters.Add("@idSolCab", SqlDbType.Int).Value = codigoRetorno;
                            cmd.Parameters.Add("@idusuario", SqlDbType.Int).Value = usuarioId;
                            break;
                        case 4:
                            cmd.CommandText = "SP_PROY_W_PROC_APROBAR_SOLICITUD_MEDICO_ENVIAR_CORREO";
                            cmd.Parameters.Add("@id_SolMedicodet", SqlDbType.Int).Value = codigoRetorno;
                            cmd.Parameters.Add("@idusuario", SqlDbType.Int).Value = usuarioId;
                            break;
                        case 5:
                            cmd.CommandText = "SP_PROY_W_PROC_SOL_DIRECCION_MEDICO_ENVIAR_CORREO";
                            cmd.Parameters.Add("@idSolMedico_Direccion", SqlDbType.Int).Value = codigoRetorno;
                            cmd.Parameters.Add("@idusuario", SqlDbType.Int).Value = usuarioId;
                            break;
                        case 6:
                            cmd.CommandText = "SP_PROY_W_PROC_APROBAR_SOL_DIRECCION_MEDICO_ENVIAR_CORREO";
                            cmd.Parameters.Add("@idSolMedico_Direccion", SqlDbType.Int).Value = codigoRetorno;
                            cmd.Parameters.Add("@idusuario", SqlDbType.Int).Value = usuarioId;
                            break;
                        case 7:
                            cmd.CommandText = "SP_PROY_W_PROC_ALTA_BAJA_TARGET_ENVIAR_CORREO";
                            cmd.Parameters.Add("@idTargetCab", SqlDbType.Int).Value = codigoRetorno;
                            cmd.Parameters.Add("@opcionTarget", SqlDbType.VarChar).Value = estado;
                            cmd.Parameters.Add("@idusuario", SqlDbType.Int).Value = usuarioId;
                            break;
                        case 8:
                            cmd.CommandText = "SP_PROY_W_PROC_APROBAR_ALTA_BAJA_TARGET_ENVIAR_CORREO";
                            cmd.Parameters.Add("@idTargetCab", SqlDbType.Int).Value = codigoRetorno;
                            cmd.Parameters.Add("@opcionTarget", SqlDbType.VarChar).Value = estado;
                            cmd.Parameters.Add("@idusuario", SqlDbType.Int).Value = usuarioId;
                            break;
                    }
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        m = new Email();
                        while (dr.Read())
                        {
                            m.remitente = dr.GetString(0);
                            m.remitentePass = dr.GetString(1);
                            m.destinatario = dr.GetString(2);
                            m.copiaDestinatario = dr.GetString(3);
                            m.asunto = dr.GetString(4);
                            m.cuerpoMensaje = dr.GetString(5);
                        }
                    }
                    con.Close();

                    return m;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static Mensaje GetVerificateVisitaMedico(int medicoId, string fecha)
        {
            try
            {
                Mensaje m = null;

                using (SqlConnection con = new SqlConnection(db))
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_PROY_W_PROC_VERIFICA_VISITA_MEDICO";
                    cmd.Parameters.Add("@id_medico", SqlDbType.Int).Value = medicoId;
                    cmd.Parameters.Add("@fecha_reporte", SqlDbType.VarChar).Value = fecha;
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        m = new Mensaje
                        {
                            mensaje = "Medico ya fue visitado en la fecha de reporte."
                        };
                    }
                    con.Close();
                    return m;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        // reporte

        public static List<RptGeneral> Rpt_RRMM_RESUMEN_GENERAL(int cicloId, int usuarioId)
        {

            try
            {
                List<RptGeneral> e = null;
                using (SqlConnection con = new SqlConnection(db))
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_PROY_M_RPT_RRMM_RESUMEN_GENERAL";
                    cmd.Parameters.Add("@id_ciclo", SqlDbType.Int).Value = cicloId;
                    cmd.Parameters.Add("@id_usuario", SqlDbType.Int).Value = usuarioId;
                    SqlDataReader dr1 = cmd.ExecuteReader();
                    if (dr1.HasRows)
                    {
                        e = new List<RptGeneral>();
                        while (dr1.Read())
                        {
                            e.Add(new RptGeneral()
                            {
                                usuarioId = dr1.GetInt32(0),
                                representanteMedico = dr1.GetString(1),
                                nombreCiclo = dr1.GetString(2),
                                fechaInicioCiclo = dr1.GetString(3),
                                fechaFinCiclo = dr1.GetString(4),
                                fechaActual = dr1.GetString(5),
                                diasCicloMes = dr1.GetInt32(6),
                                diasFecha = dr1.GetInt32(7),
                                accion = dr1.GetString(8),
                                cuotaMes = Convert.ToInt32(dr1.GetDecimal(9)),
                                numeroVisita = dr1.GetInt32(10),
                                porcentajeMes = Convert.ToInt32(dr1.GetDecimal(11)),
                                saldoMes = Convert.ToInt32(dr1.GetDecimal(12)),
                                cuotaFecha = Convert.ToInt32(dr1.GetDecimal(13)),
                                porcentajeFecha = Convert.ToInt32(dr1.GetDecimal(14)),
                                saldoFecha = Convert.ToInt32(dr1.GetDecimal(15))
                            });
                        }
                    }
                    con.Close();
                }
                return e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static List<RptDiario> Rpt_RRMM_RESUMEN_DIARIO(int cicloId, int usuarioId)
        {

            try
            {
                List<RptDiario> e = null;
                using (SqlConnection con = new SqlConnection(db))
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_PROY_M_RPT_RRMM_RESUMEN_DIARIO";
                    cmd.Parameters.Add("@id_ciclo", SqlDbType.Int).Value = cicloId;
                    cmd.Parameters.Add("@id_usuario", SqlDbType.Int).Value = usuarioId;
                    SqlDataReader dr1 = cmd.ExecuteReader();
                    if (dr1.HasRows)
                    {
                        e = new List<RptDiario>();
                        while (dr1.Read())
                        {
                            e.Add(new RptDiario()
                            {
                                nombreCiclo = dr1.GetString(0),
                                fechaInicioCiclo = dr1.GetString(1),
                                fechaFinCiclo = dr1.GetString(2),
                                fechaActual = dr1.GetString(3),
                                diasCicloMes = dr1.GetInt32(4),
                                diasFecha = dr1.GetInt32(5),
                                usuarioId = dr1.GetInt32(6),
                                representanteMedico = dr1.GetString(7),
                                cuota = dr1.GetString(8),
                                frecuencia = Convert.ToInt32(dr1.GetDecimal(9)),
                                cobertura = Convert.ToInt32(dr1.GetDecimal(10))
                            });
                        }
                    }
                    con.Close();
                }
                return e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static List<RptGeneral> Rpt_SUP_RESUMEN_GENERAL(int cicloId, int usuarioId)
        {

            try
            {
                List<RptGeneral> e = null;
                using (SqlConnection con = new SqlConnection(db))
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_PROY_M_RPT_SUP_RESUMEN_GENERAL";
                    cmd.Parameters.Add("@id_ciclo", SqlDbType.Int).Value = cicloId;
                    cmd.Parameters.Add("@id_supervisor", SqlDbType.Int).Value = usuarioId;
                    SqlDataReader dr1 = cmd.ExecuteReader();
                    if (dr1.HasRows)
                    {
                        e = new List<RptGeneral>();
                        while (dr1.Read())
                        {
                            e.Add(new RptGeneral()
                            {
                                usuarioId = dr1.GetInt32(0),
                                representanteMedico = dr1.GetString(1),
                                nombreCiclo = dr1.GetString(2),
                                fechaInicioCiclo = dr1.GetString(3),
                                fechaFinCiclo = dr1.GetString(4),
                                fechaActual = dr1.GetString(5),
                                diasCicloMes = dr1.GetInt32(6),
                                diasFecha = dr1.GetInt32(7),
                                accion = dr1.GetString(8),
                                cuotaMes = Convert.ToInt32(dr1.GetDecimal(9)),
                                numeroVisita = dr1.GetInt32(10),
                                porcentajeMes = Convert.ToInt32(dr1.GetDecimal(11)),
                                saldoMes = Convert.ToInt32(dr1.GetDecimal(12)),
                                cuotaFecha = Convert.ToInt32(dr1.GetDecimal(13)),
                                porcentajeFecha = Convert.ToInt32(dr1.GetDecimal(14)),
                                saldoFecha = Convert.ToInt32(dr1.GetDecimal(15))
                            });
                        }
                    }
                    con.Close();
                }
                return e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static List<RptDiario> Rpt_SUP_RESUMEN_DIARIO(int cicloId, int usuarioId)
        {

            try
            {
                List<RptDiario> e = null;
                using (SqlConnection con = new SqlConnection(db))
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_PROY_M_RPT_SUP_RESUMEN_DIARIO";
                    cmd.Parameters.Add("@id_ciclo", SqlDbType.Int).Value = cicloId;
                    cmd.Parameters.Add("@id_supervisor", SqlDbType.Int).Value = usuarioId;
                    SqlDataReader dr1 = cmd.ExecuteReader();
                    if (dr1.HasRows)
                    {
                        e = new List<RptDiario>();
                        while (dr1.Read())
                        {
                            e.Add(new RptDiario()
                            {
                                nombreCiclo = dr1.GetString(0),
                                fechaInicioCiclo = dr1.GetString(1),
                                fechaFinCiclo = dr1.GetString(2),
                                fechaActual = dr1.GetString(3),
                                diasCicloMes = dr1.GetInt32(4),
                                diasFecha = dr1.GetInt32(5),
                                usuarioId = dr1.GetInt32(6),
                                representanteMedico = dr1.GetString(7),
                                cuota = dr1.GetString(8),
                                frecuencia = Convert.ToInt32(dr1.GetDecimal(9)),
                                cobertura = Convert.ToInt32(dr1.GetDecimal(10))
                            });
                        }
                    }
                    con.Close();
                }
                return e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}