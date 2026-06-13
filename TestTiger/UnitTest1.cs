using MyTiger;
using NUnit.Framework;

namespace TestTiger
{
    public class TigerTests
    {
        private Tiger tiger;

        [SetUp]
        public void Setup()
        {
            tiger = new Tiger { Name = "TestTiger" };
        }

        // Feed tests
        [Test]
        public void Feed_DecreasesHunger()
        {
            tiger.Hunger = 60;
            tiger.Feed();
            Assert.That(tiger.Hunger, Is.EqualTo(40));
        }

        [Test]
        public void Feed_HungerDoesNotGoBelowZero()
        {
            tiger.Hunger = 10;
            tiger.Feed();
            Assert.That(tiger.Hunger, Is.EqualTo(0));
        }

        [Test]
        public void Feed_WhenAlreadyFull_StaysAtZero()
        {
            tiger.Hunger = 0;
            tiger.Feed();
            Assert.That(tiger.Hunger, Is.EqualTo(0));
        }

        // Play tests
        [Test]
        public void Play_IncreasesHappiness()
        {
            tiger.Happiness = 50;
            tiger.Play();
            Assert.That(tiger.Happiness, Is.EqualTo(70));
        }

        [Test]
        public void Play_HappinessDoesNotExceed100()
        {
            tiger.Happiness = 95;
            tiger.Play();
            Assert.That(tiger.Happiness, Is.EqualTo(100));
        }

        [Test]
        public void Play_DecreasesEnergy()
        {
            tiger.Energy = 50;
            tiger.Play();
            Assert.That(tiger.Energy, Is.EqualTo(40));
        }

        [Test]
        public void Play_EnergyDoesNotGoBelowZero()
        {
            tiger.Energy = 5;
            tiger.Play();
            Assert.That(tiger.Energy, Is.EqualTo(0));
        }

        // Sleep tests
        [Test]
        public void Sleep_IncreasesEnergy()
        {
            tiger.Energy = 30;
            tiger.Sleep();
            Assert.That(tiger.Energy, Is.EqualTo(50));
        }

        [Test]
        public void Sleep_EnergyDoesNotExceed100()
        {
            tiger.Energy = 90;
            tiger.Sleep();
            Assert.That(tiger.Energy, Is.EqualTo(100));
        }

        [Test]
        public void Sleep_IncreasesHunger()
        {
            tiger.Hunger = 50;
            tiger.Sleep();
            Assert.That(tiger.Hunger, Is.EqualTo(55));
        }

        // HighFive tests
        [Test]
        public void HighFive_IncreasesHappiness()
        {
            tiger.Happiness = 50;
            tiger.HighFive();
            Assert.That(tiger.Happiness, Is.EqualTo(60));
        }

        [Test]
        public void HighFive_HappinessDoesNotExceed100()
        {
            tiger.Happiness = 95;
            tiger.HighFive();
            Assert.That(tiger.Happiness, Is.EqualTo(100));
        }

        // time test
        [Test]
        public void Tick_IncreasesHunger()
        {
            tiger.Hunger = 50;
            tiger.Tick();
            Assert.That(tiger.Hunger, Is.EqualTo(51));
        }

        [Test]
        public void Tick_DecreasesHappiness()
        {
            tiger.Happiness = 50;
            tiger.Tick();
            Assert.That(tiger.Happiness, Is.EqualTo(49));
        }

        [Test]
        public void Tick_DecreasesEnergy()
        {
            tiger.Energy = 50;
            tiger.Tick();
            Assert.That(tiger.Energy, Is.EqualTo(49));
        }

        [Test]
        public void Tick_IncreasesAge()
        {
            tiger.Age = 0;
            tiger.Tick();
            Assert.That(tiger.Age, Is.EqualTo(1));
        }

        [Test]
        public void Tick_DoesNothingWhenDead()
        {
            tiger.IsDead = true;
            tiger.Hunger = 50;
            tiger.Tick();
            Assert.That(tiger.Hunger, Is.EqualTo(50));
        }

        // Death womp womp
        [Test]
        public void Tick_KillsTigerWhenHungerReaches100()
        {
            tiger.Hunger = 99;
            tiger.Happiness = 50;
            tiger.Energy = 50;
            tiger.Tick();
            Assert.That(tiger.IsDead, Is.True);
        }

        [Test]
        public void Tick_KillsTigerWhenHappinessReachesZero()
        {
            tiger.Hunger = 50;
            tiger.Happiness = 1;
            tiger.Energy = 50;
            tiger.Tick();
            Assert.That(tiger.IsDead, Is.True);
        }

        [Test]
        public void Tick_KillsTigerWhenEnergyReachesZero()
        {
            tiger.Hunger = 50;
            tiger.Happiness = 50;
            tiger.Energy = 1;
            tiger.Tick();
            Assert.That(tiger.IsDead, Is.True);
        }

        // Growing
        [Test]
        public void Stage_IsBabyWhenAgeIsZero()
        {
            tiger.Age = 0;
            Assert.That(tiger.Stage, Is.EqualTo(GrowthStage.Baby));
        }

        [Test]
        public void Stage_IsBabyWhenAgeIsNine()
        {
            tiger.Age = 9;
            Assert.That(tiger.Stage, Is.EqualTo(GrowthStage.Baby));
        }

        [Test]
        public void Stage_IsTeenWhenAgeIsTen()
        {
            tiger.Age = 10;
            Assert.That(tiger.Stage, Is.EqualTo(GrowthStage.Teen));
        }

        [Test]
        public void Stage_IsTeenWhenAgeIsTwentyNine()
        {
            tiger.Age = 29;
            Assert.That(tiger.Stage, Is.EqualTo(GrowthStage.Teen));
        }

        [Test]
        public void Stage_IsAdultWhenAgeIsThirty()
        {
            tiger.Age = 30;
            Assert.That(tiger.Stage, Is.EqualTo(GrowthStage.Adult));
        }

        [Test]
        public void Stage_IsAdultWhenAgeIsHighNumber()
        {
            tiger.Age = 100;
            Assert.That(tiger.Stage, Is.EqualTo(GrowthStage.Adult));
        }
    }
}
