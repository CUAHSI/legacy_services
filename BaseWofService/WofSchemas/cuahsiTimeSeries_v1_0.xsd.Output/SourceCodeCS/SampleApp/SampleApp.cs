using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LiquidTechnologies.Viewer.Net20;

namespace LiquidTechnologies.Test
{
	/// <summary>
	/// Summary description for SampleApp.
	/// </summary>
	public class SampleApp : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnLoad;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Label lblInfo;
		private System.Windows.Forms.ListBox lstFiles;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		#region btnLoad_Click - Opens the selected file - (THIS IS A GOOD PLACE TO START)
		// When an item is selected from the ListBox, this event handler is called.
		// 
		// If you specified Sample files in the Liquid XML wizard then they will be listed
		// in the switch statement.
		// If you did not specify Samples then there are 2 routes foward. You can either
		// use the "Browse for a File to Load", this will load the sample using a generic load
		// method. Alternatively you can run one of the SimpleTestXXXXX("<filename>") methods
		// This will load the file into the correct object, and display it in the viewer.
		private void btnLoad_Click(object sender, System.EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;

			switch (lstFiles.SelectedIndex)
			{
				case 0:
					if (openFileDialog.ShowDialog(this) == DialogResult.OK)
						SimpleTestLoadAnyXmlDocument(openFileDialog.FileName);
				break;
			};
			#region UNCOMMENT CODE IN THIS REGION TO LOAD YOUR SAMPLE XML FILES
			/* ---------------------------------------------------------------------------------
			 * This function can be used to open an XML document with a document element 
			 * (the first element in the file) named 'datasetInfo' 
			 * e.g. 
			 *
			 * <?xml version="1.0" encoding="UTF-8"?>
			 * <datasetInfo>
			 *     ...
			 * </datasetInfo>
			 * --------------------------------------------------------------------------------- */
			// SimpleTestDatasetInfo(@"<UNCOMMENT & INSERT A SAMPLE XML FILENAME HERE>");
			
			/* ---------------------------------------------------------------------------------
			 * This function can be used to open an XML document with a document element 
			 * (the first element in the file) named 'extension' 
			 * e.g. 
			 *
			 * <?xml version="1.0" encoding="UTF-8"?>
			 * <extension>
			 *     ...
			 * </extension>
			 * --------------------------------------------------------------------------------- */
			// SimpleTestExtension(@"<UNCOMMENT & INSERT A SAMPLE XML FILENAME HERE>");
			
			/* ---------------------------------------------------------------------------------
			 * This function can be used to open an XML document with a document element 
			 * (the first element in the file) named 'latLonBox' 
			 * e.g. 
			 *
			 * <?xml version="1.0" encoding="UTF-8"?>
			 * <latLonBox>
			 *     ...
			 * </latLonBox>
			 * --------------------------------------------------------------------------------- */
			// SimpleTestLatLonBox(@"<UNCOMMENT & INSERT A SAMPLE XML FILENAME HERE>");
			
			/* ---------------------------------------------------------------------------------
			 * This function can be used to open an XML document with a document element 
			 * (the first element in the file) named 'latLonPoint' 
			 * e.g. 
			 *
			 * <?xml version="1.0" encoding="UTF-8"?>
			 * <latLonPoint>
			 *     ...
			 * </latLonPoint>
			 * --------------------------------------------------------------------------------- */
			// SimpleTestLatLonPoint(@"<UNCOMMENT & INSERT A SAMPLE XML FILENAME HERE>");
			
			/* ---------------------------------------------------------------------------------
			 * This function can be used to open an XML document with a document element 
			 * (the first element in the file) named 'option' 
			 * e.g. 
			 *
			 * <?xml version="1.0" encoding="UTF-8"?>
			 * <option>
			 *     ...
			 * </option>
			 * --------------------------------------------------------------------------------- */
			// SimpleTestOption(@"<UNCOMMENT & INSERT A SAMPLE XML FILENAME HERE>");
			
			/* ---------------------------------------------------------------------------------
			 * This function can be used to open an XML document with a document element 
			 * (the first element in the file) named 'optionGroup' 
			 * e.g. 
			 *
			 * <?xml version="1.0" encoding="UTF-8"?>
			 * <optionGroup>
			 *     ...
			 * </optionGroup>
			 * --------------------------------------------------------------------------------- */
			// SimpleTestOptionGroup(@"<UNCOMMENT & INSERT A SAMPLE XML FILENAME HERE>");
			
			/* ---------------------------------------------------------------------------------
			 * This function can be used to open an XML document with a document element 
			 * (the first element in the file) named 'options' 
			 * e.g. 
			 *
			 * <?xml version="1.0" encoding="UTF-8"?>
			 * <options>
			 *     ...
			 * </options>
			 * --------------------------------------------------------------------------------- */
			// SimpleTestOptions(@"<UNCOMMENT & INSERT A SAMPLE XML FILENAME HERE>");
			
			/* ---------------------------------------------------------------------------------
			 * This function can be used to open an XML document with a document element 
			 * (the first element in the file) named 'qualifier' 
			 * e.g. 
			 *
			 * <?xml version="1.0" encoding="UTF-8"?>
			 * <qualifier>
			 *     ...
			 * </qualifier>
			 * --------------------------------------------------------------------------------- */
			// SimpleTestQualifier(@"<UNCOMMENT & INSERT A SAMPLE XML FILENAME HERE>");
			
			/* ---------------------------------------------------------------------------------
			 * This function can be used to open an XML document with a document element 
			 * (the first element in the file) named 'qualityControlLevel' 
			 * e.g. 
			 *
			 * <?xml version="1.0" encoding="UTF-8"?>
			 * <qualityControlLevel>
			 *     ...
			 * </qualityControlLevel>
			 * --------------------------------------------------------------------------------- */
			// SimpleTestQualityControlLevel(@"<UNCOMMENT & INSERT A SAMPLE XML FILENAME HERE>");
			
			/* ---------------------------------------------------------------------------------
			 * This function can be used to open an XML document with a document element 
			 * (the first element in the file) named 'site' 
			 * e.g. 
			 *
			 * <?xml version="1.0" encoding="UTF-8"?>
			 * <site>
			 *     ...
			 * </site>
			 * --------------------------------------------------------------------------------- */
			// SimpleTestSite(@"<UNCOMMENT & INSERT A SAMPLE XML FILENAME HERE>");
			
			/* ---------------------------------------------------------------------------------
			 * This function can be used to open an XML document with a document element 
			 * (the first element in the file) named 'sitesResponse' 
			 * e.g. 
			 *
			 * <?xml version="1.0" encoding="UTF-8"?>
			 * <sitesResponse>
			 *     ...
			 * </sitesResponse>
			 * --------------------------------------------------------------------------------- */
			// SimpleTestSitesResponse(@"<UNCOMMENT & INSERT A SAMPLE XML FILENAME HERE>");
			
			/* ---------------------------------------------------------------------------------
			 * This function can be used to open an XML document with a document element 
			 * (the first element in the file) named 'timeSeriesResponse' 
			 * e.g. 
			 *
			 * <?xml version="1.0" encoding="UTF-8"?>
			 * <timeSeriesResponse>
			 *     ...
			 * </timeSeriesResponse>
			 * --------------------------------------------------------------------------------- */
			// SimpleTestTimeSeriesResponse(@"<UNCOMMENT & INSERT A SAMPLE XML FILENAME HERE>");
			
			/* ---------------------------------------------------------------------------------
			 * This function can be used to open an XML document with a document element 
			 * (the first element in the file) named 'timeZoneInfo' 
			 * e.g. 
			 *
			 * <?xml version="1.0" encoding="UTF-8"?>
			 * <timeZoneInfo>
			 *     ...
			 * </timeZoneInfo>
			 * --------------------------------------------------------------------------------- */
			// SimpleTestTimeZoneInfo(@"<UNCOMMENT & INSERT A SAMPLE XML FILENAME HERE>");
			
			/* ---------------------------------------------------------------------------------
			 * This function can be used to open an XML document with a document element 
			 * (the first element in the file) named 'units' 
			 * e.g. 
			 *
			 * <?xml version="1.0" encoding="UTF-8"?>
			 * <units>
			 *     ...
			 * </units>
			 * --------------------------------------------------------------------------------- */
			// SimpleTestUnits(@"<UNCOMMENT & INSERT A SAMPLE XML FILENAME HERE>");
			
			/* ---------------------------------------------------------------------------------
			 * This function can be used to open an XML document with a document element 
			 * (the first element in the file) named 'variableCode' 
			 * e.g. 
			 *
			 * <?xml version="1.0" encoding="UTF-8"?>
			 * <variableCode>
			 *     ...
			 * </variableCode>
			 * --------------------------------------------------------------------------------- */
			// SimpleTestVariableCode(@"<UNCOMMENT & INSERT A SAMPLE XML FILENAME HERE>");
			
			/* ---------------------------------------------------------------------------------
			 * This function can be used to open an XML document with a document element 
			 * (the first element in the file) named 'variables' 
			 * e.g. 
			 *
			 * <?xml version="1.0" encoding="UTF-8"?>
			 * <variables>
			 *     ...
			 * </variables>
			 * --------------------------------------------------------------------------------- */
			// SimpleTestVariables(@"<UNCOMMENT & INSERT A SAMPLE XML FILENAME HERE>");
			
			/* ---------------------------------------------------------------------------------
			 * This function can be used to open an XML document with a document element 
			 * (the first element in the file) named 'variablesResponse' 
			 * e.g. 
			 *
			 * <?xml version="1.0" encoding="UTF-8"?>
			 * <variablesResponse>
			 *     ...
			 * </variablesResponse>
			 * --------------------------------------------------------------------------------- */
			// SimpleTestVariablesResponse(@"<UNCOMMENT & INSERT A SAMPLE XML FILENAME HERE>");
			
			#endregion
			this.Cursor = Cursors.Default;
		}
		#endregion
	
