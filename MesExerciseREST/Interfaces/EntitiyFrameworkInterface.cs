namespace MesExerciseREST.Interfaces
{
    public class EntitiyFrameworkInterface:InterfaceBase
    {
        AplicationDBContext _context;
        public EntitiyFrameworkInterface()
        {
            _context = new AplicationDBContext();
            _context.Database.EnsureCreated();
        }

        public bool DoesItemExist(string Key)
        {
            return _context.ItemTable.Where(item => item.Key == Key).Any();
        }

        public ExampleItem GetItem(string Key)
        {
            return _context.ItemTable.Where(item => item.Key == Key).First();
        }

        public void AddItem(ExampleItem newItem)
        {
            _context.ItemTable.Add(newItem);
            _context.SaveChanges();
        }

        public void DeleteItem(string Key)
        {
            _context.ItemTable.RemoveRange(_context.ItemTable.Where(item => item.Key == Key));
            _context.SaveChanges();
        }

        public void UpdateItem(ExampleItem UpdatedItem)
        {
            _context.ItemTable.Where(item => item.Key == UpdatedItem.Key).FirstOrDefault().Value = UpdatedItem.Value;
            _context.SaveChanges();
        }

        public IEnumerable<ExampleItem> SearchItemsByValue(string value)
        {
            var Querry = _context.ItemTable.Where(item => item.Value.Contains(value));
            return Querry.ToArray();
        }
    }
}
