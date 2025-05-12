namespace DDD.Domain.ValueObjects
{
    public record PersonName
    {
        public string Value { get; init; }

        internal PersonName(string value)
        {
            this.Value = value;
        }

        public static PersonName Create(string value)
        {
            Validate(value);
            return new PersonName(value);
        }

        private static void Validate(string value)
        {
            if (value == null)
                throw new ArgumentNullException("El valor no puede ser nulo");
        }
    }
}
