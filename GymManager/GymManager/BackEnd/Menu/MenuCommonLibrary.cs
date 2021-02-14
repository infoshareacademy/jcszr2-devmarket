using System;
using System.Collections.Generic;

namespace GymManager
{
    public abstract class MenuCommonLibrary
    {
        protected Dictionary<string, int> _positions = new Dictionary<string, int>();
        public Dictionary<string, int> Positions { get { return _positions; } }

        public void Print()
        {
            foreach (KeyValuePair<string, int> position in _positions)
            {
                Console.WriteLine($"{position.Value}. {position.Key}");
            }
        }
    }

}