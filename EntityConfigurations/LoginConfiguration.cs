using VoeAirlines.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VoeAirlines.EntityConfigurations;

public class LoginConfiguration : IEntityTypeConfiguration<Login>
{
    public void Configure(EntityTypeBuilder<Login> builder)
    {
        //definindo a tabela 
        builder.ToTable("Logins");

        //única, imutavel, universal/ chave primaria 
        builder.HasKey(l=>l.Id);
        //definir usuario
        builder.Property(l => l.Usuario)
               .IsRequired()
               .HasMaxLength(40);

        //definir senha 
        builder.Property(l => l.Senha)
               .IsRequired()
               .HasMaxLength(12);

        builder.Property(l=>l.DataCriacao)
               .IsRequired();



    }
}