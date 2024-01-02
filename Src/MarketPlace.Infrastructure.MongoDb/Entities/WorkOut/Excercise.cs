namespace MarketPlace.Infrastructure.MongoDb.Entities.WorkOut
{
    public class Excercise
    {
        public string Name { get; private set; }
        public int Set { get; private set; }
        public int Repetition { get; private set; }
    }
}
