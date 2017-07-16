<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="uploadActor.aspx.cs" Inherits="uploadActor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row">
		<div class="col-md-12">
            <div class="panel panel-default">
                <div class="panel-heading">Upload Actor</div>
				<div class="panel-body">
					<fieldset>
						<div class="form-group">
                            <asp:TextBox runat ="server" ID ="actorName" placeholder ="Actor Name" CssClass="form-control"></asp:TextBox>
						</div>
						<div class="form-group">
                            <asp:FileUpload runat ="server" ID="cover" />
						</div>
						<asp:Button runat ="server" cssClass="btn btn-primary" Text="Add" ID="addBtn" OnClick="addBtn_Click" />
					</fieldset>
                    <asp:Label runat="server" ID="msg"></asp:Label>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

