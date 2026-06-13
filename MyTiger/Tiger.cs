using System;
using System.IO;
using System.Text.Json;

namespace MyTiger
{
    public enum GrowthStage
    {
        Baby,
        Teen,
        Adult
    }

    public class Tiger
    {
        public string Name { get; set; } = "Tiger";
        public int Hunger { get; set; } = 50;      // 0 = full, 100 = starving
        public int Happiness { get; set; } = 50;   // 0 = sad, 100 = happy
        public int Energy { get; set; } = 50;      // 0 = tired, 100 = full energy
        public int Age { get; set; } = 0;
        public bool IsDead { get; set; } = false;

        public GrowthStage Stage
        {
            get
            {
                if (Age < 10) return GrowthStage.Baby;
                else if (Age < 30) return GrowthStage.Teen;
                else return GrowthStage.Adult;
            }
        }

        public void Tick()
        {
            if (IsDead) return;

            Hunger = Hunger + 1;
            if (Hunger > 100) Hunger = 100;

            Happiness = Happiness - 1;
            if (Happiness < 0) Happiness = 0;

            Energy = Energy - 1;
            if (Energy < 0) Energy = 0;

            Age = Age + 1;

            if (Hunger >= 100 || Happiness <= 0 || Energy <= 0)
                IsDead = true;
        }

        public void Feed()
        {
            Hunger = Hunger - 20;
            if (Hunger < 0) Hunger = 0;
        }

        public void Play()
        {
            Happiness = Happiness + 20;
            if (Happiness > 100) Happiness = 100;

            Energy = Energy - 10;
            if (Energy < 0) Energy = 0;
        }

        public void Sleep()
        {
            Energy = Energy + 20;
            if (Energy > 100) Energy = 100;

            Hunger = Hunger + 5;
            if (Hunger > 100) Hunger = 100;
        }

        public void HighFive()
        {
            Happiness = Happiness + 10;
            if (Happiness > 100) Happiness = 100;
        }

        public void Save()
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            path = Path.Combine(path, "MyTiger");

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            path = Path.Combine(path, Name);
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            var options = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(this, options);
            File.WriteAllText(Path.Combine(path, "save.json"), json);
        }

        public static Tiger? Load(string name)
        {
            var path = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "MyTiger", name, "save.json");

            if (!File.Exists(path)) return null;

            var options = new JsonSerializerOptions { WriteIndented = true };
            return JsonSerializer.Deserialize<Tiger>(File.ReadAllText(path), options);
        }
    }
}
