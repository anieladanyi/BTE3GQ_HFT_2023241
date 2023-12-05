using Feleves;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTE3GQ_HFT_2023241.Client
{
    public class CrudMethodService
    {
        private RestService rest;

        public CrudMethodService(RestService rest)
        {
            this.rest = rest;
        }

        public void Create<T>()
        {
            var properties = typeof(T).GetProperties().Where(p => p.GetAccessors().All(a => !a.IsVirtual) && p.Name != "Id");
            T instance = (T)Activator.CreateInstance(typeof(T));
            foreach (var property in properties)
            {
                Console.Write($"{property.Name} = ");
                string input = Console.ReadLine();
                if (property.PropertyType == typeof(int))
                {
                    property.SetValue(instance, int.Parse(input));
                }
                else if (property.PropertyType == typeof(double))
                {
                    property.SetValue(instance, double.Parse(input));
                }
                else if (property.PropertyType == typeof(Color))
                {
                    if (Enum.TryParse<Color>(input, out Color result))
                    {
                        property.SetValue(instance, result);
                    }
                }
                else
                {
                    property.SetValue(instance, input);
                }
            }
            rest.Post(instance, typeof(T).Name);
        }
        public void List<T>()
        {
            var properties = typeof(T).GetProperties().Where(p => p.GetAccessors().All(a => !a.IsVirtual));
            var items = rest.Get<T>(typeof(T).Name);

            foreach (var property in properties)
            {
                Console.Write($"{property.Name}\t\t");
            }
            Console.Write("\n");

            foreach (var item in items)
            {
                foreach (var property in properties)
                {
                    Console.Write($"{property.GetValue(item)}\t\t");
                }
                Console.Write("\n");
            }

            Console.ReadLine();
        }
        public void Update<T>()
        {
            Console.WriteLine("Enter Entity's Id to update:");
            int id = int.Parse(Console.ReadLine());
            var instance = rest.Get<T>(id, typeof(T).Name);
            var properties = typeof(T).GetProperties().Where(p => p.GetAccessors().All(a => !a.IsVirtual) && p.Name != "Id");
            foreach (var property in properties)
            {
                Console.Write($"New {property.Name} [Old: {property.GetValue(instance)}]= ");
                string input = Console.ReadLine();
                if (property.PropertyType == typeof(int))
                {
                    property.SetValue(instance, int.Parse(input));
                }
                else if (property.PropertyType == typeof(double))
                {
                    property.SetValue(instance, double.Parse(input));
                }
                else if (property.PropertyType == typeof(Color))
                {
                    if (Enum.TryParse<Color>(input, out Color result))
                    {
                        property.SetValue(instance, result);
                    }
                }
                else
                {
                    property.SetValue(instance, input);
                }
            }
            rest.Put(instance, typeof(T).Name);
        }
        public void Delete<T>()
        {
            Console.WriteLine("Enter Entity's id to delete:");
            int id = int.Parse(Console.ReadLine());
            rest.Delete(id, typeof(T).Name);
        }
    }
}
