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
    
    <br />
    <br />

    <h3>Chiamate Client Verso il Server <small>(Chiamata JS a __doPostBack('command','arguments')</small></h3>

    <button class="btn btn-danger" id="clntShowAlertErrorServer" onclick="__doPostBack('btnShowAlertError','')">Mostra errore</button>
    <button class="btn btn-warning" id="clntShowAlertWarningServer" onclick="__doPostBack('btnShowAlertWarning','')">Mostra warning</button>
    <button class="btn btn-info" id="clntShowAlertInfoServer" onclick="__doPostBack('btnShowAlertInfo','')">Mostra info</button>
    <button class="btn btn-success" id="clntShowAlertSuccessServer" onclick="__doPostBack('btnShowAlertSuccess','')">Mostra success</button>
    <button class="btn btn-default" id="clntHideAlertServer" onclick="__doPostBack('btnHideAlert','')">Nascondi Alert</button>

    <br />
    <br />

    <h3>Confirm! Chiamate Client Verso il Server <small>(Chiamata JS a __doPostBack('command','arguments')</small></h3>

    <button class="btn btn-danger" id="clntShowAlertErrorServerConfirm" onclick="ConfirmShowPostBack('Attenzione!', 'Vuoi mostrare Alert Error?', 'No', 'Ok', 'btnShowAlertError', ''); return false;">Mostra errore</button>
    <button class="btn btn-warning" id="clntShowAlertWarningServerConfirm" onclick="ConfirmShowPostBack('Attenzione!', 'Vuoi mostrare Alert Error?', 'No', 'Ok', 'btnShowAlertWarning', ''); return false;">Mostra warning</button>
    <button class="btn btn-info" id="clntShowAlertInfoServerConfirm" onclick="ConfirmShowPostBack('Attenzione!', 'Vuoi mostrare Alert Error?', 'No', 'Ok', 'btnShowAlertInfo', ''); return false;">Mostra info</button>
    <button class="btn btn-success" id="clntShowAlertSuccessServerConfirm" onclick="ConfirmShowPostBack('Attenzione!', 'Vuoi mostrare Alert Error?', 'No', 'Ok', 'btnShowAlertSuccess', ''); return false;">Mostra success</button>
    <button class="btn btn-default" id="clntHideAlertServerConfirm" onclick="ConfirmShowPostBack('Attenzione!', 'Vuoi Nascondere Alert?', 'No', 'Ok', 'btnHideAlert', ''); return false;">Nascondi Alert</button>

    
    <br />
    <br />

    <h3>Confirm! Chiamate Client Pure</h3>

    <button class="btn btn-danger" id="clntShowAlertErrorClientConfirm" onclick="ConfirmShow('Attenzione!', 'Vuoi mostrare Alert Error?', 'No', 'Ok', AlertShowError, ['Errore JS puro!', 'Mesaggio messaggio messaggio.']); return false;">Mostra errore</button>
    <button class="btn btn-warning" id="clntShowAlertWarningClientConfirm" onclick="ConfirmShow('Attenzione!', 'Vuoi mostrare Alert Warning?', 'No', 'Ok', AlertShowWarning, ['Warning JS puro!', 'Mesaggio messaggio messaggio.']); return false;">Mostra warning</button>
    <button class="btn btn-info" id="clntShowAlertInfoClientConfirm" onclick="ConfirmShow('Attenzione!', 'Vuoi mostrare Alert Info?', 'No', 'Ok', AlertShowInfo, ['Info JS puro!', 'Mesaggio messaggio messaggio.']); return false;">Mostra info</button>
    <button class="btn btn-success" id="clntShowAlertSuccessClientConfirm" onclick="ConfirmShow('Attenzione!', 'Vuoi mostrare Alert Success?', 'No', 'Ok', AlertShowSuccess, ['Success JS puro!', 'Mesaggio messaggio messaggio.']); return false;">Mostra success</button>
    <button class="btn btn-default" id="clntHideAlertClientConfirm" onclick="ConfirmShow('Attenzione!', 'Vuoi Nascondere Alert?', 'No', 'Ok', AlertResetAndHide); return false;">Nascondi Alert</button>

    <br />
    <br />

    <h3>Alert e Modal</h3>
    <button class="btn btn-default" id="clntShowSimpleAlert" onclick="SimpleModalBootBoxShow('Attenzione!', 'Roba semplice ma funziona anche <i>HTML<i>'); return false;">Mostra SimpleAlert</button>
    <button class="btn btn-default" id="clntShowSimpleAlertAuthoritative" onclick="SimpleModalBootBoxShowAuthoritative('Attenzione!', 'Roba semplice ma funziona anche <i>HTML<i>'); return false;">Mostra SimpleAlert Obbligatrio</button>


</asp:Content>
