<template>
    <div class="flex flex-col items-start gap-5 border rounded p-3 w-200 !mx-auto">
        <my-button @click="isGetSymByDayForm = !isGetSymByDayForm">
            Посмотреть сумму платежей за один день
        </my-button>
        
        <my-button @click="isGetCountyDayForm = !isGetCountyDayForm">
            Посмотреть количество платежей за один день
        </my-button>
        
        
        <my-button @click="getTotalSum">Посмотреть сумму за все платежи</my-button>
    </div>
    
    <div>
        <form v-if="isGetSymByDayForm" @submit.prevent="getSumByDay"
              class="!mx-auto w-120 p-3 !mt-10 border flex flex-col gap-5">
            <div class="flex items-center justify-between">
                <label>Сумма платежей за один день</label>
                <my-input v-model="dateTime" type="date"/>
            </div>
            <my-button class="self-end">Получить</my-button>
        </form>
        <p v-if="isSumByDay" class="text-center !mt-5">Сумма платежей за {{ dateTime }}: {{ paymentStore.sum }}</p>
    </div>
    
    
    <div>
        <form v-if="isGetCountyDayForm" @submit.prevent="getCountByDay"
              class="!mx-auto w-120 p-3 !mt-10 border flex flex-col gap-5">
            <div class="flex items-center justify-between">
                <label>Количество платежей за один день</label>
                <my-input v-model="dateTime" type="date"/>
            </div>
            <my-button class="self-end">Получить</my-button>
        </form>
        
        <p v-if="isCountByDay" class="text-center !mt-5">
            Количество платежей за {{ dateTime }}: {{ paymentStore.count }}
        </p>
    </div>
    
    <p v-if="isTotalSum" class="text-center !mt-5">Сумма всех платежей: {{ paymentStore.sum }}</p>
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
            dateTime: '',
            
            isGetCountyDayForm: false
        }
    },
    methods: {
        getSumByDay() {
            this.paymentStore.getSumByDay(this.dateTime);
            this.isSumByDay = true;
        },
        getCountByDay() {
            this.paymentStore.getCountByDay(this.dateTime);
            this.isCountByDay = true;
        },
        getTotalSum() {
            this.paymentStore.getTotalSum();
            this.isTotalSum = true;
        }
    }
}
</script>

<style scoped>

</style>