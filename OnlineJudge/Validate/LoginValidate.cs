using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace OnlineJudge.Validate
{
    
    public class LoginValidate : ValidationAttribute
    {
        ConnnectDatabase tmp = new ConnnectDatabase();

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value != null)
            {
                string input = value.ToString();
                //简单的验证（表达式符合）完成后，进行进一步验证
                //现在有 邮箱和密码
                //if(kind==0)
                {
                    string query = @"select * from onlinejudge.author
where Email = '" + input + "' ;";
                    MySqlDataReader mydatareader = ConnnectDatabase.ExecQuery(query);

                    //1，如果邮箱在数据库不存在
                    if (mydatareader.Read() == false)
                    {
                        return new ValidationResult("没有这个用户");
                    }
                    else
                    {
                        //string bookres = "";
                        //while (mydatareader.Read() == true)
                        //{
                        //    bookres += mydatareader["id"];
                        //    bookres += mydatareader["userName"];
                        //    bookres += mydatareader["password"];
                        //}
                    }
                }
                //else
                {
                    //邮箱已经存在，还要检查密码
                    /*
                    {
                        string query = @"select * from onlinejudge.author
where Email = '" +   "' and Password = '"+input+"' ;";
                        MySqlDataReader mydatareader = tmp.Query(query);

                        //1，密码错误
                        if (mydatareader.Read() == false)
                        {
                            return new ValidationResult("密码错误");
                        }
                    }
                     * */
                }



                

                

                //                string query = @"insert into `OnlineJudge`.`author`
                //(`AuthorID`,`Email`,`Password`,`Name`,`TotalScore`,`DataChange_CreateTime`,`DataChange_ChangeTime`)
                //values('','zhouxj327@sina.com','a','a',0,now(),now());";
                //                tmp.Insert(query);



                //2，密码和数据库中的值不对

                try
                {

                }
                catch
                {

                }
                
            }
            return ValidationResult.Success;
        }
    
        
    }
}