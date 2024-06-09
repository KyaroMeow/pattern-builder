using System.Collections.Generic;
using System.Linq;
using static WindowsFormsApp7.Class1;

namespace WindowsFormsApp7
{
    public class Class1
    {
        public class House
        {
            public string Type { get; set; }
            public int BasePrice { get; set; }
            public List<AdditionalBuilding> AdditionalBuildings { get; set; } = new List<AdditionalBuilding>();
            public int GetTotalPrice()
            {
                int totalPrice = BasePrice;
                foreach (var building in AdditionalBuildings)
                {
                    totalPrice += building.Price;
                }
                return totalPrice;
            }
            public string GetReceipt()
            {
                var receipt = new System.Text.StringBuilder();
                receipt.AppendLine($"Тип дома: {Type}");
                receipt.AppendLine($"Базовая цена: {BasePrice}");
                receipt.AppendLine("Дополнительные строения:");

                var groupedBuildings = AdditionalBuildings
                    .GroupBy(b => b.Name)
                    .Select(g => new
                    {
                        Name = g.Key,
                        Count = g.Count(),
                        TotalPrice = g.Sum(b => b.Price)
                    });

                foreach (var group in groupedBuildings)
                {
                    receipt.AppendLine($"{group.Name} (x{group.Count}): {group.TotalPrice}");
                }

                receipt.AppendLine($"Общая стоимость: {GetTotalPrice()}");

                return receipt.ToString();
            }
        }
        public class AdditionalBuilding
        {
            public string Name { get; set; }
            public int Price { get; set; }

            public AdditionalBuilding(string name, int price)
            {
                Name = name;
                Price = price;
            }
        }
        public interface IHouseBuilder
        {
            void SetHouseType(string type, int basePrice);
            void AddAdditionalBuilding(string name);
            void RemoveAdditionalBuilding(string name);
            House GetResult();
        }

        public class HouseBuilder : IHouseBuilder
        {
            private House _house = new House();

            public Dictionary<string, Dictionary<string, int>> additionalPrices = new Dictionary<string, Dictionary<string, int>>
            {
                { "Коттедж", new Dictionary<string, int>
                    {
                        { "Бассейн", 270000 },
                        { "Гараж (1 авто)", 150000 },
                        { "Гараж (2 авто)", 200000 },
                        { "Гараж (3 авто)", 350000 },
                        { "Статуя", 70000 },
                        { "Газон", 20000 },
                        { "Безопасность (охрана)", 60000 }
                    }
                },
                { "Вилла", new Dictionary<string, int>
                    {
                        { "Бассейн", 350000 },
                        { "Гараж (1 авто)", 150000 },
                        { "Гараж (2 авто)", 200000 },
                        { "Гараж (3 авто)", 350000 },
                        { "Статуя", 100000 },
                        { "Газон", 50000 },
                        { "Безопасность (охрана)", 130000 }
                    }
                },
                { "Таунхаус", new Dictionary<string, int>
                    {
                        { "Бассейн", 190000 },
                        { "Гараж (1 авто)", 150000 },
                        { "Гараж (2 авто)", 200000 },
                        { "Гараж (3 авто)", 350000 },
                        { "Статуя", 60000 },
                        { "Газон", 30000 },
                        { "Безопасность (охрана)", 70000 }
                    }
                },
                { "Дуплекс", new Dictionary<string, int>
                    {
                        { "Бассейн", 160000 },
                        { "Гараж (1 авто)", 150000 },
                        { "Гараж (2 авто)", 200000 },
                        { "Гараж (3 авто)", 350000 },
                        { "Статуя", 70000 },
                        { "Газон", 100000 },
                        { "Безопасность (охрана)", 90000 }
                    }
                },
                { "Квадруплекс", new Dictionary<string, int>
                    {
                        { "Бассейн", 340000 },
                        { "Гараж (1 авто)", 150000 },
                        { "Гараж (2 авто)", 200000 },
                        { "Гараж (3 авто)", 350000 },
                        { "Статуя", 90000 },
                        { "Газон", 120000 },
                        { "Безопасность (охрана)", 150000 }
                    }
                },
                { "Лейнхаус", new Dictionary<string, int>
                    {
                        { "Бассейн", 400000 },
                        { "Гараж (1 авто)", 250000 },
                        { "Гараж (2 авто)", 300000 },
                        { "Гараж (3 авто)", 450000 },
                        { "Статуя", 90000 },
                        { "Газон", 300000 },
                        { "Безопасность (охрана)", 300000 }
                    }
                }
            };

            public void SetHouseType(string type, int basePrice)
            {
                _house.Type = type;
                _house.BasePrice = basePrice;
            }
            public string GetHouseType()
            { 
                return _house.Type;
            }
            public int GetTotalPrice()
            {
                int totalPrice = _house.BasePrice;
                foreach (var building in _house.AdditionalBuildings)
                {
                    totalPrice += building.Price;
                }
                return totalPrice;
            }
            public void AddAdditionalBuilding(string name)
            {
                int price = additionalPrices[_house.Type][name];
                _house.AdditionalBuildings.Add(new AdditionalBuilding(name, price));
            }
            public void RemoveAdditionalBuilding(string name)
            {
                var buildingToRemove = _house.AdditionalBuildings.FirstOrDefault(b => b.Name == name);
                _house.AdditionalBuildings.Remove(buildingToRemove);
            }

            public House GetResult()
            {
                return _house;
            }
        }
    }
}
