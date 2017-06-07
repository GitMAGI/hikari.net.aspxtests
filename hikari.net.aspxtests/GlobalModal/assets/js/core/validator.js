function notNullOrVoidInputText(value) {
    if (value)
        return true;
    else
        return false;
}

function justNumericInputText(value) {
    if (!value || isNaN(value)) {
        return false;
    }
    else {
        return true;
    }

}

function isEqualToCaseSensitive(value, target) {
    if (!value || !target)
        return false;
    if (value === target)
        return true;
    else
        return false;

}

function isEqualToCaseInsensitive(value, target) {
    if (!value || !target)
        return false;
    if (value.toUpperCase() === target.toUpperCase())
        return true;
    else
        return false;
}

function validate(fields) {
    var result = true;

    //console.log(fields);

    $.each(fields, function (index, field) {
        var id = field.name;
        var errs = [];
        var validField = true;

        unmarkFromErrors(id);

        //console.log(field.rules);
        $.each(field.rules, function (index2, rule) {
            //console.log("Validation of " + id);
            //console.log(rule.op);
            //console.log(rule.err);
            //executeFunctionByName(rule.op, window, arguments);
            switch (rule.op) {
                case "notNullOrVoidInputText":
                    var value = $("#" + id).val();
                    if (!notNullOrVoidInputText(value)) {
                        validField = false;
                        errs.push(rule.err);
                    }
                    break;
                case "justNumericInputText":
                    var value = $("#" + id).val();
                    if (!justNumericInputText(value)) {
                        validField = false;
                        errs.push(rule.err);
                    }
                    break;
                case "isEqualToCaseSensitive":
                    var value = $("#" + id).val();
                    var target = $("#" + rule.targetName).val();
                    if (!isEqualToCaseSensitive(value, target)) {
                        validField = false;
                        errs.push(rule.err);
                    }
                    break;
                case "isEqualToCaseInsensitive":
                    var value = $("#" + id).val();
                    var target = $("#" + rule.targetName).val();
                    if (!isEqualToCaseInsensitive(value, target)) {
                        validField = false;
                        errs.push(rule.err);
                    }
                    break;
            }
        });

        if (!validField) {
            markWithErrors(id, errs);
            result = false;
        }
    });

    //console.log(result);

    return result;
}

function markWithErrors(id, msgs) {
    //console.log("id: " + id);
    //console.log("msg: " + msgs);
    //console.log("Mark chiamato su [" + id + "]");

    let itemParent = $("#" + id).parent();
    itemParent.addClass("has-error");

    let helpBlock_str = '<div id="' + id + '_helpBlock' + '" class="help-block no-margin-top" >';
    helpBlock_str += '<ul class="list-unstyled">';
    $.each(msgs, function (index, msg) {
        helpBlock_str += '<li class="has-error"><small>' + msg + '</small></li>';
    });
    helpBlock_str += '</ul>';
    helpBlock_str += '</div>';

    $("#" + id).after(helpBlock_str);
    //itemParent.append(helpBlock_str);
}

function unmarkFromErrors(id) {
    //console.log("Unmark chiamato [" + id + "]");

    let itemParent = $("#" + id).parent();
    itemParent.removeClass("has-error");
    $('#' + id + '_helpBlock').remove();
}