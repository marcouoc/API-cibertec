﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebDeveloper.API.Models;
using WebDeveloper.Model;
using WebDeveloper.Repository;

namespace WebDeveloper.API.Controllers
{
    [RoutePrefix("person")]
    public class PersonController : BaseApiController<Person>
    {
       // private IRepository<Person> repository;
        public PersonController(IRepository<Person> repository)
            :base(repository)
        {
            //repository = new BaseRepository<Person>();
        }

       

        //migration personController
        [HttpGet]
        [Route("list/{page:int}/{size:int}")]
        public IHttpActionResult List(int? page, int? size)
        {
            if(!page.HasValue || !size.HasValue)
                {
                page = 1;
                size = 15 ;
            
            }
            return Ok(_repository.PaginatedList(p => p.ModifiedDate, page.Value, size.Value));

        }

        [HttpPut]
        [Route("")]
        public IHttpActionResult Create(Person person)
        {

            if (!ModelState.IsValid) return BadRequest(ModelState);

            person.rowguid = Guid.NewGuid();
            person.ModifiedDate = DateTime.Now;
            person.BusinessEntity = new BusinessEntity
            {
                rowguid = person.rowguid,
                ModifiedDate = person.ModifiedDate
            };
            _repository.Add(person);
            return Ok();

        }

        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult Details(int id)
        {
            var person = _repository.GetById(x => x.BusinessEntityID == id);
            if (person==null) return BadRequest();
            return Ok(person);
        }

        [HttpGet]
        [Route("type")]
        public IHttpActionResult PersonType()
        {
            var list = new[]
    {
                    new SelectItem {Value="SC",Text= "Store Contact", Selected=false},
                    new SelectItem {Value="IN",Text= "Individual (retail) customer", Selected=false },
                    new SelectItem {Value="SP",Text= "Sales person" , Selected=false},
                    new SelectItem {Value="EM",Text= "Employee (non-sales)", Selected=false },
                    new SelectItem {Value="VC",Text= "Vendor contact" , Selected=false},
                    new SelectItem {Value="GC",Text= "General contact", Selected=false }
                };
            return Ok(list);
        }

        [HttpGet]
        [Route("email")]
        public IHttpActionResult EmailPromotion()
        {
            var list = new[]
                {
                    new SelectItem {Value="0",Text= "No promotions.", Selected=false},
                    new SelectItem {Value="1",Text= "Promotion Email", Selected=false },
                    new SelectItem {Value="2",Text= "Promotion Email and Partner Email" , Selected=false}

                };
            return Ok(list);
        }



        [HttpDelete]
        [Route("")]
        public IHttpActionResult Delete(Person person)
        {
           if (person==null) return BadRequest();
            //person = _repository.GetById(x => x.BusinessEntityID == person.BusinessEntityID);
            _repository.Delete(person);
            return Ok();
        }


        [HttpPost]
        [Route("")]
        public IHttpActionResult Update(Person person)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            _repository.Update(person);
            return Ok();
        }
    }
}
