<template>
  <form @submit.prevent="onSave">
    <div class="mt-2 mb-2 d-flex justify-content-between">
      <h3 v-text="title"></h3>
      <div class="btn-group" role="group" aria-label="Acciones">
        <button type="submit" class="btn btn-primary">Guardar</button>
        <button type="button" class="btn btn-danger" @click="onCancel">Cancelar</button>
      </div>
    </div>
    <div class="row">
      <div class="form-group col-6">
        <label for="employee-first-name">Nombre de Empleado</label>
        <input
          type="text"
          class="form-control"
          required
          maxlength="100"
          id="employee-first-name"
          v-model="localPermission.employeeFirstName"
        />
      </div>
      <div class="form-group col-6">
        <label for="employee-last-name">Apellido de Empleado</label>
        <input
          type="text"
          class="form-control"
          required
          maxlength="100"
          id="employee-last-name"
          v-model="localPermission.employeeLastName"
        />
      </div>
    </div>
    <div class="row">
      <div class="form-group col-6">
        <label for="permission-type">Tipo de Permiso</label>
        <select
          class="form-control"
          id="permission-type"
          required
          v-model="localPermission.permissionTypeId"
        >
          <option :value="null" selected disabled>Seleccione una Opción</option>
          <option
            v-for="(permissionType, index) in permissionTypes"
            :key="index"
            :value="permissionType.id"
            v-text="permissionType.description"
          ></option>
        </select>
      </div>
      <div class="form-group col-6">
        <label for="permission-date">Fecha de Permiso</label>
        <input
          type="date"
          class="form-control"
          required
          id="permission-date"
          format="dd/mm/yyyy"
          :value="permissionDateAsString"
          @input="localPermission.permissionDate = $event.target.valueAsDate"
        />
      </div>
    </div>
  </form>
</template>

<script>
import moment from "moment";

export default {
  props: {
    title: {
      type: String,
      required: true,
    },
    permission: {
      type: Object,
      required: false,
      default() {
        return {
          id: null,
          employeeFirstName: "",
          employeeLastName: "",
          permissionTypeId: null,
          permissionDate: null,
        };
      },
    },
  },
  data() {
    return {
      permissionTypes: [],
      localPermission: {
        id: null,
        employeeFirstName: "",
        employeeLastName: "",
        permissionTypeId: null,
        permissionDate: null,
      },
    };
  },
  watch: {
    permission() {
      this.localPermission = { ...this.permission };
    },
  },
  methods: {
    onSave() {
      this.$emit("save", { ...this.localPermission });
    },
    onCancel() {
      this.$emit("cancel");
    },
    async loadPermissionTypes() {
      const url = `${process.env.VUE_APP_API_URL}/permissionTypes`;
      let result = await fetch(url, {
        method: "GET",
      });
      this.permissionTypes = await result.json();
    },
  },
  computed: {
    permissionDateAsString() {
      if (!this.localPermission || !this.localPermission.permissionDate)
        return null;
      return moment(this.localPermission.permissionDate)
        .locale("es-do")
        .format("YYYY-MM-DD");
    },
  },
  created() {
    this.loadPermissionTypes();
  },
};
</script>