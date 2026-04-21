import {defineStore} from "pinia";

export const useWalletStore = defineStore('wallet', {
    state: () => ({
        wallet:{},
        wallets: [],

    }),
    actions: {},
});