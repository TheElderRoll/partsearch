using System;
using System.Linq;
using partsearch.Domain.Entities;

namespace partsearch.Domain.Repositories.Abstract
{
    public interface IPartsRepository
    {
        IQueryable<Part> GetParts();
        Part GetPartById(Guid id);
        void SavePart(Part entity);
        void DeletePart(Guid id);
    }
}
