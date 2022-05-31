import { FoodTypeApiClientInstance } from "../api/foodTypeApi";
import { FoodType } from "../classes/FoodType";
import { defineStore } from "pinia";

export const foodTypeStore = defineStore("foodType", {
    state: () => ({
        foodTypes: new Array<FoodType>(),
    }),
    actions: {
        async refreshFoodTypes() {
            const foodTypes =
                await FoodTypeApiClientInstance.GetFoodType("");
        }
    }
});