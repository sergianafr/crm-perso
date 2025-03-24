namespace crm_perso.Models
{
    public class LeadDto
{
    public int LeadId { get; set; }
    public string Name { get; set; }
    public string Status { get; set; }
    public string Phone { get; set; }
    public string ManagerName { get; set; } // Nom du manager
    public string EmployeeName { get; set; } // Nom de l'employé
    public string CustomerName { get; set; } 
    public string CreatedAt { get; set; } 
    public string Expense {get; set; }
}
}