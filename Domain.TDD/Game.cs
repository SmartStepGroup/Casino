using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.TDD
{
    public class Game
    {
        private int _count;
        public void NotifyNewPLayer(Player player)
        {
            if (_count == 6)
            {
                throw new InvalidOperationException();
            }

            _count++;
        }
    }
}
