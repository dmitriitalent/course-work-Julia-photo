<template>
    <div>
        <div class="workspace">
            <template v-for="item in items">
                <div class="about">
                    <div v-if="item.PhotoId != null">
                        <UIphoto :filename="item.Photo.Filename" class="about__photo"></UIphoto>
                    </div>
                    <div class="about__information">
                        <div class="about__dws">
                            <article>{{ item.Article }}</article>
                            <p>{{ item.Text }}</p>
                        </div>
                    </div>
                </div>
            </template>
        </div>
    </div>
</template>
<script>
import axios from "axios";
import cfg from "@/cfg";
export default {
    data() {return {
        items: [],
    }},

    mounted() {
        axios.get(cfg.serverUrl + "api/about")
        .then(r => this.items = r.data) 
    }, 
}
</script>
<style scoped lang="scss">
.workspace {
    height: calc(100% + 50px);
}
.about {
    display: flex;
    margin-bottom: 70px;
}
.about__photo {
    width: 480px;
    height: 500px;
}
.about__information {
    width: 500px;
    height: 500px;
    margin-left: 20px;
    margin-top: 20px;
}
.about__dws {
    margin-top: 50%;
    transform: translate(0, -50%);
}

@media (max-width: 1200px) {
    .about {
        display: block;
        width: 500px;
        margin: 30px auto;
    }
    .about__dws {
        margin-top: 0px;
        transform: translate(0, 0);
    }
    .about__information {
        width: 500px;
        height: auto;
        margin-left: 0px;
    }
    .about__photo {
        width: 500px;
        height: 500px;
    }
}

</style>