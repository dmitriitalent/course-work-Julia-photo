<template>
    <div>
        <template v-for="typeElem in types">
            <div class="type">
                <div class="type__elem">
                    <UIphoto v-if="typeElem.PhotoSets[0] != null" :filename="typeElem.PhotoSets[typeElem.PhotoSets.length - 1].Photos[0].Filename" 
                        class="type__photo"></UIphoto>
                    <div class="type__information">
                        <article class="type__article" :ref="'type' + typeElem.Id" contenteditable="true">
                            {{ typeElem.Type }}
                        </article>
                        <p class="type__description" :ref="'description' + typeElem.Id" contenteditable="true">
                            {{ typeElem.Description }}
                        </p>
                    </div>
                </div>
                <button @click="deleteItem(typeElem)">Удалить</button>
                <button @click="editItem(typeElem)">Изменить</button>
            </div>
        </template>

        <div class="generator">
            <input v-model="type" type="text" class="generator__article" placeholder="Название типа">
            <textarea v-model="description" class="generator__text" placeholder="Описание"></textarea>
            <button class="generator__send" @click="addElement()">Добавить</button>
        </div>
    </div>
</template>


<script>
import axios from "axios";
import cfg from "@/cfg";
export default {
    data() {return {
        types: [],
        type: "",
        description: "",
    }},

    mounted() {
        axios.get(cfg.serverUrl + "api/Type")
		.then(r => {
			this.types = r.data.slice(1);
		});
    },
    
    methods: {
        getGUID() {
			return ([1e7]+-1e3+-4e3+-8e3+-1e11).replace(/[018]/g, c =>
				(c ^ crypto.getRandomValues(new Uint8Array(1))[0] & 15 >> c / 4).toString(16)
			);
		},
        async addElement()
        {
            let body = {
                Id: 0,
                Type: this.type,
                Description: this.description,
            }
            
            await axios.post(cfg.serverUrl + "api/Type", body)
            
        },
        async deleteItem(item) 
        {
            axios.delete(cfg.serverUrl + "api/type/" + item.Id);
            this.types.splice(
				this.types.findIndex(elem => elem.Id == item.Id), 1
			);
        },
        async editItem(item) 
        {
            let body = {
                Type: this.$refs["type" + item.Id][0].innerText,
                Description: this.$refs["description" + item.Id][0].innerText,
                Id: item.Id
            }
            axios.post(cfg.serverUrl + "api/type/edit", body);
        }
    }
}
</script>


<style lang="scss">
    
@import "../assets/variables.scss";

.type {
    margin-bottom: 20px;
}
.type__elem {
    display: flex;
}
.type__photo {
    width: calc(480px) ;
    height: 500px;
}
.type__information {
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