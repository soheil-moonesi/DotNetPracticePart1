using System.ComponentModel;
using Microsoft.AspNetCore.Cors;

namespace TagHelperRazor.Models
{
    public class Person
    {
        public int id { get; set; }

        [DisplayName("نام شخص")]
        public string Name { get; set; }
    }
}
