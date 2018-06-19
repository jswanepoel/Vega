using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vega.Models
{
    [Table("Features")]
    public class Feature
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<VehicleFeature> Features { get; set; }

        public Feature()
        {
            Features = new Collection<VehicleFeature>();
        }
    }
}