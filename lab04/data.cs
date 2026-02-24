namespace data{
    public record Employee(
        string EmployeeId,
        string LastName,
        string FirstName,
        string Title,
        string TitleOfCourtesy,
        string BirthDate,
        string HireDate,
        string Address,
        string City,
        string Region,
        string PostalCode,
        string Country,
        string HomePhone,
        string Extension,
        string Photo,
        string Notes,
        string ReportsTo,
        string PhotoPath
    );

    public record OrderDetails(
        string OrderId,
        string ProductId,
        string UnitPrice,
        string Quantity,
        string Discount
    );
}