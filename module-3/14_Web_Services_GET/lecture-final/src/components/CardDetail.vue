<template>
  <div>
    <h1>{{ card.title }}</h1>
    <p>{{card.description}}</p>
    <div class="loading" v-if="isLoading">
      <img src="../assets/ping_pong_loader.gif" />
    </div>
    <comments-list v-bind:comments="card.comments" v-else/>
  </div>
</template>

<script>
import boardService from '@/services/BoardService'
import CommentsList from '@/components/CommentsList'

export default {
  name: "card-detail",
  components: {
    CommentsList
  },
  data() {
    return {
      card: {},
      isLoading: true
    }
  },
  created() {
    boardService.getCard(this.$route.params.boardID,this.$route.params.cardID)
    .then(cardSelected => {
      this.card = cardSelected;
      this.isLoading = false;
    })
  }
};
</script>
