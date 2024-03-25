<template>
  <v-table height="300px" fixed-header>
    <thead>
      <tr>
        <th class="text-left">Tên người dùng</th>
        <th class="text-left">Số điện thoại</th>
        <th class="text-left">Email</th>
        <th class="text-left">Số lần vi phạm</th>
        <th class="text-left">Trạng thái người dùng</th>
        <th class="text-left">Thao tác</th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="item in listUser" :key="item">
        <td>{{ item.hoVaTen }}</td>
        <td>{{ item.soDienThoai }}</td>
        <td>{{ item.email }}</td>
        <td>{{ item.email }}</td>

        <td>{{ item.soDienThoai }}</td>
        <td>
          <v-btn icon color="green" size="small" variant="outlined">
            <font-awesome-icon
              icon="fa-solid fa-lock-open"
              style="font-size: 16px"
            ></font-awesome-icon>
          </v-btn>
          <v-btn icon color="red" size="small" variant="outlined" class="ml-5">
            <font-awesome-icon
              icon="fa-solid fa-lock"
              style="font-size: 16px"
            ></font-awesome-icon>
          </v-btn>
        </td>
      </tr>
    </tbody>
  </v-table>
</template>
<script>
import {userApi} from "../../../apis/User/userApi"
export default {
  data(){
    return{
      userApi: userApi(),
      listUser:[],
    }
  },
  async mounted() {
    try{
      const userApi = await this.userApi.getAllUser();
      this.listUser = userApi
      console.log(this.listUser);
    }catch(e){
      console.error("Error fetching:" + e);
    }
  },
};
</script>
<style scoped>
.highlight {
  background-color: rgb(255, 192, 105);
  padding: 0px;
}
</style>
