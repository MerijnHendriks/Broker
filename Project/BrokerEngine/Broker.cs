/* Broker.cs
 * License: NCSA
 * Copyright Merijn Hendriks
 * Authors: Merijn Hendriks
 */

using System;
using System.Collections.Generic;

namespace BrokerEngine
{
    public static class Broker
    {
        static List<Price> priceHistory;

        static Broker()
        {
            priceHistory = new List<Price>();
        }

        public static void AddRecord(Currency from, Currency to, long timestamp, double value)
        {
            priceHistory.Add(new Price(from, to, timestamp, value));
        }

        public static double getPrice(Currency from, Currency to, long timestamp)
        {
            foreach (Price price in priceHistory)
            {
                if (price.timestamp == timestamp && price.from == from && price.to == to)
                {
                    return price.value;
                }
            }

            return double.NaN;
        }

        public static bool Buy(Currency from, Currency to, long timestamp, double amount)
        {
            double price = getPrice(from, to, timestamp);

            if (price == double.NaN)
            {
                // price record not found
                Console.WriteLine($"Broker couldn't find price for {from}, {to}, {timestamp} in price history");
                return false;
            }
            
            if (Person.Portfolio[from] < price * amount)
            {
                // no sufficient funds
                Console.WriteLine($"Not enough money of {from} in portfolio");
                return false;
            }

            Person.Portfolio[from] -= price * amount;
            Person.Portfolio[to] += amount;
            return true;
        }
    }
}
