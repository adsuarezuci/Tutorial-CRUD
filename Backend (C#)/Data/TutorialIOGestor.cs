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
        private int getLastID(List<Tutorial> list){
            int aux = 0;
            foreach (var item in list)
            {
                if(item.id > aux) aux = item.id;
            }
            return aux;
        }

        public List<Tutorial> getTutorials(){
            return GetListFromFile();
        }

        public Tutorial AddTutorial(Tutorial t){
            try
            {
                var list = GetListFromFile();
                t.id = getLastID(list);
                list.Add(t);
                WriteListToFile(list);
            }
            catch (System.Exception)
            {
                return null;
            }
            return t;
        }

        public bool DeleteTutorial(int id){
            try
            {
                var auxList = new List<Tutorial>();
                var list = GetListFromFile();
                foreach (var item in list)
                {
                    if(item.id != id)
                        auxList.Add(item);
                }
                WriteListToFile(auxList);
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public bool ChangeTutorial(Tutorial t){
            var success = false;
            try
            {
                var auxList = new List<Tutorial>();
                var list = GetListFromFile();
                foreach (var item in list)
                {
                    if(item.id == t.id)
                    {
                        auxList.Add(t);
                        success = true;
                    }
                    else auxList.Add(item);
                }
                WriteListToFile(auxList); 
            }
            catch (System.Exception)
            {
                success = false;
            }
            return success;
        }

        public bool DeleteAll(){
            try
            {
                WriteListToFile(new List<Tutorial>());
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

    }
}