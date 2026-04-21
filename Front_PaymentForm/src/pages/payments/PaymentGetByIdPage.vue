<template>
    <form @submit.prevent="getById" class="border rounded w-100 p-3 flex flex-col gap-5 !mx-auto">
        <div class="flex items-center justify-between">
            <label>Payment id:</label>
            <my-input v-model="paymentId" type="number" placeholder="payment id"/>
        </div>
        
        <my-button class="self-end">Get</my-button>
    </form>
    
    <div v-if="isPaymentCard">
        <payment-card :payment="paymentStore.payment" class="!mx-auto"/>
    </div>

</template>

<script>
import {usePaymentStore} from "@/pinies/paymentStore.js";
import PaymentCard from "@/components/PaymentCard.vue";

export default {
    name: "PaymentGetByIdPage",
    components: {
        PaymentCard
    },
    data() {
        return {
            paymentStore: usePaymentStore(),
            paymentId: '',
            isPaymentCard: false
        }
    },
    methods: {
        getById() {
            this.paymentStore.getById(this.paymentId);
            this.isPaymentCard = true;
        }
    }
}
</script>

<style scoped>

</style>