using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Modelos;
using Proyecto.Interfaces;

namespace Proyecto.Pages.Doctor;


partial class RegistroDoctores
{
    [Inject] private IDoctorServicio doctorServicio { get; set; }

    [Inject] private NavigationManager navigationManager { get; set; }

    [Inject] SweetAlertService Swal { get; set; }

    private Doctores doc = new Doctores();

    protected async Task Guardar()
    {
        if (string.IsNullOrEmpty(doc.IdDoctor) || string.IsNullOrEmpty(doc.Nombre) || string.IsNullOrEmpty(doc.Identidad) || string.IsNullOrEmpty(doc.FechaNacimiento) || string.IsNullOrEmpty(doc.Sexo) || string.IsNullOrEmpty(doc.NumeroTelefono) || string.IsNullOrEmpty(doc.Direccion) || string.IsNullOrEmpty(doc.Especialidad) || string.IsNullOrEmpty(doc.Turno))
        {
            return;
        }
            bool inserto = await doctorServicio.Enviar(doc);
            if (inserto)
            {
                await Swal.FireAsync("Felicidades", "Usuario del doctor creado con exito", SweetAlertIcon.Success);
            }
            else
            {
                await Swal.FireAsync("Error", "Usuario del doctor no se pudo crear", SweetAlertIcon.Error);
            }
            navigationManager.NavigateTo("/RegistroDoctores/ListadoDoctores");

    }
}

