using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;

namespace MartiX.Result.SampleWeb.Pages;

public class IndexModel : PageModel
{
    private readonly IStringLocalizer<IndexModel> _stringLocalizer;

    public IndexModel(IStringLocalizer<IndexModel> stringLocalizer)
    {
        _stringLocalizer = stringLocalizer;
    }

    public string Message { get; set; } = String.Empty;
    public void OnGet()
    {
        Message = _stringLocalizer["message"].Value;
    }
}
