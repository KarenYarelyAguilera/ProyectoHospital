using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Modelos;
using Proyecto.Interfaces;
using Datos;

namespace Proyecto.Pages.Paciente;

partial class NuevoPaciente
{
    [Inject] private NavigationManager navigationManager { get; set; }


    [Inject] SweetAlertService Swal { get; set; }

    private Pacientes pac = new Pacientes();

    protected async Task Enviar()
    {
        if (string.IsNullOrEmpty(pac.Nombre) || string.IsNullOrEmpty(pac.Identidad) || string.IsNullOrEmpty(pac.FechaNacimiento) ||
            string.IsNullOrEmpty(pac.Sexo) || string.IsNullOrEmpty(pac.NumeroTelefono) || string.IsNullOrEmpty(pac.TipodeSangre))
        {
            return;

            bool inserto;
            if (inserto)
            {
                await Swal.FireAsync("", "Paciente Registrado con exito", SweetAlertIcon.Success);
            }
            else
            {
                await Swal.FireAsync("Error", "No se puedo crear el registro del paciente", SweetAlertIcon.Error);
            }
            navigationManager.NavigateTo("/Pacientes");

        }

    }
}
