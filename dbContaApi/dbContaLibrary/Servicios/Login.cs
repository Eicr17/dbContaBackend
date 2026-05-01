using dbContaLibrary.Interfaces;
using dbContaLibrary.Modelos;
using dbContaLibrary.Servicios;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace dbContaLibrary.Servicios
{
    public class Login : ILogin 
    {
        private readonly IAPPConfiguracion _config;
        private readonly IUsuario usuario;

        public Login(IAPPConfiguracion pConfig, IUsuario _user)
        {
            _config = pConfig;
            usuario = _user;
        }


        public MdUser ValidarUsuario(MdlLogin pLogin)
        {
            var UsuarioDb = usuario.GetUsuario(pLogin.UserId).FirstOrDefault();

                if (UsuarioDb == null)
                {
                    throw new Exception("El Usuario No Existe");
                }

                bool PasswordCorrecto = BCrypt.Net.BCrypt.Verify(
                        pLogin.Password.Trim(),
                        UsuarioDb.Password.Trim()
                    );

                
                if (PasswordCorrecto)
                {
                    return new MdUser
                    {
                        IdUsuario = UsuarioDb.IdUsuario,
                        NombreUsuario = UsuarioDb.NombreUsuario,
                        Email = UsuarioDb.Email,
                    };
                }
                
                return null;
        }
    }
}
