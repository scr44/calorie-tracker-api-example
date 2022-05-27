import App from "./App.vue";
import HelloWorld from "./components/HelloWorld.vue";
import FoodList from "./FoodList/FoodList.vue";
import { createRouter, createWebHashHistory } from "vue-router";

const routes = [
    {
        name: "CalorieTracker",
        path: "/",
        components: {
            default: App
        },
        children: [
            {
                name: "Hello World",
                path: "hello-world",
                component: HelloWorld,
                props: { pageTitle: "Hello, World" }
            },
            {
                name: "Food List",
                path: "food-list",
                component: FoodList,
                props: { pageTitle: "Foods" }
            }
        ]
    }
]

export const router = createRouter({
    history: createWebHashHistory(),
    routes,
})