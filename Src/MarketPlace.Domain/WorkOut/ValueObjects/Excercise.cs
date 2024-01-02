namespace MarketPlace.Domain.WorkOut.ValueObjects
{
    public record Excercise
    {
        private Excercise()
        {
        }

        private Excercise(Name name, Set set, Repetition repetition)
        {
            Name = name;
            Set = set;
            Repetition = repetition;
        }

        public Name Name { get; private set; }
        public Set Set { get; private set; }
        public Repetition Repetition { get; private set; }

        public static Excercise Create(Name name, Set set, Repetition repetition)
        {
            var excercise = new Excercise(name, set, repetition);

            return excercise;
        }

    }
}
