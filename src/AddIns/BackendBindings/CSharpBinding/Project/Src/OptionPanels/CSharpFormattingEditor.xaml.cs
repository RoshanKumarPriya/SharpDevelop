﻿// Copyright (c) 2014 AlphaSierraPapa for the SharpDevelop Team
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of this
// software and associated documentation files (the "Software"), to deal in the Software
// without restriction, including without limitation the rights to use, copy, modify, merge,
// publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons
// to whom the Software is furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all copies or
// substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
// INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR
// PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE
// FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR
// OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
// DEALINGS IN THE SOFTWARE.

using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace CSharpBinding.OptionPanels
{
	internal class IFormattingItemContainer
	{
		string Text { get; set; }
	}
	
	/// <summary>
	/// Represents a container item for other container items in formatting editor list
	/// </summary>
	internal class FormattingGroupContainer : IFormattingItemContainer
	{
		public string Text
		{
			get;
			set;
		}
		
		public IEnumerable<IFormattingItemContainer> Children
		{
			get;
			set;
		}
	}
	
	/// <summary>
	/// Represents a container for formatting options.
	/// </summary>
	internal class FormattingOptionContainer : IFormattingItemContainer
	{
		public string Text
		{
			get;
			set;
		}
		
		public IEnumerable<FormattingOption> Children
		{
			get;
			set;
		}
	}
	
	/// <summary>
	/// Represents a single formatting option in formatting editor.
	/// </summary>
	internal class FormattingOption
	{
		public string OptionName
		{
			get;
			set;
		}
		public string Text
		{
			get;
			set;
		}
	}
	
	/// <summary>
	/// Interaction logic for CSharpFormattingEditor.xaml
	/// </summary>
	public partial class CSharpFormattingEditor : UserControl
	{
		readonly List<IFormattingItemContainer> rootEntries;
		
		public CSharpFormattingEditor()
		{
			rootEntries = new List<IFormattingItemContainer>();
			
			InitializeComponent();
			BuildOptionItems();
			this.DataContext = rootEntries;
		}

		void BuildOptionItems()
		{
			rootEntries.AddRange(
				new IFormattingItemContainer[]
				{
					new FormattingGroupContainer { Text = "Indentation", Children = new [] { new FormattingOptionContainer {
								Children = new [] {
									new FormattingOption { Text = "Indent namespace body" },
									new FormattingOption { Text = "Indent class body" },
									new FormattingOption { Text = "Indent interface body" },
									new FormattingOption { Text = "Indent struct body" },
									new FormattingOption { Text = "Indent enum body" },
									new FormattingOption { Text = "Indent method body" },
									new FormattingOption { Text = "Indent property body" },
									new FormattingOption { Text = "Indent event body" },
									new FormattingOption { Text = "Indent blocks" },
									new FormattingOption { Text = "Indent switch body" },
									new FormattingOption { Text = "Indent case body" },
									new FormattingOption { Text = "Indent break statements" },
									new FormattingOption { Text = "Align embedded using statements" },
									new FormattingOption { Text = "Align embedded if statements" },
									new FormattingOption { Text = "Align else in if statements" },
									new FormattingOption { Text = "Auto property formatting" },
									new FormattingOption { Text = "Simple property formatting" },
									new FormattingOption { Text = "Empty line formatting" },
									new FormattingOption { Text = "Indent preprocessor directives" },
									new FormattingOption { Text = "Align to member reference dot" },
								}
							}
						}
					},
					new FormattingGroupContainer { Text = "Braces", Children = new [] { new FormattingOptionContainer {
								Children = new [] {
									new FormattingOption { Text = "-" }
								}
							}
						}
					},
					new FormattingGroupContainer { Text = "New lines", Children = new [] { new FormattingOptionContainer {
								Children = new [] {
									new FormattingOption { Text = "-" }
								}
							}
						}
					},
					new FormattingGroupContainer { Text = "Spaces",
						Children = new [] {
							new FormattingGroupContainer { Text = "Methods", Children = new [] { new FormattingOptionContainer {
										Children = new [] {
											new FormattingOption { Text = "-" }
										}
									}
								}
							},
							new FormattingGroupContainer { Text = "Method calls", Children = new [] { new FormattingOptionContainer {
										Children = new [] {
											new FormattingOption { Text = "-" }
										}
									}
								}
							},
							new FormattingGroupContainer { Text = "Fields", Children = new [] { new FormattingOptionContainer {
										Children = new [] {
											new FormattingOption { Text = "-" }
										}
									}
								}
							},
							new FormattingGroupContainer { Text = "Local variables", Children = new [] { new FormattingOptionContainer {
										Children = new [] {
											new FormattingOption { Text = "-" }
										}
									}
								}
							},
							new FormattingGroupContainer { Text = "Constructors", Children = new [] { new FormattingOptionContainer {
										Children = new [] {
											new FormattingOption { Text = "-" }
										}
									}
								}
							},
							new FormattingGroupContainer { Text = "Indexers", Children = new [] { new FormattingOptionContainer {
										Children = new [] {
											new FormattingOption { Text = "-" }
										}
									}
								}
							},
							new FormattingGroupContainer { Text = "Delegates", Children = new [] { new FormattingOptionContainer {
										Children = new [] {
											new FormattingOption { Text = "-" }
										}
									}
								}
							},
							new FormattingGroupContainer { Text = "Statements", Children = new [] { new FormattingOptionContainer {
										Children = new [] {
											new FormattingOption { Text = "-" }
										}
									}
								}
							},
							new FormattingGroupContainer { Text = "Operators", Children = new [] { new FormattingOptionContainer {
										Children = new [] {
											new FormattingOption { Text = "-" }
										}
									}
								}
							},
							new FormattingGroupContainer { Text = "Brackets", Children = new [] { new FormattingOptionContainer {
										Children = new [] {
											new FormattingOption { Text = "-" }
										}
									}
								}
							}
						}
					},
					new FormattingGroupContainer { Text = "Blank lines", Children = new [] { new FormattingOptionContainer {
								Children = new [] {
									new FormattingOption { Text = "-" }
								}
							}
						}
					},
					new FormattingGroupContainer { Text = "Keep formatting", Children = new [] { new FormattingOptionContainer {
								Children = new [] {
									new FormattingOption { Text = "-" }
								}
							}
						}
					},
					new FormattingGroupContainer { Text = "Wrapping", Children = new [] { new FormattingOptionContainer {
								Children = new [] {
									new FormattingOption { Text = "-" }
								}
							}
						}
					},
					new FormattingGroupContainer { Text = "Using declarations", Children = new [] { new FormattingOptionContainer {
								Children = new [] {
									new FormattingOption { Text = "-" }
								}
							}
						}
					}
				}
			);
		}
	}
}