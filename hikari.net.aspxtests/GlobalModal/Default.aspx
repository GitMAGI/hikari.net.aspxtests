<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GlobalModal.Default" %>
<%@ MasterType VirtualPath="~/Main.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <h3>Chiamate Server Pure</h3>

    <button class="btn btn-danger" id="btnShowAlertError" runat="server" onserverclick="btnShowAlertError_click">Mostra errore (Server)</button>
    <button class="btn btn-warning" id="btnShowAlertWarning" runat="server" onserverclick="btnShowAlertWarning_click">Mostra warning (Server)</button>        
    <button class="btn btn-info" id="btnShowAlertInfo" runat="server" onserverclick="btnShowAlertInfo_click">Mostra info (Server)</button>    
    <button class="btn btn-success" id="btnShowAlertSuccess" runat="server" onserverclick="btnShowAlertSuccess_click">Mostra success (Server)</button>
    <button class="btn btn-default" id="btnHideAlert" runat="server" onserverclick="btnHideAlert_click">Nascondi Alert (Server)</button>

    <br />
    <br />

    <h3>Chiamate Client Passando dal Server <small>(Javascript chiamato dal code behind)</small></h3>

    <button class="btn btn-danger" id="btnShowAlertErrorClient" runat="server" onserverclick="btnShowAlertErrorClient_click">Mostra errore (Client)</button>
    <button class="btn btn-warning" id="btnShowAlertWarningClient" runat="server" onserverclick="btnShowAlertWarningClient_click">Mostra warning (Client)</button>    
    <button class="btn btn-info" id="btnShowAlertInfoClient" runat="server" onserverclick="btnShowAlertInfoClient_click">Mostra info (Client)</button>
    <button class="btn btn-success" id="btnShowAlertSuccessClient" runat="server" onserverclick="btnShowAlertSuccessClient_click">Mostra success (Client)</button>
    <button class="btn btn-default" id="btnHideAlertClient" runat="server" onserverclick="btnHideAlertClient_click">Nascondi Alert (Client)</button>

    <br />
    <br />

    <h3>Chiamate Client Pure</h3>

    <button class="btn btn-danger" id="clntShowAlertError" onclick="AlertShowError('Errore JS puro!','Mesaggio messaggio messaggio.'); return false">Mostra errore</button>
    <button class="btn btn-warning" id="clntShowAlertWarning" onclick="AlertShowWarning('Warning JS puro!','Mesaggio messaggio messaggio.'); return false">Mostra warning</button>
    <button class="btn btn-info" id="clntShowAlertInfo" onclick="AlertShowInfo('Info JS puro!','Mesaggio messaggio messaggio.'); return false">Mostra info</button>
    <button class="btn btn-success" id="clntShowAlertSuccess" onclick="AlertShowSuccess('Success JS puro!','Mesaggio messaggio messaggio.'); return false">Mostra success</button>
    <button class="btn btn-default" id="clntHideAlert" onclick="AlertResetAndHide(); return false">Nascondi Alert</button>
    
</asp:Content>
