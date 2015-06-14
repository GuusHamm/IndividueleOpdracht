<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="IndividueleOpdracht._Default" %>
<%@ Import Namespace="System.Web.DynamicData" %>
<%@ Import Namespace="System.Web.UI" %>
<%@ Import Namespace="System.Web.UI.WebControls" %>
<%@ Import Namespace="System.Web.UI.WebControls" %>
<%@ Import Namespace="System.Web.UI.WebControls.Expressions" %>
<%@ Import Namespace="System.Web.UI.WebControls.WebParts" %>
<%@ Register TagPrefix="uc1" TagName="aproject" Src="~/AProject.ascx" %>
<%@ MasterType virtualpath="~/Site.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="panel col-md-12 panel-default">
        <div class="panel-body">
            <h1>Populair Projects</h1>
        <div class="col-md-9">
            <asp:DropDownList ID="ProjectSelectionDD" runat="server" CssClass="form-control">
            </asp:DropDownList>
        </div>
        <div class="col-md-3">
            <asp:Button ID="BtnGotoProject" runat="server" OnClick="BtnGotoProject_OnClick" Text="Goto Project" CssClass="btn btn-default"/>
        </div>
        <asp:ListView ID="ProjectView" runat="server" OnItemDataBound="ProjectView_OnItemDataBound" ItemType="IndividueleOpdracht.Models.ProjectModel">
                <ItemTemplate>
                    <div class="col-md-4">
                        <uc1:aproject runat="server" ID="AProject" />
                    </div>
                </ItemTemplate>
            </asp:ListView>
        </div>
        
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Getting started</h2>
            <p>
                ASP.NET Web Forms lets you build dynamic websites using a familiar drag-and-drop, event-driven model.
            A design surface and hundreds of controls and components let you rapidly build sophisticated, powerful UI-driven sites with data access.
            </p>
            <p>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301948">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Get more libraries</h2>
            <p>
                NuGet is a free Visual Studio extension that makes it easy to add, remove, and update libraries and tools in Visual Studio projects.
            </p>
            <p>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301949">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Web Hosting</h2>
            <p>
                You can easily find a web hosting company that offers the right mix of features and price for your applications.
            </p>
            <p>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301950">Learn more &raquo;</a>
            </p>
        </div>
    </div>

</asp:Content>
