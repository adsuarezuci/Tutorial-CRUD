using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace APITest.Data
{
    public class TutorialIOGestor
    {
        private string fileName = "tutorials.json";
        private List<Tutorial> GetListFromFile(){
            string strFile = File.ReadAllText(fileName);
            return JsonSerializer.Deserialize<List<Tutorial>>(strFile);
        }
        private void WriteListToFile(List<Tutorial> list){
            string text = JsonSerializer.Serialize(list);
            File.WriteAllText(fileName,text);
        }
        public List<Tutorial> getTutorials(){
            return GetListFromFile();
        }

        public bool AddTutorial(Tutorial t){
            var list = GetListFromFile();
            list.Add(t);
            return true;
        }

    }
}