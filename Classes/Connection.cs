using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ПР43_Осокин.Classes
{
    public class Connection
    {
        public static readonly string connection = "server=localhost;uid=root;database=pr43;";
        public static readonly MySqlServerVersion version = new MySqlServerVersion(new Version(8, 0, 11));
    }
}
