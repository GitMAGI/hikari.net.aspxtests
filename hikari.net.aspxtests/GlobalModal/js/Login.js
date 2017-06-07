$(document).ready(function () {
    //console.log("Si mi chiami");
    //AlertShowSuccess("Siiii", "Funziono Dio Cane!");
});

function AlertResetAndHide() {
    var LoginAlertBox = $("#" + LoginAlertBoxID);
    LoginAlertBox.removeClass("alert-info");
    LoginAlertBox.removeClass("alert-success");
    LoginAlertBox.removeClass("alert-warning");
    LoginAlertBox.removeClass("alert-danger");

    LoginAlertBox.removeAttr("style");
    LoginAlertBox.attr("style", "display:none");
}
function AlertShow(cName, hdrMsg, bodyMsg) {
    var LoginAlertBox = $("#" + LoginAlertBoxID);
    var LoginAlertHeader = $("#" + LoginAlertHeaderID);
    var LoginAlertBody = $("#" + LoginAlertBodyID);

    LoginAlertBox.removeClass("alert-info");
    LoginAlertBox.removeClass("alert-success");
    LoginAlertBox.removeClass("alert-warning");
    LoginAlertBox.removeClass("alert-danger");
    LoginAlertBox.addClass(cName);

    LoginAlertBox.removeAttr("style");
    LoginAlertBox.attr("style", "display:block");

    LoginAlertHeader.html(hdrMsg);
    LoginAlertBody.html(bodyMsg);
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