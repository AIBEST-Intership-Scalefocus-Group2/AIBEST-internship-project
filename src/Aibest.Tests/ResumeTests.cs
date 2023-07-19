using System.Security.Claims;
using Aibest.Application.Controllers;
using Aibest.Business.Models;
using Aibest.Business.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace Aibest.Tests;

public class ResumeTests
{
    private Mock<IResumeService> _resumeService;
    private readonly ResumesController _controller;

    public ResumeTests()
    {
        _resumeService = new Mock<IResumeService>();
        var logger = new Mock<ILogger<ResumesController>>();
        var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.Name, "Test Username"),
            new Claim(ClaimTypes.NameIdentifier, "1"),
        }, "mock"));

        _controller = new ResumesController(_resumeService.Object, logger.Object);
        _controller.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext { User = user }
        };
    }

    

    [Fact]
    public void EditReturnsCorrectViewWhenResumeExists()
    {
        int id = 1;

        _resumeService.Setup(service => service.GetResume(id))
            .Returns(new ResumeModel() { Id = id, Name = "Test Resume", FirstName = "fname", LastName = "lname", EmailAddress = "awe@gmail.com" });

        var logger = new Mock<ILogger<ResumesController>>();

        var result = _controller.Edit(id);

        var viewResult = Assert.IsType<ViewResult>(result);
        var model = Assert.IsAssignableFrom<ResumeModel>(viewResult.ViewData.Model);
        Assert.Equal(id, model.Id);
    }

    [Fact]
    public void EditReturnsNotFoundWhenResumeDoesNotExist()
    {
        int id = 1;

        var mockService = new Mock<IResumeService>();
        mockService.Setup(service => service.GetResume(id))
            .Returns((ResumeModel)null);

        var result = _controller.Edit(id);

        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public void AddResumeReturnsRedirectWhenModelStateIsValid()
    {
        _resumeService.Setup(service => service.CreateResume(It.IsAny<ResumeModel>())).Returns(true);
        _resumeService.Setup(service => service.GetResumes())
            .Returns(new List<ResumeModel>(){
              new ResumeModel() { Id = 1, Name = "Test Resume", FirstName = "fname", LastName = "lname", EmailAddress = "awe@gmail.com" }
            });


        var result = _controller.AddResume(new ResumeModel());

        Assert.IsType<RedirectToActionResult>(result);
    }

    [Fact]
    public void AddResumeReturnsViewWhenModelStateIsInvalid()
    {
        _resumeService.Setup(service => service.CreateResume(It.IsAny<ResumeModel>())).Returns(false);

        _controller.ModelState.AddModelError("", "Test Error");

        var result = _controller.AddResume(new ResumeModel());

        Assert.IsType<ViewResult>(result);
    }




}