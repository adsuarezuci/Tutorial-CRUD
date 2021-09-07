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
        public List<Tutorial> tutorials = new List<Tutorial>{
            new Tutorial{
                id = 1,
                title = "C#",
                description = "First step with c#.",
                publish = false
            },
            new Tutorial{
                id = 2,
                title = "Pionex",
                description = "Learn how to use Pionex.",
                publish = false
            },
            new Tutorial{
                id = 3,
                title = "ReactJS",
                description = "First step with React.",
                publish = false
            },
            new Tutorial{
                id = 4,
                title = "ReactJS advance",
                description = "Development CRUD and upload files in reactjs",
                publish = false
            },
        };

       /*  public static List<Tutorial> initList(){
            List<Tutorial> auxList = new List<Tutorial>();
            tutorials.Add( new Tutorial(1,"C#","First step with c#.",false));
            tutorials.Add( new Tutorial(2,"Pionex#","Learn how to use Pionex.",false));
            tutorials.Add( new Tutorial(3,"ReactJS#","First step with React.",false));
            tutorials.Add( new Tutorial(4,"ReactJS advance#","Development CRUD and upload files in reactjs.",false));
            return auxList;
        } */
        

        [HttpGet]
        [Route("")]
        public IActionResult Get(){
            var ioGestor = new TutorialIOGestor();
            var list = ioGestor.getTutorials();
            return Ok(list);
        }

        [HttpPost]
        [Route("add")]
        public IActionResult Post(Tutorial addTutorial){
            int auxID = 0;
            /* for (int i = 0; i < tutorials.Lenght; i++)
            {
                if(tutorials[i].id > auxID) auxID = tutorials[i].id;
            } */
            foreach (var item in tutorials)
            {
                if(item.id > auxID) auxID = item.id;
            }
            addTutorial.id = auxID;
            tutorials.Add(addTutorial);
            return Ok(tutorials);
        }


    }
}