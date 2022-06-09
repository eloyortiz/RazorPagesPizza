using RazorPagesPizza.Models;

namespace RazorPagesPizza.Services;
public static class PizzaService
{
  static List<Pizza> Pizzas { get; }
  static int nextId = 3;
  static PizzaService()
  {
    Pizzas = new List<Pizza>
      {
          new Pizza { Id = 1, Name = "Margherita", Price=7.90M, Size=PizzaSize.Medium, IsGlutenFree = true },
          new Pizza { Id = 2, Name = "Quattro formaggi", Price=8.90M, Size=PizzaSize.Medium, IsGlutenFree = false },
          new Pizza { Id = 3, Name = "Prosciutto", Price=13.80M, Size=PizzaSize.Large, IsGlutenFree = false },
          new Pizza { Id = 4, Name = "Pepperoni", Price=12.50M, Size=PizzaSize.Large, IsGlutenFree = false }
      };
  }

  public static List<Pizza> GetAll() => Pizzas;

  public static Pizza? Get(int id) => Pizzas.FirstOrDefault(p => p.Id == id);

  public static void Add(Pizza pizza)
  {
    pizza.Id = nextId++;
    Pizzas.Add(pizza);
  }

  public static void Delete(int id)
  {
    var pizza = Get(id);
    if (pizza is null)
      return;

    Pizzas.Remove(pizza);
  }

  public static void Update(Pizza pizza)
  {
    var index = Pizzas.FindIndex(p => p.Id == pizza.Id);
    if (index == -1)
      return;

    Pizzas[index] = pizza;
  }
}