using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using APITest.Data;



namespace APITest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TutorialController :ControllerBase
    {
        private TutorialIOGestor ioGestor  = new TutorialIOGestor();
      
        [HttpGet]
        [Route("")]
        public IActionResult Get(){
            var list = ioGestor.getTutorials();
            return Ok(list);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult Get(int id){
            var t = ioGestor.getTutorial(id);
            if (t == null)
                return Ok(false);
            else
                return Ok(t);
        }

        [HttpPost]
        [Route("add")]
        public IActionResult Post(Tutorial t){
            return Ok(ioGestor.AddTutorial(t));
        }

        [HttpDelete]
        [Route("delete/{id:int}")]
        public IActionResult Delete(int id){
            return Ok(ioGestor.DeleteTutorial(id));
        }

        [HttpDelete]
        [Route("deleteAll")]
        public IActionResult DeleteAll(){
            return Ok(ioGestor.DeleteAll());
        }

        [HttpPut]
        [Route("change")]
        public IActionResult Change(Tutorial t){
            return Ok(ioGestor.ChangeTutorial(t));
        }


    }
}