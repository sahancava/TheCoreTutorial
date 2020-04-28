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
		public DbSet<TagsNews> TagNews { get; set; }
		public DbSet<Config> Config { get; set; }
		public DbSet<Authors> Authors { get; set; }
		public DbSet<Tags> Tags { get; set; }
		public DbSet<Comments> Comments { get; set; }
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
					ID = i,
					AuthorEmail = FakeData.NetworkData.GetEmail(FakeData.NameData.GetFirstName(), FakeData.NameData.GetSurname()),
					AuthorUsername = FakeData.NameData.GetFirstName() + FakeData.NameData.GetSurname(),
					AuthorPassword = FakeData.TextData.GetAlphaNumeric(8)
				});
				modelBuilder.Entity<Authors>().HasData(new Authors
				{
					ID = i+3,
					AuthorEmail = FakeData.NetworkData.GetEmail(FakeData.NameData.GetFirstName(), FakeData.NameData.GetSurname()),
					AuthorUsername = FakeData.NameData.GetFirstName() + FakeData.NameData.GetSurname(),
					AuthorPassword = FakeData.TextData.GetAlphaNumeric(8)
				});
				modelBuilder.Entity<News>().HasData(new News
				{
					ID = i,
					NewsBody = FakeData.TextData.GetSentences(1),
					NewsTitle = FakeData.TextData.GetSentences(1),
					NewsViewCount = FakeData.NumberData.GetNumber(1, 10),
					PublishDate = FakeData.DateTimeData.GetDatetime(),
					IsActive = true,
					ImageURL = "blog-19.jpg",
					AuthorID = i
				});
				modelBuilder.Entity<News>().HasData(new News
				{
					ID = i+3,
					NewsBody = FakeData.TextData.GetSentences(1),
					NewsTitle = FakeData.TextData.GetSentences(1),
					NewsViewCount = FakeData.NumberData.GetNumber(1, 10),
					PublishDate = FakeData.DateTimeData.GetDatetime(),
					IsActive = true,
					ImageURL = "blog-19.jpg",
					AuthorID = i+3
				});
				modelBuilder.Entity<Categories>().HasData(new Categories
				{
					ID = i,
					CategoryName = "Category for the NewsID" + i,
					CategoryDescription = "CategoryDescription for the CategoryID" + i
				});
				modelBuilder.Entity<Categories>().HasData(new Categories
				{
					ID = i+3,
					CategoryName = "Category for the NewsID" + (i+3),
					CategoryDescription = "CategoryDescription for the CategoryID" + (i + 3)
				});
				modelBuilder.Entity<Comments>().HasData(new Comments
				{
					CommentID = i,
					CommentBody = FakeData.TextData.GetSentences(1),
					NewsID = i
				});
				modelBuilder.Entity<Tags>().HasData(new Tags
				{
					ID = i,
					Tag = "Tag for the News " + i
				});
				modelBuilder.Entity<Tags>().HasData(new Tags
				{
					ID = i+3,
					Tag = "Tag for the News " + (i+3)
				});
				modelBuilder.Entity<TagsNews>().HasData(new TagsNews
				{
					ID = i,
					TagID = i,
					NewsID = i
				});
				modelBuilder.Entity<TagsNews>().HasData(new TagsNews
				{
					ID = i+3,
					TagID = i+3,
					NewsID = i+3
				});
				modelBuilder.Entity<NewsCategory>().HasData(new NewsCategory
				{
					ID = i,
					NewsID = i,
					CategoryID = i
				});
				modelBuilder.Entity<NewsCategory>().HasData(new NewsCategory
				{
					ID = i+3,
					NewsID = i+3,
					CategoryID = i+3
				});
			}
			modelBuilder.Entity<Config>().HasData(new Config { ID = 1, WebSiteAddress = "http://localhost", Description = "lorem ipsum", Keywords = "keyword,keyword2", RecordsPerPage = 10 });

		}
	}
}
