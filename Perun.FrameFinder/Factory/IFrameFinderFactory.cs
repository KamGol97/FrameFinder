using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perun.FrameFinder;
public interface IFrameFinderFactory
{
    IFinder Create();
}



public interface IFrameFactory_Prefix
{
    public IFrameFinderFactory AddPrefix(IEnumerable<byte> prefix);
}

public interface IFrameFactory_FixedDataLenght
{
    public IFrameFinderFactory AddDataLenght(ulong dataLenght);
}