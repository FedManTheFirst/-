﻿using System;
using System.Collections;
namespace DictionaryCollection.Pyrshiev
{
    class Program
    {
        static void Main(string[] args)
        {
            Hashtable lookup = new Hashtable();

            lookup["0"] = "Zero";
            lookup["1"] = "One";
            lookup["2"] = "Two";
            lookup["3"] = "Three";
            lookup["4"] = "Four";
            lookup["5"] = "Five";
            lookup["6"] = "Six";
            lookup["7"] = "Seven";
            lookup["8"] = "Eight";
            lookup["9"] = "Nine";

            string ourNumber = "888 - 555 - 1212";
        foreach (char c in ourNumber)
            {
                string digit = c.ToString(); if (lookup.ContainsKey(digit))
                {
                    Console.WriteLine(lookup[digit]);
                }
            }
        }
    }
}
