<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DiscList.aspx.cs" Inherits="DiscSite.DiscList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section>
        <div>
            <hgroup>
                <h2><%: Page.Title %></h2>
            </hgroup>

            <asp:ListView ID="discList" runat="server" 
                DataKeyNames="DiscID" GroupItemCount="4"
                ItemType="DiscSite.Models.Disc" SelectMethod="GetDiscs">
                <EmptyDataTemplate>
                    <table >
                        <tr>
                            <td>No discs were returned.</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <EmptyItemTemplate>
                    <td/>
                </EmptyItemTemplate>
                <GroupTemplate>
                    <tr id="itemPlaceholderContainer" runat="server">
                        <td id="itemPlaceholder" runat="server"></td>
                    </tr>
                </GroupTemplate>
                <ItemTemplate>
                    <td runat="server">
                        <table>
                            <tr>
                                <td>
                                    <a href="DiscDetails.aspx?discID=<%#:Item.DiscID%>">
                                        <img src="/Images/disc.jpg" 
                                            width="100" height="75" style="border: solid" /></a>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <a href="DiscDetails.aspx?discid=<%#:Item.DiscID%>">
                                        <span>
                                            <%#:Item.DiscName%>
                                        </span>
                                    </a>
                                    <br />
                                    <span>
                                        <%#: Item.Speed %>, <%#: Item.Glide %>, <%#: Item.Turn %>, <%#: Item.Fade %>
                                    </span>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                        </p>
                    </td>
                </ItemTemplate>
                <LayoutTemplate>
                    <table style="width:100%;">
                        <tbody>
                            <tr>
                                <td>
                                    <table id="groupPlaceholderContainer" runat="server" style="width:100%">
                                        <tr id="groupPlaceholder"></tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                            </tr>
                            <tr></tr>
                        </tbody>
                    </table>
                </LayoutTemplate>
            </asp:ListView>
        </div>
    </section>
</asp:Content>