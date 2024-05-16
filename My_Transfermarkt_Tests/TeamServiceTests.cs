﻿using Microsoft.EntityFrameworkCore;
using My_Transfermarkt.Data;
using My_Transfermarkt_Core.Contracts;
using My_Transfermarkt_Core.Models.FootballerModels;
using My_Transfermarkt_Core.Models.TeamModels;
using My_Transfermarkt_Core.Services;
using My_Transfermarkt_Infastructure.DataModels;

namespace My_Transfermarkt_Tests
{
    [TestFixture]
    public class TeamServiceTests
    {
        private ApplicationDbContext data;
        private IEnumerable<Team> teams;
        private IEnumerable<Country> countries;
        private IEnumerable<Stadium> stadiums;



        [Test]
        public void TestGetAllTeams()
        {

            this.countries = new List<Country>()
            {
                new Country(){Id = 1, Name= "Spain", ShortName = "SP"},
                new Country(){Id = 2, Name= "Belgium", ShortName="BE"},
                new Country(){Id = 3, Name= "Bulgaria", ShortName="BG"},
                new Country(){Id = 4, Name= "England", ShortName="EN"}
            };
            this.stadiums = new List<Stadium>()
            {
                new Stadium { Id = 4, CountryId = 2, Build = DateTime.Parse("1934/08/06"), Capacity = 74667, Name = "Olympiastadion" },
            };

            this.teams = new List<Team>()
            {
                new Team{Id =1, CountryId = 4, Name = "Manchester United" },
                new Team{Id =2, CountryId = 3, Name = "Botev Plovdiv" },
                new Team{Id =3, CountryId = 3, Name = "Levski Sofia" },
                new Team{Id =4, CountryId = 4, Name = "Arsenal" },
                new Team{Id =5, CountryId = 1, Name = "Barcelona" },
                new Team{Id =6, CountryId = 1, Name = "Real Madrid" },
                new Team{Id =7, CountryId = 2, Name = "Standard" },
                new Team{Id =8, CountryId = 2, Name = "Brugge" },
                new Team{Id =9, CountryId = 3, Name = "Spartak Varna" },
            };

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "MyMockedData")
                   .Options;
            this.data = new ApplicationDbContext(options);
            this.data.AddRange(this.teams);
            this.data.AddRange(this.countries);
            this.data.AddRange(this.stadiums);
            this.data.SaveChanges();


            ITeamService service = new TeamService(data);
            var teams = service.GetAllTeams();
            Assert.That(teams.Result.Count, Is.EqualTo(9));

            this.data.RemoveRange(this.teams);
            this.data.RemoveRange(this.countries);
            this.data.RemoveRange(this.stadiums);
            this.data.SaveChanges();

        }

        [Test]
        public void TestFindTeamToEdit()
        {

            this.countries = new List<Country>()
            {
                new Country(){Id = 1, Name= "Spain", ShortName = "SP"},
                new Country(){Id = 2, Name= "Belgium", ShortName="BE"},
                new Country(){Id = 3, Name= "Bulgaria", ShortName="BG"},
                new Country(){Id = 4, Name= "England", ShortName="EN"}
            };
            this.stadiums = new List<Stadium>()
            {
                new Stadium { Id = 4, CountryId = 2, Build = DateTime.Parse("1934/08/06"), Capacity = 74667, Name = "Olympiastadion" },
            };

            this.teams = new List<Team>()
            {
                new Team{Id =1, CountryId = 4, Name = "Manchester United" },
                new Team{Id =2, CountryId = 3, Name = "Botev Plovdiv" },
                new Team{Id =3, CountryId = 3, Name = "Levski Sofia" },
                new Team{Id =4, CountryId = 4, Name = "Arsenal" },
                new Team{Id =5, CountryId = 1, Name = "Barcelona" },
                new Team{Id =6, CountryId = 1, Name = "Real Madrid" },
                new Team{Id =7, CountryId = 2, Name = "Standard" },
                new Team{Id =8, CountryId = 2, Name = "Brugge" },
                new Team{Id =9, CountryId = 3, Name = "Spartak Varna" },
            };

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "MyMockedData")
                   .Options;
            this.data = new ApplicationDbContext(options);
            this.data.AddRange(this.teams);
            this.data.AddRange(this.countries);
            this.data.AddRange(this.stadiums);
            this.data.SaveChanges();

