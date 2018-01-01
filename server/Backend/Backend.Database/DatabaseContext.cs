﻿using System;
using System.Collections.Generic;
using System.Text;
using Backend.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Database
{
    public class DatabaseContext : DbContext
    {

        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }



        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Colaborador> Colaboradores { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Colaborador>()
                .HasKey(x => new { x.EmpresaId, x.PessoaId});

            modelBuilder.Entity<Colaborador>()
                .HasOne(bc => bc.Pessoa)
                .WithMany(b => b.Colaboradores)
                .HasForeignKey(bc => bc.PessoaId);

            modelBuilder.Entity<Colaborador>()
                .HasOne(bc => bc.Empresa)
                .WithMany(c => c.Colaboradores)
                .HasForeignKey(bc => bc.EmpresaId);
        }

    }
}
