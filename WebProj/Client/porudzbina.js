import { KoktelBar } from "./koktelBar.js";
import {Sto} from "./sto.js";

export class Porudzbina{
    constructor(id, deserti , pice){
        this.id=id;

        if (pice) {
            this.pice = pice;
        }
        else {
            this.pice = "Default";
        }

        if (deserti) {
            this.deserti = deserti;
        }
        else {
            this.deserti = "Default";
        }
        

        this.kontejnerPoruci=null;

    }

    getID(){
        return this.id;
    }

    getDesert(){
        return this.deserti;
    }

    getPice(){
        return this.pice;
    }

    izmeniNarudzbinu(deserti, pice)
    {
        this.pice = pice;
        this.deserti= deserti;
        alert("Izmena uspesna!");
        
    }

    otkaziNarudzbinu()
    {
        this.id = 0;
        this.pice = "";
        this.deserti = "";
        alert("Uspensno otkazano!");
    }

}