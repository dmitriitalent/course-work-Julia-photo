<template>
    <div>
        <div class="column" v-for="column in range(columns)">
            <UIphoto 
                v-for="photo in photoList[column]" 
                :key="photo.Id"
                :filename="photo.Filename"  
                class="column__photo"/>
        </div>
    </div>
</template>


<script>
import axios from "axios";
import cfg from "@/cfg";

export default {
    data() {return {
        photoList: [],
        columns: 0,
    }},
    methods: {
        range(length, startWith = 0) {
            let arr = [];
            for (let i = 0; i < length; i++) {
                arr[i] = i+startWith;
            }
            return arr;
        },
        cut(photoList, parts) 
        {
            let columnsLength = [];
            let columns = [];
            for(let i = 0; i < parts; i++)
            {
                columnsLength[i] = 0;
                columns[i] = [];
            }

            for(let i = 0; i < photoList.length; i++)
            {
                let lowestIndex = this.getLowestIndex(columnsLength);
                columns[lowestIndex].push(photoList[i]);
                columnsLength[lowestIndex] += photoList[i].Height/photoList[i].Width;
            }
            console.log(columnsLength)
            return columns;
        },
        append(photoList, arr) 
        {
            let columnsLength = [];

            for(let i = 0; i < photoList.length; i++)
            {
                columnsLength[i] = 0;
                photoList[i].forEach(element => {
                    columnsLength[i] += element.Height / element.Width
                });
            }
            arr.forEach(element => {
                photoList[this.getLowestIndex(columnsLength)].push(element)
                columnsLength[this.getLowestIndex(columnsLength)] += element.Height / element.Width;
            });
            return photoList;
        },
        getLowestIndex(arr) 
        {
            let lowestIndex = 0;
            for(let i = 0; i < arr.length; i++)
            {
                if(arr[i] < arr[lowestIndex])
                {
                    lowestIndex = i;
                }
            }
            return lowestIndex;
        }
    },
    
    watch: {
        columns(newValue) {
            this.photoList = this.cut(this.photoList.flat(), newValue);
        }
    },
    mounted() {
        if(window.innerWidth >= 1200) {this.$data.columns = 4}
        else if(window.innerWidth >= 800) {this.$data.columns = 3}
        else if(window.innerWidth >= 500) {this.$data.columns = 2}
        else {this.$data.columns = 1}
        window.addEventListener("resize", event => {
            if(window.innerWidth >= 1200) {this.$data.columns = 4}
            else if(window.innerWidth >= 800) {this.$data.columns = 3}
            else if(window.innerWidth >= 500) {this.$data.columns = 2}
            else if (window.innerWidth >= 1) {this.$data.columns = 1}
        });

        axios.get(cfg.serverUrl + "api/photoSet/" + this.$route.query.id).then(response => {
            this.photoList = this.cut(response.data.Photos, this.columns);
        });
    }
}
</script>


<style lang="scss">
@import "../assets/variables.scss";

.column {
    width: calc(25%);
    box-sizing: border-box;
    border: 5px solid $bgc-main;
    float: left;
}

@media (max-width: 1200px) { 
    .column {
        width: calc(33.333%);
        float: left;
    }
}
@media (max-width: 800px) { 
    .column {
        width: calc(50%);
        float: left;
    }
}
@media (max-width: 500px) { 
    .column {
        width: calc(100%);
        float: left;
    }
}
// @media (min-width: 0px) { 
//     .column {
//         width: calc(100% - 10px);
//         margin: 5px;
//         float: left;
//     }
// }
.column__photo {
    width: 100%;
    margin-bottom: 10px;
}

</style>