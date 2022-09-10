using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace Perun.FrameFinder;



public class FinderBuilder
{
    public FinderBuilder AddPrefix(IEnumerable<byte> prefix)
    {
        if (_components.FirstOrDefault(x => x.FinderType == FinderComponentType.Prefix) is { })
            throw new Exception("Builder already added prefix component");

        _components.Insert(
            index: 0, 
            new FinderComponent(
                constValue: true,
                dependsOn: new LenghtDependsOn(false),
                name: "Prefix",
                type: FinderComponentType.Prefix));

        return this;

    }

    public FinderBuilder AddFixedData(uint dataLenght)
    {
        _components.Add(
            new FinderComponent(
                constValue: true,
                dependsOn: new LenghtDependsOn(dataLenght),
                name: "Data",
                type: FinderComponentType.Data));

        return this;
    }

    private List<FinderComponent> _components = new();

    public IFinder Build()
    {
        return new Finder(_components);
    }
}
