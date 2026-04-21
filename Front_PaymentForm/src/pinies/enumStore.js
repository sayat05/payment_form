import {defineStore} from "pinia";
import axios from "@/api.js";

export const useEnumStore = defineStore('enum', {
    state: () => ({
        currenciesType: []
    }),
    actions: {
        async getCurrenciesType() {
            try {
                const response = await axios.get('enums/currencies');
                this.currenciesType = response.data;
            } catch (error) {
                console.log(error);
                alert(error.message);
            }
        }
    },
});