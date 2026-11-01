using System.Collections.Concurrent;
using blackboard;

namespace Blackboard_Server;

public class Handler : BlackboardService.IAsync
{
    private readonly ConcurrentDictionary<string, string> board = [];

    public Task<string> Put(string? key, string? value, CancellationToken c = new())
    {
        try {
            if(key == null) throw new ArgumentException("Key cannot be null!");
            if(value == null) throw new ArgumentException("Value cannot be null!");

            board[key] = value;

            return Task.FromResult("Entry added to board successfully.");
        }
        catch(ArgumentException e)
        {
            return Task.FromResult(e.Message);
        }
    }

    public Task<string> Get(string? key, CancellationToken c = new())
    {
        try {
            if(key == null) throw new ArgumentException("Key cannot be null!");
            board.TryGetValue(key, out string? value);

            return Task.FromResult(value ?? "Entry could not be found!");
        }
        catch(ArgumentException e)
        {
            return Task.FromResult(e.Message);
        }
    }

    public Task<string> Del(string? key, CancellationToken c = new())
    {
        try {
            if(key == null) throw new ArgumentException("Key cannot be null!");
            bool success = board.TryRemove(key, out _);
            return Task.FromResult(success ? "Entry successfully removed" : "Entry was not found!");
        }
        catch(ArgumentException e)
        {
            return Task.FromResult(e.Message);
        }
    }
}