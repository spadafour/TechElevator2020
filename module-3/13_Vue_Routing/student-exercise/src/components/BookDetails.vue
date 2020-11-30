<template>
  <div>
      <h2>{{book.title}}</h2>
      <h3>{{book.author}}</h3>
      <img v-if="book.isbn" v-bind:src="'http://covers.openlibrary.org/b/isbn/' + book.isbn + '-M.jpg'" />
      <p>{{book.read==true ? "I have read this book" : "I have not read this book"}}</p>
  </div>
</template>

<script>
export default {
    name: 'bookDetails',
    props: ['book']
};
</script>

<style>

</style>