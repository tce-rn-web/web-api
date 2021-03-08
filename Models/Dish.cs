using System.ComponentModel.DataAnnotations;

namespace api.Models {
    public class Dish {
        [Key]
        public int Id { get; set; }
        public float Price { get; set; }
        public string Name { get; set; }
        public bool InStock { get; set; }

        public Dish() {
            this.Id = 0;
            this.Price = 0.0f;
            this.Name = "";
            this.InStock = true;
        }
        public Dish(int id, float price, string name, bool inStock) {
            this.Id = id;
            this.Price = price;
            this.Name = name;
            this.InStock = inStock;
        }

        public override string ToString() {
            return "{ " + $"\"id\": {this.Id}, \"price\": {this.Price}, \"name\": \"{this.Name}\", \"inStock\": {this.InStock}" + " }";
        }
    }
}