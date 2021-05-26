using System;
using System.Collections;

namespace WeekEnum
{
    public class WeekEnumerator : IEnumerator
    {
        private string[] days;
        private int position = -1;

        public WeekEnumerator(string[] days)
        {
            this.days = days;
        }

        public object Current
        {
            get
            {
                return days[position];
            }
        }

        public bool MoveNext()
        {
            position++;

            if (position < days.Length)
            {
                return true;
            }

            return false;
        }

        public void Reset()
        {
            position = 0;
        }
    }
}
