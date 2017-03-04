using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Search
{
    public class BoyerMoore: IStringSearchAlgo
    {

        public IEnumerable<SearchMatch> Search(string toFind, string toSearch)
        {
            var badMatchTable = new BadMatchTable(toFind);

            // We hold these truths to be self-evident
            // truth

            // 01234567891
            // We hold these truths to be self-evident
            //       truth

            // We hold these truths to be self-evident
            //               truth

            var stepDownIndex = toFind.Length - 1;
            for (int searchIndex = stepDownIndex; searchIndex < toSearch.Length; searchIndex++)
            {
                for (int i = toFind.Length - 1; i >= 0; i--)
                {
                    var stepDownSearchIndex = searchIndex - (toFind.Length - 1 - i);

                    if (toFind[i] == toSearch[stepDownSearchIndex])
                    {
                        if (i == 0)
                        {
                            yield return new SearchMatch() {Length = toFind.Length, Start = searchIndex - toFind.Length + 1 };
                        }
                    }
                    else
                    {
                        var shift = badMatchTable.GetShift(toSearch[stepDownSearchIndex]);
                        searchIndex = searchIndex + shift - 1;
                        break;
                    }
                }
            }

        }
    }
}