		#region Sample Functions Demonstrating Reading from an XML File
		#region SimpleTestDatasetInfo - Demo for documents with a root <datasetInfo>
		// Shows a simple example of how the class DatasetInfo
		// can be used. This class can be used to load documents whose 
		// root (document) element is <datasetInfo>.
		private void SimpleTestDatasetInfo(string filename)
		{
			try
			{
				// create an instance of the class to load the XML file into
				tns.DatasetInfo elm = new tns.DatasetInfo();
				
				// load the xml from a file into the object (the root element in the
				// xml document must be <datasetInfo>.
				elm.FromXmlFile(filename);

				// This will open up a viewer, allowing you to navigate the classes
				// that have been generated. 
				// Note the veiwer can be used to modify properties, and provides a listing of
				// the code required to create the document it is displaying.
				SimpleViewer sv = new SimpleViewer(elm);
				sv.ShowDialog();

				// You can then add code to navigate the data held in the class.
				// When navigating this object model you should refer to the documentation
				// generated in the directory:
				// C:\dev2005\BaseWofService\WofSchemas\cuahsiTimeSeries_v1_0.xsd.Output\DocumentationCS\.
				// The help should be compiled into a chm before being used, (use build.bat)
				//- HTML Help Workshop is required to perform this,
				// and can be downloaded from Microsoft. The path to the help compiler (hhc.exe) 
				// may need adjusting in build.bat
				
				// ...

				////////////////////////////////////////////////////////////////////				
				// The Xml can be extracted from the class using one of 3 methods; //
				////////////////////////////////////////////////////////////////////
				
				// This method will extract the xml into a string. The string is always encoded 
				// using Unicode, there a number of options allowing the headers, 
				// end of line & indenting to be set.
				string strXml = elm.ToXml();
				Console.WriteLine(strXml);
				
				// This method will extract the xml into a file. This method provides options
				// for changing the encoding (UTF-8, UTF-16) as well as headers, 
				// end of line and indenting.
				elm.ToXmlFile(filename + ".testouput.xml");
				
				// This method will extract the xml into a stream. This method provides options
				// for changing the encoding (UTF-8, UTF-16) as well as headers, 
				// end of line and indenting.
				// This method is useful when a specific encoding is required (typically
				// UTF-8), in order to transmit it over an 8-bit connection, smtp etc
				// without the need to write the xml to file first.
				System.IO.Stream stmXml = elm.ToXmlStream();

			}
			catch (Exception e)
			{
				DisplayError(e);
			}
		}
		#endregion
		#region SimpleTestExtension - Demo for documents with a root <extension>
		// Shows a simple example of how the class Extension
		// can be used. This class can be used to load documents whose 
		// root (document) element is <extension>.
		private void SimpleTestExtension(string filename)
		{
			try
			{
				// create an instance of the class to load the XML file into
				tns.Extension elm = new tns.Extension();
				
				// load the xml from a file into the object (the root element in the
				// xml document must be <extension>.
				elm.FromXmlFile(filename);

				// This will open up a viewer, allowing you to navigate the classes
				// that have been generated. 
				// Note the veiwer can be used to modify properties, and provides a listing of
				// the code required to create the document it is displaying.
				SimpleViewer sv = new SimpleViewer(elm);
				sv.ShowDialog();

				// You can then add code to navigate the data held in the class.
				// When navigating this object model you should refer to the documentation
				// generated in the directory:
				// C:\dev2005\BaseWofService\WofSchemas\cuahsiTimeSeries_v1_0.xsd.Output\DocumentationCS\.
				// The help should be compiled into a chm before being used, (use build.bat)
				//- HTML Help Workshop is required to perform this,
				// and can be downloaded from Microsoft. The path to the help compiler (hhc.exe) 
				// may need adjusting in build.bat
				
				// ...

				////////////////////////////////////////////////////////////////////				
				// The Xml can be extracted from the class using one of 3 methods; //
				////////////////////////////////////////////////////////////////////
				
				// This method will extract the xml into a string. The string is always encoded 
				// using Unicode, there a number of options allowing the headers, 
				// end of line & indenting to be set.
				string strXml = elm.ToXml();
				Console.WriteLine(strXml);
				
				// This method will extract the xml into a file. This method provides options
				// for changing the encoding (UTF-8, UTF-16) as well as headers, 
				// end of line and indenting.
				elm.ToXmlFile(filename + ".testouput.xml");
				
				// This method will extract the xml into a stream. This method provides options
				// for changing the encoding (UTF-8, UTF-16) as well as headers, 
				// end of line and indenting.
				// This method is useful when a specific encoding is required (typically
				// UTF-8), in order to transmit it over an 8-bit connection, smtp etc
				// without the need to write the xml to file first.
				System.IO.Stream stmXml = elm.ToXmlStream();

			}
			catch (Exception e)
			{
				DisplayError(e);
			}
		}
		#endregion
		#region SimpleTestLatLonBox - Demo for documents with a root <latLonBox>
		// Shows a simple example of how the class LatLonBox
		// can be used. This class can be used to load documents whose 
		// root (document) element is <latLonBox>.
		private void SimpleTestLatLonBox(string filename)
		{
			try
			{
				// create an instance of the class to load the XML file into
				tns.LatLonBox elm = new tns.LatLonBox();
				
				// load the xml from a file into the object (the root element in the
				// xml document must be <latLonBox>.
				elm.FromXmlFile(filename);

				// This will open up a viewer, allowing you to navigate the classes
				// that have been generated. 
				// Note the veiwer can be used to modify properties, and provides a listing of
				// the code required to create the document it is displaying.
				SimpleViewer sv = new SimpleViewer(elm);
				sv.ShowDialog();

				// You can then add code to navigate the data held in the class.
				// When navigating this object model you should refer to the documentation
				// generated in the directory:
				// C:\dev2005\BaseWofService\WofSchemas\cuahsiTimeSeries_v1_0.xsd.Output\DocumentationCS\.
				// The help should be compiled into a chm before being used, (use build.bat)
				//- HTML Help Workshop is required to perform this,
				// and can be downloaded from Microsoft. The path to the help compiler (hhc.exe) 
				// may need adjusting in build.bat
				
				// ...

				////////////////////////////////////////////////////////////////////				
				// The Xml can be extracted from the class using one of 3 methods; //
				////////////////////////////////////////////////////////////////////
				
				// This method will extract the xml into a string. The string is always encoded 
				// using Unicode, there a number of options allowing the headers, 
				// end of line & indenting to be set.
				string strXml = elm.ToXml();
				Console.WriteLine(strXml);
				
				// This method will extract the xml into a file. This method provides options
				// for changing the encoding (UTF-8, UTF-16) as well as headers, 
				// end of line and indenting.
				elm.ToXmlFile(filename + ".testouput.xml");
				
				// This method will extract the xml into a stream. This method provides options
				// for changing the encoding (UTF-8, UTF-16) as well as headers, 
				// end of line and indenting.
				// This method is useful when a specific encoding is required (typically
				// UTF-8), in order to transmit it over an 8-bit connection, smtp etc
				// without the need to write the xml to file first.
				System.IO.Stream stmXml = elm.ToXmlStream();

			}
			catch (Exception e)
			{
				DisplayError(e);
			}
		}
		#endregion
		#region SimpleTestLatLonPoint - Demo for documents with a root <latLonPoint>
		// Shows a simple example of how the class LatLonPoint
		// can be used. This class can be used to load documents whose 
		// root (document) element is <latLonPoint>.
		private void SimpleTestLatLonPoint(string filename)
		{
			try
			{
				// create an instance of the class to load the XML file into
				tns.LatLonPoint elm = new tns.LatLonPoint();
				
				// load the xml from a file into the object (the root element in the
				// xml document must be <latLonPoint>.
				elm.FromXmlFile(filename);

				// This will open up a viewer, allowing you to navigate the classes
				// that have been generated. 
				// Note the veiwer can be used to modify properties, and provides a listing of
				// the code required to create the document it is displaying.
				SimpleViewer sv = new SimpleViewer(elm);
				sv.ShowDialog();

				// You can then add code to navigate the data held in the class.
				// When navigating this object model you should refer to the documentation
				// generated in the directory:
				// C:\dev2005\BaseWofService\WofSchemas\cuahsiTimeSeries_v1_0.xsd.Output\DocumentationCS\.
				// The help should be compiled into a chm before being used, (use build.bat)
				//- HTML Help Workshop is required to perform this,
				// and can be downloaded from Microsoft. The path to the help compiler (hhc.exe) 
				// may need adjusting in build.bat
				
				// ...

				////////////////////////////////////////////////////////////////////				
				// The Xml can be extracted from the class using one of 3 methods; //
				////////////////////////////////////////////////////////////////////
				
				// This method will extract the xml into a string. The string is always encoded 
				// using Unicode, there a number of options allowing the headers, 
				// end of line & indenting to be set.
				string strXml = elm.ToXml();
				Console.WriteLine(strXml);
				
				// This method will extract the xml into a file. This method provides options
				// for changing the encoding (UTF-8, UTF-16) as well as headers, 
				// end of line and indenting.
				elm.ToXmlFile(filename + ".testouput.xml");
				
				// This method will extract the xml into a stream. This method provides options
				// for changing the encoding (UTF-8, UTF-16) as well as headers, 
				// end of line and indenting.
				// This method is useful when a specific encoding is required (typically
				// UTF-8), in order to transmit it over an 8-bit connection, smtp etc
				// without the need to write the xml to file first.
				System.IO.Stream stmXml = elm.ToXmlStream();

			}
			catch (Exception e)
			{
				DisplayError(e);
			}
		}
		#endregion
		#region SimpleTestOption - Demo for documents with a root <option>
		// Shows a simple example of how the class Option
		// can be used. This class can be used to load documents whose 
		// root (document) element is <option>.
		private void SimpleTestOption(string filename)
		{
			try
			{
				// create an instance of the class to load the XML file into
				tns.Option elm = new tns.Option();
				
				// load the xml from a file into the object (the root element in the
				// xml document must be <option>.
				elm.FromXmlFile(filename);

				// This will open up a viewer, allowing you to navigate the classes
				// that have been generated. 
				// Note the veiwer can be used to modify properties, and provides a listing of
				// the code required to create the document it is displaying.
				SimpleViewer sv = new SimpleViewer(elm);
				sv.ShowDialog();

				// You can then add code to navigate the data held in the class.
				// When navigating this object model you should refer to the documentation
				// generated in the directory:
				// C:\dev2005\BaseWofService\WofSchemas\cuahsiTimeSeries_v1_0.xsd.Output\DocumentationCS\.
				// The help should be compiled into a chm before being used, (use build.bat)
				//- HTML Help Workshop is required to perform this,
				// and can be downloaded from Microsoft. The path to the help compiler (hhc.exe) 
				// may need adjusting in build.bat
				
				// ...

				////////////////////////////////////////////////////////////////////				
				// The Xml can be extracted from the class using one of 3 methods; //
				////////////////////////////////////////////////////////////////////
				
				// This method will extract the xml into a string. The string is always encoded 
				// using Unicode, there a number of options allowing the headers, 
				// end of line & indenting to be set.
				string strXml = elm.ToXml();
				Console.WriteLine(strXml);
				
				// This method will extract the xml into a file. This method provides options
				// for changing the encoding (UTF-8, UTF-16) as well as headers, 
				// end of line and indenting.
				elm.ToXmlFile(filename + ".testouput.xml");
				
				// This method will extract the xml into a stream. This method provides options
				// for changing the encoding (UTF-8, UTF-16) as well as headers, 
				// end of line and indenting.
				// This method is useful when a specific encoding is required (typically
				// UTF-8), in order to transmit it over an 8-bit connection, smtp etc
				// without the need to write the xml to file first.
				System.IO.Stream stmXml = elm.ToXmlStream();

			}
			catch (Exception e)
			{
				DisplayError(e);
			}
		}
		#endregion
		#region SimpleTestOptionGroup - Demo for documents with a root <optionGroup>
		// Shows a simple example of how the class OptionGroup
		// can be used. This class can be used to load documents whose 
		// root (document) element is <optionGroup>.
		private void SimpleTestOptionGroup(string filename)
		{
			try
			{
				// create an instance of the class to load the XML file into
				tns.OptionGroup elm = new tns.OptionGroup();
				
				// load the xml from a file into the object (the root element in the
				// xml document must be <optionGroup>.
				elm.FromXmlFile(filename);

				// This will open up a viewer, allowing you to navigate the classes
				// that have been generated. 
				// Note the veiwer can be used to modify properties, and provides a listing of
				// the code required to create the document it is displaying.
				SimpleViewer sv = new SimpleViewer(elm);
				sv.ShowDialog();

				// You can then add code to navigate the data held in the class.
				// When navigating this object model you should refer to the documentation
				// generated in the directory:
				// C:\dev2005\BaseWofService\WofSchemas\cuahsiTimeSeries_v1_0.xsd.Output\DocumentationCS\.
				// The help should be compiled into a chm before being used, (use build.bat)
				//- HTML Help Workshop is required to perform this,
				// and can be downloaded from Microsoft. The path to the help compiler (hhc.exe) 
				// may need adjusting in build.bat
				
				// ...

				////////////////////////////////////////////////////////////////////				
				// The Xml can be extracted from the class using one of 3 methods; //
				////////////////////////////////////////////////////////////////////
				
				// This method will extract the xml into a string. The string is always encoded 
				// using Unicode, there a number of options allowing the headers, 
				// end of line & indenting to be set.
				string strXml = elm.ToXml();
				Console.WriteLine(strXml);
				
				// This method will extract the xml into a file. This method provides options
				// for changing the encoding (UTF-8, UTF-16) as well as headers, 
				// end of line and indenting.
				elm.ToXmlFile(filename + ".testouput.xml");
				
				// This method will extract the xml into a stream. This method provides options
				// for changing the encoding (UTF-8, UTF-16) as well as headers, 
				// end of line and indenting.
				// This method is useful when a specific encoding is required (typically
				// UTF-8), in order to transmit it over an 8-bit connection, smtp etc
				// without the need to write the xml to file first.
				System.IO.Stream stmXml = elm.ToXmlStream();

			}
			catch (Exception e)
			{
				DisplayError(e);
			}
		}
		#endregion
		#region SimpleTestOptions - Demo for documents with a root <options>
		// Shows a simple example of how the class Options
		// can be used. This class can be used to load documents whose 
		// root (document) element is <options>.
		private void SimpleTestOptions(string filename)
		{
			try
			{
				// create an instance of the class to load the XML file into
				tns.Options elm = new tns.Options();
				
				// load the xml from a file into the object (the root element in the
				// xml document must be <options>.
				elm.FromXmlFile(filename);

				// This will open up a viewer, allowing you to navigate the classes
				// that have been generated. 
				// Note the veiwer can be used to modify properties, and provides a listing of
				// the code required to create the document it is displaying.
				SimpleViewer sv = new SimpleViewer(elm);
				sv.ShowDialog();

				// You can then add code to navigate the data held in the class.
				// When navigating this object model you should refer to the documentation
				// generated in the directory:
				// C:\dev2005\BaseWofService\WofSchemas\cuahsiTimeSeries_v1_0.xsd.Output\DocumentationCS\.
				// The help should be compiled into a chm before being used, (use build.bat)
				//- HTML Help Workshop is required to perform this,
				// and can be downloaded from Microsoft. The path to the help compiler (hhc.exe) 
				// may need adjusting in build.bat
				
				// ...

				////////////////////////////////////////////////////////////////////				
				// The Xml can be extracted from the class using one of 3 methods; //
				////////////////////////////////////////////////////////////////////
				
				// This method will extract the xml into a string. The string is always encoded 
				// using Unicode, there a number of options allowing the headers, 
				// end of line & indenting to be set.
				string strXml = elm.ToXml();
				Console.WriteLine(strXml);
				
				// This method will extract the xml into a file. This method provides options
				// for changing the encoding (UTF-8, UTF-16) as well as headers, 
				// end of line and indenting.
				elm.ToXmlFile(filename + ".testouput.xml");
				
				// This method will extract the xml into a stream. This method provides options
				// for changing the encoding (UTF-8, UTF-16) as well as headers, 
				// end of line and indenting.
				// This method is useful when a specific encoding is required (typically
				// UTF-8), in order to transmit it over an 8-bit connection, smtp etc
				// without the need to write the xml to file first.
				System.IO.Stream stmXml = elm.ToXmlStream();

			}
			catch (Exception e)
			{
				DisplayError(e);
			}
		}
		#endregion
		#region SimpleTestQualifier - Demo for documents with a root <qualifier>
		// Shows a simple example of how the class Qualifier
		// can be used. This class can be used to load documents whose 
		// root (document) element is <qualifier>.
		private void SimpleTestQualifier(string filename)
		{
			try
			{
				// create an instance of the class to load the XML file into
				tns.Qualifier elm = new tns.Qualifier();
				
				// load the xml from a file into the object (the root element in the
				// xml document must be <qualifier>.
				elm.FromXmlFile(filename);

				// This will open up a viewer, allowing you to navigate the classes
				// that have been generated. 
				// Note the veiwer can be used to modify properties, and provides a listing of
				// the code required to create the document it is displaying.
				SimpleViewer sv = new SimpleViewer(elm);
				sv.ShowDialog();

				// You can then add code to navigate the data held in the class.
				// When navigating this object model you should refer to the documentation
				// generated in the directory:
				// C:\dev2005\BaseWofService\WofSchemas\cuahsiTimeSeries_v1_0.xsd.Output\DocumentationCS\.
				// The help should be compiled into a chm before being used, (use build.bat)
				//- HTML Help Workshop is required to perform this,
				// and can be downloaded from Microsoft. The path to the help compiler (hhc.exe) 
				// may need adjusting in build.bat
				
				// ...

				////////////////////////////////////////////////////////////////////				
				// The Xml can be extracted from the class using one of 3 methods; //
				////////////////////////////////////////////////////////////////////
				
				// This method will extract the xml into a string. The string is always encoded 
				// using Unicode, there a number of options allowing the headers, 
				// end of line & indenting to be set.
				string strXml = elm.ToXml();
				Console.WriteLine(strXml);
				
				// This method will extract the xml into a file. This method provides options
				// for changing the encoding (UTF-8, UTF-16) as well as headers, 
				// end of line and indenting.
				elm.ToXmlFile(filename + ".testouput.xml");
				
				// This method will extract the xml into a stream. This method provides options
				// for changing the encoding (UTF-8, UTF-16) as well as headers, 
				// end of line and indenting.
				// This method is useful when a specific encoding is required (typically
				// UTF-8), in order to transmit it over an 8-bit connection, smtp etc
				// without the need to write the xml to file first.
				System.IO.Stream stmXml = elm.ToXmlStream();

			}
			catch (Exception e)
			{
				DisplayError(e);
			}
		}
		#endregion
		#region SimpleTestQualityControlLevel - Demo for documents with a root <qualityControlLevel>
		// Shows a simple example of how the class QualityControlLevel
		// can be used. This class can be used to load documents whose 
		// root (document) element is <qualityControlLevel>.
		private void SimpleTestQualityControlLevel(string filename)
		{
			try
			{
				// create an instance of the class to load the XML file into
				tns.QualityControlLevel elm = new tns.QualityControlLevel();
				
				// load the xml from a file into the object (the root element in the
				// xml document must be <qualityControlLevel>.
				elm.FromXmlFile(filename);

				// This will open up a viewer, allowing you to navigate the classes
				// that have been generated. 
				// Note the veiwer can be used to modify properties, and provides a listing of
				// the code required to create the document it is displaying.
				SimpleViewer sv = new SimpleViewer(elm);
				sv.ShowDialog();

				// You can then add code to navigate the data held in the class.
				// When navigating this object model you should refer to the documentation
				// generated in the directory:
				// C:\dev2005\BaseWofService\WofSchemas\cuahsiTimeSeries_v1_0.xsd.Output\DocumentationCS\.
				// The help should be compiled into a chm before being used, (use build.bat)
				//- HTML Help Workshop is required to perform this,
				// and can be downloaded from Microsoft. The path to the help compiler (hhc.exe) 
				// may need adjusting in build.bat
				
				// ...

				////////////////////////////////////////////////////////////////////				
				// The Xml can be extracted from the class using one of 3 methods; //
				////////////////////////////////////////////////////////////////////
				
				// This method will extract the xml into a string. The string is always encoded 
				// using Unicode, there a number of options allowing the headers, 
				// end of line & indenting to be set.
				string strXml = elm.ToXml();
				Console.WriteLine(strXml);
				
				// This method will extract the xml into a file. This method provides options
				// for changing the encoding (UTF-8, UTF-16) as well as headers, 
				// end of line and indenting.
				elm.ToXmlFile(filename + ".testouput.xml");
				
				// This method will extract the xml into a stream. This method provides options
				// for changing the encoding (UTF-8, UTF-16) as well as headers, 
				// end of line and indenting.
				// This method is useful when a specific encoding is required (typically
				// UTF-8), in order to transmit it over an 8-bit connection, smtp etc
				// without the need to write the xml to file first.
				System.IO.Stream stmXml = elm.ToXmlStream();

			}
			catch (Exception e)
			{
				DisplayError(e);
			}
		}
		#endregion
		#region SimpleTestSite - Demo for documents with a root <site>
		// Shows a simple example of how the class Site
		// can be used. This class can be used to load documents whose 
		// root (document) element is <site>.
		private void SimpleTestSite(string filename)
		{
			try
			{
				// create an instance of the class to load the XML file into
				tns.Site elm = new tns.Site();
				
				// load the xml from a file into the object (the root element in the
				// xml document must be <site>.
				elm.FromXmlFile(filename);

				// This will open up a viewer, allowing you to navigate the classes
				// that have been generated. 
				// Note the veiwer can be used to modify properties, and provides a listing of
				// the code required to create the document it is displaying.
				SimpleViewer sv = new SimpleViewer(elm);
				sv.ShowDialog();

				// You can then add code to navigate the data held in the class.
				// When navigating this object model you should refer to the documentation
				// generated in the directory:
				// C:\dev2005\BaseWofService\WofSchemas\cuahsiTimeSeries_v1_0.xsd.Output\DocumentationCS\.
				// The help should be compiled into a chm before being used, (use build.bat)
				//- HTML Help Workshop is required to perform this,
				// and can be downloaded from Microsoft. The path to the help compiler (hhc.exe) 
				// may need adjusting in build.bat
				
				// ...

				////////////////////////////////////////////////////////////////////				
				// The Xml can be extracted from the class using one of 3 methods; //
				////////////////////////////////////////////////////////////////////
				
				// This method will extract the xml into a string. The string is always encoded 
				// using Unicode, there a number of options allowing the headers, 
				// end of line & indenting to be set.
				string strXml = elm.ToXml();
				Console.WriteLine(strXml);
				
				// This method will extract the xml into a file. This method provides options
				// for changing the encoding (UTF-8, UTF-16) as well as headers, 
				// end of line and indenting.
				elm.ToXmlFile(filename + ".testouput.xml");
				
				// This method will extract the xml into a stream. This method provides options
				// for changing the encoding (UTF-8, UTF-16) as well as headers, 
				// end of line and indenting.
				// This method is useful when a specific encoding is required (typically
				// UTF-8), in order to transmit it over an 8-bit connection, smtp etc
				// without the need to write the xml to file first.
				System.IO.Stream stmXml = elm.ToXmlStream();

			}
			catch (Exception e)
			{
				DisplayError(e);
			}
		}
		#endregion
		#region SimpleTestSitesResponse - Demo for documents with a root <sitesResponse>
		// Shows a simple example of how the class SitesResponse
		// can be used. This class can be used to load documents whose 
		// root (document) element is <sitesResponse>.
		private void SimpleTestSitesResponse(string filename)
		{
			try
			{
				// create an instance of the class to load the XML file into
				tns.SitesResponse elm = new tns.SitesResponse();
				
				// load the xml from a file into the object (the root element in the
				// xml document must be <sitesResponse>.
				elm.FromXmlFile(filename);

				// This will open up a viewer, allowing you to navigate the classes
				// that have been generated. 
				// Note the veiwer can be used to modify properties, and provides a listing of
				// the code required to create the document it is displaying.
				SimpleViewer sv = new SimpleViewer(elm);
				sv.ShowDialog();

				// You can then add code to navigate the data held in the class.
				// When navigating this object model you should refer to the documentation
				// generated in the directory:
				// C:\dev2005\BaseWofService\WofSchemas\cuahsiTimeSeries_v1_0.xsd.Output\DocumentationCS\.
				// The help should be compiled into a chm before being used, (use build.bat)
				//- HTML Help Workshop is required to perform this,
				// and can be downloaded from Microsoft. The path to the help compiler (hhc.exe) 
				// may need adjusting in build.bat
				
				// ...

				////////////////////////////////////////////////////////////////////				
				// The Xml can be extracted from the class using one of 3 methods; //
				////////////////////////////////////////////////////////////////////
				
				// This method will extract the xml into a string. The string is always encoded 
				// using Unicode, there a number of options allowing the headers, 
				// end of line & indenting to be set.
				string strXml = elm.ToXml();
				Console.WriteLine(strXml);
				
				// This method will extract the xml into a file. This method provides options
				// for changing the encoding (UTF-8, UTF-16) as well as headers, 
				// end of line and indenting.
				elm.ToXmlFile(filename + ".testouput.xml");
				
				// This method will extract the xml into a stream. This method provides options
				// for changing the encoding (UTF-8, UTF-16) as well as headers, 
				// end of line and indenting.
				// This method is useful when a specific encoding is required (typically
				// UTF-8), in order to transmit it over an 8-bit connection, smtp etc
				// without the need to write the xml to file first.
				System.IO.Stream stmXml = elm.ToXmlStream();

			}
			catch (Exception e)
			{
				DisplayError(e);
			}
		}
		#endregion
		#region SimpleTestTimeSeriesResponse - Demo for documents with a root <timeSeriesResponse>
		// Shows a simple example of how the class TimeSeriesResponse
		// can be used. This class can be used to load documents whose 
		// root (document) element is <timeSeriesResponse>.
		private void SimpleTestTimeSeriesResponse(string filename)
		{
			try
			{
				// create an instance of the class to load the XML file into
				tns.TimeSeriesResponse elm = new tns.TimeSeriesResponse();
				
				// load the xml from a file into the object (the root element in the
				// xml document must be <timeSeriesResponse>.
				elm.FromXmlFile(filename);

				// This will open up a viewer, allowing you to navigate the classes
				// that have been generated. 
				// Note the veiwer can be used to modify properties, and provides a listing of
				// the code required to create the document it is displaying.
				SimpleViewer sv = new SimpleViewer(elm);
				sv.ShowDialog();

				// You can then add code to navigate the data held in the class.
				// When navigating this object model you should refer to the documentation
				// generated in the directory:
				// C:\dev2005\BaseWofService\WofSchemas\cuahsiTimeSeries_v1_0.xsd.Output\DocumentationCS\.
				// The help should be compiled into a chm before being used, (use build.bat)
				//- HTML Help Workshop is required to perform this,
				// and can be downloaded from Microsoft. The path to the help compiler (hhc.exe) 
				// may need adjusting in build.bat
				
				// ...

				////////////////////////////////////////////////////////////////////				
				// The Xml can be extracted from the class using one of 3 methods; //
				////////////////////////////////////////////////////////////////////
				
				// This method will extract the xml into a string. The string is always encoded 
				// using Unicode, there a number of options allowing the headers, 
				// end of line & indenting to be set.
				string strXml = elm.ToXml();
				Console.WriteLine(strXml);
				
				// This method will extract the xml into a file. This method provides options
				// for changing the encoding (UTF-8, UTF-16) as well as headers, 
				// end of line and indenting.
				elm.ToXmlFile(filename + ".testouput.xml");
				
				// This method will extract the xml into a stream. This method provides options
				// for changing the encoding (UTF-8, UTF-16) as well as headers, 
				// end of line and indenting.
				// This method is useful when a specific encoding is required (typically
				// UTF-8), in order to transmit it over an 8-bit connection, smtp etc
				// without the need to write the xml to file first.
				System.IO.Stream stmXml = elm.ToXmlStream();

			}
			catch (Exception e)
			{
				DisplayError(e);
			}
		}
		#endregion
		#region SimpleTestTimeZoneInfo - Demo for documents with a root <timeZoneInfo>
		// Shows a simple example of how the class TimeZoneInfo
		// can be used. This class can be used to load documents whose 
		// root (document) element is <timeZoneInfo>.
		private void SimpleTestTimeZoneInfo(string filename)
		{
			try
			{
				// create an instance of the class to load the XML file into
				tns.TimeZoneInfo elm = new tns.TimeZoneInfo();
				
				// load the xml from a file into the object (the root element in the
				// xml document must be <timeZoneInfo>.
				elm.FromXmlFile(filename);

				// This will open up a viewer, allowing you to navigate the classes
				// that have been generated. 
				// Note the veiwer can be used to modify properties, and provides a listing of
				// the code required to create the document it is displaying.
				SimpleViewer sv = new SimpleViewer(elm);
				sv.ShowDialog();

				// You can then add code to navigate the data held in the class.
				// When navigating this object model you should refer to the documentation
				// generated in the directory:
				// C:\dev2005\BaseWofService\WofSchemas\cuahsiTimeSeries_v1_0.xsd.Output\DocumentationCS\.
				// The help should be compiled into a chm before being used, (use build.bat)
				//- HTML Help Workshop is required to perform this,
				// and can be downloaded from Microsoft. The path to the help compiler (hhc.exe) 
				// may need adjusting in build.bat
				
				// ...

				////////////////////////////////////////////////////////////////////				
				// The Xml can be extracted from the class using one of 3 methods; //
				////////////////////////////////////////////////////////////////////
				
				// This method will extract the xml into a string. The string is always encoded 
				// using Unicode, there a number of options allowing the headers, 
				// end of line & indenting to be set.
				string strXml = elm.ToXml();
				Console.WriteLine(strXml);
				
				// This method will extract the xml into a file. This method provides options
				// for changing the encoding (UTF-8, UTF-16) as well as headers, 
				// end of line and indenting.
				elm.ToXmlFile(filename + ".testouput.xml");
				
				// This method will extract the xml into a stream. This method provides options
				// for changing the encoding (UTF-8, UTF-16) as well as headers, 
				// end of line and indenting.
				// This method is useful when a specific encoding is required (typically
				// UTF-8), in order to transmit it over an 8-bit connection, smtp etc
				// without the need to write the xml to file first.
				System.IO.Stream stmXml = elm.ToXmlStream();

			}
			catch (Exception e)
			{
				DisplayError(e);
			}
		}
		#endregion
		#region SimpleTestUnits - Demo for documents with a root <units>
		// Shows a simple example of how the class Units
		// can be used. This class can be used to load documents whose 
		// root (document) element is <units>.
		private void SimpleTestUnits(string filename)
		{
			try
			{
				// create an instance of the class to load the XML file into
				tns.Units elm = new tns.Units();
				
				// load the xml from a file into the object (the root element in the
				// xml document must be <units>.
				elm.FromXmlFile(filename);

				// This will open up a viewer, allowing you to navigate the classes
				// that have been generated. 
				// Note the veiwer can be used to modify properties, and provides a listing of
				// the code required to create the document it is displaying.
				SimpleViewer sv = new SimpleViewer(elm);
				sv.ShowDialog();

				// You can then add code to navigate the data held in the class.
				// When navigating this object model you should refer to the documentation
				// generated in the directory:
				// C:\dev2005\BaseWofService\WofSchemas\cuahsiTimeSeries_v1_0.xsd.Output\DocumentationCS\.
				// The help should be compiled into a chm before being used, (use build.bat)
				//- HTML Help Workshop is required to perform this,
				// and can be downloaded from Microsoft. The path to the help compiler (hhc.exe) 
				// may need adjusting in build.bat
				
				// ...

				////////////////////////////////////////////////////////////////////				
				// The Xml can be extracted from the class using one of 3 methods; //
				////////////////////////////////////////////////////////////////////
				
				// This method will extract the xml into a string. The string is always encoded 
				// using Unicode, there a number of options allowing the headers, 
				// end of line & indenting to be set.
				string strXml = elm.ToXml();
				Console.WriteLine(strXml);
				
				// This method will extract the xml into a file. This method provides options
				// for changing the encoding (UTF-8, UTF-16) as well as headers, 
				// end of line and indenting.
				elm.ToXmlFile(filename + ".testouput.xml");
				
				// This method will extract the xml into a stream. This method provides options
				// for changing the encoding (UTF-8, UTF-16) as well as headers, 
				// end of line and indenting.
				// This method is useful when a specific encoding is required (typically
				// UTF-8), in order to transmit it over an 8-bit connection, smtp etc
				// without the need to write the xml to file first.
				System.IO.Stream stmXml = elm.ToXmlStream();

			}
			catch (Exception e)
			{
				DisplayError(e);
			}
		}
		#endregion
		#region SimpleTestVariableCode - Demo for documents with a root <variableCode>
		// Shows a simple example of how the class VariableCode
		// can be used. This class can be used to load documents whose 
		// root (document) element is <variableCode>.
		private void SimpleTestVariableCode(string filename)
		{
			try
			{
				// create an instance of the class to load the XML file into
				tns.VariableCode elm = new tns.VariableCode();
				
				// load the xml from a file into the object (the root element in the
				// xml document must be <variableCode>.
				elm.FromXmlFile(filename);

				// This will open up a viewer, allowing you to navigate the classes
				// that have been generated. 
				// Note the veiwer can be used to modify properties, and provides a listing of
				// the code required to create the document it is displaying.
				SimpleViewer sv = new SimpleViewer(elm);
				sv.ShowDialog();

				// You can then add code to navigate the data held in the class.
				// When navigating this object model you should refer to the documentation
				// generated in the directory:
				// C:\dev2005\BaseWofService\WofSchemas\cuahsiTimeSeries_v1_0.xsd.Output\DocumentationCS\.
				// The help should be compiled into a chm before being used, (use build.bat)
				//- HTML Help Workshop is required to perform this,
				// and can be downloaded from Microsoft. The path to the help compiler (hhc.exe) 
				// may need adjusting in build.bat
				
				// ...

				////////////////////////////////////////////////////////////////////				
				// The Xml can be extracted from the class using one of 3 methods; //
				////////////////////////////////////////////////////////////////////
				
				// This method will extract the xml into a string. The string is always encoded 
				// using Unicode, there a number of options allowing the headers, 
				// end of line & indenting to be set.
				string strXml = elm.ToXml();
				Console.WriteLine(strXml);
				
				// This method will extract the xml into a file. This method provides options
				// for changing the encoding (UTF-8, UTF-16) as well as headers, 
				// end of line and indenting.
				elm.ToXmlFile(filename + ".testouput.xml");
				
				// This method will extract the xml into a stream. This method provides options
				// for changing the encoding (UTF-8, UTF-16) as well as headers, 
				// end of line and indenting.
				// This method is useful when a specific encoding is required (typically
				// UTF-8), in order to transmit it over an 8-bit connection, smtp etc
				// without the need to write the xml to file first.
				System.IO.Stream stmXml = elm.ToXmlStream();

			}
			catch (Exception e)
			{
				DisplayError(e);
			}
		}
		#endregion
		#region SimpleTestVariables - Demo for documents with a root <variables>
		// Shows a simple example of how the class Variables
		// can be used. This class can be used to load documents whose 
		// root (document) element is <variables>.
		private void SimpleTestVariables(string filename)
		{
			try
			{
				// create an instance of the class to load the XML file into
				tns.Variables elm = new tns.Variables();
				
				// load the xml from a file into the object (the root element in the
				// xml document must be <variables>.
				elm.FromXmlFile(filename);

				// This will open up a viewer, allowing you to navigate the classes
				// that have been generated. 
				// Note the veiwer can be used to modify properties, and provides a listing of
				// the code required to create the document it is displaying.
				SimpleViewer sv = new SimpleViewer(elm);
				sv.ShowDialog();

				// You can then add code to navigate the data held in the class.
				// When navigating this object model you should refer to the documentation
				// generated in the directory:
				// C:\dev2005\BaseWofService\WofSchemas\cuahsiTimeSeries_v1_0.xsd.Output\DocumentationCS\.
				// The help should be compiled into a chm before being used, (use build.bat)
				//- HTML Help Workshop is required to perform this,
				// and can be downloaded from Microsoft. The path to the help compiler (hhc.exe) 
				// may need adjusting in build.bat
				
				// ...

				////////////////////////////////////////////////////////////////////				
				// The Xml can be extracted from the class using one of 3 methods; //
				////////////////////////////////////////////////////////////////////
				
				// This method will extract the xml into a string. The string is always encoded 
				// using Unicode, there a number of options allowing the headers, 
				// end of line & indenting to be set.
				string strXml = elm.ToXml();
				Console.WriteLine(strXml);
				
				// This method will extract the xml into a file. This method provides options
				// for changing the encoding (UTF-8, UTF-16) as well as headers, 
				// end of line and indenting.
				elm.ToXmlFile(filename + ".testouput.xml");
				
				// This method will extract the xml into a stream. This method provides options
				// for changing the encoding (UTF-8, UTF-16) as well as headers, 
				// end of line and indenting.
				// This method is useful when a specific encoding is required (typically
				// UTF-8), in order to transmit it over an 8-bit connection, smtp etc
				// without the need to write the xml to file first.
				System.IO.Stream stmXml = elm.ToXmlStream();

			}
			catch (Exception e)
			{
				DisplayError(e);
			}
		}
		#endregion
		#region SimpleTestVariablesResponse - Demo for documents with a root <variablesResponse>
		// Shows a simple example of how the class VariablesResponse
		// can be used. This class can be used to load documents whose 
		// root (document) element is <variablesResponse>.
		private void SimpleTestVariablesResponse(string filename)
		{
			try
			{
				// create an instance of the class to load the XML file into
				tns.VariablesResponse elm = new tns.VariablesResponse();
				
				// load the xml from a file into the object (the root element in the
				// xml document must be <variablesResponse>.
				elm.FromXmlFile(filename);

				// This will open up a viewer, allowing you to navigate the classes
				// that have been generated. 
				// Note the veiwer can be used to modify properties, and provides a listing of
				// the code required to create the document it is displaying.
				SimpleViewer sv = new SimpleViewer(elm);
				sv.ShowDialog();

				// You can then add code to navigate the data held in the class.
				// When navigating this object model you should refer to the documentation
				// generated in the directory:
				// C:\dev2005\BaseWofService\WofSchemas\cuahsiTimeSeries_v1_0.xsd.Output\DocumentationCS\.
				// The help should be compiled into a chm before being used, (use build.bat)
				//- HTML Help Workshop is required to perform this,
				// and can be downloaded from Microsoft. The path to the help compiler (hhc.exe) 
				// may need adjusting in build.bat
				
				// ...

				////////////////////////////////////////////////////////////////////				
				// The Xml can be extracted from the class using one of 3 methods; //
				////////////////////////////////////////////////////////////////////
				
				// This method will extract the xml into a string. The string is always encoded 
				// using Unicode, there a number of options allowing the headers, 
				// end of line & indenting to be set.
				string strXml = elm.ToXml();
				Console.WriteLine(strXml);
				
				// This method will extract the xml into a file. This method provides options
				// for changing the encoding (UTF-8, UTF-16) as well as headers, 
				// end of line and indenting.
				elm.ToXmlFile(filename + ".testouput.xml");
				
				// This method will extract the xml into a stream. This method provides options
				// for changing the encoding (UTF-8, UTF-16) as well as headers, 
				// end of line and indenting.
				// This method is useful when a specific encoding is required (typically
				// UTF-8), in order to transmit it over an 8-bit connection, smtp etc
				// without the need to write the xml to file first.
				System.IO.Stream stmXml = elm.ToXmlStream();

			}
			catch (Exception e)
			{
				DisplayError(e);
			}
		}
		#endregion

