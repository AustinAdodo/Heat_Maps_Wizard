using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace HeatMaps.Utilities.Sales
{
    public class SalesService : ISalesService
    {
        private readonly ApplicationDbContext _salesContext;

        public SalesService(ApplicationDbContext salesContext)
        {
            _salesContext = salesContext;
        }

        public void Add(Sale details)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id, CancellationToken Token)
        {
            throw new NotImplementedException(Token.ToString());
        }

        public async Task<Sale> Get(int id, CancellationToken Token)
        {
            var Product = await _salesContext.Sales.FindAsync(id);
            if (Product != null) return Product;
            var result = Enumerable.Empty<Sale>().ToList().First();
            return result;
        }

        public async Task<Sale> Get(string SaleId)
        {
            var detail = await _salesContext.Sales.Where(a => a.SalesId == SaleId).FirstAsync();
            if (detail != null) return detail;
            var result = Enumerable.Empty<Sale>().ToList().First();
            return result;
        }

        public async Task<List<Sale>> GetAll(int pageNumber, CancellationToken Token)
        {
            int pageSize = Preferences.PageSize;
            var All = await _salesContext.Sales.OrderBy(a => a.id).Where(a => a.id > (pageNumber - 1) * pageSize && a.Amount != 0)
                .Take(pageSize).ToListAsync(Token);
            return All ?? Enumerable.Empty<Sale>().ToList();
        }

        public async Task<List<DateTime>> GetDates()
        {
            var dates = await _salesContext.Sales.Select(a => a.Date.Date).Distinct().ToListAsync();
            return dates ?? Enumerable.Empty<DateTime>().ToList();
        }

        public async Task<List<Sale>> GetSalesOnDate(DateTime date)
        {
            // Normalize the time component to midnight
            DateTime normalizedDate = date.Date;
            var sales = await _salesContext.Sales.Where(a => a.Date.Date == normalizedDate && a.Amount != 0).ToListAsync();
            return sales ?? Enumerable.Empty<Sale>().ToList();
        }

        public async void Update(int id, Sale newDetails)
        {
            var result = await _salesContext.Sales.FindAsync(id);
            if (result != null)
            {
                foreach (PropertyInfo prty in typeof(Sale).GetProperties())
                {
                    if (prty.GetValue(newDetails) != null)
                    {
                        prty.SetValue(result, prty.GetValue(newDetails));
                    }
                }
                _salesContext.Sales.Attach(result);
                _salesContext.Entry(result).State = EntityState.Modified;
            }
            await _salesContext.SaveChangesAsync();
        }
    }
}
