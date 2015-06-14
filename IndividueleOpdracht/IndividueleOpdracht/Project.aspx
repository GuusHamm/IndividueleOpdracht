<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Project.aspx.cs" Inherits="IndividueleOpdracht.Project" %>
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
        <a href="CreateAProject.aspx" class="btn btn-info btn-fab">+ </a>
    </div>
    <div class="panel panel-default col-md-12">
        <div class="panel-body">
            <asp:ListView ID="ProjectView" runat="server" OnItemDataBound="ProjectView_OnItemDataBound"  OnItemCommand="ProjectView_OnItemCommand" ItemType="IndividueleOpdracht.Models.ProjectModel">
                <ItemTemplate>
                    <div class="well">
                        <h3>
                            <asp:Literal runat="server" ID="LiteralNaam"></asp:Literal>
                        </h3>
                        <asp:Literal runat="server" ID="LiteralBeschrijving"></asp:Literal><br/>
                        <asp:LinkButton ID="LearnMoreButton" runat="server" OnClick="LearnMoreButton_OnClick" CssClass="btn btn-info" >Learn more</asp:LinkButton>

                        <div class="well">
                            <h5>
                                <a href="%">
                                    <asp:Literal runat="server" ID="LiteralCreator"></asp:Literal>
                                </a>
                            </h5>
                            <h5>
                                <a href="%">
                                    <asp:Literal runat="server" ID="LiteralCategorie"></asp:Literal>
                                </a>
                            </h5>
                            <p>
                                <asp:Literal runat="server" ID="LiteralViews"></asp:Literal>
                            </p>
                            <p>
                                <asp:Literal runat="server" ID="LiteralPercentageComplete"></asp:Literal>
                            </p>

                        </div>
                    </div>

                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>
    <asp:Panel ID="Panel1" runat="server" Height="593px">
    </asp:Panel>
</asp:Content>
