using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Sample05
{
    class Program
    {
        /// <summary>
        /// 测试插入单条数据
        /// </summary>
        static void test_insert()
        {
            var content = new Content
            {
                title = "标题",
                content = "内容1",
                status = 1
            };

            using (var conn = new SqlConnection("Data Source=(local);Initial Catalog=hellosql;Integrated Security=True;"))
            {
                string sql_insert = @"INSERT INTO [dbo].[content]
           ([title]
           ,[content]
           ,[status]
           ,[add_time]
           ,[modify_time])
            VALUES   ('"
            + content.title + "','"
            + content.content + "',"
            + content.status.ToString() + ",'"
            + content.add_time.ToString() + "','"
            + content.modify_time.ToString()
            + "')";
                var result = conn.Execute(sql_insert, content);
                Console.WriteLine($"test_insert：插入了{result}条数据！");
            }
        }

        static void test_select_one()
        {
            using (var conn = new SqlConnection("Data Source=(local);Initial Catalog=hellosql;Integrated Security=True;"))
            {
                string sql_insert = @"select * from [dbo].[content] where id = '1'";
                var result = conn.QueryFirstOrDefault<Content>(sql_insert, new { id = 1 });
                Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", 
                    result.id
                    ,result.title
                    , result.content
                    , result.status
                    , result.add_time.ToString()
                    , result.modify_time.ToString());
            }
        }

//        /// <summary>
//        /// 测试一次批量插入两条数据
//        /// </summary>
//        static void test_mult_insert()
//        {
//            List<Content> contents = new List<Content>() {
//               new Content
//            {
//                title = "批量插入标题1",
//                content = "批量插入内容1",

//            },
//               new Content
//            {
//                title = "批量插入标题2",
//                content = "批量插入内容2",

//            },
//        };

//            using (var conn = new SqlConnection("Data Source=127.0.0.1;User ID=sa;Initial Catalog=Czar.Cms;Pooling=true;Max Pool Size=100;"))
//            {
//                string sql_insert = @"INSERT INTO [dbo].[comment]
//           ([content_id]
//           ,[content]
//           ,[add_time])
//VALUES   (@title,@content,@status,@add_time,@modify_time)";
//                var result = conn.Execute(sql_insert, contents);
//                Console.WriteLine($"test_mult_insert：插入了{result}条数据！");
//            }
//        }

        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            test_select_one();
            //test_insert();
            //test_mult_insert();
        }
    }
}
