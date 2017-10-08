namespace To1337.Translationz
{
    public class Translation
    {
        public Translation(string value = null, L337ness l337ness = L337ness.N00b, int weight = 0)
        {
            Value = value;
            IsEmpty = string.IsNullOrEmpty(Value);
            L337ness = l337ness;
            Weight = weight;
        }

        public string Translate(string input, string trigger)
        {
            return IsEmpty ? input : input.Replace(trigger, Value);
        }

        public string Value { get; }

        public L337ness L337ness { get; }

        public int Weight { get; }

        public bool IsEmpty { get; }


        public bool Equals(Translation other)
        {
            return Equals(other.Value, Value) && Equals(other.L337ness, L337ness) && other.Weight == Weight;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (obj.GetType() != typeof(Translation)) return false;
            return Equals((Translation)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = (Value != null ? Value.GetHashCode() : 0);
                result = (result * 397) ^ L337ness.GetHashCode();
                result = (result * 397) ^ Weight;
                return result;
            }
        }
    }
}