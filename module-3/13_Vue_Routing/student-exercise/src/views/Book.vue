<template>
  <div>
    <book-details v-bind:book="book" />
  </div>
</template>

<script>
import BookDetails from "@/components/BookDetails";

export default {
  computed: {
    book() {
      return this.$store.state.books.find((b) => {
        return b.isbn == this.$route.params.isbn;
      });
    },
  },
  components: {
    BookDetails,
  },
};
</script>

<style>
</style>