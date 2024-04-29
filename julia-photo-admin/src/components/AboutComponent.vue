<template>
    <div>
        <template v-for="item in items">
            <div class="about">
                <div class="about__elem">
                    <div v-if="item.PhotoId != null">
                        <UIphoto :filename="item.Photo.Filename" class="about__photo"></UIphoto>
                    </div>
                    <div class="about__information">
                        <article :ref="'article' + item.Id" contenteditable="true">{{ item.Article }}</article>
                        <p :ref="'text' + item.Id" contenteditable="true">{{ item.Text }}</p>
                    </div>
                </div>
                <button @click="deleteItem(item)">Удалить</button>
                <button @click="editItem(item)">Изменить</button>
            </div>
        </template>

        <div class="generator">
            <input v-model="article" type="text" class="generator__article" placeholder="Article">
            <textarea v-model="text" class="generator__text"></textarea>
            <input ref="file" type="file" class="generator__file">
            <button class="generator__send" @click="addElement()">Добавить</button>
        </div>
    </div>
</template>


<script>
import axios from "axios";
import cfg from "@/cfg";
import PostedPhoto from "@/models/PostedPhoto";
export default {
    data() {return {
        items: [],
        article: "",
        text: "",
    }},

    mounted() {
        axios.get(cfg.serverUrl + "api/about")
        .then(r => this.items = r.data) 
    },

    methods: {
        getGUID() {
			return ([1e7]+-1e3+-4e3+-8e3+-1e11).replace(/[018]/g, c =>
				(c ^ crypto.getRandomValues(new Uint8Array(1))[0] & 15 >> c / 4).toString(16)
			);
		},
        async addElement()
        {
            let file = new FormData();
            let filename = this.$refs.file.name + this.getGUID()
            let body = {
                Article: this.article,
                Text: this.text,
                PhotoName: filename
            }
            if(this.$refs["file"].files[0] != null) {
                file.append("files", this.$refs["file"].files[0], filename)
                let photo = []
                await axios.get(cfg.serverUrl + "api/photoset/SystemPhotoSet").then( r => {
                    photo.push(new PostedPhoto(filename, "about", r.data))
                })
                await axios.post(cfg.serverUrl + "api/photo/files", file)
                await axios.post(cfg.serverUrl + "api/photo", photo)
            }
            await axios.post(cfg.serverUrl + "api/about", body)
        },
        async deleteItem(item) 
        {
            axios.delete(cfg.serverUrl + "api/about/" + item.Id);
            this.items.splice(
				this.items.findIndex(elem => elem.Id == item.Id), 1
			);
        },
        async editItem(item) 
        {
            let body = {
                Article: this.$refs["article" + item.Id][0].innerText,
                Text: this.$refs["text" + item.Id][0].innerText,
                PhotoName: "",
                Id: item.Id
            }
            axios.post(cfg.serverUrl + "api/about/edit", body);
        }
    }
}


</script>

<style lang="scss">
@import "../assets/variables.scss";

.about {
    
    margin-bottom: 20px;
}
.about__elem {
    display: flex;
}
.about__photo {
    width: calc(480px) ;
    height: 500px;
}
.about__information {
    width: 500px;
    margin-left: 20px;
}

.generator__article {
    margin-left: 50%;
    transform: translate(-50%);
    text-align: center;
}
.generator__text {
    width: 400px;
    resize: none;
    outline: none;
    transform: translate(-50%);
    margin-left: 50%;
    background-color: $bgc-window;
}
.generator__file {
    margin-left: 50%;
    transform: translate(-50%);
    display: block;
}
.generator__send {
    margin-left: 50%;
    transform: translate(-50%);
}
.generator__send:hover {
    margin-left: 50%;
    transform: translate(-50%) scale(1.02);
}
.generator__send:active {
    margin-left: 50%;
    transform: translate(-50%) scale(0.98);
}
</style>