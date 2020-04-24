using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.ViewModels.Search
{
    public class SearchViewModel
    {
        [Required(ErrorMessage = "Пустой поиск")]
        public string searchString { get; set; }
    }
}
