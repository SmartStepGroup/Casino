namespace Domain
{
   public class Chip
   {
      static Chip()
      {
         Zero = new Chip(0);
      }

      public static Chip Zero { get; private set; }

      private int _value;

      public Chip(int value)
      {
         _value = value;
      }

      public override bool Equals(object obj)
      {
         var other = obj as Chip;
         if (other == null)
         {
            return false;
         }

         return _value == other._value;
      }

      public static Chip operator +(Chip v1, Chip v2)
      {
         return new Chip(v1._value + v2._value);
      }

      public static Chip operator -(Chip v1, Chip v2)
      {
         return new Chip(v1._value - v2._value);
      }

      public static bool operator >(Chip v1, Chip v2)
      {
         return v1._value > v2._value;
      }

      public static bool operator <(Chip v1, Chip v2)
      {
         return v1._value < v2._value;
      }

      public static bool operator >=(Chip v1, Chip v2)
      {
         return v1._value >= v2._value;
      }

      public static bool operator <=(Chip v1, Chip v2)
      {
         return v1._value <= v2._value;
      }
   }
}