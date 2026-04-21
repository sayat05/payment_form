<template>
    <div>
        <h3>Страница платежей</h3>
        
        <div>
            <payment-card v-for="payment in paymentStore.payments"
                          :key="payment.id"
                          :payment="payment"/>
        
        </div>
    
    </div>
</template>


<script>
import PaymentCard from "@/components/PaymentCard.vue";
import {usePaymentStore} from "@/pinies/paymentStore.js";

export default {
    name: "PaymentPage",
    components: {
        PaymentCard
    },
    data() {
        return {
            paymentStore: usePaymentStore()
        };
    },
    mounted() {
        this.paymentStore.getAll();
    }
}
</script>


<style scoped>

</style>