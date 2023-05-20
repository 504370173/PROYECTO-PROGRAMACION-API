using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class MyDbContext : DbContext 
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) 
            : base(options)
        { 

        }

        public DbSet<AcademicFormation> academicFormations { get; set; } = default!;
        public DbSet<Candidate> candidates { get; set; } = default!;
        public DbSet<Company> companies { get; set; } = default!;
        public DbSet<JobApplication> jobApplications { get; set; } = default!;
        public DbSet<JobOffer> jobOffers { get; set; } = default!;
        public DbSet<OfferSkill> OfferedSkills { get; set; } = default!;
        public DbSet<CandidateSkill> candidateSkills { get; set; } = default!;
        public DbSet<Skill> skills { get; set; } = default!;
        public DbSet<User> Users { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //One to Many
            modelBuilder.Entity<AcademicFormation>()
            .HasOne(b => b.Candidate)
            .WithMany(a => a.AcademicFormation)
            .HasForeignKey(k => k.candidateId);

            modelBuilder.Entity<JobOffer>()
            .HasOne(b => b.Company)
            .WithMany(a => a.JobOffer)
            .HasForeignKey(k => k.companyId);



            //Many to Many

            modelBuilder.Entity<CandidateSkill>()
            .HasKey(i => new { i.CandidateId, i.SkillId });

            modelBuilder.Entity<CandidateSkill>()
           .HasOne(a => a.Candidate)
           .WithMany(c => c.CandidateSkill)
           .HasForeignKey(k => k.CandidateId);

            modelBuilder.Entity<CandidateSkill>()
            .HasOne(i => i.Skill)
            .WithMany(c => c.CandidateSkill)
            .HasForeignKey(k => k.SkillId);

            //        -- * --
            modelBuilder.Entity<OfferSkill>()
           .HasKey(i => new { i.SkillId, i.jobOfferId });

            modelBuilder.Entity<OfferSkill>()
           .HasOne(a => a.Skill)
           .WithMany(c => c.OfferedSkill)
           .HasForeignKey(k => k.SkillId);

            modelBuilder.Entity<OfferSkill>()
            .HasOne(i => i.JobOffer)
            .WithMany(c => c.OfferSkill)
            .HasForeignKey(k => k.jobOfferId);

            // --*--

            modelBuilder.Entity<JobApplication>()
           .HasKey(i => new { i.CandidateId, i.jobOfferId });

            modelBuilder.Entity<JobApplication>()
           .HasOne(a => a.Candidate)
           .WithMany(c => c.JobApplication)
           .HasForeignKey(k => k.CandidateId);

            modelBuilder.Entity<JobApplication>()
            .HasOne(i => i.JobOffer)
            .WithMany(c => c.JobApplication)
            .HasForeignKey(k => k.jobOfferId);



        }

    }
}
