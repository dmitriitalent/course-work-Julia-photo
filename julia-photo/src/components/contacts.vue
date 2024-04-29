<template>
    <div>
        <div class="workspace">
            <div class="contacts">
                <a href="https://t.me/juliabelova?text=Здравствуйте, я бы хотел(-a) записаться на фотосессию.">
                    <button class="contacts__button contacts__telegram">
                    <!-- <img src="" alt="" class="contacts__ico"> -->
                        Telegram
                    </button>
                </a>
                <a href="https://wa.me/79629480725?text=Здравствуйте, я бы хотел(-a) записаться на фотосессию.">
                    <button class="contacts__button contacts__whatsapp">
                    <!-- <img src="" alt="" class="contacts__ico"> -->
                        Whatsapp
                    </button>
                </a>
                <a href="https://www.instagram.com/homa.creative/">
                    <button class="contacts__button contacts__instagram">
                    <!-- <img src="" alt="" class="contacts__ico"> -->
                        Instagram
                    </button>
                </a>
                <a href="https://vk.com/julia__belova">
                    <button class="contacts__button contacts__vk">
                    <!-- <img src="" alt="" class="contacts__ico"> -->
                        ВКонтакте
                    </button>
                </a>
                <a href="tel:+79629480725">
                    <button class="contacts__button contacts__number">
                    <!-- <img src="" alt="" class="contacts__ico"> -->
                        +7 962 948 0725
                    </button>
                </a>

            </div>
        </div>
    </div>
</template>
<script>
export default {
    
}
</script>
<style lang="scss">
@import "../assets/variables.scss";

.workspace {
    width: 600px;
    height: calc(100vh - 120px);
}

.contacts__button {
    display: block;
    width: 90%;
    background-color: #fff;
    margin: 30px auto;
    border-radius: $border-radius-default;
    background-color: $bgc-window;
    box-shadow: 0px 0px 10px 3px $bgc-shadow;
    outline: $border-default;
    text-transform: none;
    transition: $transition-default;
}

.contacts__whatsapp:hover {
    box-shadow: 0px 0px 30px 10px #17d82d;
    outline-color: #17d82d;
}
.contacts__telegram:hover {
    box-shadow: 0px 0px 30px 10px #6ec5fb;
    outline-color: #6ec5fb;
}
.contacts__vk:hover {
    box-shadow: 0px 0px 30px 10px #41a1dd;
    outline-color: #41a1dd;
}
.contacts__instagram:hover {
    box-shadow: 0px 0px 30px 10px #fb6edf;
    outline-color: #fb6edf;
}
.contacts__number:hover {
    box-shadow: 0px 0px 30px 10px #edf34b;
    outline-color: #edf34b;
}
</style>