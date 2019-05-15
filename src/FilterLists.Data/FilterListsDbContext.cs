﻿using FilterLists.Data.Entities;
using FilterLists.Data.Entities.Junctions;
using FilterLists.Data.EntityTypeConfigurations;
using FilterLists.Data.EntityTypeConfigurations.Junctions;
using FilterLists.Data.Extensions;
using Microsoft.EntityFrameworkCore;

namespace FilterLists.Data
{
    public class FilterListsDbContext : DbContext
    {
        public FilterListsDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ApplyConfigurations(modelBuilder);
            ApplySeed(modelBuilder);
        }

        private static void ApplyConfigurations(ModelBuilder modelBuilder)
        {
            #region Configure Entities

            modelBuilder.ApplyConfiguration(new FilterListTypeConfiguration());
            modelBuilder.ApplyConfiguration(new LanguageTypeConfiguration());
            modelBuilder.ApplyConfiguration(new LicenseTypeConfiguration());
            modelBuilder.ApplyConfiguration(new MaintainerTypeConfiguration());
            modelBuilder.ApplyConfiguration(new RuleTypeConfiguration());
            modelBuilder.ApplyConfiguration(new SnapshotTypeConfiguration());
            modelBuilder.ApplyConfiguration(new SoftwareTypeConfiguration());
            modelBuilder.ApplyConfiguration(new SyntaxTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TagTypeConfiguration());

            #endregion

            #region Configure Junctions

            modelBuilder.ApplyConfiguration(new DependentTypeConfiguration());
            modelBuilder.ApplyConfiguration(new FilterListLanguageTypeConfiguration());
            modelBuilder.ApplyConfiguration(new FilterListMaintainerTypeConfiguration());
            modelBuilder.ApplyConfiguration(new FilterListTagTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ForkTypeConfiguration());
            modelBuilder.ApplyConfiguration(new MergeTypeConfiguration());
            modelBuilder.ApplyConfiguration(new SnapshotRuleTypeConfiguration());
            modelBuilder.ApplyConfiguration(new SoftwareSyntaxTypeConfiguration());

            #endregion
        }

        private static void ApplySeed(ModelBuilder modelBuilder)
        {
            #region Seed Entities

            modelBuilder.Seed<Language>();
            modelBuilder.Seed<License>();
            modelBuilder.Seed<Maintainer>();
            modelBuilder.Seed<Software>();
            modelBuilder.Seed<Syntax>();
            modelBuilder.Seed<Tag>();
            modelBuilder.Seed<FilterList>();

            #endregion

            #region Seed Junctions

            modelBuilder.Seed<FilterListLanguage>();
            modelBuilder.Seed<FilterListMaintainer>();
            modelBuilder.Seed<FilterListTag>();
            modelBuilder.Seed<Dependent>();
            modelBuilder.Seed<Fork>();
            modelBuilder.Seed<Merge>();
            modelBuilder.Seed<SoftwareSyntax>();

            #endregion
        }

        #region Entity DbSets

        public DbSet<FilterList> FilterLists { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<License> Licenses { get; set; }
        public DbSet<Maintainer> Maintainers { get; set; }
        public DbSet<Rule> Rules { get; set; }
        public DbSet<Snapshot> Snapshots { get; set; }
        public DbSet<Software> Software { get; set; }
        public DbSet<Syntax> Syntaxes { get; set; }
        public DbSet<Tag> Tags { get; set; }

        #endregion

        #region Junction DbSets

        public DbSet<Dependent> Dependents { get; set; }
        public DbSet<FilterListLanguage> FilterListLanguages { get; set; }
        public DbSet<FilterListMaintainer> FilterListMaintainers { get; set; }
        public DbSet<FilterListTag> FilterListTags { get; set; }
        public DbSet<Fork> Forks { get; set; }
        public DbSet<Merge> Merges { get; set; }
        public DbSet<SnapshotRule> SnapshotRules { get; set; }
        public DbSet<SoftwareSyntax> SoftwareSyntaxes { get; set; }

        #endregion
    }
}