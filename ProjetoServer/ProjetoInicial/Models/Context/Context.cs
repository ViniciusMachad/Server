using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ProjetoInicial.Models.Context
{
    public class Context : DbContext
    {
        public Context() : base("strConn")
        {
        }

        public System.Data.Entity.DbSet<ProjetoInicial.Models.Modelos> Modelos { get; set; }
    }
}