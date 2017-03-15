using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Xml.Linq;

namespace IIProjectClient.Models
{
    public class User
    {
        [Required]
        public string username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }

        public bool rememberMe { get; set; }

        public bool IsValid(string uname, string pword)
        {
            XElement userList = XElement.Load(HostingEnvironment.MapPath("/App_Data/") + "users.xml");

            foreach (var Element in userList.Elements("user"))
            {
                if (Element.Element("username").Value.Equals(uname) && Element.Element("password").Value.Equals(pword))
                {
                    return true;
                }
            }
            return false;

        }

    }
}