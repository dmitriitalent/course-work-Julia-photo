<template>
    <div>
        <div class="workspace">
            <template v-for="typeElem in types">
                <router-link v-if="typeElem.PhotoSets[0]" class="price"  
                    :to="'photoSet?id=' + typeElem.PhotoSets[typeElem.PhotoSets.length - 1].Id"
                >
                    <UIphoto :filename="typeElem.PhotoSets[typeElem.PhotoSets.length - 1].Photos[0].Filename" 
                        class="price__photo"></UIphoto>
                    <div class="price__information">
                        <article class="price__article">
                            {{ typeElem.Type }}
                        </article>
                        <p class="price__description">
                            {{ typeElem.Description }}
                        </p>
                    </div>
                </router-link>
            </template>
        </div>
    </div>
</template>


<script>
import axios from "axios";
import cfg from "@/cfg";
export default {
    data() {return {
        types: [],
    }},
    mounted() {
        axios.get(cfg.serverUrl + "api/type")
        .then(r => {
            this.types = r.data.slice(1);
        })
    },
}
</script>


<style lang="scss">
@import  "../assets/variables.scss"; 

.workspace {
    width: 1000px!important
}
.price {
    display: flex;
    margin: 100px auto;
    transition: $transition-slow;
}
.price:hover {
    transform: scale(1.02);
}

.price__photo {
    height: 500px;
    width: 50%;
    margin-right: 30px;
}
.price__information {
    width: calc(50% - 30px);
    margin: auto 0px;
    text-align: justify;
}
.price__article {
    margin-top: 30px;
}
.price__description {
    margin: 0px auto;
}

// @media (max-width: 1000px)
// {
//     .price {
//         display: block;
//         float:left;

//         width: 50%;
//     }
//     .price__photo {
//         width: calc(100% - 10px);
//         margin: 0px auto;
//     }
//     .workspace {
//         display: inline;
//     }
//     .price__information {
//         width: calc(100% - 60px);
//         margin: 0px auto;
//     }
// }
@media (max-width: 1010px)
{
    .price {
        display: block;
        float: none;
        width: 600px;
    }
    .price__photo {
        width: calc(100% - 10px);
        margin: 30px auto;
    }
    .workspace {
        display: inline;
    }
    .price__information {
        width: calc(100% - 200px);
        margin: 0px auto;
    }
}
@media (max-width: 600px)
{
    .price {
        display: block;
        float: none;
        width: 400px;
    }
    .price__photo {
        width: calc(100% - 10px);
        margin: 30px auto;
    }
    .workspace {
        display: inline;
    }
    .price__information {
        width: calc(100% - 10px);
        margin: 0px auto;
    }
}

</style>