            ITeamService service = new TeamService(data);
            var teams = service.FindTeamToBeEdited(1);
            Assert.That(teams.Result.Name, Is.EqualTo("Manchester United"));

            this.data.RemoveRange(this.teams);
            this.data.RemoveRange(this.countries);
            this.data.RemoveRange(this.stadiums);
            this.data.SaveChanges();


        }

        [Test]
        public void TestFindTeamToEditNull()
        {

            this.countries = new List<Country>()
            {
                new Country(){Id = 1, Name= "Spain", ShortName = "SP"},
                new Country(){Id = 2, Name= "Belgium", ShortName="BE"},
                new Country(){Id = 3, Name= "Bulgaria", ShortName="BG"},
                new Country(){Id = 4, Name= "England", ShortName="EN"}
            };
            this.stadiums = new List<Stadium>()
            {
                new Stadium { Id = 4, CountryId = 2, Build = DateTime.Parse("1934/08/06"), Capacity = 74667, Name = "Olympiastadion" },
            };

            this.teams = new List<Team>()
            {
                new Team{Id =1, CountryId = 4, Name = "Manchester United" },
                new Team{Id =2, CountryId = 3, Name = "Botev Plovdiv" },
                new Team{Id =3, CountryId = 3, Name = "Levski Sofia" },
                new Team{Id =4, CountryId = 4, Name = "Arsenal" },
                new Team{Id =5, CountryId = 1, Name = "Barcelona" },
                new Team{Id =6, CountryId = 1, Name = "Real Madrid" },
                new Team{Id =7, CountryId = 2, Name = "Standard" },
                new Team{Id =8, CountryId = 2, Name = "Brugge" },
                new Team{Id =9, CountryId = 3, Name = "Spartak Varna" },
            };

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "MyMockedData")
                   .Options;
            this.data = new ApplicationDbContext(options);
            this.data.AddRange(this.teams);
            this.data.AddRange(this.countries);
            this.data.AddRange(this.stadiums);
            this.data.SaveChanges();

            ITeamService service = new TeamService(data);
            var teams = service.FindTeamToBeEdited(100);
            Assert.That(teams.Result, Is.EqualTo(null));

            this.data.RemoveRange(this.teams);
            this.data.RemoveRange(this.countries);
            this.data.RemoveRange(this.stadiums);
            this.data.SaveChanges();

        }

        [Test]
        public void TestIsalreadyCreatedTrue()
        {

            this.countries = new List<Country>()
            {
                new Country(){Id = 1, Name= "Spain", ShortName = "SP"},
                new Country(){Id = 2, Name= "Belgium", ShortName="BE"},
                new Country(){Id = 3, Name= "Bulgaria", ShortName="BG"},
                new Country(){Id = 4, Name= "England", ShortName="EN"}
            };
            this.stadiums = new List<Stadium>()
            {
                new Stadium { Id = 4, CountryId = 2, Build = DateTime.Parse("1934/08/06"), Capacity = 74667, Name = "Olympiastadion" },
            };

            this.teams = new List<Team>()
            {
                new Team{Id =1, CountryId = 4, Name = "Manchester United" },
                new Team{Id =2, CountryId = 3, Name = "Botev Plovdiv" },
                new Team{Id =3, CountryId = 3, Name = "Levski Sofia" },
                new Team{Id =4, CountryId = 4, Name = "Arsenal" },
                new Team{Id =5, CountryId = 1, Name = "Barcelona" },
                new Team{Id =6, CountryId = 1, Name = "Real Madrid" },
                new Team{Id =7, CountryId = 2, Name = "Standard" },
                new Team{Id =8, CountryId = 2, Name = "Brugge" },
                new Team{Id =9, CountryId = 3, Name = "Spartak Varna" },
            };

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "MyMockedData")
                   .Options;
            this.data = new ApplicationDbContext(options);
            this.data.AddRange(this.teams);
            this.data.AddRange(this.countries);
            this.data.AddRange(this.stadiums);
            this.data.SaveChanges();

            AddNewTeamModel model = new AddNewTeamModel()
            {
                Id = 4,
                CountryId = 4,
                Name = "Arsenal"
            };

            AddNewTeamModel model2 = new AddNewTeamModel()
            {
                Id = 5,
                CountryId = 4,
                Name = "Arsenal"
            };


            ITeamService service = new TeamService(data);
            var teams = service.IsAlreadyCreated(model);
            var teams2 = service.IsAlreadyCreated(model2);
            Assert.That(teams.Result.ToString, Is.EqualTo("False"));
            Assert.That(teams2.Result.ToString, Is.EqualTo("True"));

            this.data.RemoveRange(this.teams);
            this.data.RemoveRange(this.countries);
            this.data.RemoveRange(this.stadiums);
            this.data.SaveChanges();

        }

        [Test]
        public void TestIsalreadyCreatedFalse()
        {
            this.countries = new List<Country>()
            {
                new Country(){Id = 1, Name= "Spain", ShortName = "SP"},
                new Country(){Id = 2, Name= "Belgium", ShortName="BE"},
                new Country(){Id = 3, Name= "Bulgaria", ShortName="BG"},
                new Country(){Id = 4, Name= "England", ShortName="EN"}
            };
            this.stadiums = new List<Stadium>()
            {
                new Stadium { Id = 4, CountryId = 2, Build = DateTime.Parse("1934/08/06"), Capacity = 74667, Name = "Olympiastadion" },
            };

            this.teams = new List<Team>()
            {
                new Team{Id =1, CountryId = 4, Name = "Manchester United" },
                new Team{Id =2, CountryId = 3, Name = "Botev Plovdiv" },
                new Team{Id =3, CountryId = 3, Name = "Levski Sofia" },
                new Team{Id =4, CountryId = 4, Name = "Arsenal" },
                new Team{Id =5, CountryId = 1, Name = "Barcelona" },
                new Team{Id =6, CountryId = 1, Name = "Real Madrid" },
                new Team{Id =7, CountryId = 2, Name = "Standard" },
                new Team{Id =8, CountryId = 2, Name = "Brugge" },
                new Team{Id =9, CountryId = 3, Name = "Spartak Varna" },
            };

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "MyMockedData")
                   .Options;
            this.data = new ApplicationDbContext(options);
            this.data.AddRange(this.teams);
            this.data.AddRange(this.countries);
            this.data.AddRange(this.stadiums);
            this.data.SaveChanges();


            AddNewTeamModel model = new AddNewTeamModel()
            {
                Id = 1,
                CountryId = 4,
                Name = "Gotebord"
            };

            ITeamService service = new TeamService(data);
            var teams = service.IsAlreadyCreated(model);
            Assert.That(teams.Result.ToString, Is.EqualTo("False"));

            this.data.RemoveRange(this.teams);
            this.data.RemoveRange(this.countries);
            this.data.RemoveRange(this.stadiums);
            this.data.SaveChanges();

        }

        [Test]
        public void TestIFindTeamTrue()
        {
            this.countries = new List<Country>()
            {
                new Country(){Id = 1, Name= "Spain", ShortName = "SP"},
                new Country(){Id = 2, Name= "Belgium", ShortName="BE"},
                new Country(){Id = 3, Name= "Bulgaria", ShortName="BG"},
                new Country(){Id = 4, Name= "England", ShortName="EN"}
            };
            this.stadiums = new List<Stadium>()
            {
                new Stadium { Id = 4, CountryId = 2, Build = DateTime.Parse("1934/08/06"), Capacity = 74667, Name = "Olympiastadion" },
            };

            this.teams = new List<Team>()
            {
                new Team{Id =1, CountryId = 4, Name = "Manchester United" },
                new Team{Id =2, CountryId = 3, Name = "Botev Plovdiv" },
                new Team{Id =3, CountryId = 3, Name = "Levski Sofia" },
                new Team{Id =4, CountryId = 4, Name = "Arsenal" },
                new Team{Id =5, CountryId = 1, Name = "Barcelona" },
                new Team{Id =6, CountryId = 1, Name = "Real Madrid" },
                new Team{Id =7, CountryId = 2, Name = "Standard" },
                new Team{Id =8, CountryId = 2, Name = "Brugge" },
                new Team{Id =9, CountryId = 3, Name = "Spartak Varna" },
            };

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "MyMockedData")
                   .Options;
            this.data = new ApplicationDbContext(options);
            this.data.AddRange(this.teams);
            this.data.AddRange(this.countries);
            this.data.AddRange(this.stadiums);
            this.data.SaveChanges();


            ITeamService service = new TeamService(data);
            var teams = service.FindTeam(2);
            Assert.That(teams.Result.TeamName, Is.EqualTo("Botev Plovdiv"));

            this.data.RemoveRange(this.teams);
            this.data.RemoveRange(this.countries);
            this.data.RemoveRange(this.stadiums);
            this.data.SaveChanges();

        }

        [Test]
        public void TestIFindTeamFalse()
        {
            this.countries = new List<Country>()
            {
                new Country(){Id = 1, Name= "Spain", ShortName = "SP"},
                new Country(){Id = 2, Name= "Belgium", ShortName="BE"},
                new Country(){Id = 3, Name= "Bulgaria", ShortName="BG"},
                new Country(){Id = 4, Name= "England", ShortName="EN"}
            };
            this.stadiums = new List<Stadium>()
            {
                new Stadium { Id = 4, CountryId = 2, Build = DateTime.Parse("1934/08/06"), Capacity = 74667, Name = "Olympiastadion" },
            };

            this.teams = new List<Team>()
            {
                new Team{Id =1, CountryId = 4, Name = "Manchester United" },
                new Team{Id =2, CountryId = 3, Name = "Botev Plovdiv" },
                new Team{Id =3, CountryId = 3, Name = "Levski Sofia" },
                new Team{Id =4, CountryId = 4, Name = "Arsenal" },
                new Team{Id =5, CountryId = 1, Name = "Barcelona" },
                new Team{Id =6, CountryId = 1, Name = "Real Madrid" },
                new Team{Id =7, CountryId = 2, Name = "Standard" },
                new Team{Id =8, CountryId = 2, Name = "Brugge" },
                new Team{Id =9, CountryId = 3, Name = "Spartak Varna" },
            };

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "MyMockedData")
                   .Options;
            this.data = new ApplicationDbContext(options);
            this.data.AddRange(this.teams);
            this.data.AddRange(this.countries);
            this.data.AddRange(this.stadiums);
            this.data.SaveChanges();


            ITeamService service = new TeamService(data);
            var teams = service.FindTeam(200);
            Assert.That(teams.Result, Is.EqualTo(null));

            this.data.RemoveRange(this.teams);
            this.data.RemoveRange(this.countries);
            this.data.RemoveRange(this.stadiums);
            this.data.SaveChanges();

        }
        [Test]
        public void TestAddToStadium()
        {
            this.countries = new List<Country>()
            {
                new Country(){Id = 1, Name= "Spain", ShortName = "SP"},
                new Country(){Id = 2, Name= "Belgium", ShortName="BE"},
                new Country(){Id = 3, Name= "Bulgaria", ShortName="BG"},
                new Country(){Id = 4, Name= "England", ShortName="EN"}
            };
            this.stadiums = new List<Stadium>()
            {
                new Stadium { Id = 4, CountryId = 2, Build = DateTime.Parse("1934/08/06"), Capacity = 74667, Name = "Olympiastadion" },
            };

            this.teams = new List<Team>()
            {
                new Team{Id =1, CountryId = 4, Name = "Manchester United" },
                new Team{Id =2, CountryId = 3, Name = "Botev Plovdiv" },
                new Team{Id =3, CountryId = 3, Name = "Levski Sofia" },
                new Team{Id =4, CountryId = 4, Name = "Arsenal" },
                new Team{Id =5, CountryId = 1, Name = "Barcelona" },
                new Team{Id =6, CountryId = 1, Name = "Real Madrid" },
                new Team{Id =7, CountryId = 2, Name = "Standard" },
                new Team{Id =8, CountryId = 2, Name = "Brugge" },
                new Team{Id =9, CountryId = 3, Name = "Spartak Varna" },
            };

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "MyMockedData")
                   .Options;
            this.data = new ApplicationDbContext(options);
            this.data.AddRange(this.teams);
            this.data.AddRange(this.countries);
            this.data.AddRange(this.stadiums);
            this.data.SaveChanges();

            TeamToAddStadium team = new TeamToAddStadium()
            {
                Id = 1,
                StadiumId = 4,
            };

            ITeamService service = new TeamService(data);
            service.AddToStadiumAsync(team);
            var stadiumName = data.Teams.First(x => x.Id == 1);
            Assert.That(stadiumName.StadiumId, Is.EqualTo(4));

            this.data.RemoveRange(this.teams);
            this.data.RemoveRange(this.countries);
            this.data.RemoveRange(this.stadiums);
            this.data.SaveChanges();

        }

        [Test]
        public void TestRandomList()
        {
            this.countries = new List<Country>()
            {
                new Country(){Id = 1, Name= "Spain", ShortName = "SP"},
                new Country(){Id = 2, Name= "Belgium", ShortName="BE"},
                new Country(){Id = 3, Name= "Bulgaria", ShortName="BG"},
                new Country(){Id = 4, Name= "England", ShortName="EN"}
            };
            this.stadiums = new List<Stadium>()
            {
                new Stadium { Id = 4, CountryId = 2, Build = DateTime.Parse("1934/08/06"), Capacity = 74667, Name = "Olympiastadion" },
            };

            this.teams = new List<Team>()
            {
                new Team{Id =1, CountryId = 4, Name = "Manchester United" },
                new Team{Id =2, CountryId = 3, Name = "Botev Plovdiv" },
                new Team{Id =3, CountryId = 3, Name = "Levski Sofia" },
                new Team{Id =4, CountryId = 4, Name = "Arsenal" },
                new Team{Id =5, CountryId = 1, Name = "Barcelona" },
                new Team{Id =6, CountryId = 1, Name = "Real Madrid" },
                new Team{Id =7, CountryId = 2, Name = "Standard" },
                new Team{Id =8, CountryId = 2, Name = "Brugge" },
                new Team{Id =9, CountryId = 3, Name = "Spartak Varna" },
            };

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "MyMockedData")
                   .Options;
            this.data = new ApplicationDbContext(options);
            this.data.AddRange(this.teams);
            this.data.AddRange(this.countries);
            this.data.AddRange(this.stadiums);
            this.data.SaveChanges();

            ITeamService service = new TeamService(data);
            var result = service.GetRandomListForHomePage();
            Assert.That(result.Result.Count(), Is.EqualTo(8));

            this.data.RemoveRange(this.teams);
            this.data.RemoveRange(this.countries);
            this.data.RemoveRange(this.stadiums);
            this.data.SaveChanges();


        }

        [Test]
        public void TestFindteamByCountry()
        {
            this.countries = new List<Country>()
            {
                new Country(){Id = 1, Name= "Spain", ShortName = "SP"},
                new Country(){Id = 2, Name= "Belgium", ShortName="BE"},
                new Country(){Id = 3, Name= "Bulgaria", ShortName="BG"},
                new Country(){Id = 4, Name= "England", ShortName="EN"}
            };
            this.stadiums = new List<Stadium>()
            {
                new Stadium { Id = 4, CountryId = 2, Build = DateTime.Parse("1934/08/06"), Capacity = 74667, Name = "Olympiastadion" },
            };

            this.teams = new List<Team>()
            {
                new Team{Id =1, CountryId = 4, Name = "Manchester United" },
                new Team{Id =2, CountryId = 3, Name = "Botev Plovdiv" },
                new Team{Id =3, CountryId = 3, Name = "Levski Sofia" },
                new Team{Id =4, CountryId = 4, Name = "Arsenal" },
                new Team{Id =5, CountryId = 1, Name = "Barcelona" },
                new Team{Id =6, CountryId = 1, Name = "Real Madrid" },
                new Team{Id =7, CountryId = 2, Name = "Standard" },
                new Team{Id =8, CountryId = 2, Name = "Brugge" },
                new Team{Id =9, CountryId = 3, Name = "Spartak Varna" },
            };

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "MyMockedData")
                   .Options;
            this.data = new ApplicationDbContext(options);
            this.data.AddRange(this.teams);
            this.data.AddRange(this.countries);
            this.data.AddRange(this.stadiums);
            this.data.SaveChanges();

            string country = "Spain";

            ITeamService service = new TeamService(data);
            var result = service.FindTeamByCountry(country);
            Assert.That(result.Result.Count(), Is.EqualTo(2));

            var result2 = service.FindTeamByCountry("spa");
            Assert.That(result2.Result.Count(), Is.EqualTo(2));

            var result3 = service.FindTeamByCountry("Bulga");
            Assert.That(result3.Result.Count(), Is.EqualTo(3));

            this.data.RemoveRange(this.teams);
            this.data.RemoveRange(this.countries);
            this.data.RemoveRange(this.stadiums);
            this.data.SaveChanges();


        }
        [Test]
        public void TestFindteamByBame()
        {
            this.countries = new List<Country>()
            {
                new Country(){Id = 1, Name= "Spain", ShortName = "SP"},
                new Country(){Id = 2, Name= "Belgium", ShortName="BE"},
                new Country(){Id = 3, Name= "Bulgaria", ShortName="BG"},
                new Country(){Id = 4, Name= "England", ShortName="EN"}
            };
            this.stadiums = new List<Stadium>()
            {
                new Stadium { Id = 4, CountryId = 2, Build = DateTime.Parse("1934/08/06"), Capacity = 74667, Name = "Olympiastadion" },
            };

            this.teams = new List<Team>()
            {
                new Team{Id =1, CountryId = 4, Name = "Manchester United" },
                new Team{Id =2, CountryId = 3, Name = "Botev Plovdiv" },
                new Team{Id =3, CountryId = 3, Name = "Levski Sofia" },
                new Team{Id =4, CountryId = 4, Name = "Arsenal" },
                new Team{Id =5, CountryId = 1, Name = "Barcelona" },
                new Team{Id =6, CountryId = 1, Name = "Real Madrid" },
                new Team{Id =7, CountryId = 2, Name = "Standard" },
                new Team{Id =8, CountryId = 2, Name = "Brugge" },
                new Team{Id =9, CountryId = 3, Name = "Spartak Varna" },
            };

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "MyMockedData")
                   .Options;
            this.data = new ApplicationDbContext(options);
            this.data.AddRange(this.teams);
            this.data.AddRange(this.countries);
            this.data.AddRange(this.stadiums);
            this.data.SaveChanges();

            ITeamService service = new TeamService(data);
            var result = service.FindTeams("manche");
            var result2 = service.FindTeams("ars");
            var result3 = service.FindTeams("ar");

            Assert.That(result.Result.Count(), Is.EqualTo(1));
            Assert.That(result2.Result.Count(), Is.EqualTo(1));
            Assert.That(result3.Result.Count(), Is.EqualTo(4));

            this.data.RemoveRange(this.teams);
            this.data.RemoveRange(this.countries);
            this.data.RemoveRange(this.stadiums);
            this.data.SaveChanges();

        }

        [Test]
        public void TestAddNewTeam()
        {
            this.countries = new List<Country>()
            {
                new Country(){Id = 1, Name= "Spain", ShortName = "SP"},
                new Country(){Id = 2, Name= "Belgium", ShortName="BE"},
                new Country(){Id = 3, Name= "Bulgaria", ShortName="BG"},
                new Country(){Id = 4, Name= "England", ShortName="EN"}
            };
            this.stadiums = new List<Stadium>()
            {
                new Stadium { Id = 4, CountryId = 2, Build = DateTime.Parse("1934/08/06"), Capacity = 74667, Name = "Olympiastadion" },
            };

            this.teams = new List<Team>()
            {
                new Team{Id =1, CountryId = 4, Name = "Manchester United" },
                new Team{Id =2, CountryId = 3, Name = "Botev Plovdiv" },
                new Team{Id =3, CountryId = 3, Name = "Levski Sofia" },
                new Team{Id =4, CountryId = 4, Name = "Arsenal" },
                new Team{Id =5, CountryId = 1, Name = "Barcelona" },
                new Team{Id =6, CountryId = 1, Name = "Real Madrid" },
                new Team{Id =7, CountryId = 2, Name = "Standard" },
                new Team{Id =8, CountryId = 2, Name = "Brugge" },
                new Team{Id =9, CountryId = 3, Name = "Spartak Varna" },
            };

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "MyMockedData")
                   .Options;
            this.data = new ApplicationDbContext(options);
            this.data.AddRange(this.teams);
            this.data.AddRange(this.countries);
            this.data.AddRange(this.stadiums);
            this.data.SaveChanges();

            ITeamService service = new TeamService(data);
            AddNewTeamModel model = new AddNewTeamModel()
            {
                StadiumId = 1,
                Id = 1,
                Name = "Strumska Slava",
                CountryId = 1,

            };
            service.AddNewTeamAsync(model);
            Assert.That(data.Teams.Count, Is.EqualTo(10));

            this.data.RemoveRange(this.teams);
            this.data.RemoveRange(this.countries);
            this.data.RemoveRange(this.stadiums);
            this.data.SaveChanges();


        }

        [Test]
        public void TestChangeTeam()
        {
            this.countries = new List<Country>()
            {
                new Country(){Id = 1, Name= "Spain", ShortName = "SP"},
                new Country(){Id = 2, Name= "Belgium", ShortName="BE"},
                new Country(){Id = 3, Name= "Bulgaria", ShortName="BG"},
                new Country(){Id = 4, Name= "England", ShortName="EN"}
            };
            this.stadiums = new List<Stadium>()
            {
                new Stadium { Id = 4, CountryId = 2, Build = DateTime.Parse("1934/08/06"), Capacity = 74667, Name = "Olympiastadion" },
            };

            this.teams = new List<Team>()
            {
                new Team{Id =1, CountryId = 4, Name = "Manchester United" },
                new Team{Id =2, CountryId = 3, Name = "Botev Plovdiv" },
                new Team{Id =3, CountryId = 3, Name = "Levski Sofia" },
                new Team{Id =4, CountryId = 4, Name = "Arsenal" },
                new Team{Id =5, CountryId = 1, Name = "Barcelona" },
                new Team{Id =6, CountryId = 1, Name = "Real Madrid" },
                new Team{Id =7, CountryId = 2, Name = "Standard" },
                new Team{Id =8, CountryId = 2, Name = "Brugge" },
                new Team{Id =9, CountryId = 3, Name = "Spartak Varna" },
            };

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "MyMockedData")
                   .Options;
            this.data = new ApplicationDbContext(options);
            this.data.AddRange(this.teams);
            this.data.AddRange(this.countries);
            this.data.AddRange(this.stadiums);
            this.data.SaveChanges();

            ITeamService service = new TeamService(data);
            AddNewTeamModel model = new AddNewTeamModel()
            {
                StadiumId = 1,
                Id = 1,
                Name = "Strumska Slava",
                CountryId = 1,

            };
            service.SaveChangesAsync(model);
            var result = service.FindTeamToBeEdited(1);
            Assert.That(result.Result.Name, Is.EqualTo("Strumska Slava"));
            Assert.That(result.Result.StadiumId, Is.EqualTo(1));
            Assert.That(result.Result.CountryId, Is.EqualTo(1));

            this.data.RemoveRange(this.teams);
            this.data.RemoveRange(this.countries);
            this.data.RemoveRange(this.stadiums);
            this.data.SaveChanges();

        }



    }
    
}
