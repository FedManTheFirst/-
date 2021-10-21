using System;
using System.Threading;
class Program
{
    static void Main(string[] args)
    {
        Mutex oneMutex = null;
        const String MutexName = "RUNMEONLYONCE";
        try // Пытаемся открыть Mutex
        {
            oneMutex = Mutex.OpenExisting(MutexName);
        }
        catch (WaitHandleCannotBeOpenedException)
        {
            // He можемоткрыть Mutex, потому что он не существует
        }
        if (oneMutex== null)
        {
            oneMutex = new Mutex(true, MutexName);
        }
        else
        {
            // Закрываем Mutexи выходим из приложения,
            // так как разрешается запуск только одного его экземпляра
            oneMutex.Close();
            return;
        }
        Console.WriteLine("Our Application");
        Console.Read();
}
}

