using Common.Models;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using UI.Services;

namespace UI.Pages.Students
{
    public partial class AddEditStudentDialog
    {
        [Inject] private IStudentService StudentService { get; set; } = default!;
        [Parameter] public Student StudentModel { get; set; } = new Student();
        [CascadingParameter] MudDialogInstance MudDialog { get; set; } = default!;

        MudForm form = default!;

        private async Task SaveAsync()
        {
            await StudentService.AddNewAsync(StudentModel);
            MudDialog.Close();
        }
    }
}
