<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="IndividueleOpdracht.Registration" %>
<%@ Import Namespace="System.Web.DynamicData" %>
<%@ Import Namespace="System.Web.UI" %>
<%@ Import Namespace="System.Web.UI.WebControls" %>
<%@ Import Namespace="System.Web.UI.WebControls" %>
<%@ Import Namespace="System.Web.UI.WebControls.Expressions" %>
<%@ Import Namespace="System.Web.UI.WebControls.WebParts" %>

<%@ MasterType VirtualPath="~/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="well">
        <div class="form form-horizontal">
            <fieldset>
                <legend>Nieuwe Account Aanmaken</legend>
                <div class="form-group">
                    <label for="UsernameTB" class="col-lg-2 control-label">Gebruikersnaam</label>
                    <div class="col-lg-10">
                        <asp:TextBox ID="UsernameTB" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" CssClass="label label-danger" ControlToValidate="UsernameTB" ErrorMessage="Verplicht veld"></asp:RequiredFieldValidator>
                        </div>
                </div>
                <div class="form-group">
                    <label for="PasswordTB" class="col-lg-2 control-label">Password</label>
                    <div class="col-lg-10">
                        <asp:TextBox ID="PasswordTB" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" CssClass="label label-danger" ControlToValidate="PasswordTB" ErrorMessage="Verplicht veld"></asp:RequiredFieldValidator>
                      </div>
                </div>
                <div class="form-group">
                    <label for="NaamTB" class="col-lg-2 control-label">Naam</label>
                    <div class="col-lg-10">
                        <asp:TextBox ID="NaamTB" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" CssClass="label label-danger" ControlToValidate="NaamTB" ErrorMessage="Verplicht veld"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator runat="server" CssClass="label label-info" ErrorMessage="RegularExpressionValidator" ControlToValidate="NaamTB" ValidationExpression="\w+\s\w+"></asp:RegularExpressionValidator>
                    </div>
                </div>
                <div class="form-group">
                    <label for="MailTB" class="col-lg-2 control-label">Email adres</label>
                    <div class="col-lg-10">
                        <asp:TextBox ID="MailTB" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" CssClass="label label-danger" ControlToValidate="MailTB" ErrorMessage="Verplicht veld"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator runat="server" CssClass="label label-info" ErrorMessage="RegularExpressionValidator" ControlToValidate="MailTB" ValidationExpression="\w+@\w+.\w+"></asp:RegularExpressionValidator>

                    </div>
                </div>
                <div class="form-group">
                    <label for="LandTB" class="col-lg-2 control-label">Land</label>
                    <div class="col-lg-10">
                        <asp:TextBox ID="LandTB" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" CssClass="label label-danger" ControlToValidate="LandTB" ErrorMessage="Verplicht veld"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group">
                    <label for="TelefoonnummerTB" class="col-lg-2 control-label">Telefoonnummer</label>
                    <div class="col-lg-10">
                        <asp:TextBox ID="TelefoonnummerTB" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" CssClass="label label-danger" ControlToValidate="TelefoonnummerTB" ErrorMessage="Verplicht veld"></asp:RequiredFieldValidator>
                        <asp:CompareValidator runat="server" CssClass="label label-info" ControlToValidate="TelefoonnummerTB" Operator="DataTypeCheck" Type="Integer" ErrorMessage="Telefoonnummer moeten getallen zijn"></asp:CompareValidator>
                    </div>
                </div>
                <div class="form-group">
                    <label for="ProjectTijdNodigTextBox" class="col-lg-2 control-label">Gebruiker soort</label>
                    <div class="col-lg-10">
                        <asp:DropDownList ID="AccountTypeDD" runat="server" CssClass="form-control" OnSelectedIndexChanged="AccountType_OnSelectedIndexChanged">
                            <asp:ListItem Text="Regular" Value="Regular">
                            </asp:ListItem>
                            <asp:ListItem Text="Creator" Value="Creator">
                            </asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group">
                    <label for="BiografieTB" class="col-lg-2 control-label">Biografie</label>
                    <div class="col-lg-10">
                        <asp:TextBox ID="BiografieTB" runat="server" CssClass="disabledInput"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="BiografieTBValidator" runat="server" CssClass="label label-danger" ControlToValidate="BiografieTB" ErrorMessage="Verplicht veld" Enabled="False"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group">
                    <label for="AdresTB" class="col-lg-2 control-label">Adres</label>
                    <div class="col-lg-10">
                        <asp:TextBox ID="AdresTB" runat="server" CssClass="disabledInput"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="AdresTBValidator" runat="server" CssClass="label label-danger" ControlToValidate="AdresTB" ErrorMessage="Verplicht veld" Enabled="False"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group">
                    <label for="PostcodeTB" class="col-lg-2 control-label">Postcode</label>
                    <div class="col-lg-10">
                        <asp:TextBox ID="PostcodeTB" runat="server" CssClass="disabledInput"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="PostcodeTBValidator" runat="server" CssClass="label label-danger" ControlToValidate="AdresTB" ErrorMessage="Verplicht veld" Enabled="False"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="PostcodeTBRegex" runat="server" CssClass="label label-info" ErrorMessage="RegularExpressionValidator" ControlToValidate="MailTB" ValidationExpression="\d{4}\w{2}" Enabled="False"></asp:RegularExpressionValidator>
                    </div>
                </div>
                <div class="form-group">
                    <label for="WoonplaatsTB" class="col-lg-2 control-label">Biografie</label>
                    <div class="col-lg-10">
                        <asp:TextBox ID="WoonplaatsTB" runat="server" CssClass="disabledInput"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="WoonplaatsTBValidator" runat="server" CssClass="label label-danger" ControlToValidate="WoonplaatsTB" ErrorMessage="Verplicht veld" Enabled="False"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group">
                    <label for="BetalingsGegevensTB" class="col-lg-2 control-label">Biografie</label>
                    <div class="col-lg-10">
                        <asp:TextBox ID="BetalingsGegevensTB" runat="server" CssClass="control-label">></asp:TextBox>
                        <asp:RequiredFieldValidator ID="BetalingsGegevensTBValidator" runat="server" CssClass="label label-danger" ControlToValidate="BetalingsGegevensTB" ErrorMessage="Verplicht veld" Enabled="False"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-lg-10 col-lg-offset-2">
                        <asp:Button ID="SubmitButton" CssClass="btn btn-default" runat="server" Text="Submit" OnClick="SubmitButton_OnClick" />
                    </div>
                </div>
            </fieldset>
        </div>
    </div>
</asp:Content>
