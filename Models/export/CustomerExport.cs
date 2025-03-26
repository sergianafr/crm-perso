namespace crm_perso.export
{
    public class CustomerExport{
        private String email{get;set;}
        // private CustomerLoginInfoExport profile{get;set;}
        private String name{get;set;}
        private List<BudgetExport> budgets{get; set;}
        private List<TicketExport> tickets{get;set;}
        private List<LeadExport> leads{get; set;}
    }
}