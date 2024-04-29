<template>
  <div class="wrapper">
    <headerComponent></headerComponent>
    <RouterView class="content"></RouterView>
  </div>
</template>


<script>
import headerComponent from "@/components/header.vue"
export default{
  components: {headerComponent}
}
</script>


<style lang="scss">
@import './assets/variables.scss';
.wrapper {
  font-family: $font-family-default; 
  font-weight: $font-weight-default;
  font-size: $font-size-default;
}
.unselectable {
    -moz-user-select: -moz-none;
    -khtml-user-select: none;
    -webkit-user-select: none;
    -o-user-select: none;
    user-select: none;
}

button {
  font-family: $font-family-default;
  font-weight: $font-weight-default;
  font-size: $font-size-default;
  text-transform: uppercase;
  border: none;
  transition: $transition-fast;
  height: 60px;
  width: 190px;
  outline: none;
}
button:hover {
  transform: scale(1.02);
}
button:active {
  transform: scale(0.98);
}
.workspace {
  width: 1000px;
  margin-left: auto;
  margin-right: auto;
}
.content {
  margin-top: 10px;
  margin-left: auto;
  margin-right: auto;
  padding: 0px 5px;
}
article {
  margin: 0px auto 30px auto;
  text-align: center;
  max-width: 500px;
  font-family: $font-family-default;
  font-weight: $font-weight-light;
  font-size: $font-size-large;
}
router-link, a { 
  text-decoration: none;
  color: $color;
}

</style>
