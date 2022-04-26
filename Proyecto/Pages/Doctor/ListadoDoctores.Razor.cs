using Microsoft.AspNetCore.Components;
using Proyecto.Interfaces;
using Modelos;

namespace Proyecto.Pages.Doctor;

partial class ListadoDoctores
{
    [Inject] private IDoctorServicio _doctorServicio { get; set; }

    private IEnumerable<Doctores> doctoresLista { get; set; }

    protected override async Task OnInitializedAsync()
    {
        doctoresLista = await _doctorServicio.GetLista();
    }
}
