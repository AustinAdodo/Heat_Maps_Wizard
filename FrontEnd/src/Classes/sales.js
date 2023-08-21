class Sales {
    constructor(id = 1, salesId = '', Amount = 0.00, Quantity = 0, Description = '', 
    date = null, time = '') {
        this.id = id;
        this.salesId = salesId;
        this.Amount = Amount;
        this.Quantity=  Quantity;
        this.SumTotal = this.Amount * this.Quantity;
        this.Description = Description;
        this.DateTime = date || new Date().toLocaleDateString();
        this.Time = time;
    }
}
export default Sales;