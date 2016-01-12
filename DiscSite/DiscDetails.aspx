<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DiscDetails.aspx.cs" Inherits="DiscSite.DiscDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FormView ID="discDetail" runat="server" ItemType="DiscSite.Models.Disc" SelectMethod ="GetDisc" RenderOuterTable="false">
        <ItemTemplate>
            <div>
                <h1><%#:Item.DiscName %></h1>
            </div>
            <br />
            <table>
                <tr>
                    <td>
                        <img src="/Images/disc.jpg" style="border:solid; height:300px" alt="<%#:Item.DiscName %>"/>
                    </td>
                    <td>&nbsp;</td>  
                    <td style="vertical-align: top; text-align:left;">
                        <b>Flight Characteristics</b><br />
                        <ul>
                            <li>Speed: <%#: Item.Speed %></li>
                            <li>Glide: <%#: Item.Glide %></li>
                            <li>Turn: <%#: Item.Turn %></li>
                            <li>Fade: <%#: Item.Fade %></li>
                        </ul>
                        <br />
                        <span><b>Company:</b>&nbsp;<%#: Item.Company.CompanyName %></span>
                        <br />
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:FormView>
</asp:Content>