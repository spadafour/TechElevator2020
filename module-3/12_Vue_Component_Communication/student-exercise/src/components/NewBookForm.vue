<template>
    <form v-on:submit.prevent="addReview" class="new-book-form">
        <div>
            <label for="new-title">Title:</label>
            <input type="text" id="new-title" class="title-input" v-model="newReview.title"/>
        </div>
        <div>
            <label for="new-author">Author:</label>
            <input type="text" id="new-author" class="author-input" v-model="newReview.author"/>
        </div>
        <div>
            <label for="new-isbn">ISBN:</label>
            <input type="text" id="new-isbn" class="isbn-input" v-model="newReview.isbn"/>
        </div>
        <input type="submit" value="Save"/>
        <input type="button" value="Cancel" v-on:click="resetForm"/>
    </form>
</template>

<script>
export default {
    name: 'new-book-form',
    data() {
        return {
            newReview: {
                read: false
            }
        }
    },
    methods: {
        addReview() {
            this.$store.commit('ADD_REVIEW', this.newReview);
            this.resetForm();
        },
        resetForm() {
            this.newReview = { read: false };
        }
    }
}
</script>