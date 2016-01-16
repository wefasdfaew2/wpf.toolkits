using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTFToolkits.BindableBase;

namespace WTFToolkits
{
    public class SimpleModel : ValidatableBase
    {
        public int Id { get; set; }


        private string _name;
        [Required(ErrorMessage = "Model name is required")]
        [StringLength(50, MinimumLength = 3)]
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }


        private string _description;
        [Required(ErrorMessage = "Description is required")]
        [StringLength(50, MinimumLength = 3)]        
        public string Description
        {
            get { return _description; }
            set { SetProperty(ref _description, value); }
        }

    }
}
