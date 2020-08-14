<template>
  <div>
    <save-permission
      :title="title"
      :permission="savedPermission"
      @save="onSave"
      @cancel="onCancel"
    />
  </div>
</template>

<script>
import SavePermission from "@/components/SavePermission";

export default {
  components: {
    SavePermission,
  },
  data() {
    return {
      title: "Editar Permiso",
      savedPermission: null,
    };
  },
  methods: {
    async onSave(permission) {
      const url = `${process.env.VUE_APP_API_URL}/permissions/${this.$route.params.id}`;
      let result = await fetch(url, {
        method: "PUT",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(permission),
      });

      if (result.status >= 200 && result.status <= 299) {
        window.alert("El Permiso ha sido modificado correctamente");
        this.$router.push({ path: "/" });
      } else {
        let errorResult = await result.json();
        let errorMessage = "Ha ocurrido un error modificar el permiso";

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
    },
    async loadPermission() {
      const url = `${process.env.VUE_APP_API_URL}/permissions/${this.$route.params.id}`;
      let result = await fetch(url, {
        method: "GET",
      });

      this.savedPermission = await result.json();
    },
    onCancel() {
      this.$router.push({ path: "/" });
    },
  },
  created() {
    this.loadPermission();
  },
};
</script>