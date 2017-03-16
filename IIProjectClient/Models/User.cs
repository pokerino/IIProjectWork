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
        XElement userList = XElement.Load(HostingEnvironment.MapPath("/App_Data/") + "users.xml");
        
        [Required]
        public string username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }

        public bool rememberMe { get; set; }

        public bool IsValid(string uname, string pword)
        {
            foreach (var Element in userList.Elements("user"))
            {
                if (Element.Element("username").Value.Equals(uname) && Element.Element("password").Value.Equals(pword))
                {
                    return true;
                }
            }
            return false;

        }

        public User getUser(string uname)
        {
            foreach (var Element in userList.Elements("user"))
            {
                if (Element.Element("username").Value.Equals(uname))
                {
                    User user = new User();
                    user.username = Element.Element("username").Value;
                    user.password = Element.Element("password").Value;
                    return user;
                }
            }
            return null;
        }

        public bool modifieUser(User user, string pword, string oldName)
        {
            if (user.username != oldName && userList.Elements("user").Count(u => u.Element("username").Value.Equals(user.username)) > 0)
            {
                return false;
            }
            else
            {
                foreach (var Element in userList.Elements("user"))
                {
                    if (Element.Element("username").Value.Equals(oldName) && Element.Element("password").Value.Equals(pword))
                    {
                        userList.Elements("user").First(n => n.Element("username").Value.Equals(oldName)).ReplaceWith(new XElement("user",
                            new XElement("username", user.username),
                            new XElement("password", user.password)));
                        userList.Save(HostingEnvironment.MapPath("/App_Data/") + "users.xml");
                        return true;
                    }
                }
                return false;
            }
        }

        public bool registerNewUser(User user)
        {
            if (userList.Elements("user").Count(u => u.Element("username").Value.Equals(user.username)) < 1)
            {
                userList.Add(new XElement("user",
                    new XElement("username", user.username),
                    new XElement("password", user.password)));
                userList.Save(HostingEnvironment.MapPath("/App_Data/") + "users.xml");
                return true;
            }
            return false;
        }
    }
}