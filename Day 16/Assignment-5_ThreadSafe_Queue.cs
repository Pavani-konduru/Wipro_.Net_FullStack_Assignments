using System;
using System.Collections.Generic;

public class ThreadSafeQueue<T>
{
    private readonly Queue<T> _queue = new Queue<T>();
    private readonly object _lockObject = new object();

    // Enqueue operation
    public void Enqueue(T item)
    {
        lock (_lockObject)
        {
            _queue.Enqueue(item);
        }
    }

    // Dequeue operation
    public bool TryDequeue(out T result)
    {
        lock (_lockObject)
        {
            if (_queue.Count > 0)
            {
                result = _queue.Dequeue();
                return true;
            }
            else
            {
                result = default(T);
                return false;
            }
        }
    }

    // Peek operation (optional)
    public bool TryPeek(out T result)
    {
        lock (_lockObject)
        {
            if (_queue.Count > 0)
            {
                result = _queue.Peek();
                return true;
            }
            else
            {
                result = default(T);
                return false;
            }
        }
    }

    // Get the count of items in the queue
    public int Count
    {
        get
        {
            lock (_lockObject)
            {
                return _queue.Count;
            }
        }
    }
}

class Program
{
    static void Main()
    {
        // Create an instance of the thread-safe queue
        var queue = new ThreadSafeQueue<int>();

        // Example usage
        var enqueueThread = new System.Threading.Thread(() =>
        {
            for (int i = 0; i < 10; i++)
            {
                queue.Enqueue(i);
                Console.WriteLine($"Enqueued: {i}");
                System.Threading.Thread.Sleep(50); // Simulate work
            }
        });

        var dequeueThread = new System.Threading.Thread(() =>
        {
            for (int i = 0; i < 10; i++)
            {
                if (queue.TryDequeue(out int item))
                {
                    Console.WriteLine($"Dequeued: {item}");
                }
                else
                {
                    Console.WriteLine("Queue is empty.");
                }
                System.Threading.Thread.Sleep(100); // Simulate work
            }
        });

        enqueueThread.Start();
        dequeueThread.Start();

        enqueueThread.Join();
        dequeueThread.Join();
    }
}
