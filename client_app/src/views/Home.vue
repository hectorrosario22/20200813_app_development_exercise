<template>
  <div>
    <div class="mt-2 mb-2">
      <router-link to="/permissions/create" class="btn btn-primary">Crear Permiso</router-link>
    </div>
    <table class="table table-striped table-bordered">
      <thead>
        <tr>
          <th scope="col">Id</th>
          <th scope="col">Nombre Empleado</th>
          <th scope="col">Apellido Empleado</th>
          <th scope="col">Tipo Permiso</th>
          <th scope="col">Fecha Permiso</th>
          <th scope="col">Acciones</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(permission, index) in permissions" :key="index">
          <th scope="row" v-text="permission.id">1</th>
          <td v-text="permission.employeeFirstName"></td>
          <td v-text="permission.employeeLastName"></td>
          <td v-text="permission.permissionTypeDescription"></td>
          <td>{{ permission.permissionDate | formatDate }}</td>
          <td>
            <router-link
              :to="'/permissions/update/' + permission.id"
              class="btn btn-sm btn-info"
            >Editar</router-link>
            <button class="ml-1 btn btn-sm btn-danger" @click="onDelete(permission)">Eliminar</button>
          </td>
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
    async loadPermissions() {
      const url = `${process.env.VUE_APP_API_URL}/permissions`;
      let result = await fetch(url, {
        method: "GET",
      });
      this.permissions = await result.json();
    },
    async onDelete(permission) {
      const confirmMessage = `¿Está seguro de eliminar el permiso para ${permission.permissionTypeDescription} de ${permission.employeeFirstName} ${permission.employeeLastName}?`;
      if (window.confirm(confirmMessage)) {
        const url = `${process.env.VUE_APP_API_URL}/permissions/${permission.id}`;
        let result = await fetch(url, {
          method: "DELETE",
        });

        if (result.status >= 200 && result.status <= 299) {
          window.alert("El Permiso ha sido eliminado correctamente");
          this.loadPermissions();
        } else {
          let errorResult = await result.json();
          let errorMessage = "Ha ocurrido un error al eliminar el permiso";

          if (errorResult && errorResult.error) {
            errorMessage = errorResult.error;
          } else if (errorResult && errorResult.errors) {
            errorMessage = "";
            errorResult.errors.forEach((error) => {
              errorMessage += `${error}\n`;
            });
          }

          window.alert(errorMessage);
        }
      }
    },
  },
  created() {
    this.loadPermissions();
  },
  filters: {
    formatDate(date) {
      return moment(date).locale("es-do").format("DD [de] MMMM [del] YYYY");
    },
  },
};
</script>
