<template>
  <HeaderComponent></HeaderComponent>
  <div class="workspace wrapper">
    <RouterView></RouterView>
  </div>
</template>

<script>
import WelcomeComponent from './components/WelcomeComponent.vue';
import HeaderComponent from './components/HeaderComponent.vue';
export default {
  components: {
    HeaderComponent
  }
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
  transition: 0.07s;
  height: 60px;
  width: 200px;
  outline: none;
  background-color: $bgc-window;
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
  margin-top: 30px;
  margin-left: auto;
  margin-right: auto;
}
article {
  margin: 30px auto 30px auto;
  text-align: center;
  max-width: 500px;
  font-family: $font-family-default;
  font-weight: $font-weight-light;
  font-size: $font-size-large;
}
input {
  font-family: $font-family-default;
  font-weight: $font-weight-default;
  font-size: $font-size-default;
  transition: 0.07s;
  height: 60px;
  width: 400px;
  margin-top: 10px;
  margin-bottom: 10px;
  background-color: $bgc-window;
  border: $border-default;
}
select {
	font-family: $font-family-default;
	font-weight: $font-weight-default;
	font-size: $font-size-default;
	transition: 0.07s;
	height: 60px;
	width: 400px;
	margin-top: 10px;
	margin-bottom: 10px;
	background-color: $bgc-window;
	border: $border-default;
}
textarea {
  width: 400px;
  height: 300px;
  font-family: $font-family-default;
	font-weight: $font-weight-default;
	font-size: $font-size-default;
  border: $border-default;
}

</style>
