using System;
using System.Collections.Generic;
using System.Net;
using API.Base;
using API.Models;
using API.Repository.Data;
using API.Repository.Interface;
using API.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : BasesController<Employee, Repository.Data.EmployeeRepository, string>
    {
        

        private readonly Repository.Data.EmployeeRepository employeeRepository;
        public IConfiguration _configuration;
        public EmployeesController(Repository.Data.EmployeeRepository repository, IConfiguration configuration) : base(repository)
        {
            this.employeeRepository = repository;
            this._configuration = configuration;
        }

        [HttpPost("Register")]
        public ActionResult Post(RegisterVM registerVM)
        {
            try
            {
                 var result = employeeRepository.Register(registerVM);

                if(result == 2)
                {
                    return BadRequest(new { Status = HttpStatusCode.BadRequest, Message = "NIK Sama" });
                } else if (result == 3)
                {
                    return BadRequest(new { Status = HttpStatusCode.BadRequest, Message = "Email Sama" });
                }
                else if (result == 4)
                {
                    return BadRequest(new { Status = HttpStatusCode.BadRequest, Message = "Phone Sama" });
                }
                else 
                {
                    return Ok(new { status = HttpStatusCode.OK, result, Message = "Data berhasil di create"});
                } 
            } catch(Exception)

            {
                return BadRequest(new { Status = HttpStatusCode.BadRequest, Message = "Gagal Masuk Data" });
            }
           
        }

        [Authorize(Roles = "Director,Manager")]
        [HttpGet("Get")]
        public ActionResult GetAll()
        {

            var result = employeeRepository.EmployeeAllData();
            return Ok(new { status = HttpStatusCode.OK, result, Message = "Data berhasil di tembak" });
        }

        [HttpGet("Profile/{NIK}")]
        public ActionResult<RegisterVM> Profile(string NIK)
        {
            var result = employeeRepository.GetProfile(NIK);
            if (result != null)
            {
                return Ok(new { status = HttpStatusCode.OK, result, messageResult = "Data ditemukan" });
            }
            return NotFound(new { status = HttpStatusCode.NotFound, result, messageResult = $"Data {NIK} tidak ditemukan." });
        }

        [HttpGet("TestCORS")]
        public ActionResult TestCORS()
        {
            return Ok("Test Cors Berhasil");
        }
    }
}
