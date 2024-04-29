<template>
	<div>
		<input type="file" multiple ref="files">
		<select v-model="type">
			<option v-for="typeElem in types" :value="typeElem.Type">{{ typeElem.Type }}</option>
		</select>
		<button class="submitButton" @click="saveChanges()">Сохранить</button>
		
		<div class="photoSets">
			<routerLink class="photoSet" v-for="photoSet in photoSets" :key="photoSet.Id" :to="'photoSetEditor?id=' + photoSet.Id">
				<UIphoto :filename="photoSet.Photos[0].Filename" class="photoSet__preview"></UIphoto>
				<div class="photoSet__information">
					<div class="photoSet__date photoSet__field"> Дата загрузки: 
						{{ 
							photoSet.Date.slice(0,10).split("-")[2] + "." +
							photoSet.Date.slice(0,10).split("-")[1] + "." +
							photoSet.Date.slice(0,10).split("-")[0]
						}}
					</div>
					<div class="photoSet__type photoSet__field">
						Тип фотосессии: {{ photoSet.PhotoSetType.Type }}
					</div>
					<div class="photoSet__buttons">
						<button class="photoSet__button" @click.prevent="deletePhotoSet(photoSet.Id)">Удалить</button>
					</div>
				</div>
			</routerLink>
		</div>		
	</div>
</template>


<script>
import axios from "axios";
import cfg from "@/cfg";
import PostedPhoto from "@/models/PostedPhoto"
 
export default {
	data () {return {
		fileMessage: "Перетащи сюда файлы",
		type: "",
		types: [],
		photoSets: []
	}},

	mounted() {
		axios.get(cfg.serverUrl + "api/Type")
		.then(r => {
			this.types = r.data.slice(1);
		});

		axios.get(cfg.serverUrl + "api/photoset/all")
		.then(response => {
			this.photoSets = response.data.slice(1);
		})
	},
	methods: {
		deletePhotoSet(photoSetId) {
			axios.delete(cfg.serverUrl + "api/photoSet/" + photoSetId)
			this.photoSets.splice(
				this.photoSets.findIndex(photoSet => photoSet.Id == photoSetId), 1
			);
		},
		getGUID() {
			return ([1e7]+-1e3+-4e3+-8e3+-1e11).replace(/[018]/g, c =>
				(c ^ crypto.getRandomValues(new Uint8Array(1))[0] & 15 >> c / 4).toString(16)
			);
		},
		saveChanges() {
			
			let files = new FormData();
			let postedPhotos = []

			for(let index = 0; index < this.$refs['files'].files.length; index++)
			{
				let GUID = this.getGUID();
				let filename =  this.$refs['files'].files[index].name + GUID;
				files.append("files", this.$refs['files'].files[index], filename);
				
				let photo = new PostedPhoto(filename, this.type, null)
				postedPhotos.push(photo);
			}

			axios.post(
				cfg.serverUrl + "api/photo/files",
				files,
				{
					headers: {
						"Content-Type" : "multipart-form-data"
					}
				}
			).then(r => {
				if(r.data == "OK") {
					axios.post(
						cfg.serverUrl + "api/photoSet/" + this.type,
						postedPhotos
					)
				}
			})
			.then(r => {
				alert("Фотосет успешно добавлен");
			}) 
			.catch(err => {
				console.log(err.data);
			})
		}
	}
}
</script>


<style lang="scss" scoped>
@import "../assets/variables.scss";

select, input {
	margin-left: 50%;
    transform: translate(-50%);
    text-align: center;
}

.filesLabel {
	display: block;
	height: 60px;
	width: 400px;
	margin: 0px auto;
	border: $border-default;
	background-color: $bgc-window;
	font-family: $font-family-default;
  	font-weight: $font-weight-default;
  	font-size: $font-size-default;
    text-align: center;
}
.submitButton {
    margin-top: 30px;
    margin-left: 50%;
    transform: translate(-50%);
    text-align: center;
    border: $border-default;
    border-radius: $border-radius-default;
}

.photoSet {
	margin: 30px auto;
	display: flex;
	text-decoration: none;
	color: $color;
}

.photoSet__preview
{
	width: 400px;
	height: 400px;
}
.photoSet__information {
	width: 570px;
	margin-left: 30px;
}
.photoSet__field {
	margin: 20px;
}
.photoSet__button {
	margin: 0px 10px;
}


</style>