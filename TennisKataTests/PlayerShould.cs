using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using TennisKata;

namespace TennisKataTests
{
    [TestFixture]
    public class PlayerShould
    {
        Player player;

        [SetUp]
        public void BeforeEach()
        {
            player = new Player("Player1");
        }

        [Test]
        public void BeInicialisedWithAName()
        {
            player.Name.Should().Be("Player1");
        }

        [Test]
        public void AddOnePoints()
        {
            player.AddPoint();

            player.Points.Should().Be(1);
        }

        [Test]
        public void KnowIfHasMoreThanThreePoints()
        {
            player.AddPoint();
            player.AddPoint();
            player.AddPoint();
            player.AddPoint();

            player.HasPointsToWin().Should().Be(true);
        }
    }
}
