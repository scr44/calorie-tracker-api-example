<script setup lang="ts">
import { foodTypeStore } from '../stores/foodTypeStore';
import { storeToRefs } from "pinia";
import { onMounted } from 'vue';
import FoodTypeCard from './FoodTypeCard.vue';

const cards = [
    { id: 1, name: "Bowl of Strawberries", units: "bowl", caloriesPerUnit: "125" },
    { id: 2, name: "Chicken Breast", units: "gram", caloriesPerUnit: "1.65"}
]

const foodTypeStoreInstance = foodTypeStore();
const { foodTypes } = storeToRefs(foodTypeStoreInstance);

onMounted(async () => {
    await foodTypeStoreInstance.refreshFoodTypes();
});
</script>

<template>
<h1>Food List</h1>
<div class="list">
<FoodTypeCard
    v-for="card in cards"
        :key="card.id"
        :name="card.name"
        :units="card.units"
        :caloriesPerUnit="card.caloriesPerUnit"
    />
</div>
</template>

<style>
.list {
    display: flex;
    flex-direction: column;
}
</style>