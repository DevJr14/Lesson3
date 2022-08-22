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

        private async Task InvokeAddEditDialogForEdit(int studentId)
        {
            //Search for a student with id studentId parameter in the Students.
            var student = Students.Where(student => student.Id == studentId).First();

            //Assigned dialog parameters with student values
            var paramenters = new DialogParameters();

            paramenters.Add(nameof(AddEditStudentDialog.StudentModel),
            new Student
            {
                Id = student.Id,
                Age = student.Age,
                Firstname = student.Firstname
            });

            var options = new DialogOptions { CloseButton = true, CloseOnEscapeKey = true, MaxWidth = MaxWidth.Large };
            
            var dialog = _dialogService.Show<AddEditStudentDialog>("Student Dialog", paramenters, options);

            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                dialog.Close();
                await LoadStudentAsync();
            }
        }

        private async Task InvokeDeleteConfirmationDialog(int studentId)
        {
            //Assigned dialog parameters with student values
            var paramenters = new DialogParameters();

            paramenters.Add(nameof(Shared.DeleteConfirmation.Message), "Are you sure you want to delete the student?");

            var options = new DialogOptions { CloseButton = true, CloseOnEscapeKey = true, MaxWidth = MaxWidth.Small };

            var dialog = _dialogService.Show<Shared.DeleteConfirmation>("Delete Confirmation", paramenters, options);

            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                await StudentService.DeleteAsync(studentId);
                dialog.Close();
                await LoadStudentAsync();
            }
        }
    }
}
