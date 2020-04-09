using System;
using System.Collections.Generic;

namespace WSInventary.Model
{
    public partial class Usuario
    {
        public int Id { get; set; }
        public string CompletName { get; set; }
        public string UserName { get; set; }
        public int IdProfile { get; set; }
        public int IdStatus { get; set; }
        public DateTime RegisterDate { get; set; }
        public string Password { get; set; }
    }
}
