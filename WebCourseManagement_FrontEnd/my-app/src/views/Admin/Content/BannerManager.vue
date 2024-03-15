<template>
  <v-card class="mx-auto">
    <div class="text-right mb-3">
      <v-dialog max-width="500">
        <template v-slot:activator="{ props: activatorProps }">
          <v-btn
            v-bind="activatorProps"
            color="purple-accent-4"
            text="Thêm mới"
            variant="flat"
          ></v-btn>
        </template>

        <template v-slot:default="{ isActive }">
          <v-card title="Thêm banner mới">
            <v-card-text>
              <v-file-input
                label="File input"
                prepend-icon="mdi-camera"
                variant="filled"
              ></v-file-input>
            </v-card-text>

            <v-card-actions>
              <v-spacer></v-spacer>

              <v-btn
                color="purple-accent-4"
                variant="flat"
                text="Thêm mới"
                @click="isActive.value = false"
              ></v-btn>
              <v-btn
                text="Hủy"
                color="black  "
                variant="outlined"
                @click="isActive.value = false"
              ></v-btn>
            </v-card-actions>
          </v-card>
        </template>
      </v-dialog>
    </div>
    <v-container fluid>
      <v-row dense>
        <v-col v-for="card in cards" :key="card.title" :cols="card.flex">
          <v-card>
            <v-img
              :src="card.src"
              class="align-end"
              gradient="to bottom, rgba(0,0,0,.1), rgba(0,0,0,.5)"
              height="200px"
              cover
            >
              <v-card-title
                class="text-white"
                v-text="card.title"
              ></v-card-title>
            </v-img>

            <v-card-actions>
              <v-spacer></v-spacer>

              <v-btn
                color="red"
                icon="mdi-share-variant"
                size="small"
                variant="text"
                ><font-awesome-icon
                  style="font-size: 25px"
                  icon="fa-regular fa-trash-can"
                ></font-awesome-icon
              ></v-btn>
            </v-card-actions>
          </v-card>
        </v-col>
      </v-row>
    </v-container>
    <div class="text-center">
      <v-container>
        <v-row justify="center">
          <v-col cols="4">
            <v-container>
              <v-pagination
                v-model="page"
                :length="15"
                class="my-4"
              ></v-pagination>
            </v-container>
          </v-col>
        </v-row>
      </v-container>
    </div>
  </v-card>
</template>
<script>
export default {
  data() {
    return {
      page: 1,
      cards: [
        {
          title: "Pre-fab homes",
          src: "https://cdn.vuetifyjs.com/images/cards/house.jpg",
          flex: 6,
        },
        {
          title: "Pre-fab homes",
          src: "https://cdn.vuetifyjs.com/images/cards/docks.jpg",
          flex: 6,
        },
        {
          title: "Favorite road trips",
          src: "https://cdn.vuetifyjs.com/images/cards/road.jpg",
          flex: 6,
        },
        {
          title: "Best airlines",
          src: "https://cdn.vuetifyjs.com/docs/images/cards/purple-flowers.jpg",
          flex: 6,
        },
      ],
    };
  },
};
</script>
