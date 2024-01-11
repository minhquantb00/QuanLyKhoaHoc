<template>
  <a-row justify="center">
    <a-col :xxl="6" :xl="12" :md="12" :sm="18">
      <AuthWrapper>
        <div class="ninjadash-authentication-top">
          <h2 class="ninjadash-authentication-top__title">Đăng ký tại đây</h2>
        </div>
        <div class="ninjadash-authentication-content">
          <a-form
            name="register"
            :model="formState"
            @finish="handleSubmit"
            layout="vertical"
          >
            <a-form-item
              label="Họ và tên"
              name="name"
              :rules="[
                { required: true, message: 'Vui lòng nhập họ và tên của bạn!' },
              ]"
            >
              <a-input v-model:value="formState.name" placeholder="Họ và tên" />
            </a-form-item>
            <a-form-item
              name="username"
              label="Tài khoản"
              :rules="[
                { required: true, message: 'Vui lòng nhập tên tài khoản của bạn!' },
              ]"
            >
              <a-input
                v-model:value="formState.username"
                placeholder="Tài khoản"
              />
            </a-form-item>
            <a-form-item
              name="email"
              label="Email"
              :rules="[
                {
                  required: true,
                  message: 'Vui lòng nhập Email của bạn!',
                  type: 'email',
                },
              ]"
            >
              <a-input
                type="email"
                v-model:value="formState.email"
                placeholder="name@example.com"
              />
            </a-form-item>
            <a-form-item
              label="Mật khẩu"
              name="password"
              :rules="[
                { required: true, message: 'Vui lòng nhập mật khẩu của bạn!' },
              ]"
            >
              <a-input
                type="password"
                v-model:value="formState.password"
                placeholder="Mật khẩu"
              />
            </a-form-item>
            <div class="ninjadash-auth-extra-links">
              <a-checkbox @change="onChange">
                Bạn đồng ý với điều khoản dịch vụ và chính sách quyền riêng tư của chúng tôi
              </a-checkbox>
            </div>
            <a-form-item>
              <sdButton
                class="btn-create"
                htmlType="submit"
                type="primary"
                size="lg"
              >
                Đăng ký tài khoản
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
          </a-form>
        </div>
        <div class="ninjadash-authentication-bottom">
          <p>
            Bạn đã có tài khoản?<router-link to="/auth/login"
              >Đăng nhập</router-link
            >
          </p>
        </div>
      </AuthWrapper>
    </a-col>
  </a-row>
</template>
<script>
import { AuthWrapper } from "./style";
import { reactive, ref, defineComponent } from "vue";
import InlineSvg from "vue-inline-svg";

const SignUp = defineComponent({
  name: "SignUp",
  components: { AuthWrapper, InlineSvg },
  setup() {
    const values = ref(null);
    const checked = ref(null);
    const handleSubmit = (value) => {
      values.value = value;
    };

    const onChange = (check) => {
      checked.value = check;
    };
    const formState = reactive({
      name: "",
      username: "",
      email: "",
      password: "",
    });
    return {
      onChange,
      handleSubmit,
      formState,
    };
  },
});

export default SignUp;
</script>
