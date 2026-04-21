<template>
    <div class="flex flex-col items-start gap-5 border w-200 rounded p-3 !mx-auto">
        <router-link to="/payments/add">
            <my-button>Совершить платеж</my-button>
        </router-link>
        
        <router-link to="/payments/getById">
            <my-button>Посмотреть платеж по id</my-button>
        </router-link>
        
        <router-link to="/payments/stats">
            <my-button>Посмотреть статистику</my-button>
        </router-link>
        
        
        <my-button v-if="!isGetAll" @click="getAll">Посмотреть все платежи</my-button>
        <my-button v-else @click="isGetAll = false">Скрыть все платежи</my-button>
        
        <my-button v-if="!isGetCreated" @click="getCreated">Посмотреть все созданные платежи</my-button>
        <my-button v-else @click="isGetCreated = false">Скрыть все созданные платежи</my-button>
        
        <my-button v-if="!isGetRejected" @click="getRejected">Посмотреть все отклоненные платежи</my-button>
        <my-button v-else @click="isGetRejected = false">Скрыть все отклоненные платежи</my-button>
    </div>
    
    <div v-if="isGetAll">
        <p class="text-center !mt-10">Все платежи</p>
        <payment-card v-for="payment in paymentStore.payments"
                      :key="payment.id"
                      :payment="payment"
                      class="!mx-auto"/>
    </div>
    
    <div v-if="isGetCreated">
        <p class="text-center !mt-5">Количество созданных платежей: {{ paymentStore.payments.length }}</p>
        <payment-card v-for="payment in paymentStore.payments" :key="payment.id" :payment="payment" class="!mx-auto"/>
    </div>
    
    <div v-if="isGetRejected">
        <p class="text-center !mt-5">Количество отклоненных платежей: {{ paymentStore.payments.length }}</p>
        <payment-card v-for="payment in paymentStore.payments" :key="payment.id" :payment="payment" class="!mx-auto"/>
    </div>

</template>

<script>
import PaymentCard from "@/components/PaymentCard.vue";
import {usePaymentStore} from "@/pinies/paymentStore.js";

export default {
    name: "PaymentsDefaultPage",
    components: {
        PaymentCard
    },
    data() {
        return {
            paymentStore: usePaymentStore(),
            isGetAll: false,
            isGetCreated: false,
            isGetRejected: false,
        }
    },
    methods: {
        async getAll() {
            this.isGetAll = true;
            await this.paymentStore.getAll();
        },
        async getCreated() {
            this.isGetCreated = true;
            await this.paymentStore.getCreated();
        },
        async getRejected() {
            this.isGetRejected = true;
            await this.paymentStore.getRejected();
        }
    }
}
</script>

<style scoped>

</style>