import { KoktelBar } from "./koktelBar.js";
import { Porudzbina } from "./porudzbina.js";
import { Sto } from "./sto.js";


fetch("https://localhost:5001/KoktelBar/PreuzmiKoktelBar").then(p=>{
    p.json().then(data=>{
        console.log(data);
        
        data.forEach(koktelBar=>{
            
            const koktelBar1=new KoktelBar(koktelBar.id,koktelBar.naziv,koktelBar.adresa,koktelBar.kapacitet,koktelBar.maxLjudi,koktelBar.maxLokala);
            console.log(koktelBar.id);
            
            
            koktelBar.stolovi.forEach((s,index)=>{
                
                koktelBar1.stolovi[index]=s.brojStola;
                
            }); 
            
            koktelBar.porudzbine.forEach((s,index)=>{

                koktelBar1.porudzbine[index]=s.brojStola;
               
            }); 

            console.log(koktelBar1);
            koktelBar1.crtajKoktelBar(document.body);
        });
    });
});