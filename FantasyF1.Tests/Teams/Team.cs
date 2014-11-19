using System.Linq;
using Effort;
using FantasyF1.Controllers;
using NUnit.Framework;
using Shouldly;

namespace FantasyF1.Tests.Teams
{
    namespace FantasyF1.Tests
    {
        [TestFixture]
        public class TeamTests
        {
            FantasyF1Entities dataBase;
            TeamController teamController;

            [SetUp]
            public void Team_TestInitialize()
            {
                var connection = EntityConnectionFactory.CreateTransient("name=FantasyF1Entities");
                dataBase = new FantasyF1Entities(connection);

                dataBase.Teams.Add(new Team()
                    {
                        TeamName = "Team One"
                    });

                dataBase.Teams.Add(new Team()
                {
                    TeamName = "Team Two"
                });

                dataBase.SaveChanges();

                teamController = new TeamController(dataBase);
            }

            [Test]
            public void Can_Add_a_Team()
            {
                var team = new Team()
                    {
                        TeamName = "Team 3"
                    };

                teamController.Create(team);

                var newTeam = dataBase.Teams.FirstOrDefault(t => t.TeamName == "Team 3");
                newTeam.ShouldNotBe(null);
            }

            [Test]
            public void Can_edit_an_existing_team()
            {
                var team = dataBase.Teams.FirstOrDefault(t => t.TeamId == 1);
                team.TeamName = "Changed Team Name";

                teamController.Edit(team);
                var newTeam = dataBase.Teams.FirstOrDefault(t => t.TeamName == "Changed Team Name");
                newTeam.ShouldNotBe(null);
            }


            [Test]
            public void Can_delete_a_team()
            {
                teamController.DeleteConfirmed(1);
                var team = dataBase.Teams.Find(1);
                team.ShouldBe(null);
            }
        }
    }
}
