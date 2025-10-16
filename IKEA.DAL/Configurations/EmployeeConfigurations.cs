using IKEA.DAL.Models.Employee;
using IKEA.DAL.Models.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.DAL.Configurations
{
    public class EmployeeConfigurations : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(d => d.Name).HasColumnType("varchar(50)");
            builder.Property(d => d.Address).HasColumnType("varchar(50)");
            builder.Property(d => d.Salary).HasColumnType("decimal(10,3)");

            builder.Property(d => d.Gender).HasConversion(
                (empGender) => empGender.ToString(), (gender) => (Gender)Enum.Parse
                (typeof(Gender),gender));

            builder.Property(d => d.EmployeeType).HasConversion(
                (Etype) => Etype.ToString(), (Type) => (EmployeeType)Enum.Parse
                (typeof(EmployeeType), Type));
        }
    }
}
