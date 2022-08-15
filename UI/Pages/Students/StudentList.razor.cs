using Common.Models;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using UI.Services;

namespace UI.Pages.Students
{
    public partial class StudentList
    {
        [Inject] private IStudentService StudentService { get; set; } = default!;

        private bool _loading;
        private IEnumerable<Student> Students = new List<Student>();

        protected override async Task OnInitializedAsync()
        {
            _loading = true;

            await LoadStudentAsync();

            _loading = false;
        }

        private async Task LoadStudentAsync()
        {
            var students = await StudentService.GetAllAsync();
            if (students != null)
            {
                Students = students;
            }
        }

        private async Task InvokeAddEditDialog()
        {
            var paramenters = new DialogParameters();

            var options = new DialogOptions {CloseButton=true, CloseOnEscapeKey = true, MaxWidth = MaxWidth.Large };

            var dialog = _dialogService.Show<AddEditStudentDialog>("Student Dialog", paramenters, options);

            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                dialog.Close();
                await LoadStudentAsync();
            }

        }
    }
}
