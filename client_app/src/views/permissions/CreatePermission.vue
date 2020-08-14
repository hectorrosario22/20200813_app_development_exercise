<template>
  <div>
    <save-permission :title="title" @save="onSave" @cancel="onCancel" />
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
      title: "Crear Permiso",
    };
  },
  methods: {
    async onSave(permission) {
      const url = `${process.env.VUE_APP_API_URL}/permissions`;
      let result = await fetch(url, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(permission),
      });

      if (result.status >= 200 && result.status <= 299) {
        window.alert("El Permiso ha sido creado correctamente");
        this.$router.push({ path: "/" });
      } else {
        let errorResult = await result.json();
        let errorMessage = "Ha ocurrido un error crear el permiso";

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
    onCancel() {
      this.$router.push({ path: "/" });
    },
  },
};
</script>