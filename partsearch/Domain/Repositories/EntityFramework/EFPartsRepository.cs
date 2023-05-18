using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using partsearch.Domain;
using partsearch.Domain.Entities;
using partsearch.Domain.Repositories.Abstract;

namespace partsearch.Domain.Repositories.EntityFramework
{
    public class EFPartsRepository : IPartsRepository
    {
        private readonly AppDbContext context;
        public EFPartsRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Part> GetParts()
        {
            return context.Parts;
        }

        public Part GetPartById(Guid id)
        {
            return context.Parts.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<Part> GetPartsByCode(string code)
        {
            System.Diagnostics.Debug.WriteLine(code);
            System.Diagnostics.Trace.WriteLine(code);
            return context.Parts.Where(x => x.Code == code);
        }

        public void SavePart(Part entity)
        {
            if (entity.Id == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeletePart(Guid id)
        {
            context.Parts.Remove(new Part() { Id = id });
            context.SaveChanges();
        }
    }
}
