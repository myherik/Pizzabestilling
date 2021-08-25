$(()=>{
    hentBestillinger()
})

const hentBestillinger=()=>{
    $.get("/api/Bestilling", Data => {
        console.log(Data);
        let tom = "";
        for (let Bestilling of Data){
            tom+=`<tr><td>${Bestilling.pizzatype}</td><td>${Bestilling.tykkelse}</td><td>${Bestilling.antall}</td>
        <td>${Bestilling.kunde.navn}</td><td>${Bestilling.kunde.adresse}</td><td>${Bestilling.kunde.telefon}</td></tr>`
        }
        $("#bestillingsListe").append(tom)
    })
    
}