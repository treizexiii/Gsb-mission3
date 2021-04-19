namespace GsbRapports
{
    class Person
    {
        private readonly string nom;
        private readonly int age;

        public Person(string nom, int age)
        {
            this.nom = nom;
            this.age = age;
        }

        public string GetNom()
        {
            return nom;
        }
    }
}
