using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perun.FrameFinder;
public class Finder : IFinder

{
    List<byte> _queue = new();

    public Byte[] GetData => _queue.ToArray();
    public Int64 DataLenght => _queue.Count();
    private bool _CircularSearching = false;

    public event EventHandler<Object>? FrameFound;

    public Boolean CircularSearching
    {
        get => _CircularSearching;
        set { _CircularSearching = value; }
    }

    private FinderComponent[] _Components;
    public FinderComponent[] Components => throw new NotImplementedException();

    private bool _iHavePrefix = false;
    private bool _iHaveFixedDataLenght = false;


    public void Clean()
    {
        _queue.Clear();
    }

    public void FeedMe(IEnumerable<Byte> data)
    {
        _queue.AddRange(data);
    }

    public object[] Find()
    {
        return new object[0];
    }


    public Finder(FinderComponent[] components)
    {
        this._Components = components;
    }
    public Finder()
    {
        this._Components = Array.Empty<FinderComponent>();
    }
}
