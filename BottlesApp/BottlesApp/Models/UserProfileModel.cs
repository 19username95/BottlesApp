using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.GoogleMaps;

namespace BottlesApp.Models
{
    public class UserProfileModel : IEntityBase
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }
        public int UserModelId { get; set; }
        public string Name { get; set; }
        public int BottlesSaved { get; set; }
        public int CarboneSaved { get; set; }
        //[OneToMany]
        //public List<PinModel> FavouritePoints { get; set; }
    }
}
