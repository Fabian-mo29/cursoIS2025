<template>
  <div class="container mt-5">
    <h1 class="display-4 text-center">Lista de Paises</h1>
    <div class="row justify-content-end">
      <div class="col-2">
        <a href="/pais">
          <button type="button" class="btn btn-outline-secondary float-right">
            Agregar pais
          </button>
        </a>
      </div>
    </div>
    <table
      class="table is-bordered is-striped is-narrow is-hoverable is-fullwidth"
    >
      <thead>
        <tr>
          <th>Nombre</th>
          <th>Continente</th>
          <th>Idioma</th>
          <th>Acciones</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(pais, index) of paises" :key="index">
          <td>{{ pais.nombre }}</td>
          <td>{{ pais.continente }}</td>
          <td>{{ pais.idioma }}</td>
          <td>
            <button class="btn btn-secondary btn-sm">Editar</button>
            <button v-on:click="eliminar(index)" class="btn btn-danger btn-sm">
              Eliminar
            </button>
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import axios from "axios";
export default {
  name: "ListaPaises",
  data() {
    return {
      paises: [],
    };
  },
  methods: {
    eliminar: function (index) {
      this.paises.splice(index, 1);
    },
    obtenerTareas() {
      axios
        .get("https://localhost:7032/api/Paises", {
          headers: { "Content-Type": "application/json" },
        })
        .then((response) => {
          this.paises = response.data;
        })
        .catch((error) => {
          console.error("Error al obtener los países:", error);
        });
    },
  },
  created: function () {
    this.obtenerTareas();
  },
};
</script>

<style lang="scss" scoped></style>
