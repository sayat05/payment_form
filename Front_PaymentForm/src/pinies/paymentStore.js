import {defineStore} from "pinia";
import axios from "@/api.js";

export const usePaymentStore = defineStore('payment', {
    state: () => ({
        payment: {},
        payments: [],
        sum: null,
        count: null

    }),
    actions: {
        async getAll() {
            try {
                const response = await axios.get('payments');
                this.payments = response.data;
            } catch (error) {
                console.log(error.response);
                alert(error.message);
            }
        },
        async getCreated() {
            try {
                const response = await axios.get('payments/getCreated');
                this.payments = response.data;
            } catch (error) {
                console.log(error.response);
                alert(error.message);
            }
        },
        async getRejected() {
            try {
                const response = await axios.get('payments/getRejected');
                this.payments = response.data;
            } catch (error) {
                console.log(error.response);
                alert(error.message);
            }
        },
        async getById(id) {
            try {
                const response = await axios.get(`payments?id=${id}`);
                this.payment = response.data;
            } catch (error) {
                console.log(error.response);
                alert(error.message);
            }
        },
        async getSumByDay(dateTime) {
            try {
                const response = await axios.get('payments/getSumByDay', dateTime);
                this.sum = response.data;
            } catch (error) {
                console.log(error.response);
                alert(error.message);
            }
        },
        async getCountByDay() {
            try {
                const response = await axios.get('payments/');
                this.count = response.data;
            } catch (error) {
                console.log(error.response);
                alert(error.message);
            }
        },
        async geTotalSum() {
            try {
                const response = await axios.get('payments/');
                this.sum = response.data;
            } catch (error) {
                console.log(error.response);
                alert(error.message);
            }
        },
        async add() {
            try {
                const response = await axios.post('payments/add', this.payment);
                alert(`Id: ${response.data.id} \nStatus: ${response.data.status}`);
                this.payment = {};
            } catch (error) {
                console.log(error.response);
                alert(error.message);
            }
        }
    },
});