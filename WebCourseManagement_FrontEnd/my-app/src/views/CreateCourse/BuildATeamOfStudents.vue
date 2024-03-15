<template>
  <div>
    <v-row>
      <v-col cols="1">
        <HeaderDashboardVue class="header"></HeaderDashboardVue>
      </v-col>
      <v-col>
        <div class="container">
          <div class="body-content">
            <div class="header-content">
              <div class="header-content-item text-center">
                <img
                  src="../../assets/image/build-audience.jpg"
                  width="230"
                  alt="Lỗi hình ảnh"
                />
              </div>
              <div class="header-content-text">
                <h2 class="ma-8 text-center">
                  Xây dựng đội ngũ học viên của bạn
                </h2>
              </div>
            </div>
            <div class="middle-content">
              <div class="middle-content-text mb-10">
                <p>
                  Bạn có cơ hội tiếp cận với hàng triệu học viên ham học hỏi
                  trên MyBugs. Để có sự khởi đầu thuận lợi và vị thế nổi bật so
                  với đối thủ cạnh tranh, điều quan trọng là bạn phải tự tạo một
                  chút thành công cho bản thân.
                </p>
              </div>
              <div class="middle-content-step">
                <div class="step-one mb-8">
                  <h5 class="mb-6">
                    Bước 1: Viết nội dung cho trang tổng quan khóa học.
                  </h5>
                  <p>
                    Dù học viên tìm thấy khóa học của bạn thông qua kết quả tìm
                    kiếm tự nhiên, chương trình khuyến mại của MuBugs hay thông
                    qua hoạt động marketing của riêng bạn, thì cuối cùng họ cũng
                    sẽ truy cập vào
                    <router-link to="#" class="content-middle-item-link"
                      ><span>Trang tổng quan khóa học (CLP)</span></router-link
                    >
                    của bạn. Đây là nơi học viên quyết định xem khóa học của bạn
                    có đáng để họ ghi danh hay không bằng cách xem xét tiêu đề,
                    đọc nội dung mô tả khóa học, xem trước bài giảng của bạn,
                    v.v.
                  </p>
                </div>
                <div class="step-two mb-8">
                  <h5 class="mb-6">
                    Bước 2: Chọn giá khóa học và tham gia các chương trình
                    khuyến mại của MyBugs.
                  </h5>
                  <p>
                    Khóa học của bạn có thể miễn phí hoặc phải trả phí, dao động
                    <router-link to="#" class="content-middle-item-link"
                      ><span>từ 20-200 đô la Mỹ</span></router-link
                    >
                    (bạn có thể điều chỉnh giá khóa học bên ngoài lãnh thổ Hoa
                    Kỳ sao cho phù hợp với thị trường nội địa). Bạn cũng có thể
                    quyết định xem có muốn tham gia
                    <router-link to="#" class="content-middle-item-link"
                      ><span
                        >chương trình Ưu đãi chiết khấu MyBugs</span
                      ></router-link
                    >
                    hay không. Chương trình này cho phép MyBugs quản lý giá khóa
                    học của bạn, cũng như giúp nội dung của bạn tiếp cận với
                    hàng triệu học viên quốc tế.
                  </p>
                </div>
                <div class="step-three mb-8">
                  <h5 class="mb-6">Bước 3: Tạo hiệu ứng lan truyền.</h5>
                  <p>
                    Để tạo đà phát triển cho khóa học của bạn sau khi xuất bản
                    lần đầu tiên, bạn cần phải có hiệu ứng lan truyền. Điều này
                    có nghĩa là bạn nhận được vài chục lượt ghi danh (cho khóa
                    học có trả phí) và một số đánh giá trung thực từ học viên.
                    Để tạo hiệu ứng lan truyền, hãy chia sẻ khóa học của bạn với
                    bạn bè, gia đình và trên mạng xã hội (ví dụ: Facebook,
                    LinkedIn, v.v.) hoặc trên các diễn đàn online khác liên quan
                    đến chủ đề của khóa học.
                  </p>
                </div>
                <div class="step-four mb-8">
                  <h5 class="mb-6">
                    Bước 4: Mở rộng sang các kênh khác và tăng số lượng học
                    viên.
                  </h5>
                  <p>
                    Khi bạn đã khẳng định được bản thân trong vai trò giảng viên
                    trên MyBugs, hãy nghĩ cách thu hút lưu lượng truy cập từ các
                    trang web bên ngoài đến khóa học của bạn. Ví dụ: bạn có thể
                    sử dụng blog, kênh YouTube hoặc mạng xã hội như LinkedIn hay
                    Instagram để mở rộng đối tượng học viên bên ngoài MyBugs và
                    khiến nhiều người biết đến khóa học của bạn hơn.
                  </p>
                </div>
              </div>
              <div class="middle-content-question">
                <p class="content-middle-question mb-8">Câu hỏi thường gặp</p>
                <div class="question-content">
                  <h5 class="mb-8">MyBugs chia sẻ doanh thu theo cách nào?</h5>
                  <p class="mb-6">
                    When you drive learners to your course with an instructor
                    coupon or a referral link, you earn 97% of the net revenue.
                    When learners discover your course through MyBugs -- whether
                    that's an email they receive, an ad they click on, a
                    recommendation they see, or any other way -- you earn 37%.
                  </p>
                  <h5 class="mb-8">
                    Một giảng viên thông thường có khả năng kiếm được bao nhiêu
                    thu nhập?
                  </h5>
                  <p class="mb-6">
                    Điều này phụ thuộc nhiều vào chủ đề khóa học cũng như quy mô
                    đối tượng tiềm năng của bạn. Trước khi quyết định dạy chủ đề
                    gì, bạn nên thực hiện một số nghiên cứu bằng cách sử dụng
                    <router-link to="#" class="content-middle-item-link"
                      ><span>công cụ Thông tin</span></router-link
                    >
                    chi tiết về thị trường để hiểu rõ chủ đề của bạn có bao
                    nhiêu người mua tiềm năng và có bao nhiêu đối thủ cạnh
                    tranh.
                  </p>
                  <h5 class="mb-8">MyBugs thanh toán cho tôi bằng cách nào?</h5>
                  <p class="mb-6">
                    Udemy thanh toán cho giảng viên thông qua PayPal, Payoneer
                    hoặc phương thức ký gửi trực tiếp tại ngân hàng (chỉ ở Hoa
                    Kỳ). Các khoản thanh toán từ PayPal được chuyển trực tiếp
                    đến tài khoản PayPal của bạn, sau đó có thể chuyển đến tài
                    khoản ngân hàng của bạn. Các khoản thanh toán qua Payoneer
                    có thể được chuyển đến tài khoản ngân hàng địa phương của
                    bạn hoặc đến thẻ MasterCard® trả trước.
                  </p>
                  <h5 class="mb-8">
                    MyBugs tiếp thị khóa học của tôi bằng cách nào?
                  </h5>
                  <p class="mb-6">
                    Một trong những lợi ích lớn nhất của việc đưa khóa học của
                    bạn lên Udemy là để khóa học của bạn tiếp cận với hàng triệu
                    học viên trên khắp thế giới. Đối với những giảng viên chọn
                    tham gia chương trình Ưu đãi chiết khấu Udemy, các chương
                    trình khuyến mại của Udemy thu hút hàng chục triệu lượt ghi
                    danh có trả phí mỗi năm. Chúng tôi đầu tư vào nhiều kênh
                    marketing khác nhau để quảng bá nội dung của giảng viên, bao
                    gồm email, SEO (Tối ưu hóa công cụ tìm kiếm), quảng cáo trên
                    mạng xã hội, vị trí quảng cáo của đơn vị liên kết, v.v.
                    Chúng tôi sử dụng dữ liệu để xác định khóa học phù hợp đề
                    xuất cho từng học viên. Vì vậy, nếu bạn muốn hưởng lợi từ
                    hoạt động marketing của chúng tôi, hãy tạo một khóa học nổi
                    bật về chủ đề mà học viên muốn học.
                  </p>
                  <h5 class="mb-8">
                    Có bất kỳ yêu cầu nào về khóa học không? Yêu cầu đó là gì?
                  </h5>
                  <p class="mb-6">
                    Khóa học phải có ít nhất 30 phút nội dung, bao gồm ít nhất 5
                    bài giảng riêng biệt và video phải có chất lượng HD. Hãy xem
                    <router-link to="#" class="content-middle-item-link"
                      ><span>bài viết</span></router-link
                    >
                    này để biết danh sách hoàn chỉnh về yêu cầu tối thiểu đối
                    với khóa học.
                  </p>
                </div>
              </div>
            </div>
          </div>
        </div>
      </v-col>
    </v-row>
    <FooterItem style="border-radius:0px;"></FooterItem>
  </div>
</template>

<script>
import FooterItem from "../Header/FooterItem.vue";
import HeaderDashboardVue from "./HeaderDashboard.vue";
export default {
  components: {
    FooterItem,
    HeaderDashboardVue,
  },
};
</script>

<style scope>
.header-content-text h2 {
  font-family: initial;
  font-weight: bold;
  font-size: 37px;
}
.middle-content-text p {
  font-size: 26px;
}
.body-content {
  margin: 0px 200px 0px 50px;
  padding: 20px;
  /* background: blue; */
}
.item-content-middle {
  font-weight: bold;
}
.content-middle-item-link {
  /* text-decoration: none; */
  color: blueviolet;
}
.content-middle-question {
  font-size: 24px;
}
</style>
