namespace crm_perso.Models;
public class DashboardData
{
    public bool Success { get; set; }
    public int NbCustomers { get; set; }
    public int NbTickets { get; set; }
    public int NbLeads { get; set; }
    public decimal totalBudget {get; set;}
    public string TotalBudgetFormat {get; set;}
    public List<CustomerTBDto> CustomerBudget {get; set;}
    public string TotalExpense {get; set;}
    public string TotalExpenseFormat {get; set;}
    public List<CustomerTBDto> CustomerExpense {get; set;}


}