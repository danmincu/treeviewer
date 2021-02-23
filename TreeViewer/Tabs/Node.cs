using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace TestApp
{
	public class Node
	{
		private readonly ObservableCollection<Node> _children = new ObservableCollection<Node>();
		public ObservableCollection<Node> Children
		{
			get { return _children; }
		}

		public string Name { get; set; }

		public int Id { get; set; }

		static int _i;
		public Node()
		{
			Id = ++_i;
		}

		public override string ToString()
		{
			return Name;
		}
	}
}