/* Record.cs
 * License: NCSA
 * Copyright Merijn Hendriks
 * Authors: Merijn Hendriks
 */

namespace BrokerEngine
{
    public class Price
    {
        public Currency from;
        public Currency to;
        public long timestamp;
        public double value;

        public Price(Currency from, Currency to, long timestamp, double value)
        {
            this.from = from;
            this.to = to;
            this.timestamp = timestamp;
            this.value = value;
        }
    }
}
