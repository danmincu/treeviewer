﻿using System.Windows;
using System.Windows.Controls;

namespace TestApp.Tree
{
    public class RowExpander : Control
	{
		static RowExpander()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(RowExpander), new FrameworkPropertyMetadata(typeof(RowExpander)));
		}
	}
}
