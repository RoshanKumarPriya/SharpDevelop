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
using System.Collections;
using System.IO;
using System.Xml;

using ICSharpCode.Reporting.Interfaces;
using ICSharpCode.Reporting.Items;
using ICSharpCode.Reporting.PageBuilder;
using ICSharpCode.Reporting.Xml;

namespace ICSharpCode.Reporting
{
	/// <summary>
	/// Description of Reporting.
	/// </summary>
	public class ReportingFactory
	{
		
		public IReportCreator ReportCreator (Stream stream,IEnumerable list)
		{
			ReportModel = LoadReportModel (stream);
			IReportCreator builder = null;
			builder = new DataPageBuilder(ReportModel,list );
			return builder;
		}
		
		
		[Obsolete("Use public IReportCreator ReportCreator (Stream stream,IEnumerable list")]
		public IReportCreator ReportCreator (Stream stream,Type listType,IEnumerable list)
		{
			ReportModel = LoadReportModel (stream);
			IReportCreator builder = null;
			builder = new DataPageBuilder(ReportModel,list );
			return builder;
		}
		
		
		public IReportCreator ReportCreator (Stream stream)
		{
			ReportModel = LoadReportModel (stream);
//			IReportCreator builder = null;
//			builder = ReportCreatorFactory.ExporterFactory(ReportModel);
			var builder = new FormPageBuilder(ReportModel);
			return builder;
		}
		

		public IReportCreator ReportCreator (ReportModel reportModel) {
			ReportModel = reportModel;
//			IReportCreator builder = null;
//			builder = ReportCreatorFactory.ExporterFactory(ReportModel);
			var builder = new FormPageBuilder(ReportModel);
			return builder;
		}
		
		
		internal ReportModel LoadReportModel (Stream stream)
		{
			var doc = new XmlDocument();
			doc.Load(stream);
			ReportModel = LoadModel(doc);
			return ReportModel;
		}
		
		static ReportModel LoadModel(XmlDocument doc)
		{
			var loader = new ModelLoader();
			object root = loader.Load(doc.DocumentElement);

			var model = root as ReportModel;
			if (model == null) {
//				throw new IllegalFileFormatException("ReportModel");
			}
			return model;
		}
		
		public ReportModel ReportModel {get;private set;}
	}
}
