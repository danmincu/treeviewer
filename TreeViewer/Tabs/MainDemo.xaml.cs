using System.Windows;
using System.Windows.Controls;
using TestApp.Tree;

namespace TestApp
{
	/// <summary>
	/// Interaction logic for MainDemo.xaml
	/// </summary>
	public partial class MainDemo : UserControl
	{
		public MainDemo()
		{
			InitializeComponent();
			var model = NodeModel.LoadFromFile("dept.txt");
			_treeList.Model = model;

		}

		private void Toggle_Click(object sender, RoutedEventArgs e)
		{
			foreach(var node in _treeList.SelectedNodes)
				if (node.IsExpandable)
					node.IsExpanded = !node.IsExpanded;
		}

		private void Add_Click(object sender, RoutedEventArgs e)
		{
			if (_treeList.SelectedNode != null)
			{
				var p = new Node() { Name = "New node" };
				(_treeList.SelectedNode.Tag as Node).Children.Add(p);
				_treeList.SelectedNode.IsExpanded = true;
			}
		}

        private void Toggle_Click_All(object sender, RoutedEventArgs e)
        {
			foreach (var node in _treeList.SelectedNodes)
            {
				Expand(node);
            }
		}

		private TreeNode Expand(TreeNode node)
        {
			if (node.IsExpandable)
				node.IsExpanded = true;//!node.IsExpanded;

            foreach (var item in node.AllVisibleChildren)
            {
				Expand(item);
            }

			return node;

        }

    }
}
