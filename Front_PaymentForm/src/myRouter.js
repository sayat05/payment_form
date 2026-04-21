import {createRouter, createWebHistory} from "vue-router";

const routes = [
    {
        path: '/',
        name: 'HomePage',
        component: () => import('@/pages/HomePage.vue')
    },
    {
        path: '/users',
        name: 'UserPage',
        component: () => import('@/pages/users/UserPage.vue')
    },
    {
        path: '/wallets',
        name: 'WalletPage',
        component: () => import('@/pages/wallets/WalletPage.vue')
    },
    {
        path: '/payments',
        name: 'PaymentsPage',
        component: () => import('@/pages/payments/PaymentPage.vue'),
        children: [
            {
                path: '',
                name: 'PaymentDefaultPage',
                component: () => import('@/pages/payments/PaymentsDefaultPage.vue')
            },
            {
                path: 'add',
                name: 'PaymentAddPage',
                component: () => import('@/pages/payments/PaymentAddPage.vue')
            },
            {
                path: 'getById',
                name: 'PaymentGetByIdPage',
                component: () => import('@/pages/payments/PaymentGetByIdPage.vue')
            },
            {
                path: 'stats',
                name: 'PaymentStatsPage',
                component: () => import('@/pages/payments/PaymentStatsPage.vue')
            },
        ]
    }
];

const router = createRouter({
    history: createWebHistory(),
    routes
});

export default router;