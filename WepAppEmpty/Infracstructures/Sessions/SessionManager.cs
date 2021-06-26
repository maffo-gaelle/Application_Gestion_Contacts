using Microsoft.AspNetCore.Http;
using Model.Client.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace WepAppEmpty.Infracstructures.Sessions
{
    //Va contenir nos variables sessions
    public class SessionManager : ISessionManager
    {
        //Recupère la session du startup(http context)
        private readonly ISession _session;


        public SessionManager(IHttpContextAccessor httpContextAccessor)
        {
            _session = httpContextAccessor.HttpContext.Session;
        }

        //Les variables de session ne peubent être que de 3 types
        public UserSession User
        {
            get
            {
                string json = _session.GetString(nameof(User));
                //convertir notre chaîne de carctère en user. Le deserialisateur ne peut pas retourner un user
                return (json is null) ? null : JsonSerializer.Deserialize<UserSession>(json);
            }
            set
            {//La difference entre une chaîne de caract-=ère et un nameof: la chaine de caractère n'est pas vérifée à la compilation tandis que le nameof est vérifié à a compilation
                //_session.SetString("email", user.Email);
                //Suivre l'enregistrement!
                _session.SetString(nameof(User), JsonSerializer.Serialize(value));
            }
        }

        public void Clear()
        {
            _session.Clear();
        }
    }
}
