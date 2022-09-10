using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perun.FrameFinder.Factory;
public class FinderFactory_Prefix_FixedLenght : IFrameFinderFactory
{

    FinderBuilder _builder;
    public FinderFactory_Prefix_FixedLenght(FinderBuilder builder, IEnumerable<Byte> prefix, uint dataLenght)
    {
        _builder = builder;
        _builder.AddPrefix(prefix);
        _builder.AddFixedData(dataLenght);
    }


    public IFinder Create()
    {
        return _builder.Build();
    }
}
