using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace APITest.Data
{
    public class Tutorial
    {
        
        public int id{get; set;}

        public string title {get; set;}
        public string description {get; set;}
        public bool publish {get; set;}

       /*  public Tutorial(int pId,string pTitle,string pDescription, bool pPublish){
            this.id = pId;
            this.title = pTitle;
            this.description = pDescription;
            this.publish = pPublish;
        } */

    }
}