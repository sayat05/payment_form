<template>
    <div class="h-100 bg-gray-500">
        <div v-for="currency in enumStore.currenciesType" :key="currency">
            {{currency}}
        </div>
    </div>
</template>

<script>
import {useEnumStore} from "@/pinies/enumStore.js";

export default {
    name: 'App',
    data() {
        return {
            enumStore: useEnumStore()
        };
    },
    methods: {
    },
    mounted() {
       this.enumStore.getCurrenciesType();
    }
}
</script>

<style>

* {
    box-sizing: border-box;
    margin: 0;
}

</style>