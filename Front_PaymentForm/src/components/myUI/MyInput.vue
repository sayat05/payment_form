<template>
    <input :value="modelValue"
           @input="updateInput"
           type="text"
           class="p-2 border border-gray-200 outline-none rounded">
</template>

<script>
export default {
    name: 'MyInput',
    props: {
        modelValue: [String, Number],
    },
    methods: {
        updateInput(newVal) {
            this.$emit('update:modelValue', newVal.target.value)
        }
    }
}
</script>

<style scoped>

</style>