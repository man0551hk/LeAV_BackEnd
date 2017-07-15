<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="actor.aspx.cs" Inherits="actor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row">
		<div class="col-md-12">
            <div class="panel panel-default">
                <div class="panel-heading">Actor</div>
				<div class="panel-body">
                    <a href ="uploadActor.aspx">New Actor</a>
					<table data-toggle="table">
						<thead>
						    <tr>
						        <th>Actor ID</th>
						        <th>Image</th>
                                <th>Actor Name</th>
						    </tr>
						</thead>
                        <asp:Repeater ID ="actorRepeater" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td><a href = 'actorDetail.aspx?actor_id=<%# DataBinder.Eval(Container.DataItem, "actor_id") %>'><%# DataBinder.Eval(Container.DataItem, "actor_id") %></a></td>
                                    <td><image src = '<%# DataBinder.Eval(Container.DataItem, "cover_path") %>' class ="img-responsive"></image></td>

                                    <td><%# DataBinder.Eval(Container.DataItem, "actor_name") %></td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
					</table>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

