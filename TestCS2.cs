using System;
using System.Threading.Tasks;

public static class ServerCS 
{
    int count;

	public ServerCS()
	{
        count = 0;
	}

    public static async Task GetCount()
    {
        await Task.Delay(100);
        return count;
    }

    public static void AddToCount(int value)
    {
        count += value;
    }

}
