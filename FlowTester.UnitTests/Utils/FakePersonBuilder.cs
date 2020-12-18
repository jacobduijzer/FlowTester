using Bogus;
using FlowTester.Core;
using Person = FlowTester.Core.Person;

namespace FlowTester.UnitTests.Utils
{
    public static class FakePersonBuilder
    {
        public static Person Create(int age, Sex sex, int score = 0) =>
            new Faker<Person>()
                .CustomInstantiator(factory =>
                    new Person(
                        factory.Person.FirstName,
                        factory.Person.LastName,
                        age,
                        sex,
                        score));
    }
}
