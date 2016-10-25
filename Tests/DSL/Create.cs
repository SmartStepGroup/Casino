using System;
using Domain;

namespace Tests.DSL
{
    public static class Create
    {
        public static PlayerBuilder Player()
        {
            return new PlayerBuilder();
        }

        internal static RollDiceGameBuilder Game()
        {
            return new RollDiceGameBuilder();
        }
    }
}