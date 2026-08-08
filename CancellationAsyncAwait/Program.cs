namespace CancellationAsyncAwait;

class Program
{
    static async Task Main(string[] args)
    {
        CancellationTokenSource token = new CancellationTokenSource();
        try
        {
            Task printNumTask = CountAsync(token.Token);
            await Task.Delay(3001);
            token.Cancel();
            await printNumTask;
        }
        catch (OperationCanceledException ex)
        {
            Console.WriteLine($"\nOperation was cancelled: {ex.Message}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"\nUnexpected Error: {e.Message}");
        }
        finally
        {
            Console.WriteLine("Main cleanup done");
        }
    
    }

    static async Task CountAsync(CancellationToken token)
    {
        int num = 0;

        try
        {
            while(true)
            {
                token.ThrowIfCancellationRequested();
                Console.Write($"{num++} ");
                await Task.Delay(1000, token);
            }    
        }
        finally
        {
        Console.WriteLine("\nCleaning up CountAsync resources...");
        }
    }
}