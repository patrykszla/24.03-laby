using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Xamarin.Essentials;

namespace LabApp.Models
{
    public class InstallationEntity
    {
        public string Id { get; set; }
        public string Location { get; set; }
        public string Address { get; set; }
        public double Elevation { get; set; }
        [JsonProperty(PropertyName = "airly")]
        public bool IsAirlyInstallation { get; set; }

        public InstallationEntity()
        {
        }

        public InstallationEntity(Installation installation)
        {
            this.Id = installation.Id.ToString();
            this.Location = JsonConvert.SerializeObject(installation.Location);
            this.Address = JsonConvert.SerializeObject(installation.Address);
            this.Elevation = installation.Elevation;
            this.IsAirlyInstallation = installation.IsAirlyInstallation;
        }
    }

}
