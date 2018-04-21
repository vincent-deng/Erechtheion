﻿// <auto-generated />

using DNIC.Erechtheion.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace DNIC.Erechtheion.EntityFrameworkCore.Migrations
{
    [DbContext(typeof(ErechtheionDbContext))]
    [Migration("20180420030139_Erechtheion")]
    partial class Erechtheion
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DNIC.Erechtheion.Domain.Entities.Channel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BgColor")
                        .HasMaxLength(100);

                    b.Property<int?>("ChannelId");

                    b.Property<string>("Class")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("CreationTime");

                    b.Property<long?>("CreatorUserId");

                    b.Property<bool>("Deleted");

                    b.Property<DateTime?>("DeletionTime");

                    b.Property<string>("Description")
                        .HasMaxLength(500);

                    b.Property<bool>("Enabled");

                    b.Property<string>("Icon")
                        .HasMaxLength(100);

                    b.Property<string>("ImageClass")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("LastModificationTime");

                    b.Property<long?>("LastModifierUserId");

                    b.Property<string>("Link")
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("Order");

                    b.Property<int>("ParentId");

                    b.Property<string>("Slug")
                        .HasMaxLength(100);

                    b.Property<int?>("TopicId");

                    b.HasKey("Id");

                    b.HasIndex("ChannelId");

                    b.HasIndex("TopicId");

                    b.ToTable("Channel");
                });

            modelBuilder.Entity("DNIC.Erechtheion.Domain.Entities.ContentChannels", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ChannelId");

                    b.Property<Guid>("ContentId");

                    b.Property<DateTime?>("CreationTime");

                    b.Property<long?>("CreatorUserId");

                    b.Property<DateTime?>("LastModificationTime");

                    b.Property<long?>("LastModifierUserId");

                    b.HasKey("Id");

                    b.ToTable("ContentChannels");
                });

            modelBuilder.Entity("DNIC.Erechtheion.Domain.Entities.Topic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<int>("ContentType");

                    b.Property<DateTime?>("CreationTime");

                    b.Property<long?>("CreatorUserId");

                    b.Property<bool>("Deleted");

                    b.Property<DateTime?>("DeletionTime");

                    b.Property<bool>("Enabled");

                    b.Property<DateTime?>("LastModificationTime");

                    b.Property<long?>("LastModifierUserId");

                    b.Property<bool>("Locked");

                    b.Property<int>("SecondId");

                    b.Property<string>("Slug");

                    b.Property<int>("State");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Topic");

                    b.HasDiscriminator().HasValue("Topic");
                });

            modelBuilder.Entity("DNIC.Erechtheion.Domain.Entities.Channel", b =>
                {
                    b.HasOne("DNIC.Erechtheion.Domain.Entities.Channel")
                        .WithMany("ChildNodes")
                        .HasForeignKey("ChannelId");

                    b.HasOne("DNIC.Erechtheion.Domain.Entities.Topic")
                        .WithMany("Channels")
                        .HasForeignKey("TopicId")
                        .HasPrincipalKey("Id");
                });
#pragma warning restore 612, 618
        }
    }
}
