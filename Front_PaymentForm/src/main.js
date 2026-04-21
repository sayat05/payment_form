import './assets/main.css';

import {createApp} from 'vue';
import App from './App.vue';
import {createPinia} from "pinia";
import components from '@/components/myUI/myUI.js';
import router from '@/myRouter.js';


const pinia = createPinia();

const app = createApp(App);
app.use(pinia);
components.forEach(component => {
    app.component(component.name, component)
});
app.use(router);
app.mount('#app');
