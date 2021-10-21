using System;
using System.Threading;
class Program
{
    static void Main(string[] args)
    {
        WaitCallback callback = new WaitCallback(ShowMyText);
        ThreadPool.QueueUserWorkItem(callback, "Hello");
        ThreadPool.QueueUserWorkItem(callback, "Hi");
        ThreadPool.QueueUserWorkItem(callback, "Heya"); 
        ThreadPool.QueueUserWorkItem(callback, "Goodbye");
        Console.Read();
    }
    static void ShowMyText(object state)
       {
        string myText = (string)state;
        Console.WriteLine(myText);


    }


}

