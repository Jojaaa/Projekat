import { KoktelBar } from "./koktelBar.js";
import { Porudzbina } from "./porudzbina.js";
import { Sto } from "./sto.js";

//const posl=new Poslasticara(1,"Slatkica","Slatka",12,3,3);
//posl.crtajPoslasticaru(document.body);


//const posl1=new Poslasticara(2,"Baby", "Baby",10,2,3);
//posl1.crtajPoslasticaru(document.body);

fetch("https://localhost:5001/KoktelBar/PreuzmiKoktelBar").then(p=>{
    p.json().then(data=>{
        console.log(data);
        
        data.forEach(koktelBar=>{
            //alert(poslasticara.naziv);
            const koktelBar1=new KoktelBar(koktelBar.id,koktelBar.naziv,koktelBar.adresa,koktelBar.kapacitet,koktelBar.maxLjudi,koktelBar.maxLokala);
            console.log(koktelBar.id);
            //console.log(poslasticara);
           // poslasticara1.stolovi=poslasticara.stolovi;


           koktelBar.stolovi.forEach((s,index)=>{
                //var sto=poslasticara1.stolovi[s.brojStola];
                //var por=poslasticara1.porudzbine[s.brojStola];
                //console.log(sto);
                 //console.log(por);
                 koktelBar1.stolovi[index]=s.brojStola;
                 
               
                
            }); 
            koktelBar.porudzbine.forEach((s,index)=>{
                //var sto=poslasticara1.stolovi[s.brojStola];
                //var por=poslasticara1.porudzbine[s.brojStola];
                //console.log(sto);
                 //console.log(por);
                
                 koktelBar1.porudzbine[index]=s.brojStola;
               
                
            }); 


            console.log(koktelBar1);
            koktelBar1.crtajKoktelBar(document.body);
        });
    });
});