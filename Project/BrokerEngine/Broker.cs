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
        static List<Record> priceHistory;

        static Broker()
        {
            priceHistory = new List<Record>();
        }

        public static void AddRecord(Currency from, Currency to, long timestamp, double value)
        {
            priceHistory.Add(new Record(from, to, timestamp, value));
        }

        public static double getPrice(Currency from, Currency to, long timestamp)
        {
            foreach (Record record in priceHistory)
            {
                if (record.timestamp == timestamp && record.from == from && record.to == to)
                {
                    return record.value;
                }
            }

            return double.NaN;
        }

        public static bool Buy(Currency from, Currency to, long timestamp, double amount)
        {
            if (Person.Portfolio[from] < amount)
            {
                // no sufficient funds
                Console.WriteLine($"Not enough money of {from} in portfolio");
                return false;
            }

            double price = getPrice(from, to, timestamp);

            if (price == double.NaN)
            {
                // price record not found
                Console.WriteLine($"Broker couldn't find price for {from}, {to}, {timestamp} in price history");
                return false;
            }

            Person.Portfolio[from] -= price * amount;
            Person.Portfolio[to] += amount;
            return true;
        }
    }
}
