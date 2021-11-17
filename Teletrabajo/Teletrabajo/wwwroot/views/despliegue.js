document.addEventListener("DOMContentLoaded", () => {

    const checkboxes = document.getElementsByClassName("checkTrabajador");
    const divs = document.getElementsByClassName("divTrabajador");

    const idselectTrabajador = document.getElementsByClassName("selectDomicilioTrabajador");

    const divsDomicilio = document.getElementsByClassName("divDomicilioTrabajador");

    const idSelects = new Array();
    const idDivsDomicilio = new Array();

    const idChecks = new Array();
    const idDivs = new Array();

    for (let item of idselectTrabajador) {
        idSelects.push(item.id);
    }
    for (let item of divsDomicilio) {
        idDivsDomicilio.push(item.id);
    }


    for (let item of checkboxes) {
        idChecks.push(item.id);
    }
    for (let item of divs) {
        idDivs.push(item.id);
    }

    for (var i = 0; i < idselectTrabajador.length; i++) {

        domicilioDespliegue(idSelects[i], idDivsDomicilio[i]);
    }

    for (var i = 0; i < checkboxes.length; i++) {


        myFunction(idChecks[i], idDivs[i]);

    }




});


function domicilioDespliegue(idSelect, idDivDomicilio) {
    var select = document.getElementById(idSelect);
    var div = document.getElementById(idDivDomicilio);
    //console.log(div);

    select.addEventListener('click', () => {
        //console.log("Cambié");
        //console.log(select.value);
        if (select.value == "Argentina") {
            //console.log("Entré");
            div.style.display = "block";
        } else {
            div.style.display = "none";
        }

    })








}





function myFunction(idCheckbox, idDiv) {
    // Get the checkbox
    var checkBox = document.getElementById(idCheckbox);

    console.log(idCheckbox);
    // Get the output text
    var text = document.getElementById(idDiv);

    checkBox.addEventListener('click', () => {
        if (checkBox.checked == true) {
            text.style.display = "block";
            //console.log("True");
        } else {
            text.style.display = "none";
            //console.log("False");
        }
    })
}




function alerta() {
    swal("Enviado", "Los datos han sido procesados", "success");

}







    //const idselectTrabajador = document.getElementsByClassName("selectDomicilioTrabajador");

    //const divsDomicilio = document.getElementsByClassName("divDomicilioTrabajador");

    //const idSelects = new Array();
    //const idDivsDomicilio = new Array()


    //for (let item of idselectTrabajador) {
    //    idSelects.push(item.id);
    //}
    //for (let item of divsDomicilio) {
    //    idDivsDomicilio.push(item.id);
    //}

    //for (var i = 0; i < idselectTrabajador.length; i++) {

    //    domicilioDespliegue(idSelects[i], idDivsDomicilio[i]);
    //}


    //function domicilioDespliegue(idSelect, idDivDomicilio) {
    //    var select = document.getElementById(idSelect);
    //    var div = document.getElementById(idDivDomicilio);

    //    select.addEventListener('click', () => {
    //        console.log("Cambié");
    //        console.log(select.value);
    //        if (select.value == 8) {
    //            div.style.display = "block";
    //        } else {
    //            div.style.display = "none";
    //        }

    //    })

    //}
