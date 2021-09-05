using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ApiPackExpress.Helpers
{
    public class HelpersFunctions
    {
        public static int getIdUser(List<Claim> claims)
        {
            var user = claims.First(c => c.Type == "Id");
            int id = Int32.Parse(user.Value);
            
            return id;
        }
        public static bool isAdmin(List<Claim> claims)
        {
            var isAdmin = claims.Any(x => x.Type == "Rol" && x.Value == ((int) ERole.Admin).ToString());
            return isAdmin;        
        }

        public static string generateUsername(string name, string lastname)
        {
            //Eliminar tildes
            name = Regex.Replace(name.Normalize(System.Text.NormalizationForm.FormD), @"[^a-zA-z0-9 ]+", "");
            lastname = Regex.Replace(lastname.Normalize(System.Text.NormalizationForm.FormD), @"[^a-zA-z0-9 ]+", "");
            
            string username = string.Empty; // Acá se almacena el username que se va a generar
            Random rnd = new Random();
            int random = rnd.Next(1, 7);

            string[] namesArray = name.Split(" ");
            string[] lastNamesArray = lastname.Split(" ");

            switch (random)
            {
                case 1:
                    username = namesArray[0].Substring(0, 1);
                    username += lastNamesArray[0];
                    break;

                case 2:
                    username = namesArray[0].Substring(0, 1);
                    username += "_" + lastNamesArray[0];
                    break;
                case 3:
                    username = namesArray[0].Substring(0, 1);
                    username += "." + lastNamesArray[0];
                    break;

                case 4:
                    username = namesArray[0] + "_" + lastNamesArray[0];
                    break;

                case 5:
                    username = namesArray[0] + "." + lastNamesArray[0];
                    break;
                case 6:
                    if (namesArray.Length > 1 && lastNamesArray.Length > 1)
                    {
                        username = namesArray[0].Substring(0, 1) + lastNamesArray[0] + lastNamesArray[1].Substring(0, 1);
                    }
                    else
                    {
                        username = lastNamesArray[0] + "." + namesArray[0];
                    }
                    break;
            }

            return username.ToLower();
        }

    }
}
