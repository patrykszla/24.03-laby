using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;


namespace LabApp.Models
{
    public class Installation
    {
        public int Id { get; set; }
        public Location Location { get; set; }
        public Address Address { get; set; }
        public double Elevation { get; set; }
        [JsonProperty(PropertyName = "airly")]
        public bool IsAirlyInstallation { get; set; }

        public Installation(InstallationEntity installationEntity)
        {
            int.TryParse(installationEntity.Id, out int installationEntityId);
            Id = installationEntityId;
            Location = JsonConvert.DeserializeObject<Location>(installationEntity.Location);
            Address = JsonConvert.DeserializeObject<Address>(installationEntity.Address);
            Elevation = installationEntity.Elevation;
            IsAirlyInstallation = installationEntity.IsAirlyInstallation;
        }
        public Installation()
        {

        }
    }

}