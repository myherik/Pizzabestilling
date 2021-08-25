$(()=>{
    hentBestillinger()
})

const hentBestillinger=()=>{
    $.get("/api/Bestilling", Data => {
        console.log(Data);
        let tom = "";
        for (let Bestilling of Data){
            tom+=`<tr>
        <td>${Bestilling.pizzatype}</td>
        <td>${Bestilling.tykkelse}</td>
        <td>${Bestilling.antall}</td>
        <td>${Bestilling.kunde.navn}</td>
        <td>${Bestilling.kunde.adresse}</td>
        <td>${Bestilling.kunde.telefon}</td>
        <td><button onclick="slettBestilling(${Bestilling.id})" class="btn btn-danger" id="deleteKnapp">Delete</button></td>
        </tr>`
        }
        $("#bestillingsListe").html(tom)
    })
    
}
const slettBestilling=(id)=>{
    $.ajax({
        url: "/api/Bestilling/" + id,
        type: "PUT",
        success: data =>{
            console.log(data);
            if (data === true){
                hentBestillinger();
            }
        }
    })
}