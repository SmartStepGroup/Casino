using System;
using Domain;
using Domain.Fakes;

namespace Tests.DSL
{
    internal class RollDiceGameBuilder
    {
        private IDice _dice;

        //public IRollDiceGame WithSixSideRandomDice()
        //{
            
        //}

        public RollDiceGameBuilder WithDiceThatAlwaysRolls(int value)
        {
            if (_dice != null)
            {
                throw new InvalidOperationException("Cannot call twice.");
            }

            _dice = new StubIDice { Roll = () => value }; ;

            return this;
        }

        public static implicit operator RollDiceGame(RollDiceGameBuilder rollDiceGameBuilder)
        {
            return new RollDiceGame(rollDiceGameBuilder._dice);
        }
    }
}