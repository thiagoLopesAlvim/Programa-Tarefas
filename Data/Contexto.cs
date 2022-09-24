using Microsoft.EntityFrameworkCore;
using programa_consultorio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace programa_consultorio.Data
{
    public class Contexto : DbContext
    {

        public Contexto(DbContextOptions<Contexto> options)
            : base(options)
        { }


        public DbSet<Tarefas> Tarefas { get; set; }


    }
}