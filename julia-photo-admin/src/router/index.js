import { createRouter, createWebHistory } from 'vue-router';
import WelcomeComponent from "@/components/WelcomeComponent.vue";
import PhotoSetComponent from "@/components/PhotoSetComponent.vue";
import PhotoSetEditorComponent from "@/components/PhotoSetEditorComponent.vue";
import AboutComponent from "@/components/AboutComponent.vue";
import TypeComponent from "@/components/TypeComponent.vue";


const routes = [
  {
    path: "/",
    component: WelcomeComponent
  },
  {
    path: "/photoSet",
    component: PhotoSetComponent
  },
  {
    path: "/photoSetEditor",
    component: PhotoSetEditorComponent
  },
  {
    path: "/about",
    component: AboutComponent
  },
  {
    path: "/types",
    component: TypeComponent
  }
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router
