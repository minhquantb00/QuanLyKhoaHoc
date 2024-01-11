<template>
  <a-row justify="center">
    <a-col :xxl="6" :xl="12" :md="12" :sm="18">
      <AuthWrapper>
        <div class="ninjadash-authentication-top">
          <h2 class="ninjadash-authentication-top__title">Vui lòng đăng nhập tài khoản</h2>
        </div>
        <div class="ninjadash-authentication-content">
          <a-form @finish="handleSubmit" :model="formState" layout="vertical">
            <a-form-item name="username" label="Tài khoản">
              <a-input type="text" v-model:value="formState.taiKhoan" />
            </a-form-item>
            <a-form-item name="password" initialValue="123456" label="Mật khẩu">
              <a-input
                type="password"
                v-model:value="formState.matKhau"
                placeholder="Mật khẩu"
              />
            </a-form-item>
            <div class="ninjadash-auth-extra-links">
              <a-checkbox @change="onChange">Lưu mật khẩu</a-checkbox>
              <router-link class="forgot-pass-link" to="/auth/forgotPassword">
                Quên mật khẩu?
              </router-link>
            </div>
            <a-form-item>
              <sdButton class="btn-signin" htmlType="submit" type="primary">
                {{ isLoading ? "Đang chờ..." : "Đăng nhập" }}
              </sdButton>
            </a-form-item>
            <p class="ninjadash-form-divider">
              <span>hoặc</span>
            </p>
            <ul class="ninjadash-social-login">
              <li>
                <a class="google-social" href="#">
                  <InlineSvg
                    :src="require('@/static/img/icon/google-plus.svg')"
                  ></InlineSvg>
                </a>
              </li>
              <li>
                <a class="facebook-social" href="#">
                  <unicon name="facebook-f"></unicon>
                </a>
              </li>
              <li>
                <a class="twitter-social" href="#">
                  <unicon name="twitter"></unicon>
                </a>
              </li>
              <li>
                <a class="twitter-social" href="#">
                  <unicon name="github"></unicon>
                </a>
              </li>
            </ul>
            <!-- <div class="auth0-login">
              <a href="#" @click="() => lock.show()"> Đăng nhập với </a>
            </div> -->
          </a-form>
        </div>
        <div class="ninjadash-authentication-bottom">
          <p>
            Bạn không có tài khoản?<router-link to="/auth/register"
              >Đăng ký</router-link
            >
          </p>
        </div>
      </AuthWrapper>
    </a-col>
  </a-row>
</template>
<script>
import { computed, reactive, ref, defineComponent } from "vue";
import { useStore } from "vuex";
import { AuthWrapper } from "./style";
import { useRouter } from "vue-router";
import { Auth0Lock } from "auth0-lock";
import { auth0options } from "@/config/auth0";
import InlineSvg from "vue-inline-svg";

const domain = process.env.VUE_APP_AUTH0_DOMAIN;
const clientId = process.env.VUE_APP_AUTH0_CLIENT_ID;

const SignIn = defineComponent({
  name: "SignIn",
  components: { AuthWrapper, InlineSvg },
  setup() {
    const { state, dispatch } = useStore();
    const isLoading = computed(() => state.auth.loading);
    const checked = ref(null);
    const router = useRouter();

    const handleSubmit = () => {
      router.push("/");
      dispatch("login");
    };
    const onChange = (checked) => {
      checked.value = checked;
    };

    const formState = reactive({
      taiKhoan: "anhquantbbg",
      matKhau: "Anhquan123@",
    });

    const lock = new Auth0Lock(clientId, domain, auth0options);

    lock.on("authenticated", (authResult) => {
      lock.getUserInfo(authResult.accessToken, (error) => {
        if (error) {
          return;
        }

        handleSubmit();
        lock.hide();
      });
    });

    return {
      isLoading,
      checked,
      handleSubmit,
      onChange,
      formState,
      lock,
    };
  },
});

export default SignIn;
</script>
