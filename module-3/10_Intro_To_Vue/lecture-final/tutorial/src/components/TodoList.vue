<template>
  <div class="todo-list">
      <input type="text" v-model.lazy="todoTitle"></input>
      <input type="checkbox" name="permissions" value="w" v-model="permissions">
        <input type="checkbox" name="permissions" value="x" v-model="permissions">
        <input type="checkbox" name="permissions" value="d" v-model="permissions"><br/>
        <input type="checkbox" name="friday" value="d" v-model="isFriday"><br/>
        <input type="checkbox" name="monday" value="d" v-model="isMonday">
    <h1 v-if="isFriday">Happy Friday</h1>
    <h1 v-show="isMonday">Bummer, it's Monday</h1>
    <h1>{{todoTitle}}</h1>
    <ul>
        <li v-for="todo in todosArray" v-bind:key="todo.name">{{todo.name}}</li>
    </ul>
</div>
</template>

<script>
export default {
    data() {
        return {
            isMonday: false,
            isFriday: false,
            todoTitle: 'My Morning Routine',
            permissions:[],
            todosArray: [
                {
                name: 'Wake up'
                },
                {
                name: '5 Minute Morning Movement'
                },
                {
                name: 'Meditate'
                },
                {
                name: 'Brush Teeth'
                },
                {
                name: 'Shower'
                }       
            ]
        }
    }
}
</script>

<style>
.todo-list {
    width:450px;
    background: #fff;
    margin: 50px auto;
    font-family: 'Roboto Condensed', sans-serif;
    border-radius: 10px;
}
h1 {
    background:#f2f2f2;
    color:#4b86A6;
    padding:10px;
    font-size:24px;
    text-transform: uppercase;
    text-align: center;
    margin-bottom: 0px;
    border-top-left-radius: 10px;
    border-top-right-radius: 10px;
}
ul {
    list-style-type: none;
    margin:0px;
    padding:0px;
}
li {
    font-size: 24px;
    border-bottom:1px solid #f2f2f2;
    padding:10px 20px;
}
li:last-child{
    border:0px;
}
</style>