using System;
using WhoScored.Models.Models.Enums;

namespace WhoScored.MVP.Models.CustomEventArgs
{
    public class AddPlayerEventArgs : EventArgs
    {
        public AddPlayerEventArgs(
            string firstName,
            string lastName,
            string imagePath,
            string position,
            int height,
            int weight,
            int shirtNumber,
            int countryId,
            int teamId,
            DateTime birthDate)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.ImagePath = imagePath;
            this.Position = (PlayerPositionType)Enum.Parse(typeof (PlayerPositionType), position);
            this.ShirtNumber = shirtNumber;
            this.Height = height;
            this.Weight = weight;
            this.CountryId = countryId;
            this.TeamId = teamId;
            this.BirthDate = birthDate;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string ImagePath { get; set; }

        public PlayerPositionType Position { get; set; }

        public int ShirtNumber { get; set; }

        public DateTime? BirthDate { get; set; }

        public int Height { get; set; }

        public int Weight { get; set; }

        public int CountryId { get; set; }

        public int TeamId { get; set; }
    }
}
