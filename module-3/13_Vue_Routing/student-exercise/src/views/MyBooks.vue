<template>
  <div>
    <reading-list/>
    <router-link v-bind:to="{name: 'addBook'}">Add Book to Reading List</router-link>
  </div>
</template>

<script>
import ReadingList from '@/components/ReadingList'

export default {
    name: 'myBooks',
    components: {
        ReadingList
    }
};
</script>

<style>

</style>