using System;
using System.Drawing;
using System.IO;
using System.Net.Http.Headers;
using System.Windows.Forms;

namespace MyTiger
{
    public partial class Form1 : Form
    {
        private Tiger tiger;
        private System.Windows.Forms.Timer gameTimer;

        private static readonly HttpClient client = new HttpClient();
        const string api_key = "?api-key=foo";
        public Form1()
        {
            InitializeComponent();
            InitializeGame();

            client.BaseAddress = new Uri("https://virtualpetparty.up.railway.app");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
            
            UpdateUI();
        }

        private void InitializeGame()
        {
            // check for existing pets and show names if any
            var savePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            savePath = Path.Combine(savePath, "MyTiger");

            if (Directory.Exists(savePath))
            {
                var folders = Directory.GetDirectories(savePath);
                if (folders.Length > 0)
                {
                    string petList = "Existing pets:\n";
                    foreach (var folder in folders)
                    {
                        petList = petList + Path.GetFileName(folder) + "\n";
                    }
                    MessageBox.Show(petList, "Welcome Back!");
                }
            }

            // ask for name, try to load existing tiger
            string name = Microsoft.VisualBasic.Interaction.InputBox("What is your tiger's name?", "My Pet Tiger");
            if (string.IsNullOrWhiteSpace(name)) name = "Tiger";

            Tiger loaded = Tiger.Load(name);
            if (loaded != null)
            {
                tiger = loaded;
            }
            else
            {
                tiger = new Tiger { Name = name };
                tiger.Save();
            }

            this.FormClosing += (s, e) => tiger.Save();

            btnFeed.Click += btnFeed_Click;
            btnPlay.Click += btnPlay_Click;
            Sleep.Click += btnSleep_Click;
            btnHighFive.Click += btnHighFive_Click;
            btnDelete.Click += btnDelete_Click;
            btnParty.Click += btnParty_Click;

            // timer ticks every 10 seconds rn which still seems long maybe try 5 seconds instead of 1?
            gameTimer = new System.Windows.Forms.Timer();
            gameTimer.Interval = 5000;
            gameTimer.Tick += GameTick;
            gameTimer.Start();

            UpdateUI();
        }

        private void GameTick(object sender, EventArgs e)
        {
            tiger.Tick();

            if (tiger.IsDead)
            {
                gameTimer.Stop();
                UpdateUI();
                MessageBox.Show($"Oh no, {tiger.Name} your little baby has passed away. Please do not ever buy even a plant, you virtual murderer!");
                return;
            }

            tiger.Save();
            UpdateUI();
        }

        private void UpdateUI()
        {
            lblHunger.Text = $"Hunger: {tiger.Hunger}";
            lblHappiness.Text = $"Happiness: {tiger.Happiness}";
            lblEnergy.Text = $"Energy: {tiger.Energy}";
            lblStage.Text = $"Stage: {tiger.Stage}  |  Age: {tiger.Age}";
            UpdateImage();
        }

