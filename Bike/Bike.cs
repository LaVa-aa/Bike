using System;

namespace Bike
{
    public class Bike
    {

        // instansier
        private int id;
        private string name;
        private string brand;
        private int price;

            public int Id { get; set; }

            public string Name
            {
                get => name;
                set
                {
                    //null er tom der er ikke nogle
                    if (value == null) throw new ArgumentNullException("Name", "Null");
                    if (value.Length < 4)
                        throw new ArgumentOutOfRangeException("Name length must be at least have 4 charaters");
                    // value bliver set til name
                    name= value;
                }
            }

            public int Price
            {
                get => price;
                set
                {
                    if (value <= 0) throw new ArgumentOutOfRangeException("Price","Price must be heiger than 0");
                    price= value;
                }
            }

            public string Brand { get; set; }

        // Needs to have a no-argument constructor for serialization/deserialization
       // It is most important that the model class has a no-arguments constructor.
       // The REST controller needs the model to have a no-arguments constructor, to be able to serialize/deserialize the model.
        public Bike()
            {
               //default constructor
            }

        //A constructor taking all the properties as parameters
        public Bike(int id, string name, string brand, int price)
            {
                Id = id;
                Name = name;
                Brand = brand;
                Price = price;

            }

        //Overrides the default ToString method
        public override string ToString()
            {
             //Simple string containing the property names and thier respective values
             return " ID " + Id + " \nName " + Name + " \nBrand " + Brand + " \nPrice " + Price;
            }
        }
    }

