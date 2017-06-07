$(document).ready(function () {
    //console.log("Si mi chiami");
    //AlertShowSuccess("Siiii", "Funziono Dio Cane!");
});

function ModalShow() {
    var MainModalBox = $("#" + MainModalBoxID);
    var MainModalTitle = $("#" + MainModalTitleID);
    var MainModalBody = $("#" + MainModalBodyID);
    var MainModalFooter = $("#" + MainModalFooterID);

    MainModalBox.modal({ show: false });
    MainModalBox.modal('show');
}

function AlertResetAndHide() {
    var MainAlertBox = $("#" + MainAlertBoxID);
    MainAlertBox.removeClass("alert-info");
    MainAlertBox.removeClass("alert-success");
    MainAlertBox.removeClass("alert-warning");
    MainAlertBox.removeClass("alert-danger");

    MainAlertBox.removeAttr("style");
    MainAlertBox.attr("style", "display:none");
}
function AlertShow(cName, hdrMsg, bodyMsg) {
    var MainAlertBox = $("#" + MainAlertBoxID);
    var MainAlertHeader = $("#" + MainAlertHeaderID);
    var MainAlertBody = $("#" + MainAlertBodyID);

    MainAlertBox.removeClass("alert-info");
    MainAlertBox.removeClass("alert-success");
    MainAlertBox.removeClass("alert-warning");
    MainAlertBox.removeClass("alert-danger");
    MainAlertBox.addClass(cName);

    MainAlertBox.removeAttr("style");
    MainAlertBox.attr("style", "display:block");

    MainAlertHeader.html(hdrMsg);
    MainAlertBody.html(bodyMsg);
}
function AlertShowError(hdrMsg, bodyMsg) {
    AlertShow("alert-danger", hdrMsg, bodyMsg);
}
function AlertShowInfo(hdrMsg, bodyMsg) {
    AlertShow("alert-info", hdrMsg, bodyMsg);
}
function AlertShowSuccess(hdrMsg, bodyMsg) {
    AlertShow("alert-success", hdrMsg, bodyMsg);
}
function AlertShowWarning(hdrMsg, bodyMsg) {
    AlertShow("alert-warning", hdrMsg, bodyMsg);
}