using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Persistence.ScaffoldedPostgres
{
    public partial class PredictionsContext : DbContext
    {
        public virtual DbSet<Expert> Expert { get; set; }
        public virtual DbSet<Match> Match { get; set; }
        public virtual DbSet<Migrationhistory1> Migrationhistory1 { get; set; }
        public virtual DbSet<Oldtour> Oldtour { get; set; }
        public virtual DbSet<Prediction1> Prediction1 { get; set; }
        public virtual DbSet<SpatialRefSys> SpatialRefSys { get; set; }
        public virtual DbSet<Team> Team { get; set; }
        public virtual DbSet<Tour1> Tour1 { get; set; }
        public virtual DbSet<Tournament1> Tournament1 { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//             if (!optionsBuilder.IsConfigured)
//             {
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                 optionsBuilder.UseNpgsql(@"Server=baasu.db.elephantsql.com;Port=5432;Database=iwegytef;User Id=iwegytef;Password=orcrmtcznzR5zWEQ0TwU6cIC1qjeobBO;");
//             }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("btree_gin")
                .HasPostgresExtension("btree_gist")
                .HasPostgresExtension("citext")
                .HasPostgresExtension("cube")
                .HasPostgresExtension("dblink")
                .HasPostgresExtension("dict_int")
                .HasPostgresExtension("dict_xsyn")
                .HasPostgresExtension("earthdistance")
                .HasPostgresExtension("fuzzystrmatch")
                .HasPostgresExtension("hstore")
                .HasPostgresExtension("intarray")
                .HasPostgresExtension("ltree")
                .HasPostgresExtension("pg_stat_statements")
                .HasPostgresExtension("pg_trgm")
                .HasPostgresExtension("pgcrypto")
                .HasPostgresExtension("pgrowlocks")
                .HasPostgresExtension("pgstattuple")
                .HasPostgresExtension("plv8")
                .HasPostgresExtension("postgis")
                .HasPostgresExtension("tablefunc")
                .HasPostgresExtension("unaccent")
                .HasPostgresExtension("uuid-ossp")
                .HasPostgresExtension("xml2");

            modelBuilder.Entity<Expert>(entity =>
            {
                entity.ToTable("expert");

                entity.Property(e => e.Expertid)
                    .HasColumnName("expertid")
                    .HasDefaultValueSql("nextval('expert_seq'::regclass)");

                entity.Property(e => e.Differences)
                    .HasColumnName("differences")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Nickname).HasColumnName("nickname");

                entity.Property(e => e.Outcomes)
                    .HasColumnName("outcomes")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Scores)
                    .HasColumnName("scores")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Sum)
                    .HasColumnName("sum")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<Match>(entity =>
            {
                entity.ToTable("match");

                entity.HasIndex(e => e.Awayteamid)
                    .HasName("ix_awayteamid");

                entity.HasIndex(e => e.Hometeamid)
                    .HasName("ix_hometeamid");

                entity.HasIndex(e => e.Tourid)
                    .HasName("ix_tourid");

                entity.Property(e => e.Matchid)
                    .HasColumnName("matchid")
                    .HasDefaultValueSql("nextval('match_seq'::regclass)");

                entity.Property(e => e.Awayteamid).HasColumnName("awayteamid");

                entity.Property(e => e.Date).HasColumnName("date");

                entity.Property(e => e.Hometeamid).HasColumnName("hometeamid");

                entity.Property(e => e.Score).HasColumnName("score");

                entity.Property(e => e.Title).HasColumnName("title");

                entity.Property(e => e.Tourid).HasColumnName("tourid");

                entity.HasOne(d => d.Awayteam)
                    .WithMany(p => p.MatchAwayteam)
                    .HasForeignKey(d => d.Awayteamid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_dbo.match_dbo.team_awayteamid");

                entity.HasOne(d => d.Hometeam)
                    .WithMany(p => p.MatchHometeam)
                    .HasForeignKey(d => d.Hometeamid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_dbo.match_dbo.team_hometeamid");

                entity.HasOne(d => d.Tour)
                    .WithMany(p => p.Match)
                    .HasForeignKey(d => d.Tourid)
                    .HasConstraintName("fk_dbo.match_dbo.newtour_newtourid");
            });

            modelBuilder.Entity<Migrationhistory1>(entity =>
            {
                entity.HasKey(e => new { e.Migrationid, e.Contextkey });

                entity.ToTable("__migrationhistory");

                entity.Property(e => e.Migrationid).HasColumnName("migrationid");

                entity.Property(e => e.Contextkey).HasColumnName("contextkey");

                entity.Property(e => e.Model)
                    .IsRequired()
                    .HasColumnName("model");

                entity.Property(e => e.Productversion)
                    .IsRequired()
                    .HasColumnName("productversion");
            });

            modelBuilder.Entity<Oldtour>(entity =>
            {
                entity.ToTable("oldtour");

                entity.Property(e => e.Oldtourid)
                    .HasColumnName("oldtourid")
                    .HasDefaultValueSql("nextval('oldtour_seq'::regclass)");

                entity.Property(e => e.Enddate).HasColumnName("enddate");

                entity.Property(e => e.Isclosed).HasColumnName("isclosed");

                entity.Property(e => e.Oldtournumber).HasColumnName("oldtournumber");

                entity.Property(e => e.Startdate).HasColumnName("startdate");
            });

            modelBuilder.Entity<Prediction1>(entity =>
            {
                entity.HasKey(e => e.Predictionid);

                entity.ToTable("prediction");

                entity.HasIndex(e => e.Expertid)
                    .HasName("ix_expertid");

                entity.HasIndex(e => e.Matchid)
                    .HasName("ix_matchid");

                entity.Property(e => e.Predictionid)
                    .HasColumnName("predictionid")
                    .HasDefaultValueSql("nextval('prediction_seq'::regclass)");

                entity.Property(e => e.Difference).HasColumnName("difference");

                entity.Property(e => e.Expertid).HasColumnName("expertid");

                entity.Property(e => e.Isclosed)
                    .HasColumnName("isclosed")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.Matchid).HasColumnName("matchid");

                entity.Property(e => e.Outcome).HasColumnName("outcome");

                entity.Property(e => e.Score).HasColumnName("score");

                entity.Property(e => e.Sum).HasColumnName("sum");

                entity.Property(e => e.Value).HasColumnName("value");

                entity.HasOne(d => d.Expert)
                    .WithMany(p => p.Prediction1)
                    .HasForeignKey(d => d.Expertid)
                    .HasConstraintName("fk_dbo.prediction_dbo.expert_expertid");

                entity.HasOne(d => d.Match)
                    .WithMany(p => p.Prediction1)
                    .HasForeignKey(d => d.Matchid)
                    .HasConstraintName("fk_dbo.prediction_dbo.match_matchid");
            });

            modelBuilder.Entity<SpatialRefSys>(entity =>
            {
                entity.HasKey(e => e.Srid);

                entity.ToTable("spatial_ref_sys");

                entity.Property(e => e.Srid)
                    .HasColumnName("srid")
                    .ValueGeneratedNever();

                entity.Property(e => e.AuthName).HasColumnName("auth_name");

                entity.Property(e => e.AuthSrid).HasColumnName("auth_srid");

                entity.Property(e => e.Proj4text).HasColumnName("proj4text");

                entity.Property(e => e.Srtext).HasColumnName("srtext");
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.ToTable("team");

                entity.Property(e => e.Teamid)
                    .HasColumnName("teamid")
                    .HasDefaultValueSql("nextval('team_seq'::regclass)");

                entity.Property(e => e.Title).HasColumnName("title");
            });

            modelBuilder.Entity<Tour1>(entity =>
            {
                entity.HasKey(e => e.Tourid);

                entity.ToTable("tour");

                entity.HasIndex(e => e.Tournamentid)
                    .HasName("ix_tournamentid");

                entity.Property(e => e.Tourid)
                    .HasColumnName("tourid")
                    .HasDefaultValueSql("nextval('tour_seq'::regclass)");

                entity.Property(e => e.Enddate).HasColumnName("enddate");

                entity.Property(e => e.Isclosed).HasColumnName("isclosed");

                entity.Property(e => e.Startdate).HasColumnName("startdate");

                entity.Property(e => e.Tournamentid).HasColumnName("tournamentid");

                entity.Property(e => e.Tournumber).HasColumnName("tournumber");

                entity.HasOne(d => d.Tournament)
                    .WithMany(p => p.Tour1)
                    .HasForeignKey(d => d.Tournamentid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_dbo.newtour_dbo.tournament_tournamentid");
            });

            modelBuilder.Entity<Tournament1>(entity =>
            {
                entity.HasKey(e => e.Tournamentid);

                entity.ToTable("tournament");

                entity.Property(e => e.Tournamentid)
                    .HasColumnName("tournamentid")
                    .HasDefaultValueSql("nextval('tournament_seq'::regclass)");

                entity.Property(e => e.Enddate).HasColumnName("enddate");

                entity.Property(e => e.Startdate).HasColumnName("startdate");

                entity.Property(e => e.Title).HasColumnName("title");
            });

            modelBuilder.HasSequence("expert_seq").StartsAt(23);

            modelBuilder.HasSequence("match_seq").StartsAt(321);

            modelBuilder.HasSequence("oldtour_seq");

            modelBuilder.HasSequence("prediction_seq").StartsAt(2625);

            modelBuilder.HasSequence("team_seq").StartsAt(56);

            modelBuilder.HasSequence("tour_seq").StartsAt(21);

            modelBuilder.HasSequence("tournament_seq").StartsAt(5);
        }
    }
}
