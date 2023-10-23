using Microsoft.AspNetCore.Mvc;
using Hospiten.Core.Application.Interface.Services;
using Hospiten.Core.Application.ViewModel.Exam;
using Hospiten.Infrastructure.Persistence.Contexts;
using System.Threading.Tasks;
using Hospiten.Core.Application.Service;
using Hospiten.Core.Application.ViewModel.Doctor;

namespace WebApp.Hospiten.Controllers
{
    public class ExamController : Controller
    {
        private readonly IExamService _ExamService;
        public ExamController(IExamService ExamService)
        {
            _ExamService = ExamService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _ExamService.GetAllViewModel());
        }
        public async Task<IActionResult> Create()
        {
            SaveExamViewModel vm = new();
            vm.Exams = await _ExamService.GetAllViewModel();
            return View("SaveExam", vm);
        }
        [HttpPost]
        public async Task<IActionResult> Create(SaveExamViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Exams = await _ExamService.GetAllViewModel();
                return View("SaveExam", vm);
            }

            await _ExamService.Add(vm);
            return RedirectToRoute(new { controller = "Exam", action = "Index" });
        }
        public async Task<IActionResult> Edit(int id)
        {
            SaveExamViewModel vm = await _ExamService.GetByIdSaveViewModel(id);
            vm.Exams = await _ExamService.GetAllViewModel();
            return View("SaveExam", vm);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(SaveExamViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Exams = await _ExamService.GetAllViewModel();
                return View("SaveExam", vm);
            }

            await _ExamService.Update(vm);
            return RedirectToRoute(new { controller = "Exam", action = "Index" });
        }
        public async Task<IActionResult> Delete(int id)
        {
            return View(await _ExamService.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int Exam_Id)
        {

            await _ExamService.Delete(Exam_Id);
            return RedirectToRoute(new { controller = "Exam", action = "Index" });
        }
    }

}
