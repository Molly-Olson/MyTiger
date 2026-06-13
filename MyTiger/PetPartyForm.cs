using System;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;

namespace MyTiger
{
    public partial class PetPartyForm : Form
    {
        private string petName;
        private string imagePath;
        private static readonly HttpClient client = new HttpClient();

        public PetPartyForm(string petName, string imagePath)
        {
            InitializeComponent();
            this.petName = petName;
            this.imagePath = imagePath;
        }

        private async void btnCreate_Click(object sender, EventArgs e)
        {
            lblStatus.Text = "Creating room...";
            btnCreate.Enabled = false;

            string imageBase64 = Convert.ToBase64String(File.ReadAllBytes(imagePath));

            var body = new { name = petName, image = imageBase64 };
            var json = JsonSerializer.Serialize(body);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await client.PostAsync("https://virtualpetparty.up.railway.app/api/room/create?api-key=foo", content);
                string responseText = await response.Content.ReadAsStringAsync();

                string roomCode = responseText.Trim('"');

                lblStatus.Text = $"Room created! Code: {roomCode}";
                txtRoomCode.Text = roomCode;
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error: " + ex.Message;
            }

            btnCreate.Enabled = true;
        }

        private async void btnJoin_Click(object sender, EventArgs e)
        {
            string code = txtRoomCode.Text.Trim();
            if (string.IsNullOrEmpty(code))
            {
                MessageBox.Show("Enter a room code first.");
                return;
            }

            lblStatus.Text = "Joining room...";
            btnJoin.Enabled = false;

            try
            {
                var response = await client.PostAsync(
                    $"https://virtualpetparty.up.railway.app/api/room/join/{code}?api-key=foo",
                    new StringContent(""));

                string responseText = await response.Content.ReadAsStringAsync();

                using var doc = JsonDocument.Parse(responseText);
                var visitor = doc.RootElement.GetProperty("visitor");
                string visitorName = visitor.GetProperty("name").GetString() ?? "Unknown";
                string visitorImage = visitor.GetProperty("image").GetString() ?? "";

                lblVisitorName.Text = $"Visitor: {visitorName}";

                if (!string.IsNullOrEmpty(visitorImage))
                {
                    byte[] imageBytes = Convert.FromBase64String(visitorImage);
                    using var ms = new MemoryStream(imageBytes);
                    visitorPic.Image = Image.FromStream(ms);
                }

                lblStatus.Text = $"{visitorName} came to visit!";
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error: " + ex.Message;
            }

            btnJoin.Enabled = true;
        }
    }
}
