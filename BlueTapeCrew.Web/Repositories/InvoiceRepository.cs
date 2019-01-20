using BlueTapeCrew.Web.Data;
using BlueTapeCrew.Web.Models.Entities;
using BlueTapeCrew.Web.Repositories.Interfaces;
using System;
using System.Threading.Tasks;

namespace BlueTapeCrew.Web.Repositories
{
    public class InvoiceRepository : IInvoiceRepository, IDisposable
    {
        private readonly ApplicationDbContext _db;

        public InvoiceRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Invoice> Create(Invoice invoice)
        {
            _db.Invoices.Add(invoice);
            await _db.SaveChangesAsync();
            return invoice;
        }

        public async Task Delete(int id)
        {
            var invoice = await _db.Invoices.FindAsync(id);
            if (invoice == null) return;
            _db.Invoices.Remove(invoice);
            await _db.SaveChangesAsync();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}