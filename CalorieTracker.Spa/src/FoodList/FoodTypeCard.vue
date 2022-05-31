<script setup lang="ts">
defineProps(['name', 'units', 'caloriesPerUnit'])
</script>

<template>
<div class="card">
    <div class="name">{{name}}</div>
    <div class="card-contents">
        <div class="units">1 {{units}}</div>
        <div class="calories-per-unit">{{caloriesPerUnit}} calories</div>
    </div>
</div>
</template>

<style>
.card {
    width: 12rem;
    border-style: solid;
    border-radius: .5rem;
    border-width: 2px;
    border-color: gray;
    padding: 1rem;
    margin-bottom: 1rem;
}
.card-contents {
    display: flex;
    flex-direction: row;
    flex-grow: 1;
    padding-top: 1rem;
    justify-content: center;
}
.calories-per-unit {
    padding-left: 1rem;
}
</style>