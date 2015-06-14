<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AProject.ascx.cs" Inherits="IndividueleOpdracht.AProject" %>
<%@ Import Namespace="System.Web.DynamicData" %>
<%@ Import Namespace="System.Web.UI" %>
<%@ Import Namespace="System.Web.UI.WebControls" %>
<%@ Import Namespace="System.Web.UI.WebControls" %>
<%@ Import Namespace="System.Web.UI.WebControls.Expressions" %>
<%@ Import Namespace="System.Web.UI.WebControls.WebParts" %>

<div class="panel panel-primary">
    <div class="panel-body">
        <h3>
        <asp:Literal runat="server" ID="LiteralNaam"></asp:Literal><br/>
    </h3>
    <asp:Literal runat="server" ID="LiteralBeschrijving"></asp:Literal><br/><br/><br/>

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
        <p>
            <asp:Literal runat="server" ID="LiteralBackings"></asp:Literal>
        </p>
    </div>
    </div>
    
</div>
