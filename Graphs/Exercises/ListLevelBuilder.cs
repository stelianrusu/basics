using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.Exercises
{
    public class ListLevelBuilder
    {
        public List<LinkedList<SearchNode>> BuildLists(SearchNode root)
        {
            List<LinkedList<SearchNode>> allLevels = new List<LinkedList<SearchNode>>();
            LinkedList<SearchNode> rootLevelList = new LinkedList<SearchNode>();
            rootLevelList.AddLast(root);

            allLevels.Add(rootLevelList);

            LinkedList<SearchNode> parentList = rootLevelList;
            while (parentList.Count > 0)
            {
                parentList = BuildListWithChildren(parentList);
                if(parentList.Count > 0)
                    allLevels.Add(parentList);
            }

            return allLevels;
        }

        private LinkedList<SearchNode> BuildListWithChildren(LinkedList<SearchNode> parentsList)
        {
            LinkedList<SearchNode> children = new LinkedList<SearchNode>();
            foreach (var parent in parentsList)
            {
                if (parent.Left != null)
                    children.AddLast(parent.Left);
                if (parent.Right != null)
                    children.AddLast(parent.Right);
            }

            return children;
        }
    }
}
