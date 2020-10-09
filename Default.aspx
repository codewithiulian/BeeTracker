<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BeeTracker._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="gvBees" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="Type" HeaderText="Bee Type" />
            <asp:BoundField DataField="Health" HeaderText="Health" />
            <asp:BoundField DataField="IsDead" HeaderText="Is Dead" />
            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <asp:LinkButton ID="LnkDamage" Text="Damage" runat="server" CommandArgument='<%# Eval("ID") %>' OnClick="LnkDamage_Click"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
