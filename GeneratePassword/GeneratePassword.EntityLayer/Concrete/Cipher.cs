using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratePassword.EntityLayer.Concrete
{
    public class Cipher
	{
		[Key]
		public Guid GuidID { get; set; }
        public string? Description { get; set; }
        public string? Password { get; set; }
    }
}
