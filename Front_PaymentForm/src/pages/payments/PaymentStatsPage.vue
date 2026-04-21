<template>
    <div class="flex flex-col items-start gap-4 border rounded p-3 w-200 !mx-auto">
        <my-button @click="isGetSymByDayForm = !isGetSymByDayForm">
            Посмотреть сумму платежей за один день
        </my-button>
        <my-button>Посмотреть сумму за все платежи</my-button>
        <my-button>Посмотреть количество платежей за один день</my-button>
    </div>
    
    
    <form v-if="isGetSymByDayForm" @submit.prevent="getSumByDay" class="!mx-auto w-120 p-3 !mt-10 border flex flex-col gap-5">
        <div class="flex items-center justify-between">
            <label>Сумма платежей за один день</label>
            <my-input v-model="dateTime" type="date"/>
        </div>
        <my-button class="self-end">Получить</my-button>
    </form>
    
    
    <p v-if="isSumByDay">Сумма платежей за: {{ paymentStore.sum}}</p>

</template>

<script>
import {usePaymentStore} from "@/pinies/paymentStore.js";
export default {
    name: "PaymentStatsPage",
  
    data() {
        return {
            paymentStore: usePaymentStore(),
            isCountByDay: false,
            isSumByDay: false,
            isTotalSum: false,
            
            isGetSymByDayForm: false,
            dateTime: ''
        }
    },
    methods: {
        getSumByDay() {
            this.paymentStore.getSumByDay(this.dateTime);
            this.isSumByDay = true;
            this.dateTime = '';
        }
    }
}
</script>


<style scoped>

</style>