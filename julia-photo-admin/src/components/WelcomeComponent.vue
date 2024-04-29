<template>
    <div>
        <article>Нажми на фото чтобы его заменить</article>
        <div class="gridPhotos">
            <label for="filePhoto1"><UIphoto filename="file1" class="gridPhoto1 gridPhoto"></UIphoto></label>
            <label for="filePhoto2"><UIphoto filename="file2" class="gridPhoto2 gridPhoto"></UIphoto></label>
            <label for="filePhoto3"><UIphoto filename="file3" class="gridPhoto3 gridPhoto"></UIphoto></label>
            <input type="file" class="filePhoto" id="filePhoto1" ref="filePhoto1" @change="handlerFileUpload(1)"/>
            <input type="file" class="filePhoto" id="filePhoto2" ref="filePhoto2" @change="handlerFileUpload(2)"/>
            <input type="file" class="filePhoto" id="filePhoto3" ref="filePhoto3" @change="handlerFileUpload(3)"/> 
        </div>
        <button class="submitButton" @click="saveChanges()">Сохранить</button>

    </div>
</template>
<script>
import axios from "axios";
import cfg from "@/cfg";
import PostedPhoto from "@/models/PostedPhoto"
export default {
    data() {return {
        file1: "",
        file2: "",
        file3: "",
    }},
    methods: {
        handlerFileUpload(fileNumber) {
            for(let i = 1; i < 4; i++) {
                if(fileNumber == i) {
                    this.$data["file"+i] = this.$refs['filePhoto'+i].files[0];
                }
            }            
        },

        async saveChanges() {
            let files = new FormData();
            let body = [];

            let SystemPhotoSetId = 1;
            await axios.get(cfg.serverUrl + "api/PhotoSet/SystemPhotoSet")
            .then(response => {
                SystemPhotoSetId = response.data;
            });
            for(let i = 1; i < 4; i++)
            {
                if (this.$data["file"+i] == "")
                {
                    continue
                }
                files.append("files", this.$data["file"+i], "file"+i);

                let pp = new PostedPhoto("file"+i, "Welcome", SystemPhotoSetId); 
                body.push(pp);
            }
            await axios.post(
                cfg.serverUrl + "api/photo/files",
                files,
                {
                    headers: {
                        "Content-Type" : "multipart/form-data"
                    }
                }
            ).catch(err => {
                console.log(err.response);
            });
            
            await axios.post(
                cfg.serverUrl + "api/photo",
                body
            ).catch(err => {
                console.log(err.response);
            });

            
        }
    }
}

</script>


<style lang="scss" scoped>
@import "../assets/variables.scss";

.gridPhotos {
    display: flex;
    justify-content: space-around;
}
.gridPhoto {
    height: 400px;
    border: $border-default;
}
input {
    margin-left: 50%;
    transform: translate(-50%);
    text-align: center;
}
input:hover {
    transform: translate(-50%), scale(1.02);
}
input:active {
    transform: translate(-50%), scale(0.98);
}
.filePhoto {
    display: none;
}
.submitButton {
    margin-top: 30px;
    margin-left: 50%;
    transform: translate(-50%);
    text-align: center;
    border: $border-default;
    border-radius: $border-radius-default;
}
.submitButton:hover {
    transform: translate(-50%) scale(1.02);
}
.submitButton:active {
    transform: translate(-50%) scale(1.02);
}

</style>