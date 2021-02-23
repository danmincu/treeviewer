using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Aga.Controls.Tree;

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
	}
}
