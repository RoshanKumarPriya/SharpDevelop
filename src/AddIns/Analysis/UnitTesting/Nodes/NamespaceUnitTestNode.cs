﻿// Copyright (c) AlphaSierraPapa for the SharpDevelop Team (for details please see \doc\copyright.txt)
// This code is distributed under the GNU LGPL (for details please see \doc\license.txt)

using System;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

using ICSharpCode.Core;
using ICSharpCode.SharpDevelop;
using ICSharpCode.SharpDevelop.Project;
using ICSharpCode.TreeView;

namespace ICSharpCode.UnitTesting
{
	public class NamespaceUnitTestNode : UnitTestBaseNode
	{
		string name;
		
		public string Namespace {
			get { return name; }
		}
		
		public string FullNamespace {
			get {
				TestProject p = GetProject();
				if (p != null)
					return p.Project.RootNamespace + "." + name;
				return name;
			}
		}
		
		public NamespaceUnitTestNode(string name)
		{
			if (string.IsNullOrEmpty(name))
				throw new ArgumentException("name");
			this.name = name;
		}
		
		public override object Text {
			get { return name.Substring(name.LastIndexOf('.') + 1); }
		}
		
		internal override TestResultType TestResultType {
			get {
				if (Children.Count == 0) return TestResultType.None;
				if (Children.OfType<UnitTestBaseNode>().Any(node => node.TestResultType == TestResultType.Failure))
					return TestResultType.Failure;
				if (Children.OfType<UnitTestBaseNode>().Any(node => node.TestResultType == TestResultType.None))
					return TestResultType.None;
				if (Children.OfType<UnitTestBaseNode>().Any(node => node.TestResultType == TestResultType.Ignored))
					return TestResultType.Ignored;
				return TestResultType.Success;
			}
		}
		
		public TestProject GetProject()
		{
			UnitTestBaseNode parent = this;
			while (parent is NamespaceUnitTestNode)
				parent = (UnitTestBaseNode)parent.Parent;
			if (parent is ProjectUnitTestNode)
				return ((ProjectUnitTestNode)parent).Project;
			return null;
		}
	}
}
