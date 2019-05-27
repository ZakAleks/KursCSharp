﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MantisTests
{
    public class AccauntData
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public AccauntData()
        {
        }

        public AccauntData(string username, string password, string email)
        {
            Username = username;
            Password = password;
            Email = email;
        }

        public static AccauntData GetAdminAccaunt()
        {
            AccauntData admin = new AccauntData()
            {
                Username = "administrator",
                Password = "root",
                Email = "testuser@localhost.localdomain"
            };

            return admin;
        }

    }
}
