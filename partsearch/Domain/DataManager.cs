using partsearch.Domain.Repositories.Abstract;

namespace partsearch.Domain
{
    public class DataManager
    {
        public ITextFieldsRepository TextFields { get; set; }
        public IPartsRepository Parts { get; set; }

        public DataManager(ITextFieldsRepository textFieldsRepository, IPartsRepository partsRepository)
        {
            TextFields = textFieldsRepository;
            Parts = partsRepository;
        }
    }
}
