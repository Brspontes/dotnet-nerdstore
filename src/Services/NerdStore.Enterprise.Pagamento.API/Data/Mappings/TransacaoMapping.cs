using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NerdStore.Enterprise.Pagamento.API.Data.Mappings
{
    public class TransacaoMapping : IEntityTypeConfiguration<Models.Transacao>
    {
        public void Configure(EntityTypeBuilder<Models.Transacao> builder)
        {
            builder.HasKey(c => c.Id);

            // 1 : N => Pagamento : Transacao
            builder.HasOne(c => c.Pagamento)
                .WithMany(c => c.Transacoes);

            builder.ToTable("Transacoes");
        }
    }
}
