/*
var myObj, i, j, x = "";
myObj = {
    "name": "John",
    "age": 30,
    "cars": [
        { "name": "Ford", "models": ["Fiesta", "Focus", "Mustang"] },
        { "name": "BMW", "models": ["320", "X3", "X5"] },
        { "name": "Fiat", "models": ["500", "Panda"] }
    ]
}
for (i in myObj.cars) {
    x += "<h2>" + myObj.cars[i].name + "</h2>";
    for (j in myObj.cars[i].models) {
        x += myObj.cars[i].models[j] + "<br>";
    }
}
*/
var partecipanti;
partecipanti = {
    "last":0,
    "partecipanti": [
        //{ "nome": "carlo" },
        //{ "nome": "mario" }
    ]
}

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
      pClear();

    $("#MainContent_edPartecipante").focus();
    return false;
}




function pAddToTable() {
      
    if ($("#MainContent_tblP tbody").length == 0) {
        $("#MainContent_tblP").append("<tbody></tbody>");
    
    }

    var n = {
        id: partecipanti.last + 1,
        nome: $("#MainContent_edPartecipante").val()
    };
    partecipanti.partecipanti.push(n);
    partecipanti.last = partecipanti.last + 1;
   
    $("#MainContent_tblP tbody").append(
                "<tr>" +
        "<td>" + $("#MainContent_edPartecipante").val() + "</td>" +
                "<td>" +
                "<button type='button' " +
            "onclick='pDelete(this," + n.id +");' " +
            "class='btn btn-default'>" +
                "<span class='glyphicon glyphicon-remove' />" +
                "</button>" +
                "</td>" +
                "</tr>"
            );
}

// Clear form fields
function pClear() {
    $("#MainContent_edPartecipante").val("");

  
}function formClear() {
    $("#MainContent_edAzienda").val("");

    $("#MainContent_edData").val(new Date(Date.now()).toLocaleString().split(',')[0]);
}

// Delete product from <table>
function pDelete(ctl,arrayid) {
    $(ctl).parents("tr").remove();

    for (j in partecipanti.partecipanti) {
        if (partecipanti.partecipanti[j].id == arrayid)
        {
            delete partecipanti.partecipanti[j];
            return;
        }
    }
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
    //var ev = {};
    //ev.azienda = 'bla';//$("#MainContent_edAzienda").val();
    var ev = {
        'azienda': $("#MainContent_edAzienda").val(),
        'data': $("#MainContent_edData").val(),
        'partecipanti':partecipanti
    };

    $.ajax({
        url: "/api/Eventi/",
        type: 'POST',
        dataType: 'json',
        contentType:
            "application/json;charset=utf-8",
        data: JSON.stringify(ev),
        success: function () {
            formClear(); alert('Operazione completata');
        },
        error: function (request, message, error) {
            alert(message + "\n" + request.responseJSON.ExceptionMessage);
        }
    });

    return false;
}
    