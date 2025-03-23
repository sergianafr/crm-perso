namespace crm_perso.Models
{
    public class TicketDto
    {
        public int TicketId { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string Priority { get; set; }
        public string EmployeeName { get; set; }
        public string CustomerName { get; set; }
        public string ManagerName { get; set; }
        public string CreatedAt { get; set; }
        public string Expense {get; set;}

        // Constructeur par défaut
        public TicketDto()
        {
        }

        // Constructeur avec tous les paramètres
        public TicketDto(int ticketId, string subject, string description, string status, string priority, string employeeName, string customerName, string managerName, string createdAt)
        {
            TicketId = ticketId;
            Subject = subject;
            Description = description;
            Status = status;
            Priority = priority;
            EmployeeName = employeeName;
            CustomerName = customerName;
            ManagerName = managerName;
            CreatedAt = createdAt;
        }
    }
}