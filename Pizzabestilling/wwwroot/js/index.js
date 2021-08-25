const saveToServer=()=>{
    const Bestilling = {
        id: 0,
        Pizzatype: $("#pizzatype").val(),
        Tykkelse: $('input[name="tykkelse"]:checked').val(),
        Antall: $("#antall").val(),
        Kunde: {
            id: 0,
            Navn: $("#navn").val(),
            Adresse: $("#adresse").val(),
            Telefon: $("#nummer").val()
        }
    }
    $.ajax({
        url: "/api/Bestilling",
        type: "POST",
        data: JSON.stringify(Bestilling),
        dataType: "json",
        contentType: "application/json"
    })
}