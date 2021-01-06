<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Employee_Vacation.aspx.cs"  Inherits="_Employee_Vacation" %>

<asp:FileUpload  runat="server" ID="fuSample" v-model="NewHR_Vacations_Requests.Attach_File" class='custom-file-input' />
<asp:Button  runat="server" ID="btnUpload" Text="Upload" onclick="btnUpload_Click" class='uploadBtn HideUpload' />
