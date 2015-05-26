using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace OnlineJudge
{
    public class RunCode
    {
        public static void CompileCode(string fileName)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo = new System.Diagnostics.ProcessStartInfo("cmd.exe");
            process.StartInfo.WorkingDirectory = System.AppDomain.CurrentDomain.BaseDirectory + "../Submissions";
            string fileGet = fileName + ".exe";
            string filePush = fileName + ".cpp";
            process.StartInfo.Arguments = String.Format("/c g++ -o "+fileGet+" "+filePush);
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.ErrorDialog = false;
            process.Start();


            process.Close();
        }


        public static string RunCodeGetResult(string fileName,int problemId,int SubmissionId)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            string temp = System.AppDomain.CurrentDomain.BaseDirectory + "../Submissions";
            process.StartInfo.WorkingDirectory = temp;
            process.StartInfo.FileName = temp + "/" + fileName+".exe";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.CreateNoWindow = true;
            process.Start();

            string filePath = System.AppDomain.CurrentDomain.BaseDirectory + "../Problems/"+problemId.ToString()+"/"+problemId.ToString()+"_input.txt";
            string[] lines = System.IO.File.ReadAllLines(filePath);
            foreach(string line in lines)
            {
                process.StandardInput.WriteLine(line);
            }
            
            process.StandardInput.WriteLine("exit");
            string strRst = process.StandardOutput.ReadToEnd();

            string filepath = System.AppDomain.CurrentDomain.BaseDirectory + "../Submissions/" + SubmissionId.ToString() + ".txt";

            if (File.Exists(filepath))
                File.Delete(filepath);
            FileStream fs = new FileStream(filepath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            //代码执行的输出结果保存到Submissions下SubmissionsId.txt文件
            StreamWriter swWriteFile = new StreamWriter(fs);
            swWriteFile.Write(strRst);
            swWriteFile.Close();
            return strRst;
        }

        public static string CompareResult(string Result,int problemId,int SubmissionId)
        {
            string[] source = Result.Split('\n');
            string filePath = System.AppDomain.CurrentDomain.BaseDirectory+"../Problems/"+problemId.ToString()+"/"+problemId.ToString()+"_output.txt";
            string[] tar = System.IO.File.ReadAllLines(filePath);
            int judge1 = 0;
            int len = tar.Count();
            string strWriteFilePath = System.AppDomain.CurrentDomain.BaseDirectory + "../Submissions/" + SubmissionId.ToString() + "_result.txt";
            
            
            if (File.Exists(strWriteFilePath))
                File.Delete(strWriteFilePath);
            
            FileStream fs = new FileStream(strWriteFilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamWriter swWriteFile = new StreamWriter(fs);
            int g = source.Length;
            for(int i=0;i<len;i++)
            {
                if(i>=g)
                {
                    swWriteFile.WriteLine("WrongAnswer");
                    continue;
                }
                //source[i] = source[i].Replace(" ","");
                if (source[i].Length>0&&source[i].Contains('\r'))
                    source[i] = source[i].Replace("\r", "");
                //int g = source[i].Length;
                string[] source_element = source[i].Split(new char[3] { ' ', '\t','\r' });
                string[] tar_element = tar[i].Split(new char[2] { ' ', '\t' });

                int len2 = source_element.Count();
                int judge = 0;
                if (tar_element.Count() != len2)
                {
                    swWriteFile.WriteLine("WrongAnswer");
                    judge1 = 1;
                    continue;
                }
                for(int j=0;j<len2;j++)
                {
                    if (source_element[j].CompareTo(tar_element[j]) != 0)
                    {
                        swWriteFile.WriteLine("WrongAnswer");
                        judge1 = 1;
                        judge = 1;
                        break;
                    }
                }
                if (judge == 1) continue;

                swWriteFile.WriteLine("Accept");
            }
            swWriteFile.Close();
            if (judge1==1) return "WrongAnswer";
            return "Accept";
        }
    }
}