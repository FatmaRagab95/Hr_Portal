<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Vacation_Request.aspx.cs"  Inherits="_Vacation_Request" %>
				<asp:FileUpload  runat="server" ID="fuSample" v-model="NewHR_Vacations_Requests.Attach_File" class='custom-file-input' />
				<asp:Button  runat="server" ID="btnUpload" Text="Upload" onclick="btnUpload_Click" class='uploadBtn HideUpload' />
						
