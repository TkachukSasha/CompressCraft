﻿using CompressCraft.Domain.Encodings;
using CompressCraft.Infrastructure.Database.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompressCraft.Infrastructure.Database.Configurations;

public class EncodingTableConfigurations : IEntityTypeConfiguration<EncodingTable>
{
    public void Configure(EntityTypeBuilder<EncodingTable> builder)
    {
        builder.ToTable(TableNames.EncodingTables);

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, x => new EncodingTableId());

        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, x => new EncodingTableId());

        builder.OwnsMany(x => x.Elements);
    }
}

public class EncodingFileConfigurations : IEntityTypeConfiguration<EncodingFile>
{
    public void Configure(EntityTypeBuilder<EncodingFile> builder)
    {
        builder.ToTable(TableNames.EncodingFiles);

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, x => new EncodingFileId());

        builder.Property(x => x.EncodingSize)
            .IsRequired();

        builder.Property(x => x.DefaultSize)
            .IsRequired();
    }
}

public class EncodingTableLanguageConfigurations : IEntityTypeConfiguration<EncodingTableLanguage>
{
    public void Configure(EntityTypeBuilder<EncodingTableLanguage> builder)
    {
        builder.ToTable(TableNames.EncodingTableLanguages);

        builder.HasKey(x => x.Value);

        builder.HasMany(x => x.EncodingTables);

        builder.HasMany(x => x.EncodingFiles);
    }
}

public class EncodingAlgorithmConfigurations : IEntityTypeConfiguration<EncodingAlgorithm>
{
    public void Configure(EntityTypeBuilder<EncodingAlgorithm> builder)
    {
        builder.ToTable(TableNames.EncodingAlgorithms);

        builder.HasKey(x => x.Value);

        builder.HasMany(x => x.EncodingFiles);
    }
}
