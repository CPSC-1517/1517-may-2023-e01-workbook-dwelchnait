using FluentAssertions;
using OOPsReview;

namespace TDDUnitTestDemo
{
    public class Person_Should
    {
        //Attribute title
        //  Fact which does one test and is usually setup and coded within the test
        //  Theory which allow for multiple test data stream applied to the same test

        [Fact]
        public void Create_an_Instance_With_First_And_Last_Name()
        {
            //Arrange (setup)
            string firstname = "Don";
            string lastname = "Welch";

            //Act (execution) (sut subject under test)
            Person sut = new Person(firstname, lastname);

            //Assert (testing of the action)
            sut.FirstName.Should().Be(firstname);
            sut.LastName.Should().Be(lastname);
        }
    }
}