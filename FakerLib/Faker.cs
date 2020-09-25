namespace FakerLib
{
    public class Faker
    {
        private Generator _generator;

        public Faker()
        {
            _generator = new Generator();
        }

        public Faker(FakerConfig config) : this()
        {
            _generator.Config = config;
        }

        public T Create<T>()
        {
            ObjectFiller objectFiller = new ObjectFiller(_generator);
            return (T)objectFiller.FillObject(new FakerType(typeof(T)));
        }
    }
}
