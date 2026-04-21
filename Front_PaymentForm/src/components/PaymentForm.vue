<template>
    <form @submit.prevent="paymentStore.add" class="border p-3 w-100 rounded border-gray-200 flex flex-col gap-5">
        <h3 class="text-xl text-center">Payment form</h3>
        
        <div class="flex items-center justify-between">
            <label>Wallet number: </label>
            <my-input v-model="paymentStore.payment.walletNumber"
                      placeholder="wallet number"
                      type="text"
                      minlength="4"
                      required/>
        </div>
        
        <div class="flex items-center justify-between">
            <label>User id: </label>
            <my-input v-model="paymentStore.payment.userId"
                      placeholder="user id"
                      type="number"
                      required/>
        </div>
        
        <div class="flex items-center justify-between">
            <label>Email: </label>
            <my-input v-model="paymentStore.payment.email"
                      placeholder="email"
                      type="email"
                      required/>
        </div>
        
        
        <div class="flex items-center justify-between">
            <label>Phone number: </label>
            <my-input v-model="paymentStore.payment.phoneNumber"
                      placeholder="phone number"
                      type="tel"/>
        </div>
        
        <div class="flex items-center justify-between">
            <label>Currency: </label>
            <my-select v-model="paymentStore.payment.currency"
                       name="currency"
                       :items="enumStore.currenciesType"
                       required/>
        </div>
        
        <div class="flex items-center justify-between">
            <label>Payment amount: </label>
            <my-input v-model="paymentStore.payment.amount"
                      placeholder="payment amount"
                      type="number" required/>
        </div>
        
        <div class="flex items-center justify-between">
            <label>Comment: </label>
            <my-input v-model="paymentStore.payment.comment"
                      placeholder="comment"
                      type="text"/>
        </div>
        
        <my-button class="!mt-3 self-end" type="submit">Pay</my-button>
    </form>
</template>

<script>
import {useEnumStore} from "@/pinies/enumStore.js";
import {usePaymentStore} from "@/pinies/paymentStore.js";

export default {
    name: "PaymentForm",
    data() {
        return {
            enumStore: useEnumStore(),
            paymentStore: usePaymentStore()
        };
    },
    methods: {},
    mounted() {
        this.enumStore.getCurrenciesType();
    }
}
</script>


<style scoped>

</style>