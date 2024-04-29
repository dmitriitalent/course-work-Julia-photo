<template>
    <img :src="serverUrl + 'photo/' + filename + '.png'">
</template>


<script>
import cfg from "@/cfg";
export default {
    name: "UIphoto",
    data() {return {
        serverUrl: cfg.serverUrl, 
    }},
    props: { 
        filename: {
            type: String,
            required: true,
        },
    }
}
</script>


<style lang="scss">
img {
    object-fit:cover;
    display: block;
    max-width: 100vw;
    max-height: 100vh;
}
</style>