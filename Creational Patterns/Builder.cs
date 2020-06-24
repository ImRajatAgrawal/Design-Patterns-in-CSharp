//Builder Pattern - Create a complex Object from a group of objects /
// Encapsulate the complete Object creation Logic
namespace DesignPatterns
{
    public class House
    {
        public string floorType { get; set; }
        public string wallType { get; set; }
        public string roofType { get; set; }
       
        
        public override string ToString()
        {
            return floorType + " " + wallType + " " + roofType;
        }
    }
    public interface HouseBuilder {
        HouseBuilder buildFloor();
        HouseBuilder buildWall();
        HouseBuilder buildRoof();
        House build();
    }
    public class ConcreteHouseBuilder : HouseBuilder
    {
        private House house;
        public ConcreteHouseBuilder() {
            house = new House();
        }
        public House build()
        {
            return house;
        }

        public HouseBuilder buildFloor()
        {
            house.floorType = "Concrete";
            return this;
        }

        public HouseBuilder buildRoof()
        {

            house.wallType = "Concrete";
            return this;
        }

        public HouseBuilder buildWall()
        {

            house.roofType = "Concrete";
            return this;
        }
    }
    public class WoodenHouseBuilder : HouseBuilder
    {
        private House house;
        public WoodenHouseBuilder()
        {
            house = new House();
        }
        public House build()
        {
            return house;
        }

        public HouseBuilder buildFloor()
        {
            house.floorType = "Wooden";
            return this;
        }

        public HouseBuilder buildRoof()
        {

            house.wallType = "Wooden";
            return this;
        }

        public HouseBuilder buildWall()
        {

            house.roofType = "Wooden";
            return this;
        }
    }
    public class HouseBuildDirector
    {
        private HouseBuilder houseBuilder;
        public HouseBuildDirector(HouseBuilder builder)
        {
            houseBuilder = builder;
        }
        public House Construct()
        {
            return houseBuilder.buildFloor().buildWall().buildRoof().build();
        }

    }
}
