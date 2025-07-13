## 📌 Descripción

Sistema completo para la gestión de eventos, desarrollado en **C# con Windows Forms**, base de datos en **SQL Server 2008**, y arquitectura en **capas** (Entidad, Lógica de Negocio y Acceso a Datos).

Permite a **clientes** y **trabajadores** interactuar con el sistema mediante módulos como:

- Registro y gestión de órdenes de eventos
- Catálogo de eventos predefinidos
- Módulo de quejas y sugerencias
- Generación de reportes en PDF
- Validaciones robustas

## 🛠️ Tecnologías utilizadas

- 🖥️ C# con Windows Forms (.NET Framework)
- 🗃️ SQL Server 2008
- 🧱 Arquitectura por capas (EN, BL, DAL)
- 📄 Crystal Reports (para reportes PDF)
- 🔒 Validaciones y control de errores

## 🧩 Estructura del Proyecto

ProyectoFinal

│
├── EN (Entidad) - Clases que representan las tablas
│ └── OrdenesEventos.cs, MensajesAyuda.cs, etc.
│
├── DAL (Acceso a Datos) - Manejo directo con SQL Server
│ └── OrdenesDAL.cs, MensajeAyudaDAL.cs
│
├── BL (Lógica de Negocio)
│ └── OrdenesBL.cs, MensajeAyudaBL.cs
│
├── UI (Interfaz de Usuario)
│ └── Formularios Windows Forms
│ ├── frmPrincipal.cs
│ └── frmAyuda.cs, frmOrdenes.cs
│
└── BD (Base de Datos)
└── Script de creación y SPs


## 🧪 Funcionalidades clave
✉️ Módulo de buzon de quejas y sugerencias
Permite al usuario (cliente o trabajador) enviar una queja o sugerencia. Se usan RadioButton el tipo de mensaje:
string tipoMensaje = rbQueja.Checked ? "Queja" : 
                     rbSugerencia.Checked ? "Sugerencia" : string.Empty;

if (string.IsNullOrEmpty(tipoMensaje) || string.IsNullOrEmpty(tipoUsuario))
{
    MessageBox.Show("Por favor, selecciona si eres Cliente o Trabajador y el tipo de mensaje.", "Faltan datos");
    return;
}


MensajesAyuda mensaje = new MensajesAyuda
{
    NombreCompleto = txtNombreAyuda.Text,
    Usuario = txtayudausuario.Text,
    Correo = txtayudacorreo.Text,
    TipoMensaje = tipoMensaje,
    TipoUsuario = tipoUsuario, // <-- este campo lo agregaste tú 💡
    Mensaje = rtbproblema.Text
};
El mensaje se guarda en la tabla MENSAJESAYUDA, incluyendo si fue enviado por un cliente o trabajador, y si fue una queja o una sugerencia. Esto se refleja también al generar reportes.


## 📄 Reportes PDF
Generación de reportes para visualizar órdenes, clientes o quejas/sugerencias en formato imprimible usando Crystal Reports.

## ✅ Estado del proyecto
📌 100% Finalizado
💪 Probado y sin errores
📁 Listo para portafolio profesional

## 🙋‍♂️ Autor
EDWIN SAN LUCAS
## GitHub · Ecuador 🇪🇨


