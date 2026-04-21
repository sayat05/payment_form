<template>
    <div class="flex flex-col items-start gap-3 border w-200 rounded p-3 !mx-auto">
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
        
        <my-button>Посмотреть все созданные платежи</my-button>
        <my-button>Посмотреть все отклоненные платежи</my-button>
    </div>
    
    <div v-if="isGetAll">
        <payment-card v-for="payment in paymentStore.payments"
                      :key="payment.id"
                      :payment="payment"/>
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
        }
    },
    methods: {
        async getAll() {
            this.isGetAll = true;
            await this.paymentStore.getAll();
        }
    }
}
</script>

<style scoped>

</style>