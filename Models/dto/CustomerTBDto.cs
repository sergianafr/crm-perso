namespace crm_perso.Models
{
    using System;

public class CustomerTBDto
{
    public int CustomerId { get; set; }
    public string CustomerName { get; set; }
    public string CustomerCountry { get; set; }
    public decimal TotalAmount { get; set; }

    public CustomerTBDto()
    {
    }

    public CustomerTBDto(int customerId, string customerName, string customerCountry, decimal totalAmount)
    {
        CustomerId = customerId;
        CustomerName = customerName;
        CustomerCountry = customerCountry;
        TotalAmount = totalAmount;
    }
}
}