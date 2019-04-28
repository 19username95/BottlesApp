using SQLite;

namespace BottlesApp.Models
{
    public class UserModel : IEntityBase
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

    }
}
