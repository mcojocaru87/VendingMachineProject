<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/BasePage.Master" Inherits="System.Web.Mvc.ViewPage<VendingMachine.Web.Models.MachineModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <% var model = (VendingMachine.Web.Models.MachineViewModel)ViewBag.Model; %>

    <div class="row">
        <div class="col-md-6">
            <div class="table-responsive">
                <table class="table table-hover">
                    <tbody>
                        <% foreach (var tray in model.Trays.Select((value, i) => new { i, value }))
                           { %>
                        <tr>
                            <td><%:string.Format("T{0}", tray.i+1) %></td>
                            <% for (int i = 1; i < tray.value.Product.Inventory.InStock + 1; i++)
                               { %>
                            <td><%: string.Format("{0}",tray.value.Product.Name) %><br />
                                <%: string.Format("{0:c}",tray.value.Product.Price) %>
                            </td>
                            <% } %>
                        </tr>
                        <% } %>
                    </tbody>
                </table>
            </div>
        </div>
        <%using (Html.BeginForm())
          {      %>
        <%: Html.Hidden("Total", model.Total) %>
        <div class="col-md-6">

            <%: Html.TextBox("Display", model.Display, new { @class = "form-control", @disabled="disabled"}) %>

            <div class="row">
                <div class="col-md-6">
                    <div class="input-group">
                        <%: Html.TextBox("Bills", model.Bills, new { @class = "form-control", @placeholder="Please insert your bills."}) %>
                        <span class="input-group-btn">
                            <button type="submit" class="btn btn-success">Insert</button>
                        </span>
                    </div>

                </div>
                <div class="col-md-6">
                    <div class="input-group">
                        <%: Html.TextBox("Coins", model.Coins, new { @class = "form-control", @placeholder="Please insert your coins."}) %>
                        <span class="input-group-btn">
                            <button type="submit" class="btn btn-success">Insert</button>
                        </span>
                    </div>

                </div>
            </div>

            <%: Html.DropDownList("Choices", model.Choices, new { @class = "form-control"}) %>
            <button type="submit" class="btn btn-success">Order</button>
            <button type="submit" class="btn btn-danger">Cancel</button>
        </div>
        <% } %>
    </div>




</asp:Content>
