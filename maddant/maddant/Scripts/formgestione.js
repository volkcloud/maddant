
function pUpdate() {
    var validationResult = true;

    if (typeof (Page_ClientValidate) == 'function') {
        validationResult = Page_ClientValidate("part");
    }

    if (!validationResult) {
        alert('Specificare il partecipante');
        return false;
    }

    // if ($("#pname").val() != null && $("#pname").val() != '') {
      pAddToTable();

      // Clear form fields
      formClear();

      $("#pname").focus();
    }
}


function pAddToTable() {
      
    if ($("#MainContent_tblP tbody").length == 0) {
        $("#MainContent_tblP").append("<tbody></tbody>");
    
    }

   
    $("#MainContent_tblP tbody").append(
                "<tr>" +
                "<td>" + $("#pname").val() + "</td>" +
                "<td>" +
                "<button type='button' " +
            "onclick='pDelete(this);' " +
            "class='btn btn-default'>" +
                "<span class='glyphicon glyphicon-remove' />" +
                "</button>" +
                "</td>" +
                "</tr>"
            );
}

// Clear form fields
function formClear() {
    $("#pname").val("");

}

// Delete product from <table>
function pDelete(ctl) {
    $(ctl).parents("tr").remove();
}

//javascript: WebForm_DoPostBackWithOptions(new WebForm_PostBackOptions("ctl00$MainContent$btnCrea", "", true, "crea", "", false, false))
//function WebForm_OnSubmit() {
//    if (typeof (ValidatorOnSubmit) == "function" && ValidatorOnSubmit() == false) return false;
//    return true;
//}
//var theForm = document.forms['ctl01'];
//if (!theForm) {
//    theForm = document.ctl01;
//}
//function __doPostBack(eventTarget, eventArgument) {
//    if (!theForm.onsubmit || (theForm.onsubmit() != false)) {
//        theForm.__EVENTTARGET.value = eventTarget;
//        theForm.__EVENTARGUMENT.value = eventArgument;
//        theForm.submit();
//    }
//}
function save() {
 //   WebForm_DoPostBackWithOptions(new WebForm_PostBackOptions("ctl00$MainContent$btnCrea", "", true, "crea", "", false, false));
    var validationResult = true;
   
    if (typeof (Page_ClientValidate) == 'function') {
        validationResult = Page_ClientValidate("crea");
    }
    
    if (!validationResult) {
        alert('Ci sono errori nei campi, impossibile proseguire');
        return false;
    }
    var ev = {};
    ev.descrizione = 'bla';

    $.ajax({
        url: "/api/Eventi/",
        type: 'POST',
        dataType: 'json',
        contentType:
            "application/json;charset=utf-8",
        data: ev,
        success: function () {
            alert('ok');
        },
        error: function (request, message, error) {
            alert(message);
        }
    });
}
    