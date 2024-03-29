﻿using Microsoft.EntityFrameworkCore;
using TARge21Shop.Core.Domain;
using TARge21Shop.Core.Domain.CarDomains;

namespace TARge21Shop.Data
{
    public class TARge21ShopContext : DbContext
    {
        public TARge21ShopContext(DbContextOptions<TARge21ShopContext> options) 
        : base(options) { }

        public DbSet<Spaceship> Spaceships { get; set; }
        public DbSet<FileToDatabase> FileToDatabases { get; set; }
        //
        public DbSet<RealEstate> RealEstates { get; set; }
        public DbSet<FileToApi> FileToApis { get; set; }
        //
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarFileToDatabase> CarFileToDatabases { get; set; }
        public DbSet<House> Houses { get; set; }
    }
}
