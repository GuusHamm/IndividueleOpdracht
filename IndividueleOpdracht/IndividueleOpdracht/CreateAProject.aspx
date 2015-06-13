<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateAProject.aspx.cs" Inherits="IndividueleOpdracht.CreateAProject" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">




    <div class="well">
        <div class="form form-horizontal">
            <fieldset>
                <legend>Nieuw project aanmaken</legend>
                <div class="form-group">
                    <label for="ProjectNameTextbox" class="col-lg-2 control-label">Project Naam</label>
                    <div class="col-lg-10">
                        <asp:TextBox ID="ProjectNameTextbox" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" CssClass="label label-danger" ControlToValidate="ProjectNameTextbox" ErrorMessage="Verplicht veld"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group">
                    <label for="ProjectBeschrijvingTextbox" class="col-lg-2 control-label">Beschrijving van het project</label>
                    <div class="col-lg-10">
                        <asp:TextBox ID="ProjectBeschrijvingTextbox" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" CssClass="label label-danger" ControlToValidate="ProjectBeschrijvingTextbox" ErrorMessage="Verplicht veld"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group">
                    <label for="ProjectGeldNodigTextBox" class="col-lg-2 control-label">Geld benodigd voor het project</label>
                    <div class="col-lg-10">
                        <asp:TextBox ID="ProjectGeldNodigTextBox" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" CssClass="label label-danger" ControlToValidate="ProjectGeldNodigTextBox" ErrorMessage="Verplicht veld"></asp:RequiredFieldValidator>
                        <asp:CompareValidator runat="server" CssClass="label label-info" ControlToValidate="ProjectGeldNodigTextBox" Operator="DataTypeCheck" Type="Integer" ErrorMessage="Geld nodig voor het project moet een getal zijn."></asp:CompareValidator>
                    </div>
                </div>
                <div class="form-group">
                    <label for="ProjectTijdNodigTextBox" class="col-lg-2 control-label">Duur van het project</label>
                    <div class="col-lg-10">
                        <asp:TextBox ID="ProjectTijdNodigTextBox" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" CssClass="label label-danger" ControlToValidate="ProjectTijdNodigTextBox" ErrorMessage="Verplicht veld"></asp:RequiredFieldValidator>
                        <asp:CompareValidator runat="server" CssClass="label label-info" ControlToValidate="ProjectTijdNodigTextBox" Operator="DataTypeCheck" Type="Integer" ErrorMessage="Duur van het project moet een getal zijn."></asp:CompareValidator>
                    </div>
                </div>
                <div class="form-group">
                    <label for="CategorieDD" class="col-lg-2 control-label">Categorie</label>
                    <div class="col-lg-10">
                        <asp:DropDownList ID="CategorieDD" runat="server" CssClass="form-control">
                            <asp:ListItem Text="---Select a Categorie---" Value="0" />
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group">
                    <label for="TagsDD" class="col-lg-2 control-label">Tag</label>
                    <div class="col-lg-10">
                        <asp:DropDownList ID="TagsDD" runat="server" CssClass="form-control">
                            <asp:ListItem Text="---Select a Tag---" Value="0" />
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-lg-10 col-lg-offset-2">
                        <button class="btn btn-default">Cancel</button>
                        <asp:Button ID="SubmitButton" runat="server" Text="Submit" OnClick="SubmitButton_OnClick" />
                    </div>
                </div>
            </fieldset>
        </div>
    </div>


</asp:Content>

