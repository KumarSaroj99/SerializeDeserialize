using System.Configuration;
using System.Text.Json;
using SerializationPerson.Models;

namespace SerializationPerson
{
    internal class Program
    {
        static string path=ConfigurationManager.AppSettings["filePath"].ToString();
        static void Main(string[] args)
        {
            Person persons = new Person();
            Person[] personsArr = { new Person{Id=100,Name="Raj",Email="raj123@gmail.com" },
                new Person{Id=101,Name="Raju",Email="raju123@gmail.com" },
                new Person{Id=102,Name="Rajesh",Email="rajesh123@gmail.com" },
                new Person{Id=103,Name="Rajendra",Email="rajendra123@gmail.com" },
                new Person{Id=104,Name="Rajpal",Email="rajpal123@gmail.com" }
            };
            if (File.Exists(path))
            {
                Deserialize();
                return;
            }
            else
            {
                Serialize(personsArr);
                Deserialize();
            }


        }
        static void Serialize(Person[] persons)
        {
            foreach (Person person in persons)
            {
                using (StreamWriter sw = new StreamWriter(path,true))
                {
                    sw.WriteLine(JsonSerializer.Serialize(person));
                }
            }
            Console.WriteLine("Objects are serialized successfully !");
        }
        static void Deserialize()
        {
            using (StreamReader reader = new StreamReader(path))
            {
                while(!reader.EndOfStream)
                {
                    Person person1 = JsonSerializer.Deserialize<Person>(reader.ReadLine());
                    Console.WriteLine(person1);
                }


               

            }
        }
    }
}
