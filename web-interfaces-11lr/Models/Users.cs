using System.ComponentModel.DataAnnotations;

namespace _6lr
{
    public class Users
    {
        public int Id { get; set; }
        [MaxLength(15, ErrorMessage = "Ім'я не повинно перевищувани 15 букв, але якщо ваше ім'я містить більше, не вибачаюсь")]
        public string? Name { get; set; }
        [MaxLength(15, ErrorMessage = "Прізвище не повинно перевищувани 15 букв, але якщо ваше мрізвище містить більше, не вибачаюсь")]
        public string? Surname { get; set; }
        [EmailAddress(ErrorMessage = "Некоректна адреса")]
        public string? Email { get; set; }
        public DateTime Birth { get; set; }
        public string? Password { get; set; }
        public DateTime LastAuth { get; set; }
        public int ErrAuth { get; set; }

    }
}
