<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Project.aspx.cs" Inherits="IndividueleOpdracht.Project" %>

<%@ Register TagPrefix="uc1" TagName="aproject" Src="~/AProject.ascx" %>
<%@ Import Namespace="System.Web.DynamicData" %>
<%@ Import Namespace="System.Web.UI" %>
<%@ Import Namespace="System.Web.UI.WebControls" %>
<%@ Import Namespace="System.Web.UI.WebControls" %>
<%@ Import Namespace="System.Web.UI.WebControls.Expressions" %>
<%@ Import Namespace="System.Web.UI.WebControls.WebParts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>Projects
        </h1>
        <div class="col-md-6">
            <asp:DropDownList ID="ProjectSelectionDD" runat="server" CssClass="form-control">
            </asp:DropDownList>
        </div>
        <div class="col-md-4">
            <asp:Button ID="BtnGotoProject" runat="server" OnClick="BtnGotoProject_OnClick" Text="Goto Project" CssClass="btn btn-default" />
        </div>
    </div>
    <div class="panel panel-default col-md-12">
        <div class="panel-body">
            <asp:ListView ID="ProjectView" runat="server" OnItemDataBound="ProjectView_OnItemDataBound" OnItemCommand="ProjectView_OnItemCommand" ItemType="IndividueleOpdracht.Models.ProjectModel">
                <ItemTemplate>
                    <div class="col-md-6">
                        <uc1:aproject runat="server" ID="AProject" />
                    </div>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>
    <asp:Panel ID="Panel1" runat="server" Height="593px">
    </asp:Panel>
</asp:Content>
