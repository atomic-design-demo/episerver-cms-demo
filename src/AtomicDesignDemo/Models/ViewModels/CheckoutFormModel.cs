using System.Collections.Generic;
using AtomicDesignDemo.Features.Button.ViewModels;

namespace AtomicDesignDemo.Models.ViewModels
{
    public class CheckoutFormModel
    {
        public IEnumerable<ButtonBlockViewModel> ButtonGroup { get; set; }
        public FormFieldsModel FormFields { get; set; }
    }

    public class FormFieldsModel
    {
        public IEnumerable<FormFieldItemModel> Items { get; set; }
    }

    public class FormFieldItemModel
    {
        public SelectFieldItemModel SelectField { get; set; }
    }

    public class SelectFieldItemModel
    {
        public string Label { get; set; }
        public IEnumerable<SelectOptionModel> SelectOptions { get; set; }
    }

    public class SelectOptionModel
    {
        public string Value { get; set; }
        public string Option { get; set; }
    }
}
