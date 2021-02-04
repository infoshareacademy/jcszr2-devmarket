using System;
using System.Collections.Generic;

namespace GymManager
{
    public abstract class MenuCommonLibrary
    {
        protected Dictionary<int, string> _positions = new Dictionary<int, string>();

        public Dictionary<int, string> Positions { get { return _positions; } }
        public void Print()
        {
            foreach (KeyValuePair<int, string> position in _positions)
            {
                Console.WriteLine($"{position.Key}. {position.Value}");
            }
        }
    }

}