		#region SimpleTestLoadAnyXmlDocument
		// Shows a generic way to load up an XML document.
		private void SimpleTestLoadAnyXmlDocument(string filename)
		{
			try
			{
				// load the xml from a file into the object (the root element in the
				// xml document must be <ElmBaseElement>.
				LiquidTechnologies.Runtime.Net20.XmlObjectBase elm = cuahsiTimeSeries_v1_0Lib.ClassFactory.FromXmlFile(filename);

				// This will open up a viewer, allowing you to navigate the classes
				// that have been generated. 
				// Note the veiwer can be used to modify properties, and provides a listing of
				// the code required to create the document it is displaying.
				SimpleViewer sv = new SimpleViewer(elm);
				sv.ShowDialog();

				// You can then add code to navigate the data held in the class.
				// When navigating this object model you should refer to the documentation
				// generated in the directory:
				// C:\dev2005\BaseWofService\WofSchemas\cuahsiTimeSeries_v1_0.xsd.Output\DocumentationCS\.
				// The help should be compiled into a chm before being used, (use build.bat)
				//- HTML Help Workshop is required to perform this,
				// and can be downloaded from Microsoft. The path to the help compiler (hhc.exe) 
				// may need adjusting in build.bat
				
				// ...

				////////////////////////////////////////////////////////////////////				
				// The Xml can be extracted from the class using one of 3 methods; //
				////////////////////////////////////////////////////////////////////
				
				// This method will extract the xml into a string. The string is always encoded 
				// using Unicode, there a number of options allowing the headers, 
				// end of line & indenting to be set.
				string strXml = elm.ToXml();
				Console.WriteLine(strXml);
				
				// This method will extract the xml into a file. This method provides options
				// for changing the encoding (UTF-8, UTF-16) as well as headers, 
				// end of line and indenting.
				elm.ToXmlFile(filename + ".testouput.xml");
				
				// This method will extract the xml into a stream. This method provides options
				// for changing the encoding (UTF-8, UTF-16) as well as headers, 
				// end of line and indenting.
				// This method is useful when a specific encoding is required (typically
				// UTF-8), in order to transmit it over an 8-bit connection, smtp etc
				// without the need to write the xml to file first.
				System.IO.Stream stmXml = elm.ToXmlStream();

			}
			catch (Exception e)
			{
				DisplayError(e);
			}
		}
		#endregion
		#endregion

