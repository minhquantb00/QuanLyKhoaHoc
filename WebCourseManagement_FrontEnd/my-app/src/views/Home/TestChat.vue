<template>
  <!-- #app -->
  <div class="container topo--pag" id="app">
    <!-- .row -->
    <div class="row">
      <!-- app-sidebar -->

      <app-sidebar class="col-4">
        <div class="list-group" id="list-tab" role="tablist">
          <a
            class="list-group-item list-group-item-action active"
            id="list-home-list"
            data-toggle="list"
            href="#fulano"
            role="tab"
            aria-controls="home"
            >Fulano</a
          >
          <a
            class="list-group-item list-group-item-action"
            id="list-profile-list"
            data-toggle="list"
            href="#ciclano"
            role="tab"
            aria-controls="profile"
            >Ciclano</a
          >
          <a
            class="list-group-item list-group-item-action"
            id="list-settings-list"
            data-toggle="list"
            href="#beltrano"
            role="tab"
            aria-controls="settings"
            >Beltrano</a
          >
        </div>
      </app-sidebar>

      <!-- /app-sidebar -->

      <!-- app-view -->
      <app-view class="col-8">
        <div class="tab-content" id="nav-tabContent">
          <div
            style="display: block !important; opacity: 1"
            class="tab-pane fade active"
            id="fulano"
            role="tabpanel"
            aria-labelledby="list-home-list"
          >
            <componente-chat> </componente-chat>

            <ul>
              <li v-for="testes in teste">
                {{ testes.valor | upper }}
              </li>
            </ul>
          </div>
        </div>
      </app-view>

      <!-- /app-view -->
    </div>
    <!-- .row -->
  </div>
  <!-- /#app -->
</template>

<script>
Vue.component("componente-chat", {
  data: function () {
    return {
      texto: "",
      arr_mensagens: [],
      bilada: "BRKsEdu",
    }; // retorna variavel objeto
  },
  template: ` 
    <chat>
    <strong>{{bilada}}</strong>
      <conversa class='row'>
       <mensagemlinha v-for="mensagem in arr_mensagens" class="col-12">
          <mensagem :class="mensagem.por">{{mensagem.texto}}</mensagem>
        </mensagemlinha>
      </conversa>
      <textoconversa class='row'>
          <input v-model="texto" @keyup.enter="enviarmsg(texto)">
      </textoconversa>
    </chat>`,
  mounted: function () {
    this.apresentacao();
    //alert('Olá, VUE');
  },
  methods: {
    // Msg Apresentação
    apresentacao: function () {
      var msg = {
        por: "",
        texto: `
                      Olá, sou uma mensagem virtual.\n
                      Nosso horário de atendimento é das 00:00 as 00:00 de Seg a Sex.
                      `,
      };
      this.arr_mensagens.push(msg);
    },
    enviarmsg: function (texto) {
      var escopo = this;
      var msg = { por: "direita", texto: texto };

      this.arr_mensagens.push(msg);

      setTimeout(function () {
        var r = {
          por: "esquerda",
          texto: " Olá, sou uma mensagem automática!",
        };
        escopo.arr_mensagens.push(r);
      }, 1000);
    },
  },
});

var app = new Vue({
  el: "#app",
  data: {
    compConversa: [
      {
        url: "urlurlrul",
        user: "teste",
      },
    ],
    teste: [
      { valor: "AAAAAAAAAAAAAA" },
      { valor: "BBBBBBBBBBBBBB" },
      { valor: "CCCCCCCCCCCCCC" },
    ],
  },
  filters: {
    upper: function (texto) {
      var r = texto.toUpperCase();
      return r;
    },
  },
});
</script>

<style scoped>
.row {
  /* border: 1px solid red; */
}
div[class*="col"] {
  /* border: 1px solid #C0C0C0; */
}
.topo--pag {
  margin-top: 1%;
}

mensagem {
  float: left;
  background-color: #e0e0e0;
  padding: 10px;
}

mensagem.direita {
  float: right;
  background-color: #0077f9;
  padding: 10px;
  color: #fff;
}
/* End message TAG */
</style>
