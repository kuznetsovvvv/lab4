using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;

namespace CsharpProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Car obj1 = new Car("Toyota Camry", 2002, 198);
            Car obj2 = new Car("Kia Rio", 2000, 202);
            Car obj3 = new Car("Lada Granta", 2010, 156);
            List<Car> list = new List<Car>();
            list.Add(obj1); 
            list.Add(obj2);
            list.Add(obj3);  // создание списка

            CarComparer carComparer1 = new CarComparer(1);
            Console.WriteLine("Cортировка по скорости");// сортировка по скорости
            list.Sort(carComparer1);
            foreach (Car car in list)
            {
                Console.WriteLine(car.Print());
            }

            CarComparer carComparer2 = new CarComparer(2); // сортировка по году производства
            Console.WriteLine("Cортировка по году производства");
            list.Sort(carComparer2);
            foreach (Car car in list)
            {
                Console.WriteLine(car.Print());
            }

            CarComparer carComparer3 = new CarComparer(3); // сортировка по году производства
            Console.WriteLine("Cортировка по названию машины");
            list.Sort(carComparer3);
            foreach (Car car in list)
            {
                Console.WriteLine(car.Print());
            }





            Car[] mass = new Car[2];
            mass[0] = new Car("Toyota Camry", 2002, 198);
            mass[1] = new Car("Kia Rio", 2000, 202);
            CarCatalor catalor = new CarCatalor(mass);

            //Console.WriteLine(catalor.GetEnumeratorProductionYear(2000));
            //catalor.GetEnumeratorreverce();
            //catalor.GetEnumerator();
            //Console.WriteLine(catalor.GetEnumeratorMaxSpeed(202));


        }
    }

    public class Car
    {
        public string Name { get; set; }
        public int ProductionYear { get; set; }
        public int MaxSpeed { get; set; }

        public Car(string Name, int ProductionYear, int MaxSpeed)
        {
            this.Name = Name;
            this.ProductionYear = ProductionYear;
            this.MaxSpeed = MaxSpeed;
        }

        public string Print()
        {
            return ($"{Name}, {ProductionYear}, {MaxSpeed}");
        }
    }

    public class CarComparer : IComparer<Car>
    {
        public int k;

        public CarComparer(int k)
        {
            this.k = k;
        }

        public int Compare(Car x, Car y)
        {
            if (k == 1)
            {
                if (x.MaxSpeed > y.MaxSpeed)
                {
                    return 1; // x больше
                }
                else if (x.MaxSpeed == y.MaxSpeed)
                {
                    return 0; // x равен y
                }
                else
                {
                    return -1; // x меньше
                }
            }
            else if (k == 2)
            {
                return x.ProductionYear.CompareTo(y.ProductionYear); // Используем CompareTo для сравнения годов
            }
            else if (k == 3)
            {
                return string.Compare(x.Name, y.Name, StringComparison.OrdinalIgnoreCase); // Сравниваем имена без учета регистра
            }

            throw new ArgumentException("Неверный критерий сортировки");
        }
    }



    public class CarCatalor
    {
        public Car[] massiv;

        public CarCatalor(Car[] massiv)
        {
            if (massiv == null) { return; }
            this.massiv = massiv;
        }

        public IEnumerator<Car> GetEnumerator() {
            foreach (Car car in massiv) 
            {
                car.Print();
            yield return car;
            }
        
        }

        public IEnumerator<Car> GetEnumeratorreverce()
        {
            for (int i = massiv.Length-1; i >=0; i--)
            {
                massiv[i].Print();
                yield return massiv[i];
            }
        }


        public IEnumerator<Car> GetEnumeratorProductionYear(int k)
        {
            
            foreach (Car car in massiv)
            {
                if (car.ProductionYear==k)
                {
                    car.Print();
                    yield return car;
                }
            }



        }

        public IEnumerator<Car> GetEnumeratorMaxSpeed(int l)
        {
            
            foreach (Car car in massiv)
            {
                if (car.MaxSpeed == l)
                {
                    car.Print();
                    yield return car;
                }
            }



        }



    }




}