		#region Error Handler
		private void DisplayError(Exception ex)
		{
			string errText = "Error - \n";
			// Note : exceptions are likely to contain inner exceptions
			// that provide further detail about the error.
			while (ex != null)
			{
				errText += ex.Message + "\n";
				ex = ex.InnerException;
			}
			MessageBox.Show(this,  errText, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error); 
		}
		#endregion

		#region Basic Form Plumbing
		#region SampleApp - Constructor
		public SampleApp()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}
		#endregion 

		#region Dispose
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		#endregion

		#region Main
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new SampleApp());
		}
		#endregion 
	
		#region SampleApp_Load - Populates the list box
		private void SampleApp_Load(object sender, System.EventArgs e)
		{
			lblInfo.Text = "All Sample XML Files that you specified in the Wizard will be shown here, see btnLoad_Click(...) method in SampleApp.cs.\n\nSelect the file you want to load into the simple viewer and click the 'Load Selected XML File' button:";
			lstFiles.Items.AddRange(new object[] {
													"Browse for a File to Load"
													});
            lstFiles.SelectedIndex = 0;
		}
		#endregion

		#region btnClose_Click
		private void btnClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
		#endregion
		#endregion

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnLoad = new System.Windows.Forms.Button();
			this.btnClose = new System.Windows.Forms.Button();
			this.lblInfo = new System.Windows.Forms.Label();
			this.lstFiles = new System.Windows.Forms.ListBox();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.SuspendLayout();
			// 
			// btnLoad
			// 
			this.btnLoad.Location = new System.Drawing.Point(344, 96);
			this.btnLoad.Name = "btnLoad";
			this.btnLoad.Size = new System.Drawing.Size(96, 48);
			this.btnLoad.TabIndex = 2;
			this.btnLoad.Text = "Load Selected XML File";
			this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
			// 
			// btnClose
			// 
			this.btnClose.Location = new System.Drawing.Point(344, 216);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(96, 24);
			this.btnClose.TabIndex = 3;
			this.btnClose.Text = "Close";
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// lblInfo
			// 
			this.lblInfo.Location = new System.Drawing.Point(16, 16);
			this.lblInfo.Name = "lblInfo";
			this.lblInfo.Size = new System.Drawing.Size(424, 72);
			this.lblInfo.TabIndex = 0;
			// 
			// lstFiles
			// 
			this.lstFiles.HorizontalScrollbar = true;
			this.lstFiles.Location = new System.Drawing.Point(8, 96);
			this.lstFiles.Name = "lstFiles";
			this.lstFiles.Size = new System.Drawing.Size(328, 134);
			this.lstFiles.TabIndex = 1;
			this.lstFiles.DoubleClick += new System.EventHandler(this.btnLoad_Click);
			// 
			// openFileDialog
			// 
			this.openFileDialog.DefaultExt = "xml";
			this.openFileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
			// 
			// SampleApp
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(448, 246);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.lstFiles,
																		  this.lblInfo,
																		  this.btnClose,
																		  this.btnLoad});
			this.Name = "SampleApp";
			this.Text = "Liquid XML Sample";
			this.Load += new System.EventHandler(this.SampleApp_Load);
			this.ResumeLayout(false);

		}
		#endregion
	}
}

