import {defineStore} from "pinia";
import axios from "@/api.js";

export const usePaymentStore = defineStore('payment', {
    state: () => ({
        payment:{},
        payments: [],

    }),
    actions: {

        async add(){
            try{
                const response = await axios.post('payments/add', this.payment);
                alert(`Id: ${response.data.id} \nStatus: ${response.data.status}`);
                this.paymment = {};

            } catch (error){
                console.log(error.response);
                alert(error.message);
            }
        }
    },
});