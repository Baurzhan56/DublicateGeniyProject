using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Data.Common;
using System.Reflection.Metadata;
using System.Collections;
namespace InterfaceLearner
{
    public class Product
    {
        public string Name { get; set; } // Имя 
        public double Price { get; set; } // Цена
        public int Quantity { get; set; } // Количество

        public override string ToString()
        {
            return $"Название: {Name}, Цена: {Price}, Количество: {Quantity}";
        }
    }
    public class Store : IEnumerable<Product>, IEnumerator<Product>
    {
        private List<Product> products { get; set; }
        public void AddProduct(Product product)
        {
            products.Add(product);
        }
        public Store()
        {
            products = new List<Product>();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this;
        }
        IEnumerator<Product> IEnumerable<Product>.GetEnumerator()
        {
            return this;
        }
        public int index = -1;
        object IEnumerator.Current => products[index];
        public Product Current => products[index];
        public bool MoveNext()
        {
            index++;
            if (index >= products.Count)
            {
                return false;
            }
            return true;
        }
        public void Reset()
        {
            index = -1;
        }
        public void Dispose() { }

    }



    class Program
    {
        static void Main(string[] args)
        {
            Store store = new Store();
            store.AddProduct(new Product { Name = "Чайник", Price = 1000, Quantity = 3 });
            store.AddProduct(new Product { Name = "Мультиварка", Price = 3000, Quantity = 7 });
            store.AddProduct(new Product { Name = "Пылесос", Price = 7500, Quantity = 15 });

            foreach (var product in store)
            {
                Console.WriteLine(product);
            }
        }
    }



}