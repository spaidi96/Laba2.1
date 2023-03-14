using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Linq;
namespace Laba2_1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            do
            {
                Console.Write("Введiть число, яке завдання хочете обрати: ");
                switch (int.Parse(Console.ReadLine()))
                {
                    case 1:
                        Console.WriteLine("Завдання 1:" + '\n' +
                        "Дано текстовий файл. Створіть список, кожен елемент якого містить кількість символів у відповідному рядку тексту.");
                        Console.WriteLine("---------------------------------------");
                        string filepath = "D:\\Laba\\Text.txt";
                        if (File.Exists(filepath))
                        {
                            string[] lines = File.ReadAllLines(filepath);
                            Console.WriteLine("Текст:");
                            foreach (string line in lines)
                            {
                                Console.WriteLine(line);
                            }

                            Console.WriteLine("---------------------------------------");
                        }
                        List<int> lengths = new List<int>();
                        using (StreamReader reader = new StreamReader(filepath))
                        {
                            string line;
                            while ((line = reader.ReadLine()) != null)
                            {
                                lengths.Add(line.Length);
                            }
                        }
                        Console.WriteLine("Кількість символів у кожному рядку:");
                        foreach (int length in lengths)
                        {
                            Console.WriteLine(length);
                        }
                        break;
                    case 2:
                        Console.WriteLine("Завдання 2" + '\n' +
                        "Порахувати кількість записів у словнику, значення яких є списком. Записати словник у JSON");
                        Console.WriteLine("---------------------------------------");
                        int count = 0;
                        var dict = new Dictionary<string, object>();
                        dict.Add("key1", new List<int> { 1, 2, 3 });
                        dict.Add("key2", "value");
                        dict.Add("key3", new List<string> { "Mama", "Papa" });
                        dict.Add("key4", 4);
                        dict.Add("key5", new List<double> {123f});
                        foreach (var value in dict.Values)
                        {
                            if (value is IList)
                            {
                                count++;
                            }
                        }
                        Console.WriteLine("Кількість записів у словнику, значення яких є списком: " + count);
                        Console.WriteLine("---------------------------------------");
                        string json = JsonConvert.SerializeObject(dict);
                        Console.WriteLine(json);
                        break;
                    case 3:
                        Console.WriteLine("Завдання 3:" + '\n' +
                        "Дана послідовність непустих рядків. Використовуючи метод Aggregate, отримати рядок, що" + '\n' +
                        "складається з початкових символів всіх рядків вихідної послідовності.");
                        Console.WriteLine("---------------------------------------");
                        List<string> list = new List<string> { "i", "linq", "orange", "value", "earth", "cat", "#" };
                        foreach (var i in list)
                        {
                            Console.WriteLine(i);
                        }
                        Console.WriteLine("---------------------------------------");
                        string newlist = list.Aggregate("", (a, b) => a + b[0]);
                        Console.WriteLine(newlist);
                        break;
                }
                Console.WriteLine();
            Console.WriteLine("Для закінчення програми напишіть \"вийти\", щоб продовжити, натисніть будь-яку кнопку");
        } while (Console.ReadLine().ToLower() != "вийти");
        }
    }
}