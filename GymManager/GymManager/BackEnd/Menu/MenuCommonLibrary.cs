using System;
using System.Collections.Generic;

namespace GymManager
{
    public abstract class MenuCommonLibrary
    {
        protected List<string> _positions = new List<string>();
        public List<string> Positions { get { return _positions; } }

        public void Print()
        {
            int counter = 0;
            foreach (var element in _positions)
            {
                counter++;
                Console.WriteLine(counter + " " + element);
            }
        }
    }

}