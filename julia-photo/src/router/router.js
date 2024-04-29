import MainComponent from "@/components/main.vue";
import PriceComponent from "@/components/price.vue";
import PhotoSetComponent from "@/components/photoSet.vue";
import ReviewsComponent from "@/components/reviews.vue";
import ContactsComponent from "@/components/contacts.vue";
import AboutComponent from "@/components/about.vue";

import { createRouter, createWebHistory } from "vue-router";

const routes = [
    {
        path: "/",
        component: MainComponent
    },
    {
        path: "/price",
        component: PriceComponent
    },
    {
        path: "/photoSet",
        component: PhotoSetComponent
    },
    {
        path: "/contacts",
        component: ContactsComponent
    },
    {
        path: "/about",
        component: AboutComponent
    }
    
]

const router = createRouter({routes, history: createWebHistory()});

export default router;
