using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ProjetPoulinaDomain.Models;



namespace ProjetPoulinaData.Context
{
   public class ProjetPoulinaDbContext : DbContext
    {
        public ProjetPoulinaDbContext() { }

        public ProjetPoulinaDbContext(DbContextOptions options) : base(options)
        {

        }

        #region DbSets
        
        public DbSet<Amortissement> amortissement { get; set; }
        public DbSet<Centre> centre { get; set; }
        public DbSet<Prix> prix { get; set; }
        public DbSet<Speculation> speculation { get; set; }
        public DbSet<Stock> stock { get; set; }
        public DbSet<TraitementStock> traitementstock { get; set; }
        public DbSet<Marche> marche { get; set; }
        public DbSet<Oeuf> ouef { get; set; }
        public DbSet<Reforme> reforme { get; set; }
        public DbSet<Speculation_centre> speculation_centre { get; set; }

        #endregion




        #region on ModelBuildingCreated
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {



            #region  Settings:Primary Keys Contraints 




            modelBuilder.Entity<Amortissement>().HasKey(a => a.AmortissementId);
            modelBuilder.Entity<Centre>().HasKey(c => c.CentreId);
            modelBuilder.Entity<Prix>().HasKey(p => p.PrixId);
            modelBuilder.Entity<Speculation>().HasKey(sp => sp.SpeculationId);
            modelBuilder.Entity<Stock>().HasKey(s => s.StockId);
            modelBuilder.Entity<TraitementStock>().HasKey(ts => ts.TraitementStockId);
            modelBuilder.Entity<Speculation_centre>().HasKey(ts => ts.speculation_centre_Id);




            #endregion


            #region Settings: One to many relations

            //Centre => Amortissement         
            modelBuilder.Entity<Centre>()
                                               .HasOne(a => a.amortissment)
                                               .WithMany(c => c.centre)
                                               .HasForeignKey(bc => bc.fk_amortissement);


            //Stock => TraitementStock
            modelBuilder.Entity<TraitementStock>()
                                               .HasOne(s => s.stock)
                                               .WithMany(ts => ts.traitementStocks)
                                               .HasForeignKey(bc => bc.fk_stock);

            //Prix => Spéculation        
            modelBuilder.Entity<Prix>()
                                               .HasOne(p => p.speculation)
                                               .WithMany(sp => sp.prix)
                                               .HasForeignKey(bc => bc.fk_Speculation);


            //Prix => Spéculation        
            modelBuilder.Entity<Speculation_centre>()
                                               .HasOne(c => c.centre)
                                               .WithMany(sp => sp.speculation_centre)
                                               .HasForeignKey(bc => bc.fk_centre);
            
            // => Spéculation        
            modelBuilder.Entity<Speculation_centre>()
                                               .HasOne(p => p.speculation)
                                               .WithMany(sp => sp.speculation_centre)
                                               .HasForeignKey(bc => bc.fk_speculation);


           
            #endregion
        }
        #endregion
    }

}