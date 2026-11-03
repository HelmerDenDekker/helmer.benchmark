
namespace Helmer.Benchmark.Application.Code
{
    public class SelectFromListTest
    {
        private static List<Store> _storeList = GenerateStores();

        private static List<Store> GenerateStores()
        {
            var stores = new List<Store>();
            for (int i = 1; i <= 100; i++)
            {
                stores.Add(new Store
                {
                    StoreId = $"S{i:000}",
                    Name = $"Store {i}"
                });
            }
            return stores;
        }

        public static List<Store?> TestEquals()
        {
            var storeIds = new [] { "S001", "S040", "S067", "S100" };
            var stores = storeIds
                .Select(requestedStoreId => _storeList.FirstOrDefault(store => store.StoreId.Equals(requestedStoreId)))
                .Where(reference => reference != null)
                .ToList();
            
            Console.WriteLine("Stores found: " + stores.Count);
            
            return stores;
        }
        
        public static List<Store?> TestIsIs()
        {
            var storeIds = new [] { "S001", "S040", "S067", "S100" };
            var stores = storeIds
                .Select(requestedStoreId => _storeList.FirstOrDefault(store => store.StoreId == requestedStoreId))
                .Where(reference => reference != null)
                .ToList();
            
            Console.WriteLine("Stores found: " + stores.Count);
            
            return stores;
        }
        
        public static List<Store> TestHashSet()
        {
            var storeIds = new [] { "S001", "S040", "S067", "S100" };
            var storeIdSet = new HashSet<string>(storeIds);
            var stores = _storeList.Where(store => storeIdSet.Contains(store.StoreId)).ToList();
            Console.WriteLine("Stores found: " + stores.Count);
            return stores;
        }

        public static List<Store?> TestFilterOnStoreId()
        {
            var storeIds = new [] { "S001", "S040", "S067", "S100" };

            var stores = _storeList.Where(store => storeIds.Contains(store.StoreId)).ToList();
            Console.WriteLine("Stores found: " + stores.Count);
            return stores;
        }
        
        public static List<Store?> TestIntersect()
        {
            var storeIds = new [] { "S001", "S040", "S067", "S100" };

            var stores = _storeList.Intersect(
                _storeList.Where(store => storeIds.Contains(store.StoreId))
            ).ToList();
            Console.WriteLine("Stores found: " + stores.Count);
            return stores;
        }
        
        public static List<Store?> TestForeach()
        {
            var storeIds = new [] { "S001", "S040", "S067", "S100" };
            
            var stores = new List<Store>();
            foreach (var storeId in storeIds)
            {
                var store = _storeList.FirstOrDefault(s => s.StoreId == storeId);
                if (store != null)
                {
                    stores.Add(store);
                }
            }
            Console.WriteLine("Stores found: " + stores.Count);
            return stores;
        }
        
    }

    public class Store
    {
        public string StoreId { get; set; }
        public string Name { get; set; }
    }
}
