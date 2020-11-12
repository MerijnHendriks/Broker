/* Program.cs
 * License: NCSA
 * Copyright Merijn Hendriks
 * Authors: Merijn Hendriks
 */

using System;
using BrokerEngine;

class Program
{
    static void Main(string[] args)
    {
        // add broker price entry
        Broker.AddRecord(Currency.EUR, Currency.BTC, 0, 2.0);

        // add 100 euro to portfolio
        Person.Portfolio[Currency.EUR] = 100.0;

        // print initial values
        Console.WriteLine($">> Initial");
        Person.Print();

        // do a transaction
        Broker.Buy(Currency.EUR, Currency.BTC, 0, 20.3);

        // print the result
        Console.WriteLine($">> Result");
        Person.Print();
    }
}
