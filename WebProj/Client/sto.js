import {Porudzbina} from "./porudzbina.js";

export class Sto{

    constructor(rbr,stanje,maxKapacitet,ime,prezime){
        
        if (rbr) {
            this.rbr = rbr;
        }
        else {
            this.rbr = 0;
        }
        
        if (stanje) {
            this.stanje = stanje;
        }
        else {
            this.stanje = "slobodan";  // da li je slobodan ili ne
        }

        if (maxKapacitet) {
            this.maxKapacitet = maxKapacitet;
        }
        else {
            this.maxKapacitet = 5;  // max ljudi za stolom
        }
        
        this.kapacitet = 0; //koliko ima ljudi za stolom
        
        if (ime) {
            this.ime = ime;
        }
        else {
            this.ime = "Default";
        }

        if (prezime) {
            this.prezime = prezime;
        }
        else {
            this.prezime = "Default";
        }        
        
        this.stoKontejner=null;

    }


    vratiStanje(){
        if(this.stanje==="slobodan")
            return "rgb(212, 201, 179)";
        else
            return "rgb(255, 174, 0)";

    }

    crtajSto(host){
        if(!host)
           throw new Exception ("Roditeljski element ne postoji!");
        this.stoKontejner=document.createElement("div");
        this.stoKontejner.className="stoKontejner";
        this.stoKontejner.innerHTML= this.rbr + "<br>" +" slobodan";
        this.stoKontejner.style.backgroundColor=this.vratiStanje();
        host.appendChild(this.stoKontejner);

    }

    crtajSto1(host){
        if(!host)
           throw new Exception ("Roditeljski element ne postoji!");
        this.stoKontejner=document.createElement("div");
        this.stoKontejner.className="stoKontejner";
        this.stoKontejner.innerHTML= this.rbr + "<br>" +" zauzet";
        this.stoKontejner.style.backgroundColor=this.vratiStanje();
        this.kliknuto(this.rbr,this.ime,this.prezime);
        host.appendChild(this.stoKontejner);

    }

    zauzmiSto(brojStola, brojLjudi){
        if(this.stanje==="zauzet" || this.maxKapacitet<=brojLjudi)
            alert("Sto je rezervisan!");
        else{
            this.rbr=brojStola;
            this.kapacitet=brojLjudi;
            this.stanje="zauzet";
            this.stoKontejner.innerHTML=  this.rbr + "<br> zauzet";
            this.stoKontejner.style.backgroundColor=this.vratiStanje(); 
        }
    }


    oslobodiSto(rbr){
        this.stanje="slobodan";
        this.kapacitet=0;
        this.stoKontejner.innerHTML=rbr +"<br> slobodan";
        this.stoKontejner.style.backgroundColor=this.vratiStanje();

    }

    izmeniSto(rbr, br, ime, prezime){
        this.rbr=rbr;
        this.kapacitet += parseInt(br);
        this.ime=ime;
        this.prezime=prezime;
        this.stoKontejner.innerHTML= this.rbr + "<br> zauzet";
    }


    naruciSaStola(rbr,nar){
        if(this.stanje=="slobodan")
           alert("Sa ovog stola je nemoguce  naručiti jer je sto slobodan!");
        else{
            let naruciDugme=document.createElement("button");
            naruciDugme.className="naruciDugme";
            naruciDugme.innerHTML="Naručeno";
            this.stoKontejner.appendChild(naruciDugme);
            naruciDugme.onclick=(ev)=>{
                alert("Broj narudžbine je: "+ nar.getID() + "\n Naručeno je piće: "+ nar.getPice() + "\n Naručen je desert: "+ nar.getDesert());
            }
        }   
    }

    kliknuto(rbr, i, p)
    {
        this.stoKontejner.addEventListener("click", () => {
            //confirm(`Sto broj ${rbr} je zauzeo/la ${i} ${p}`);
            confirm("Sto broj " + rbr + " je zauzeo/la → " + i + " " + p);
        });

    }

}