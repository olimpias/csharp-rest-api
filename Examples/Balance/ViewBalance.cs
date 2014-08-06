﻿using System;
using System.Net;
using MessageBird;
using MessageBird.Exceptions;
using MessageBird.Objects;

namespace Examples.Balance
{
    class ViewBalance
    {
        const string YourAccessKey = "YOUR_ACCESS_KEY"; // your access key here.

        static void Main(string[] args)
        {
            Client client = Client.CreateDefault(YourAccessKey);

            try
            {
                MessageBird.Objects.Balance balance = client.Balance();
                Console.WriteLine("{0}", balance);
            }
            catch (ErrorException e)
            {
                // Either the request fails with error descriptions from the endpoint.
                if (e.HasErrors)
                {
                    foreach (Error error in e.Errors)
                    {
                        Console.WriteLine("code: {0} description: '{1}' parameter: '{2}'", error.Code, error.Description, error.Parameter);
                    }
                }
                // or fails without error information from the endpoint, in which case the reason contains a 'best effort' description.
                if (e.HasReason)
                {
                    Console.WriteLine(e.Reason);
                }
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
