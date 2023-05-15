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
        //public DbSet<Company> companies { get; set; } = default!;
        //public DbSet<JobApplication> jobApplications { get; set; } = default!;
        //public DbSet<JobOffer> jobOffers { get; set; } = default!;
        //public DbSet<OfferedSkill> OfferedSkills { get; set; } = default!;
        //public DbSet<CandidateSkill> candidateSkills { get; set; } = default!;
        //public DbSet<Skill> skills { get; set; } = default!;
        public DbSet<User> Users { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //One to Many
            modelBuilder.Entity<AcademicFormation>()
            .HasOne<Candidate>(b => b.Candidate)
            .WithMany(a => a.AcademicFormation)
            .HasForeignKey(k => k.candidateId);



            //Many to Many

            // modelBuilder.Entity<CandidateSkill>()
            // .HasKey(i => new { i.candidateId, i.SkillId });

            // modelBuilder.Entity<CandidateSkill>()
            //.HasOne(a => a.Candidate)
            //.WithMany(c => c.candidateSkills)
            //.HasForeignKey(k => k.candidateId);

            // modelBuilder.Entity<CandidateSkill>()
            // .HasOne(i => i.Skill)
            // .WithMany(c => c.candidateSkill)
            // .HasForeignKey(k => k.SkillId);

        }

    }
}
