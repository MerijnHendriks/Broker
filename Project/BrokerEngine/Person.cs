/* Person.cs
 * License: NCSA
 * Copyright Merijn Hendriks
 * Authors: Merijn Hendriks
 */

using System;
using System.Collections.Generic;

namespace BrokerEngine
{
    public static class Person
    {
        public static Dictionary<Currency, double> Portfolio;

        static Person()
        {
            Portfolio = new Dictionary<Currency, double>();

            // initialize portfolio
            foreach (Currency currency in Enum.GetValues(typeof(Currency)))
            {
                Portfolio[currency] = 0.0;
            }
        }

        public static void Print()
        {
            foreach (Currency currency in Enum.GetValues(typeof(Currency)))
            {
                Console.WriteLine($"{currency}: {Portfolio[currency]}");
            }
        }
    }
}
