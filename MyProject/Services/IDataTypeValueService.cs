using Microsoft.AspNetCore.Mvc.Rendering;

namespace MyProject.Services
{
    public interface IDataTypeValueService
    {
        IEnumerable<SelectListItem> GetItemsFromValueListDataType(string dataTypeName, 
            string[] selectedValues);
    }
}
