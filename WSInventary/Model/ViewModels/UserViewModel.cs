using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WSInventary.Model.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string CompletName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int IdStatus { get; set; }
        public int IdProfile { get; set; }
        public DateTime Date { get; set; }
    }
}
