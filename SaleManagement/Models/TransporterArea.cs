using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SaleManagement.Models
{
    public class TransporterArea
    {
        [ForeignKey("Transporter")]
        public int TransporterId { get; set; }
        public Transporter Transporter { get; set; }

        [ForeignKey("Area")]
        public int AreaId { get; set; }
        public Area Area { get; set; }
    }
}
