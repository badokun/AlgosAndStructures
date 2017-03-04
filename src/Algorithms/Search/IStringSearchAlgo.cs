using System.Collections.Generic;

namespace Algorithms.Search
{
    public interface IStringSearchAlgo
    {
        IEnumerable<SearchMatch> Search(string toFind, string toSearch);
    }
}