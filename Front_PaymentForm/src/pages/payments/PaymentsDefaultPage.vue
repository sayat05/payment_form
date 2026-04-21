<template>
    <div class="flex flex-col items-start gap-3 border w-200 rounded p-3">
        <router-link to="/payments/add">
            <my-button>Совершить платеж</my-button>
        </router-link>
        
        <my-button v-if="!isGetById" @click="isGetByIdForm = !isGetByIdForm">Посмотреть платеж по id</my-button>
        <div v-else>
            <my-button @click="isGetById = false">Скрыть платеж по id</my-button>
            <form v-if="isGetByIdForm" @submit.prevent="getById">
                <label>Payment id: </label>
                <my-input v-model="paymentId" placeholed="payment id" type="number"/>
            </form>
        </div>
        
        
        <my-button>Посмотреть сумму платежей за один день</my-button>
        <my-button>Посмотреть сумму за все платежи</my-button>
        <my-button>Посмотреть количество платежей за один день</my-button>
        
        <my-button v-if="!isGetAll" @click="getAll">Посмотреть все платежи</my-button>
        <my-button v-else @click="isGetAll = false">Скрыть все платежи</my-button>
        
        <my-button>Посмотреть все созданные платежи</my-button>
        <my-button>Посмотреть все отклоненные платежи</my-button>
    </div>
    
    <div v-if="isGetAll">
        <payment-card v-for="payment in paymentStore.payments"
                      :key="payment.id"
                      :payment="payment"/>
    </div>
    
    <div v-if="isGetByIdCard">
        <payment-card :payment="paymentStore.payment"/>
    </div>
</template>

<script>
import PaymentCard from "@/components/PaymentCard.vue";
import {usePaymentStore} from "@/pinies/paymentStore.js";
import MyInput from "@/components/myUI/MyInput.vue";

export default {
    name: "PaymentsDefaultPage",
    components: {
        MyInput,
        PaymentCard
    },
    data() {
        return {
            paymentStore: usePaymentStore(),
            isGetAll: false,
            isGetCreated: false,
            isGetRejected: false,
            isGetById: false,
            isCountByDay: false,
            isSumByDay: false,
            isTotalSum: false,
            isGetByIdForm: false,
            
            paymentId: ''
            
        }
    },
    methods: {
        async getAll() {
            
            this.isGetAll = true;
            await this.paymentStore.getAll();
        },
        async getById() {
            this.isGetById = true;
            this.paymentStore.getById(this.paymentId);
        }
    }
}
</script>

<style scoped>

</style>