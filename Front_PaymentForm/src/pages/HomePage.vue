<template>
    <div>
        <h1 class="text-3xl text-center !m-5"> Дефолтная страница</h1>
        <div class="flex flex-col justify-center items-center gap-5 border rounded p-3 w-100 !mx-auto">
            <my-button @click="toPayments">Платежи</my-button>
            <my-button @click="toUsers">Пользователи</my-button>
            <my-button @click="toWallets">Счета</my-button>
        </div>
    </div>

</template>

<script>
import router from "@/myRouter.js";

export default {
    name: "HomePage",
    methods: {
        toPayments() {
            router.push('/payments')
        },
        toUsers() {
            router.push('/users')
        },
        toWallets() {
            router.push('/wallets')
        }
    }
}
</script>


<style scoped>

</style>