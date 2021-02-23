using System.Collections.Generic;
using TestApp.Tree;

namespace TestApp
{
	public class NodeModel : ITreeModel
	{
		public static NodeModel LoadFromFile(string filename)
        {
			var lines = System.IO.File.ReadAllLines(filename);
			var model = new NodeModel();
			var nodes = new Dictionary<int, Node>();
			var tree = new Dictionary<int, List<int>>();
			Node root = null;

			foreach (var item in lines)
            {
				var values = item.Split('\t');
				if (int.TryParse(values[0], out int id))
                {
					var n = new Node() { Id = id, Name = values[2] };
					nodes.Add(id, n);
					if (int.TryParse(values[1], out int parent))
					{
						if (tree.ContainsKey(parent))
						{
							tree[parent].Add(id);
						}
						else
						{
							tree.Add(parent, new List<int>() { id });
						}
					}
					else
						root = n;
                }
            }

            foreach (var key in tree.Keys)
            {
                foreach (var childKey in tree[key])
                {
					nodes[key].Children.Add(nodes[childKey]);
                }
            }

			model.Root.Children.Add(root);

			return model;
        }


		public Node Root { get; private set; }

		public NodeModel()
		{
			Root = new Node();
		}

		public System.Collections.IEnumerable GetChildren(object parent)
		{
			if (parent == null)
				parent = Root;
			return (parent as Node).Children;
		}

		public bool HasChildren(object parent)
		{
			return (parent as Node).Children.Count > 0;
		}
	}
}
