import {defineStore} from "pinia";

export const usePaymentStore = defineStore('payment', {
    state: () => ({
        payment:{},
        payments: [],

    }),
    actions: {},
});