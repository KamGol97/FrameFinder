using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perun.FrameFinder;
public interface IFinder
{

    /// <summary>
    /// Adds data to internal queue.
    /// </summary>
    /// <param name="data"></param>
    void FeedMe(IEnumerable<byte> data);


    /// <summary>
    /// Returns count of matched elements in data.
    /// </summary>
    /// <returns></returns>
    object[] Find();


    /// <summary>
    /// Removes all bytes from finder queue.
    /// </summary>
    void Clean();

    byte[] GetData { get; }

    long DataLenght { get; }

    bool CircularSearching { get; set; }

    event EventHandler<object> FrameFound;

    FinderComponent[] Components { get; }
}
