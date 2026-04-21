<template>
    <select :value="modelValue"
            @change="changeOptions"
            required
            class="w-4/6 p-2 cursor-pointer outline-none border border-gray-200 rounded">
        
        <option class="text-[#A9A9A9]" value="" disabled selected>select the {{ name }}</option>
        <option v-for="item in items" :key="item" :value="item">{{ item }}</option>
    </select>
</template>

<script>
export default {
    name: "MySelect",
    props: {
        modelValue: {
            type: Object,
            required: true
        },
        items: {
            type: Array,
            required: true
        },
        name: {
            type: String,
            required: true
        }
    },
    methods: {
        changeOptions(event) {
            this.$emit('update:modelValue', event.target.value);
        }
    }
}
</script>

<style scoped>

</style>