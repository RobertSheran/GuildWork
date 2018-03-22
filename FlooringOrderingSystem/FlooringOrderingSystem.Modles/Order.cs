namespace FlooringOrderingSystem.Modles
{
    //OrderNumber – int
    //CustomerName – string
    //State – string
    //TaxRate – decimal
    //ProductType – string
    //Area – decimal
    //CostPerSquareFoot – decimal
    //LaborCostPerSquareFoot – decimal
    //MaterialCost – decimal
    //LaborCost – decimal
    //Tax – decimal
    //Total – decimal

    public class Order
    {
        public int OrderNumber { get; set; }
        public string CustomerName { get; set; }
        public string State { get; set; }
        public decimal TaxRate { get; set; }
        public string ProductType { get; set; }
        public decimal Area { get; set; }
        public decimal CostPerSquareFoot { get; set; }
        public decimal LaborCostPerSquareFoot { get; set; }
        public decimal MaterialCost { get; set; }
        public decimal LaborCost { get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }
        public string OrderDate { get; set; }
    }
}
