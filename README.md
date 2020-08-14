# 20200813_APP_DEVELOPMENT_EXERCISE

Proyecto de evaluación.

## Ejecutar el proyecto localmente

Clonar el repositorio
```
git clone https://github.com/hectorrosario22/20200813_app_development_exercise
```

Instalar las dependencias en la carpeta ```client_app```
```bash
npm install
```

Colocar la url del api en el archivo ```.env``` que se encuentra en la carpeta ```client_app```
```
VUE_APP_API_URL="{COLOCAR URL DEL API AQUI}"
```

Aplicar las migraciones en el Proyecto ```Api.csproj``` utilizando la consola de ```Visual Studio```
##### Asegurese de que los ConnectionStrings del archivo ```appsettings.json``` estén configurados para su Base de Datos
```bash
Update-Database
```

Ejecutar el Proyecto ```Api.csproj``` utilizando ```Visual Studio``` o ```dotnet```
##### Ejemplo usando ```dotnet```
```bash
dotnet run --project Api.csproj
```

Ejecutar la aplicación de VueJS en la carpeta ```client_app```
```bash
npm run serve
```