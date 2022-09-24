﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Portal.Database;

#nullable disable

namespace Portal.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Portal.Database.IgnoreMe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("IgnoreMe");
                });

            modelBuilder.Entity("Portal.Database.Tables.Pipeline", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Pipelines");
                });

            modelBuilder.Entity("Portal.Plugins.Plugin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("PipelineId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PipelineId");

                    b.ToTable("Plugins");
                });

            modelBuilder.Entity("Portal.Plugins.FilterPlugin", b =>
                {
                    b.HasBaseType("Portal.Plugins.Plugin");

                    b.Property<string>("Column")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("DesiredValue")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Operator")
                        .HasColumnType("integer");

                    b.ToTable("FilterPlugins", (string)null);
                });

            modelBuilder.Entity("Portal.Plugins.Plugin", b =>
                {
                    b.HasOne("Portal.Database.Tables.Pipeline", null)
                        .WithMany("Plugins")
                        .HasForeignKey("PipelineId");
                });

            modelBuilder.Entity("Portal.Plugins.FilterPlugin", b =>
                {
                    b.HasOne("Portal.Plugins.Plugin", null)
                        .WithOne()
                        .HasForeignKey("Portal.Plugins.FilterPlugin", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Portal.Database.Tables.Pipeline", b =>
                {
                    b.Navigation("Plugins");
                });
#pragma warning restore 612, 618
        }
    }
}
