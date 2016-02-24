<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="DailyValues.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <style type="text/css">
    
		BODY { color: #000000; background-color: white; font-family: Verdana; margin-left: 0px; margin-top: 0px; }
		#content { margin-left: 0px; font-size: .70em; padding-bottom: 2em; }
		A:link { color: #336699; font-weight: bold; text-decoration: underline; }
		A:visited { color: #6699cc; font-weight: bold; text-decoration: underline; }
		A:active { color: #336699; font-weight: bold; text-decoration: underline; }
		A:hover { color: cc3300; font-weight: bold; text-decoration: underline; }
		P { color: #000000; margin-top: 0px; margin-bottom: 12px; font-family: Verdana; }
		pre { background-color: #e5e5cc; padding: 5px; font-family: Courier New; font-size: x-small; margin-top: 05px; border: 1px #f0f0e0 solid; }
		td { color: #000000; font-family: Verdana; font-size: .7em; }
		h2 { font-size: 1.5em; font-weight: bold; margin-top: 25px; margin-bottom: 10px; border-top: 1px solid #003366; margin-left: 015px; color: #003366; }
		h3 { font-size: 1.1em; color: #000000; margin-left: 15px; margin-top: 10px; margin-bottom: 10px; }
		ul { margin-top: 10px; margin-left: 20px; }
		ol { margin-top: 10px; margin-left: 20px; }
		li { margin-top: 10px; color: #000000; margin-left: 20px; }
		font.value { color: darkblue; font: bold; }
		font.key { color: darkgreen; font: bold; }
		font.error { color: darkred; font: bold; }
		.heading1 { color: #ffffff; font-family: Tahoma; font-size: 26px; font-weight: normal; background-color: #003366; margin-top: 0px; margin-bottom: 0px; margin-left: 0px; padding-top: 10px; padding-bottom: 3px; padding-left: 15px; width: 100%; }
		.button { background-color: #dcdcdc; font-family: Verdana; font-size: 1em; border-top: #cccccc 1px solid; border-bottom: #666666 1px solid; border-left: #cccccc 1px solid; border-right: #666666 1px solid; }
		.frmheader { color: #000000; background: #dcdcdc; font-family: Verdana; font-size: .7em; font-weight: normal; border-bottom: 1px solid #dcdcdc; padding-top: 2px; padding-bottom: 2px; }
		.frmtext { font-family: Verdana; font-size: .7em; margin-top: 8px; margin-bottom: 0px; margin-left: 32px; }
		.frmInput { font-family: Verdana; font-size: 1em; }
		.intro { margin-left: 015px; }
           
    </style>
    <title>CUAHSI Web Services for Observations Databases </title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="content">
 
      <div class="heading1">  <asp:Label CssClass="heading1" ID="PageTitle" runat="server" Text="Web Service"></asp:Label>
        </div>
         
         <span>
          
      </span>
       <h2>
          CUAHSI Web Services for USGS NWIS Daily Values Help Pages  
        </h2>
       <div class="intro">
            This web page describes <a href="http://www.cuahsi.org/his/webservices.html" target="_blank">
                <span style="color: #0000ff">CUAHSI WaterOneFlow web services</span></a> developed
            to provide access to data from the <a href="http://waterdata.usgs.gov/"
                target="_blank"><span style="color: #0000ff">USGS NWIS Web services</span></a>
            at the USGS NWIS Web services. <strong>These are <asp:Label ID="lbl_serivceLevel" runat="server" Text="<%$ AppSettings:serviceLevel %>"></asp:Label> prototype web services
                subject to change and should not be relied upon to be static or persistent.</strong>
  
      </div> 
      <ul>
       <li></li>
          </ul> 
      <span>

          <h2>
              Service Description.</h2>
          <div class="intro">
              The service is found at:<asp:HyperLink ID="serviceLocation" runat="server" NavigateUrl="~/DailyValues.asmx">HyperLink</asp:HyperLink>
              </div>
          <div class="intro">
              The following operations are supported.  For a formal definition, please review the <a href="DailyValues.asmx?WSDL">Service Description</a>. 
          </div>
          
          
              <ul>
            
              <li>
                  <asp:HyperLink ID="linkGetSiteInfo" runat="server" NavigateUrl="~/DailyValues.asmx?op=GetSiteInfo">GetSiteInfo</asp:HyperLink>  
                
                <span>
                  <br>Given a site number, this method returns the site's metadata. Send the site code in this format: '<asp:Label ID="lblNet1" runat="server" Text="<%$ AppSettings:network %>"></asp:Label>:SiteCode'
                    or to retrieve by internal database identifier, siteId, use 'BYID:siteId'</span><p>
            
              </p>
              </li>
              <li>&nbsp;<asp:HyperLink ID="HyperLinkGetSiteInfoObject" runat="server" NavigateUrl="~/DailyValues.asmx?op=GetSiteInfoObject">GetSiteInfoObject</asp:HyperLink>
                <span>
                  <br>Given a site number, this method returns the site's metadata. Send the site code in this format: '<asp:Label ID="Label1" runat="server" Text="<%$ AppSettings:network %>"></asp:Label>:SiteCode'
                    or to retrieve by internal database identifier, siteId, use 'BYID:siteId'</span><p>
            
              </p>
              </li>
 

              <li>
                <a href="http://localhost:4536/genericODws/cuahsi_1_0.asmx?op=GetVariableInfo"></a>
                <asp:HyperLink ID="HyperLinkGetVariableInfo" runat="server" NavigateUrl="~/DailyValues.asmx?op=GetVariableInfo">GetVariableInfo</asp:HyperLink>
                <span>
                  <br>Given a variable code, this method returns the variable's name. Pass in the variable in this format:'<asp:Label ID="Label8" runat="server" Text="<%$ AppSettings:vocabulary %>"></asp:Label>:VariableCode'
                    or to retrieve by internal database identifier, variableId, use 'BYID:variableId'</span><p>
            
              </p>
              </li>
              <li>
                <a href="http://localhost:4536/genericODws/cuahsi_1_0.asmx?op=GetVariableInfoObject"></a>
                <asp:HyperLink ID="HyperLinkGetVariableInfoObject" runat="server" NavigateUrl="~/DailyValues.asmx?op=GetVariableInfoObject">GetVariableInfoObject</asp:HyperLink>
                <span>
                  <br>Given a variable code, this method returns the variable's siteName. Pass in the variable in this format: '<asp:Label ID="Label9" runat="server" Text="<%$ AppSettings:vocabulary %>"></asp:Label>:VariableCode'
                    or to retrieve by internal database identifier, variableId, use 'BYID:variableId'</span><p>
            
              </p>
              </li>
              
                <li>
                <asp:HyperLink ID="HyperLinkGetValues" runat="server" NavigateUrl="~/DailyValues.asmx?op=GetValues">GetValues</asp:HyperLink>
                <span>
                  <br>Given
a site number, a variable, a start date, and an end date, this method
returns a time series. Pass in the sitecode and variable in this
format: '<asp:Label ID="Label4"
                        runat="server" Text="<%$ AppSettings:network %>"></asp:Label>:SiteCode' and
                    '<asp:Label ID="Label5" runat="server" Text="<%$ AppSettings:vocabulary %>"></asp:Label>:VariableCode'
                </span>
              <p>
            
              </p>
              </li>
              <li>&nbsp;<asp:HyperLink ID="HyperLinkGetValuesObject" runat="server" NavigateUrl="~/cuahsi_1_0.asmx?op=GetValuesObject">GetValuesObject</asp:HyperLink>
                <span>
                  <br>Given
a site number, a variable, a start date, and an end date, this method
returns a time series. Pass in the sitecode and variable in this
format: '<asp:Label ID="Label6"
                        runat="server" Text="<%$ AppSettings:network %>"></asp:Label>:SiteCode' and
                    '<asp:Label ID="Label7" runat="server" Text="<%$ AppSettings:vocabulary %>"></asp:Label>:VariableCode<strong><span
                        style="color: #336699; text-decoration: underline"></span></strong>' </span>
              <p>
            
              </p>
              </li>
              
 
              </ul>
            
      </span>

      
      

    <span>
        
    </span>
        <br />
        <h2>
        
        Web Service Description:</h2>
        <div class="intro">
        Status Level:
        <asp:Label ID="lblServiceLevel" runat="server" Text="<%$ AppSettings:serviceLevel %>"
            Width="90px"></asp:Label><br />
        <br />
        Network Name:
        <asp:Label ID="lblNetworkName" runat="server" Text="<%$ AppSettings:network %>" Width="90px"></asp:Label><br />
        Vocabulary Name:
        <asp:Label ID="lblVocabularyName" runat="server" Text="<%$ AppSettings:vocabulary %>" Width="93px"></asp:Label><br />
        <br />
        </div>
        <h2 style="visibility: hidden">
        Configured Properties:</h2>
        <div class="intro" style="visibility: hidden">
        GetSiteInfo from OD:<asp:Label ID="Label10" runat="server" Text="<%$ AppSettings:UseODForInformation %>"
            Width="73px"></asp:Label><br />
        GetSiteInfo&nbsp; Series From OD:<asp:Label ID="Label11" runat="server" Text="<%$ AppSettings:UseODForValues %>"
            Width="73px"></asp:Label><br />
        GetValues from OD:<asp:Label ID="Label12" runat="server" Text="<%$ AppSettings:UseODForInformation %>"
            Width="79px"></asp:Label><br />
        <br />
        Software and Database Information:<br />
            Software:<asp:TextBox ID="wsversion" runat="server" Width="269px"></asp:TextBox><br />
        database version:<br />
            <br />
            <br />
       </div>
  
    </form>
</body>
</html>
