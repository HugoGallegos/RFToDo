using CurrieTechnologies.Razor.SweetAlert2;

namespace RFToDo.Shared.Helpers
{
    public interface ISweetAlertMessage
    {
        Task SweetMessege(SweetAlertService service, string _title, string _text, string _icon);
        Task SweetMessegeLoading(SweetAlertService service, string _title, string _text);
        Task<bool> SweetQuestion(SweetAlertService service, string _title, string _text, string _icon);
    }
}
