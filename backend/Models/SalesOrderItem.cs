public class SalesOrderItem {

    public int OrderId { get; set; }
    public int ProductId { get; set; }

    public required int Quantity { get; set; }

    public required decimal UnitPrice { get; set; }
}