namespace Domain
{
    public class Chips
    {
        private uint _count;

        public Chips(uint count)
        {
            _count = count;
        }

        public void Add(Chips chips)
        {
            _count += chips._count;
        }

        public uint GetCount()
        {
            return _count;
        }

        public static bool operator ==(Chips chips1, Chips chips2)
        {
            return chips1.Equals(chips2);
        }

        public static bool operator !=(Chips chips1, Chips chips2)
        {
            return !(chips1 == chips2);
        }

        protected bool Equals(Chips other)
        {
            return _count == other._count;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Chips) obj);
        }

        public override int GetHashCode()
        {
            return (int) _count;
        }
    }
}
