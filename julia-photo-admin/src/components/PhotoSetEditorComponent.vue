<template>
    <div>
        <div class="photos">
			<div class="photo" v-for="photo in photoSet" :key="photo.Id">
				<UIphoto :filename="photo.Filename" class="photo__preview"></UIphoto>
				<div class="photo__information">
					<div class="photo__filename photo__field"> 
                        Название файла: {{ photo.Filename }}
					</div>
					<div class="photo__type photo__field">
                        Тип фотосета: {{ photo.Alt }}
					</div>
					<div class="photo__buttons">
						<button class="photo__button" @click="deletePhoto(photo.Id)">Удалить</button>
					</div>
				</div>
			</div>
		</div>
    </div>
</template>


<script>
import axios from "axios";
import cfg from "@/cfg";
export default {
    data() { return {
        photoSet: [],
    }},
    mounted() {
        axios.get(cfg.serverUrl + "api/photoSet/" + this.$route.query.id)
        .then(response => {
            this.photoSet = response.data.Photos;
        });
    },
    methods: {
        deletePhoto(photoId) {
			axios.delete(cfg.serverUrl + "api/photo/" + photoId)
			this.photoSet.splice(
				this.photoSet.findIndex(elem => elem.Id == photoId), 1
			);
			if(this.photoSet.length == 0)
			{
				axios.delete(cfg.serverUrl + "api/photoSet/" + this.$route.query.id)
			};
		},
    }
}
</script>


<style lang="scss">
@import "../assets/variables.scss";

.photo {
	margin: 30px auto;
	display: flex;
	text-decoration: none;
	color: $color;
}

.photo__preview
{
	width: 400px;
	height: 400px;
}
.photo__information {
	width: 570px;
	margin-left: 30px;
}
.photo__field {
	margin: 20px;
}
.photo__button {
	margin: 0px 10px;
}
</style>