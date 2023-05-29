using FluentAssertions;
using OOPsReview;

namespace TDDUnitTestDemo
{
    public class Person_Should
    {
        #region Valid Data
        //Attribute title
        //  Fact which does one test and is usually setup and coded within the test
        //  Theory which allow for multiple test data stream applied to the same test
        [Fact]
        public void Create_an_Instance_Using_Default_Constructor()
        {
            //Arrange (setup)
            string expectedfirstname = "unknown";
            string expectedlastname = "unknown";

            //Act (execution) (sut subject under test)
            Person sut = new Person();

            //Assert (testing of the action)
            sut.FirstName.Should().Be(expectedfirstname);
            sut.LastName.Should().Be(expectedlastname);
            sut.Address.Should().BeNull();
            sut.EmploymentPositions.Count().Should().Be(0);
        }

        [Fact]
        public void Create_an_Instance_With_First_And_Last_Name_Residence_With_NO__List_Of_Employment()
        {
            //Arrange (setup)
            string firstname = "Don";
            string lastname = "Welch";
            Residence address = new Residence(123, "Maple St.", "Edmonton", "AB", "T6Y7U8");
            string expectedaddress = "123,Maple St.,Edmonton,AB,T6Y7U8";


            //Act (execution) (sut subject under test)
            Person sut = new Person(firstname, lastname, address, null);

            //Assert (testing of the action)
            sut.FirstName.Should().Be(firstname);
            sut.LastName.Should().Be(lastname);
            sut.Address.ToString().Should().Be(expectedaddress);
            sut.EmploymentPositions.Count().Should().Be(0);
        }
        #endregion

        [Fact]
        public void Change_FirstName_To_New_Name()
        {
            //Arrange (setup)
            string firstname = "don";
            string lastname = "welch";
            Residence address = new Residence(123, "Maple St.", "Edmonton", "AB", "T6Y7U8");
            string expectedaddress = "123,Maple St.,Edmonton,AB,T6Y7U8";
            Person me = new Person(firstname, lastname, address, null);

            string expectedfirstname = "bob";

            // Act
            me.FirstName = expectedfirstname;

            // Assert
            me.FirstName.Should().Be(expectedfirstname);
            
        }

        [Fact]
        public void Change_LastName_To_New_Name()
        {
            //Arrange (setup)
            string firstname = "don";
            string lastname = "welch";
            Residence address = new Residence(123, "Maple St.", "Edmonton", "AB", "T6Y7U8");
            string expectedaddress = "123,Maple St.,Edmonton,AB,T6Y7U8";
            Person me = new Person(firstname, lastname, address, null);

            string expectedlastname = "smith";

            // Act
            me.LastName = expectedlastname;

            // Assert
            me.LastName.Should().Be(expectedlastname);

        }

        #region Invalid Data
        [Theory]
        [InlineData(null, "welch")]
        [InlineData("don", null)]
        [InlineData("", "welch")]
        [InlineData("don","")]
        [InlineData("    ", "welch")]
        [InlineData("don", "     ")]
        public void Creating_an_Greedy_Instance_With_No_Names_Throws_Expection(string firstname, string lastname)
        {
            //Arrange (setup)
            Residence address = new Residence(123, "Maple St.", "Edmonton", "AB", "T6Y7U8");
            string expectedaddress = "123,Maple St.,Edmonton,AB,T6Y7U8";


            //Act (execution) (sut subject under test)
            Action action = () => new Person(firstname, lastname, address, null);

            //Assert (testing of the action)
            action.Should().Throw<ArgumentNullException>();
        }


        //changing the firstname via the FirstName property
        //validation firstname is required.
        [Theory]
        [InlineData(null)]

        [InlineData("")]

        [InlineData("    ")]

        public void Throw_Expection_When_Setting_FirstName_To_Missing_Data(string changename)
        {
            //Arrange (setup)
            string firstname = "don";
            string lastname = "welch";
            Residence address = new Residence(123, "Maple St.", "Edmonton", "AB", "T6Y7U8");
            Person me = new Person(firstname, lastname, address, null);
            

            //Act (execution) (testing will the property capture an invalid name change)
            Action action = () => me.FirstName = changename;

            //Assert (testing of the action)
            action.Should().Throw<ArgumentNullException>();
        }
        #endregion
    }
}