<template>
    <div>
        <header>
            <nav class="nav">
                <router-link to="/"><button class="nav__button">welcome</button></router-link>
                <router-link to="photoSet"><button class="nav__button">Фотосеты</button></router-link>
                <router-link to="types"><button class="nav__button">Типы</button></router-link>
                <router-link to="about"><button class="nav__button">Обо мне</button></router-link>
            </nav>
        </header>
    </div>
</template>


<script>
export default {
    
}
</script>


<style lang="scss" scoped>


.nav {
    display: flex;
    justify-content: center;
}
.nav__button {
    margin: 5px;
}

</style>