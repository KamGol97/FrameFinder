using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perun.FrameFinder;



public class FinderBuilder
{


    public IFinder Build()
    {
        return new Finder();
    }
}

public class Finder : IFinder
{
    public void FeedMe(IEnumerable<Byte> data)
    {
       
    }

    public Int32 Find()
    {
        return -1;
    }
}