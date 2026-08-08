namespace CancellableDownloadsAsync;

class Program
{
    static async Task Main(string[] args)
    {
        CancellationTokenSource source = new CancellationTokenSource();

        try
        {
            Task fileA = DownloadAsync("FileA", 2000, source.Token);
            Task fileB = DownloadAsync("FileB", 4000, source.Token);
            Task fileC = DownloadAsync("FileC", 6000, source.Token);

            await Task.Delay(3000);
            source.Cancel();

            await Task.WhenAll(fileA, fileB, fileC);
        }
        catch (OperationCanceledException ex)
        {
            Console.WriteLine($"\nOperation was cancelled: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nUnexpected Error: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("Main cleanup done");
        }
    }

    static async Task DownloadAsync(string name, int durationMs, CancellationToken token)
    {
        try
        {   
            int part = 1;
            while (durationMs > 0)
            {
                await Task.Delay(500, token);
                durationMs -= 500;
                Console.WriteLine($"{name}: 500ms part {part++} done");
            }
        }
        finally
        {
            Console.WriteLine($"{name}: cleanup");
        }
    }
}