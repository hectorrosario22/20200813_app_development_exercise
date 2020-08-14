<template>
  <div>
    <table class="table table-striped">
      <thead>
        <tr>
          <th scope="col">Id</th>
          <th scope="col">Nombre Empleado</th>
          <th scope="col">Apellido Empleado</th>
          <th scope="col">Tipo Permiso</th>
          <th scope="col">Fecha Permiso</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(permission, index) in permissions" :key="index">
          <th scope="row" v-text="permission.id">1</th>
          <td v-text="permission.employeeFirstName"></td>
          <td v-text="permission.employeeLastName"></td>
          <td v-text="permission.permissionTypeDescription"></td>
          <td>{{ permission.permissionDate | formatDate }}</td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import moment from "moment";

export default {
  name: "Home",
  data() {
    return {
      permissions: [],
    };
  },
  methods: {
    async getAllPermissions() {
      const url = `${process.env.VUE_APP_API_URL}/permissions`;
      let result = await fetch(url, {
        method: "GET",
      });
      this.permissions = await result.json();
    },
  },
  created() {
    this.getAllPermissions();
  },
  filters: {
    formatDate(date) {
      return moment(date).locale("es-do").format("DD [de] MMMM [del] YYYY");
    },
  },
};
</script>
