namespace LibreriaBoscoso.Models
{
    public class User  // Cambié 'class' por 'public class'
    {
        public int UserId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Pass { get; set; }

        public string Role { get; set; }
    }
}
