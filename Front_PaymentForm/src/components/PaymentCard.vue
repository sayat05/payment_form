<template>
    <div class="border !m-3 p-3 w-100">
        <p>Id: {{payment.id}}</p>
        <p>Wallet id: {{payment.walletId}}</p>
        <p>User email: {{payment.email}}</p>
        <p>Phone number: {{payment.phoneNumber}}</p>
        <p>Amount: {{ payment.amount}}</p>
        <p>Currency: {{payment.currency}}</p>
        <p>Status: {{payment.status}}</p>
        <p>Comment: {{payment.comment}}</p>
        <p>Created at: {{payment.createdAt}}</p>
    </div>
</template>

<script>
export default {
    name: "PaymentCard",
    props: {
        payment: {
            type: Object,
            required: true
        }
    }
}
</script>

<style scoped>

</style>