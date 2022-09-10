using System;
using System.Text;

using Perun.FrameFinder;
using Perun.FrameFinder.Factory;

namespace UnitTests;

public class FinderTests
{
    [Fact]
    public void FrameFinder_Find_FrameInText_Fixed()
    {       

        Random rng= new Random();

        byte[] prefix = new byte[rng.NextInt64(0, 10)] ;

        rng.NextBytes(prefix);

        byte[] data = new byte[rng.NextInt64(0, 30)];

        rng.NextBytes(prefix);

        List<byte> message = new();

        message.AddRange(prefix);
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

        var finder = new FinderFactory_Prefix_FixedLenght(new ())
            .AddPrefix(prefix);

        finder.FeedMe(wholeMessage);

        var foundItems =finder.Find();

        if (foundItems.Length != howMmay)
            throw new Exception($"found:{foundItems}, expected:{howMmay}. ");

        Assert.Equal(foundItems.Length, howMmay);
    }

    public static string RandomString(int length)
    {
        Random r = new();
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[r.Next(s.Length)]).ToArray());
    }

}