namespace ConsoleApp;

class Program
{
    static async Task Main(string[] args)
    {

        // If else with methods returning null
        IfElseWithNull.Run();

        // Try / catch
        TryCatch.Run();

        // Try catch with custom exception hierarchy  
        TryCatchExceptionHierarchy.Run();

        // Result<TSucess, string> with Bind
        ResultString.Run();

        // Result<TSucess, string> with LINQ
        ResultStringLinq.Run();

        // Async Result<TSucess, Error> with LINQ
        await ResultLinqAsync.Run();

        // Async and sync Result<TSucess, Error> with LINQ
        await ResultLinqAsyncAndSync.Run();
    }
}
