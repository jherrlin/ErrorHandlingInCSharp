namespace ConsoleApp;

class Program
{
    static async Task Main(string[] args)
    {

        IfElseWithNull.Run();

        // Example using try / catch
        await TryCatch.Run();

        // Try catch with exception 
        await TryCatchExceptionHierarchy.Run();

        // In this example we use async operations in the LINQ expression
        await ResultLinqAsync.Run();

        // In this example we combine async and sync operations in the same LINQ expression
        await ResultLinqAsyncAndSync.Run();
    }
}
