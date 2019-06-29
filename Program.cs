using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace ConsoleApp1
{
    class Program
    {
        static public int DisplayMenu() {
            Console.WriteLine("basic Customer Relationship Manager (CRM) application");
            Console.WriteLine("Please choose the report you would like to generate");
            Console.WriteLine("1. All known customers and any vehicles they own.");
            Console.WriteLine("2. All customers between the age of 20 and 30");
            Console.WriteLine("3. All Vehicles registered before 1st January 2010.");
            Console.WriteLine("4. All Vehicles with an engine size over 1100.");
            Console.WriteLine("5. Exit");
            String result = Console.ReadLine();
            return Convert.ToInt32(result);
        }
        static void Main(string[] args)
        {
            int userInput = 0;
            try
            {
                String[] allLines = File.ReadAllLines(".//..//..//CustomerInformation.csv");
                var customers = new List<Customer>();
                var cars = new List<Car>();
                var motorcycles = new List<Motorcycle>();
                for (int i = 0; i < allLines.Length; i++)
                {
                    if (i != 0)
                    {
                        String[] elements = allLines[i].Split(',');
                        Customer customer = new Customer(Int32.Parse(elements[0]), elements[1], elements[2], elements[3]);
                        customers.Add(customer);
                        if (elements[12] == "Car")
                        {
                            Car car = new Car(Int32.Parse(elements[4]), elements[5], elements[6], elements[7], elements[8], elements[9], elements[10]);
                            cars.Add(car);
                            customer.SetCar(car);

                        }
                        else if (elements[12] == "Motorcycle")
                        {
                            Motorcycle motorcycle = new Motorcycle(Int32.Parse(elements[4]), elements[5], elements[6], elements[7], elements[8], elements[9], elements[11]);
                            motorcycles.Add(motorcycle);
                            customer.SetMotorcycles(motorcycle);
                        }
                        else if (elements[12] == "")
                        {

                        }
                        else
                        {

                        }
                    }
                }



                do
                {

                    userInput = DisplayMenu();
                    switch (userInput)
                    {
                        case 1:
                            Console.WriteLine("1");
                            foreach (Customer customer in customers)
                            {
                                Console.WriteLine(customer.getOwnVehicle());
                            }

                            break;
                        case 2:
                            Console.WriteLine("2");
                            break;
                        case 3:
                            Console.WriteLine("3");
                            break;
                        case 4:
                            Console.WriteLine("4");
                            break;
                        default:
                            break;
                    }
                } while (userInput != 5);


            }

            catch (Exception e)
            {
                Console.WriteLine("The file could not be read");
                Console.WriteLine(e.Message);
            }

            Console.Read();
        }
    }

    class Customer
    {
        private int cusomerId { get; set; }
        private String foreName { get; set; }
        private String surName { get; set; }
        private String dayOfBirth { get; set; }
        List<Motorcycle> motorcycles = new List<Motorcycle>();
        List<Car> vehicles = new List<Car>();
        public List<Motorcycle> getsetMotorcycle
        {
            set { motorcycles = value; }
            get { return motorcycles; }
        }
        public String getOwnVehicle() {
            String result = cusomerId+" , "+foreName+" , "+surName+" , "+dayOfBirth + "	Owner  ";
            return result;
        }
        public void SetCar(Car car)
        {
            vehicles.Add(car);

        }
        public List<Car> getCar() {
            return vehicles;
        }
        public void SetMotorcycles(Motorcycle motorcycle)
        {
            motorcycles.Add(motorcycle);

        }
        public List<Motorcycle> GetMotorcycles()
        {
            return motorcycles;
        }
        public Customer(int cusomerId, String foreName, String surName, String dayOfBirth) {
            this.cusomerId = cusomerId;
            this.foreName = foreName;
            this.surName = surName;
            this.dayOfBirth = dayOfBirth;
        }
        public Customer() { }
    }

    class Vehicle
    {
        private int vehicleId;
        private String manufacturer;
        private String model;
        private String resgistrateNum;
        private String registrateDate;
        private String engineSize;
        public Vehicle(int vehicleId, String manufacturer, String model, String resgistrateNum,String registrateDate, String engineSize) {
            this.vehicleId = vehicleId;
            this.manufacturer = manufacturer;
            this.model = model;
            this.resgistrateNum = resgistrateNum;
            this.registrateDate = registrateDate;
            this.engineSize = engineSize;
        }
    }

    class Car : Vehicle
    {
        protected String interiorCol;
        public Car(int vehicleId,String manufacturer, String model, String resgistrateNum, String registrateDate, String engineSize, String interiorCol) : base(vehicleId, manufacturer, model, resgistrateNum, registrateDate, engineSize)
        {
            this.interiorCol = interiorCol;

        }

    }

    class Motorcycle : Vehicle
    {
        protected String hasHelmetStorage;
        public Motorcycle(int vehicleId,String manufacturer, String model, String resgistrateNum, String registrateDate, String engineSize, String hasHelmetStorage) : base(vehicleId,manufacturer, model, resgistrateNum, registrateDate, engineSize)
        {
            this.hasHelmetStorage = hasHelmetStorage;

        }
    }
}
