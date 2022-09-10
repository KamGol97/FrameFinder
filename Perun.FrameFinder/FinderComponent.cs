using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perun.FrameFinder;
public struct FinderComponent
{
    public FinderComponent(bool constValue, LenghtDependsOn dependsOn, string name, FinderComponentType type)
    {
        ConstValue = constValue;
        LenghtsDepends = dependsOn;
        Name= name;
        FinderType = type;
    }

    public string Name { get; init; }

    public FinderComponentType FinderType { get; init; }

    bool ConstValue { get; init; }
    LenghtDependsOn LenghtsDepends { get; init; }

}
public enum FinderComponentType
{
    Prefix,
    Data,
    Variable,
}
public struct LenghtDependsOn // czy zależy od czegoś
{
    public LenghtDependsOn(bool isDepends,uint elementNumber)
    {
        IsDepends = isDepends;
        ElementNumber = elementNumber;
        Lenght = 0;
    }
    public LenghtDependsOn(bool isDepends)
    {
        IsDepends = isDepends;
        ElementNumber = 0;
        Lenght = 0;
    }
    public LenghtDependsOn(uint lenght)
    {
        this.IsDepends = false;
        this.ElementNumber = 0;
        Lenght = lenght;
    }
    bool IsDepends { get; init; }
    uint ElementNumber { get; init; }
    uint Lenght { get; init; }
}
