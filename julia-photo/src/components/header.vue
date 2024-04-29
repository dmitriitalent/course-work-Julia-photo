<template>
    <div>
        <header class="unselectable" id="bigHeader" v-show="bigHeaderVisible">
            <div class="welcome-box">
                <div class="welcome">WELCOME</div>
            </div>
            <div class="grid">
                <UIphoto filename="file1" class="grid__photo firstPhoto"/>
                <UIphoto filename="file2" class="grid__photo secondPhoto"/>
                <UIphoto filename="file3" class="grid__photo thirdPhoto"/>
            </div>
        </header>
        <header :class="menuIsOpen ? 'smallHeader smallHeader_open unselectable' : 'smallHeader unselectable'" @click="toogleMenu()">
            <router-link to="/">
                <button :class="menuIsOpen ? 'smallHeader__button smallHeader__button_open' : 'smallHeader__button'">главная</button>
            </router-link>
            <router-link to="/price">
                <button :class="menuIsOpen ? 'smallHeader__button smallHeader__button_open' : 'smallHeader__button'">расценки</button>
            </router-link>
            <!-- <router-link to="/reviews">
                <button :class="menuIsOpen ? 'smallHeader__button smallHeader__button_open' : 'smallHeader__button'">отзывы</button>
            </router-link> -->
            <router-link to="/contacts">
                <button :class="menuIsOpen ? 'smallHeader__button smallHeader__button_open' : 'smallHeader__button'">контакты</button>
            </router-link>
            <router-link to="/about">
                <button :class="menuIsOpen ? 'smallHeader__button smallHeader__button_open' : 'smallHeader__button'">обо мне</button>
            </router-link>
            <img src="../assets/menu-button_icon-icons.com_72989.png" :class="menuIsOpen ? 'smallHeader__menuIco_open' : 'smallHeader__menuIco'">
        </header>
    </div>
</template>


<script>
export default {
    data() {return {
        bigHeaderVisible: true,
        menuIsOpen: false,
    }},
    methods: {
        toogleMenu() 
        {
            if(window.innerWidth < 800) {
                this.menuIsOpen = !this.menuIsOpen;
            }
        }
    },
    mounted() {
        window.addEventListener("resize", event => {
            if(window.innerWidth >= 800) {
                this.menuIsOpen = false;
            }
        })
        let bh = document.querySelector("#bigHeader");
        document.addEventListener("scroll", event => {
            if(window.pageYOffset > bh.offsetHeight)
            {
                window.pageYOffset = 0;
                this.bigHeaderVisible = false;
            }
        })
    }
}
</script>


<style lang="scss" scope>
@import '../assets/variables.scss';

#bigHeader {
    height: calc(100vh - 10px);
    position: relative;
}
.welcome-box {
    padding: 40px;
    position: absolute;
    left: 50%;
    top: 50%;
    transform: translate(-50%,-50%);
    border-radius: $border-radius-default;
    background-color: $bgc-main;
}
.welcome {
    font-size: $font-size-larger;
}
@media (max-width: 500px) {
    .welcome {font-size: $font-size-large;}
    .welcome-box { padding: 10px;}
}

.grid { 
    display: grid;
    height: calc(100vh - 10px);
    border: 5px solid $bgc-main;
    grid-template-columns: 1fr;
    grid-template-rows: 1fr 1fr;
}
.grid__photo {
    border: 5px solid $bgc-main;
    box-sizing: border-box;
}


.firstPhoto {
    display: none;
}
.thirdPhoto {
    height: calc(50vh - 10px);
    width: 100%;
}
.secondPhoto {
    height: 50vh;
    width: 100%;
}

@media (min-width: 1200px) {
    .grid { 
        grid-template-columns: 1fr 2fr;
        grid-template-rows: 1fr 1fr;
    }
    .firstPhoto {
        display: block;
        grid-row-start: 1;
        grid-row-end: 3;
        height: calc(100vh - 10px);
        width: 100%;
    }
    .secondPhoto {
        grid-column-start: 2;
        grid-column-end: 3;
        grid-row-start: 1;
        grid-row-end: 1;
        height: 50vh;
        width: 100%;
    }
    .thirdPhoto {
        grid-column-start: 2;
        grid-column-end: 3;
        grid-row-start: 2;
        grid-row-end: 2;
        height: calc(50vh - 10px);
        width: 100%;
    }
}

.smallHeader {
    display: flex;
    justify-content: center;
    height: 100px;
    box-shadow: 0px 2px 10px $bgc-shadow;
}


.smallHeader__button {
    margin-top: 20px;
    margin-left: 5px;
    margin-right: 5px;
    background-color: inherit;
    font-size: $font-size-small;
}

.smallHeader__menuIco {
    display: none;
}

@media (max-width: 800px) {
    .smallHeader__button {
        display: none;
    }
    .smallHeader {
        height: 60px;
    }
    .smallHeader__menuIco {
        display: block;
        height: 30px;
        margin-top: auto;
        margin-bottom: auto;
        opacity: 0.3;
    }
    .smallHeader__button_open {
        display: block;
        margin: 0px auto;
        width: 100%
    }
    .smallHeader_open {
        display: block;
        height: auto;
    }
    .smallHeader__menuIco_open {
        display: none;
    }
}


</style>