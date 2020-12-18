namespace FlowTester.Core
{
    public record Person(
        string FirstName,
        string LastName,
        int Age,
        Sex Sex,
        int Score);

    public enum Sex
    {
        Female,
        Male
    }
}