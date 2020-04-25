using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheCoreTutorial.Models.DBHandler
{
	public class DatabaseContext : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=TheNews;Integrated Security=True;").EnableSensitiveDataLogging();
		}
		public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
		{

		}
		public DbSet<News> News { get; set; }
		public DbSet<Categories> Categories { get; set; }
		public DbSet<NewsCategory> NewsCategories { get; set; }
		public DbSet<AuthorNews> AuthorNew { get; set; }
		public DbSet<CommentNew> CommentNews { get; set; }
		public DbSet<TagsNews> TagNews { get; set; }
		public DbSet<Config> Config { get; set; }
		public override int SaveChanges(bool acceptAllChangesOnSuccess)
		{
			var serviceProvider = this.GetService<IServiceProvider>();
			var items = new Dictionary<object, object>();
			foreach (var entry in this.ChangeTracker.Entries().Where(e => (e.State == EntityState.Added) || (e.State == EntityState.Modified)))
			{
				var entity = entry.Entity;
				var context = new ValidationContext(entity, serviceProvider, items);
				var results = new List<ValidationResult>();
				if (Validator.TryValidateObject(entity, context, results, true) == false)
				{
					foreach (var result in results)
					{
						if (result != ValidationResult.Success)
						{
							throw new ValidationException(result.ErrorMessage);
						}
					}
				}
			}
			return base.SaveChanges(acceptAllChangesOnSuccess);
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			for (int i = 1; i < 4; i++)
			{
				modelBuilder.Entity<Authors>().HasData(new Authors
				{
					AuthorID = i,
					AuthorEmail = FakeData.NetworkData.GetEmail(FakeData.NameData.GetFirstName(), FakeData.NameData.GetSurname()),
					AuthorUsername = FakeData.NameData.GetFirstName() + FakeData.NameData.GetSurname(),
					AuthorPassword = FakeData.TextData.GetAlphaNumeric(8)
				});
				modelBuilder.Entity<News>().HasData(new News
				{
					NewsID = i,
					NewsBody = FakeData.TextData.GetSentences(1),
					NewsTitle = FakeData.TextData.GetSentences(1),
					NewsViewCount = FakeData.NumberData.GetNumber(1, 10),
					PublishDate = FakeData.DateTimeData.GetDatetime(),
					IsActive = true,
					ImageURL = FakeData.NetworkData.GetDomain()
				});
				modelBuilder.Entity<Categories>().HasData(new Categories
				{
					CategoryID = i,
					CategoryName = FakeData.TextData.GetAlphaNumeric(20),
					CategoryDescription = FakeData.TextData.GetSentences(1)
				});
				modelBuilder.Entity<Comments>().HasData(new Comments
				{
					CommentID = i,
					CommentBody = FakeData.TextData.GetSentences(1)
				});
				modelBuilder.Entity<Tags>().HasData(new Tags
				{
					TagID = i,
					Tag = FakeData.TextData.GetAlphabetical(8)
				});

				modelBuilder.Entity<TagsNews>().HasData(new TagsNews { TagID = i, NewsID = i });
				modelBuilder.Entity<CommentNew>().HasData(new CommentNew { CommentID = i, NewsID = i });
				modelBuilder.Entity<NewsCategory>().HasData(new NewsCategory { CategoryID = i, NewsID = i });
				modelBuilder.Entity<AuthorNews>().HasData(new AuthorNews { AuthorID = i, NewsID = i });
			}

			modelBuilder.Entity<Config>().HasData(new Config { ID = 1, WebSiteAddress = "http://localhost", Description = "lorem ipsum", Keywords = "keyword,keyword2", RecordsPerPage = 10 });

			modelBuilder.Entity<NewsCategory>().HasKey(sc => new { sc.NewsID, sc.CategoryID });
			modelBuilder.Entity<AuthorNews>().HasKey(sc => new { sc.NewsID, sc.AuthorID });
			modelBuilder.Entity<CommentNew>().HasKey(sc => new { sc.NewsID, sc.CommentID });
			modelBuilder.Entity<TagsNews>().HasKey(sc => new { sc.NewsID, sc.TagID });

		}
	}
}
