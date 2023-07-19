using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class Respons
    {
        public string Message { get; set; }
        public object Data { get; set; }
        public bool Flag { get; set; }
    }
    public static  class TestStaticClass
    {
       
        public static Respons ShowMessager(this object data)
        {
                return new Respons()
                {
                    Message = "Tác vụ thành công",
                    Data = data,
                    Flag = true
                };
        }
    }
}
