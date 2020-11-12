/* Record.cs
 * License: NCSA
 * Copyright Merijn Hendriks
 * Authors: Merijn Hendriks
 */

namespace BrokerEngine
{
    public class Record
    {
        public Currency from;
        public Currency to;
        public long timestamp;
        public double value;

        public Record(Currency from, Currency to, long timestamp, double value)
        {
            this.from = from;
            this.to = to;
            this.timestamp = timestamp;
            this.value = value;
        }
    }
}
