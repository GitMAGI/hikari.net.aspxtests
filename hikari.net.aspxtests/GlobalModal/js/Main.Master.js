function ConfirmShowPostBack(title, message, confirmLabel, cancelLabel, postBackOp, postBackParams) {
    bootbox.confirm({
        title: title,
        message: message,
        buttons: {
            cancel: {
                label: '<i class="fa fa-times"></i> ' + cancelLabel
            },
            confirm: {
                label: '<i class="fa fa-check"></i> ' + confirmLabel
            }
        },
        callback: function (result) {
            if (result === true)
                __doPostBack(postBackOp, postBackParams)
        }
    });
}
function ConfirmShow(title, message, cancelLabel, confirmLabel, clientCallback, clientCallbackParamsArray) {
    bootbox.confirm({
        title: title,
        message: message,
        buttons: {
            cancel: {
                label: '<i class="fa fa-times"></i> ' + cancelLabel
            },
            confirm: {
                label: '<i class="fa fa-check"></i> ' + confirmLabel
            }
        },
        callback: function (result) {
            if (result === true) {
                if (clientCallbackParamsArray) {
                    clientCallback.apply(null, clientCallbackParamsArray);
                }
                else {
                    clientCallback();
                }

            }
        }
    });
}

function SimpleModalBootBoxShow(title, message) {
    bootbox.alert({
        title: title,
        message: message,
        backdrop: true,
        buttons: {}
    })
}

function SimpleModalBootBoxShowAuthoritative(title, message) {
    bootbox.alert({
        closeButton: false,
        title: title,
        message: message
    })
}

function ModalShow(titleHTML, bodyHTML, footerHTML) {
    var MainModalBox = $("#" + MainModalBoxID);
    var MainModalTitle = $("#" + MainModalTitleID);
    var MainModalBody = $("#" + MainModalBodyID);
    var MainModalFooter = $("#" + MainModalFooterID);

    if (titleHTML)
        MainModalTitle.html(titleHTML);
    if (bodyHTML)
        MainModalBody.html(bodyHTML);
    if (footerHTML)
        MainModalFooter.html(footerHTML);

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