using CM.Services.Wallet.Views.Contract.Domain.Models;
using CM.Services.Wallet.Views.Infrastracture.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CM.Services.Wallet.Views.Infrastracture.Mappings
{
    public class UserMap
    {
        public UserMap(EntityTypeBuilder<User> entityBuilder)
        {
            entityBuilder.ToTable(TableNames.User, SchemaNames.WalletViews);
            entityBuilder.HasKey(u => u.Id);
            entityBuilder.Property(u => u.Username);
            entityBuilder.Property(u => u.Email);
        }
    }
}