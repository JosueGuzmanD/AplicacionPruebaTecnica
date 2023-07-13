using Microsoft.AspNetCore.Mvc.Rendering;

namespace AplicacionPruebaTecnica.Models
{
    public class CustomSelectListItem : SelectListItem
    {
        public string Value { get; set; }
        public string Text { get; set; }
        public virtual string Group { get; set; }
        public bool Selected { get; set; }
    }
}
