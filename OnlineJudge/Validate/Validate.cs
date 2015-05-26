using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Data;

namespace OnlineJudge
{
    /*
    public class Validate:ValidationAttribute
    {
        public Validate(int Kind)
        {
            kind = Kind;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value!=null)
            {
                if(kind==0)//login
                {
                    //获取到邮箱和密码
                    string s = "server=localhost;user id=root;persistsecurityinfo=True;database=onlinejudge";  //此处使用本地计算机连接方式  
                    SqlConnection conn = new SqlConnection(s);   //创建连接  
                    conn.Open();    //打开连接 
                    SqlCommand cmd = conn.CreateCommand();
//                    cmd.CommandText = @"use OnlineJudge;
//select password from author
//where email='"+value.email+"';";


                    string tmp = value.ToString();

                    cmd.CommandText = @"insert into `OnlineJudge`.`author`
(`AuthorID`,`Email`,`Password`,`Name`,`TotalScore`,`DataChange_CreateTime`,`DataChange_ChangeTime`)
values('1','zhouxj327@sina.com','a',0,now(),now());";
                    cmd.ExecuteNonQuery();

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable mytable = new DataTable();
                    adapter.Fill(mytable);

                    //到数据库查询邮箱对应的密码和用户名，看密码是否正确
                    //passwordConfirm=password
                }
                else //register
                {
                    //验证邮箱在数据库中没有存在
                }
            }
            //return base.IsValid(value, validationContext);
            return ValidationResult.Success;
        }
        private readonly int kind;
    }
     * */
}