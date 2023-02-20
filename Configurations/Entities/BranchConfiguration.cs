using KaravanCoffeeWebAPI.Data;
using Microsoft.AspNetCore.Components.Server.Circuits;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Hosting;
using Org.BouncyCastle.Ocsp;
using System;
using System.IO.Pipelines;
using System.Net;
using System.Text.RegularExpressions;

namespace KaravanCoffeeWebAPI
{
    internal class BranchConfiguration : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            builder.HasData(
                new Branch
                {
                    BranchId= 1,
                    BranchName= "Megenagna",
                    BranchAddress= "Megenagna, Bethelehem Plaza Gd.F"
                }, new Branch
                {
                    BranchId = 2,
                    BranchName = "Bole",
                    BranchAddress = "Bole Medhanialem Mall"
                }, new Branch
                {
                    BranchId = 3,
                    BranchName = "Ayer Tena",
                    BranchAddress = "Ayer Tena, 7 Story Building Gd.F"
                }, new Branch
                {
                    BranchId = 4,
                    BranchName = "Tulu Dimtu",
                    BranchAddress = "Tulu Dimtu, Amakor Building"
                },  new Branch
                {
                    BranchId = 5,
                    BranchName = "Summit",
                    BranchAddress = "Summit, Infront of Cambridge Academy"
                });
        }
    }
}