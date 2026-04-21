import {createRouter, createWebHistory} from "vue-router";

const routes = [
    {
        path: '/users',
        name: 'UserPage',
        component: () => import('@/pages/UserPage.vue')
    },
    {
        path: '/wallets',
        name: 'WalletPage',
        component: () => import('@/pages/WalletPage.vue')
    },
    {
        path: '/payments',
        name: 'PaymentsPage',
        component: () => import('@/pages/PaymentPage.vue')
    }
];

const router = createRouter({
    history: createWebHistory(),
    routes
});

export default router;