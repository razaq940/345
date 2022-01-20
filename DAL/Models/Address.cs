using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class Address
    {
        public long Id { get; set; }
        public string Alamat { get; set; }
        public string KodePos { get; set; }
        public string Kelurahan { get; set; }
        public string Kecamatan { get; set; }
        public string Kabupaten_Kota { get; set; }
        public string Provinsi { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
    }
}
