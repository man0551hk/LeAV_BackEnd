<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="actorDetail.aspx.cs" Inherits="actorDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row">
		<div class="col-md-12">
            <div class="panel panel-default">
                <div class="panel-heading"><asp:TextBox runat="server" ID="actor_name" CssClass="form-control"></asp:TextBox></div>
				<div class="panel-body">
					<fieldset>
                        <div class="form-group">
                           <asp:Image runat="server" ID="actor_image" CssClass="img-responsive" />
                        </div>
						<div class="form-group">
                            <asp:FileUpload runat ="server" ID="cover" />
						</div>
						<asp:Button runat ="server" cssClass="btn btn-primary" Text="Update" ID="updateBtn" OnClick ="updateBtn_Click"/>
					</fieldset>
                    <asp:Label runat="server" ID="msg"></asp:Label>

                    <h2>Add New Video</h2>
					<fieldset>
                        <div class="form-group">
                           <asp:TextBox runat="server" ID ="video_name" CssClass="form-control" placeHolder ="Video Name"></asp:TextBox>
                        </div>
						<div class="form-group">
                            Video Cover
                            <asp:FileUpload runat ="server" ID="video_cover" />
						</div>
						<div class="form-group">
                            Video
                            <asp:FileUpload runat ="server" ID="video" />
						</div>
                        <div class="form-group">
                            Category
                            <asp:CheckBoxList runat="server" ID="catList" RepeatColumns="7" RepeatDirection="Horizontal"></asp:CheckBoxList>
						</div>
						<asp:Button runat ="server" cssClass="btn btn-primary" Text="Add" ID="newVideoBtn" OnClick="newVideoBtn_Click"/>
					</fieldset>

                </div>
            </div>
        </div>
    </div>
</asp:Content>

