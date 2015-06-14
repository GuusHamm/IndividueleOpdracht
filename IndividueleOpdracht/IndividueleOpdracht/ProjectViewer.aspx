<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProjectViewer.aspx.cs" Inherits="IndividueleOpdracht.ProjectViewer" %>
<%@ Import Namespace="System.Web.DynamicData" %>
<%@ Import Namespace="System.Web.UI" %>
<%@ Import Namespace="System.Web.UI.WebControls" %>
<%@ Import Namespace="System.Web.UI.WebControls" %>
<%@ Import Namespace="System.Web.UI.WebControls.Expressions" %>
<%@ Import Namespace="System.Web.UI.WebControls.WebParts" %>
<%@ Register Src="~/AProject.ascx" TagPrefix="uc1" TagName="AProject" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-default col-md-12" runat="server" id="PageContents">
        <div runat="server" id="ExtraStuffDiv">
            
        </div>
        <asp:ListView ID="ProjectView" runat="server" OnItemDataBound="ProjectView_OnItemDataBound">
            <ItemTemplate>
                <uc1:aproject runat="server" id="AProject" />
            </ItemTemplate>
        </asp:ListView>
        <div class="col-md-3">
            <div class="well">
                <asp:DropDownList ID="TierDD" runat="server" CssClass="form-control">
                </asp:DropDownList>
                <asp:Button ID="BackButton" runat="server" OnClick="BackButton_OnClick" CssClass="btn btn-primary btn-block" Text="Back this project" />
                <asp:ListView ID="TierViewer" runat="server" OnItemDataBound="TierViewer_OnItemDataBound">
                    <ItemTemplate>
                        <div class="panel panel-default">
                            <div class="panel-body">
                                <h4>
                                    <asp:Literal ID="LiteralTierNaam" runat="server"></asp:Literal>

                                </h4>
                                <p><asp:Literal ID="LiteralTierReward" runat="server"></asp:Literal></p>
                                <p><asp:Literal ID="LiteralTierPrijs" runat="server"></asp:Literal></p>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:ListView>
            </div>
        </div>

        <div class="col-md-6">
            <div class="well">
                <div class="form form-horizontal">
                    <fieldset>
                        <div class="form-group">
                            <asp:TextBox ID="CommentTextBox" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ID="CommentTextBoxValidator" CssClass="label label-danger" ControlToValidate="CommentTextBox" ErrorMessage="Verplicht veld"></asp:RequiredFieldValidator>
                            <asp:Button ID="CommentButton" runat="server" OnClick="CommentButton_OnClick" Text="Place Comment" CssClass="btn btn-primary btn-block" />
                        </div>
                    </fieldset>
                </div>
                <asp:ListView ID="CommentView" runat="server" OnItemDataBound="CommentView_OnItemDataBound">
                    <ItemTemplate>

                        <div class="panel panel-default">
                            <div class="panel-body">
                                <h4>
                                    <asp:Literal runat="server" ID="CommentCreator"></asp:Literal>
                                </h4>
                                <p>
                                    <asp:Literal runat="server" ID="CommentText"></asp:Literal>
                                </p>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:ListView>
            </div>
            <div class="col-md-3">
                <div class="well">
                    <h3>Tags</h3>
                    <asp:ListView ID="ProjectTagView" runat="server" OnItemDataBound="ProjectTagView_OnItemDataBound">
                        <ItemTemplate>
                            <p>
                                <asp:Literal runat="server" ID="LiteralTag"></asp:Literal>
                            </p>
                        </ItemTemplate>
                    </asp:ListView>
                </div>
            </div>
        </div>


    </div>
</asp:Content>
