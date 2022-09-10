using System;
using System.Text;

using Perun.FrameFinder;

namespace UnitTests;

public class FinderTests
{
    [Fact]
    public void FrameFinder_Find_FrameInText_Fixed()
    {       

        Random rng= new Random();

        byte[] preamble = new byte[rng.NextInt64(0, 10)] ;

        rng.NextBytes(preamble);

        byte[] data = new byte[rng.NextInt64(0, 30)];

        rng.NextBytes(preamble);

        List<byte> message = new();

        message.AddRange(preamble);
        message.AddRange(data);


        var howMmay=rng.Next(0,byte.MaxValue);

        List<byte> wholeMessage= new();

        for (int i = 0; i < howMmay; i++)
        {
            wholeMessage.AddRange( 
                Encoding.UTF8.GetBytes(
                    RandomString(rng.Next(0, 30))));

            wholeMessage.AddRange(message);
        }

        var finder = new FinderBuilder().Build();

        finder.FeedMe(wholeMessage);

        var foundItems=finder.Find();
        if (foundItems != howMmay)
            throw new Exception($"found:{foundItems}, expected:{howMmay}. ");

        Assert.Equal(foundItems, howMmay);
    }

    public static string RandomString(int length)
    {
        Random r = new();
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[r.Next(s.Length)]).ToArray());
    }

}