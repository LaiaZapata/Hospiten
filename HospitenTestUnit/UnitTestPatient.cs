using Hospiten.Core.Application.Interface.Services;
using Hospiten.Core.Application.ViewModel.Patient;
using Microsoft.AspNetCore.Mvc;
using WebApp.Hospiten.Controllers;
using Moq;


namespace HospitenTestUnit
{
    public class PatientControllerTests
    {
        [Fact]
        public async Task Create_GET_ReturnsViewResult()
        {
            // Arrange
            var patientServiceMock = new Mock<IPatientService>();
            var controller = new PatientController(patientServiceMock.Object);

            // Act
            var result = await controller.Create() as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("SavePatient", result.ViewName);
        }

        [Fact]
        public async Task Create_POST_InvalidModel_ReturnsViewResultWithModel()
        {
            // Arrange
            var patientServiceMock = new Mock<IPatientService>();
            var invalidModel = new SavePatientViewModel();
            var controller = new PatientController(patientServiceMock.Object);
            controller.ModelState.AddModelError("SomeProperty", "Error Message");

            // Act
            var result = await controller.Create(invalidModel) as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("SavePatient", result.ViewName);
            Assert.Same(invalidModel, result.Model);
        }

        [Fact]
        public async Task Create_POST_ValidModel_RedirectsToIndex()
        {
            // Arrange
            var patientServiceMock = new Mock<IPatientService>();
            var validModel = new SavePatientViewModel(); 
            var controller = new PatientController(patientServiceMock.Object);

            // Act
            var result = await controller.Create(validModel) as RedirectToRouteResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Patient", result.RouteValues["controller"]);
            Assert.Equal("Index", result.RouteValues["action"]);
        }
    }
}


