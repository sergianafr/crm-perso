namespace crm_perso.Models
{
        public class CustomerDto
    {
        public int Id { get; set; } // Correspond à customerId en Java
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Country { get; set; }
        public string Budget { get; set; } // Supposé être une chaîne de caractères
        public string Expense { get; set; } // Supposé être une chaîne de caractères

        // Constructeur par défaut
        public CustomerDto()
        {
        }

        // Constructeur paramétré
        public CustomerDto(int id, string name, string email, string phone, string country, string budget, string expense)
        {
            Id = id;
            Name = name;
            Email = email;
            Phone = phone;
            Country = country;
            Budget = budget;
            Expense = expense;
        }
    }
}