        private void UpdateImage()
        {
            string imageName;

            if (tiger.IsDead)
            {
                imageName = "AngryTiger.jpg";
            }
            else if (tiger.Hunger >= 70)
            {
                imageName = "TiredTiger.jpg";   // feed yo tiger fool, I was thinking of like updating the images to have text on them but we'll see
            }
            else if (tiger.Energy <= 30)
            {
                imageName = "ChillTiger.jpg";   // wanting the pictures as like visual cues
            }
            else if (tiger.Happiness <= 30)
            {
                imageName = "AngryTiger.jpg";   // no one wants an angry tiger!
            }
            else
            {
                imageName = tiger.Stage switch
                {
                    GrowthStage.Baby  => "BabyTiger.jpg",
                    GrowthStage.Teen  => "TeenTiger.jpg",
                    GrowthStage.Adult => "AdultTiger.jpg",
                    _                 => "Tiger.jpg"
                };
            }

            string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", imageName);

            if (!File.Exists(imagePath))
                imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", "Tiger.jpg");

            // load via stream so the file isn't locked between ticks... I don't remember where I found this now... this is why I never x out my dang tabs!!!
            Image newImage;
            using (var stream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                newImage = Image.FromStream(stream);

            var old = petImage.Image;
            petImage.Image = newImage;
            old?.Dispose();
        }

        private void btnFeed_Click(object sender, EventArgs e)
        {
            tiger.Feed();
            lblHunger.Text = $"Hunger: {tiger.Hunger}";
            lblHappiness.Text = $"Happiness: {tiger.Happiness}";
            lblEnergy.Text = $"Energy: {tiger.Energy}";
            lblStage.Text = $"Stage: {tiger.Stage}  |  Age: {tiger.Age}";

            string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", "TiredTiger.jpg");
            if (File.Exists(imagePath))
            {
                Image newImage;
                using (var stream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                    newImage = Image.FromStream(stream);
                var old = petImage.Image;
                petImage.Image = newImage;
                old?.Dispose();

                var t = new System.Windows.Forms.Timer { Interval = 2000 };
                t.Tick += (s, ev) => { t.Stop(); t.Dispose(); UpdateImage(); };
                t.Start();
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            tiger.Play();
            lblHunger.Text = $"Hunger: {tiger.Hunger}";
            lblHappiness.Text = $"Happiness: {tiger.Happiness}";
            lblEnergy.Text = $"Energy: {tiger.Energy}";
            lblStage.Text = $"Stage: {tiger.Stage}  |  Age: {tiger.Age}";

            // show a different image briefly when pushing buttons
            string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", "DancingTiger.jpg");
            if (File.Exists(imagePath))
            {
                Image newImage;
                using (var stream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                    newImage = Image.FromStream(stream);
                var old = petImage.Image;
                petImage.Image = newImage;
                old?.Dispose();

                var t = new System.Windows.Forms.Timer { Interval = 2000 };
                t.Tick += (s, ev) => { t.Stop(); t.Dispose(); UpdateImage(); };
                t.Start();
            }
        }

        private void btnSleep_Click(object sender, EventArgs e)
        {
            tiger.Sleep();
            lblHunger.Text = $"Hunger: {tiger.Hunger}";
            lblHappiness.Text = $"Happiness: {tiger.Happiness}";
            lblEnergy.Text = $"Energy: {tiger.Energy}";
            lblStage.Text = $"Stage: {tiger.Stage}  |  Age: {tiger.Age}";

            string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", "ChillTiger.jpg");
            if (File.Exists(imagePath))
            {
                Image newImage;
                using (var stream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                    newImage = Image.FromStream(stream);
                var old = petImage.Image;
                petImage.Image = newImage;
                old?.Dispose();

                var t = new System.Windows.Forms.Timer { Interval = 2000 };
                t.Tick += (s, ev) => { t.Stop(); t.Dispose(); UpdateImage(); };
                t.Start();
            }
        }

        private void btnHighFive_Click(object sender, EventArgs e)
        {
            tiger.HighFive();
            lblHunger.Text = $"Hunger: {tiger.Hunger}";
            lblHappiness.Text = $"Happiness: {tiger.Happiness}";
            lblEnergy.Text = $"Energy: {tiger.Energy}";
            lblStage.Text = $"Stage: {tiger.Stage}  |  Age: {tiger.Age}";

            string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", "HighFiveBruhTiger.jpg");
            if (File.Exists(imagePath))
            {
                Image newImage;
                using (var stream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                    newImage = Image.FromStream(stream);
                var old = petImage.Image;
                petImage.Image = newImage;
                old?.Dispose();

                var t = new System.Windows.Forms.Timer { Interval = 2000 };
                t.Tick += (s, ev) => { t.Stop(); t.Dispose(); UpdateImage(); };
                t.Start();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                $"Are you sure you want to release {tiger.Name}? This cannot be undone.",
                "Release Pet",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes) return;

            gameTimer.Stop();

            var savePath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "MyTiger", tiger.Name);

            if (Directory.Exists(savePath))
                Directory.Delete(savePath, true);

            MessageBox.Show($"{tiger.Name} has been released into the wild. Goodbye!", "Released");
            Application.Restart();
        }

        private void btnParty_Click(object sender, EventArgs e)
        {
            string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", "Tiger.jpg");
            var partyForm = new PetPartyForm(tiger.Name, imagePath);
            partyForm.ShowDialog();
        }

        private void lblStage_Click(object sender, EventArgs e)
        {
            tiger.Save();
            UpdateUI();
        }
    }
}
