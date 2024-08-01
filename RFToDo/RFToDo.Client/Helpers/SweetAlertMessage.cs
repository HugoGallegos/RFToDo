using CurrieTechnologies.Razor.SweetAlert2;

namespace RFToDo.Client.Helpers
{
    public class SweetAlertMessage : ISweetAlertMessage
    {
        public async Task SweetMessege(SweetAlertService service, string _title, string _text, string _icon)
        {
            await service.FireAsync(new SweetAlertOptions
            {
                Title = _title,
                Text = _text,
                Icon = _icon,
                ConfirmButtonText = "Ok"

            });
        }

        public async Task SweetMessegeLoading(SweetAlertService service, string _title, string _text)
        {
            SweetAlertCustomClass sweetAlertCustomClass = new SweetAlertCustomClass();
            sweetAlertCustomClass.Title = _text;
            sweetAlertCustomClass.HtmlContainer = "fa-solid fa-2x text-warning fa-circle-notch fa-spin";

            await service.FireAsync
            (
                new SweetAlertOptions
                {
                    Position = SweetAlertPosition.Center,
                    ShowConfirmButton = false,
                    TimerProgressBar = true,
                    Title = _title,
                    Text = " ",
                    CustomClass = sweetAlertCustomClass
                }

            );
        }

        public async Task<bool> SweetQuestion(SweetAlertService service, string _title, string _text, string _icon)
        {
            var icon = SweetAlertIcon.Warning;
            switch (_icon)
            {
                case "info":
                    icon = SweetAlertIcon.Info;
                    break;
                case "warning":
                    icon = SweetAlertIcon.Warning;
                    break;
                case "success":
                    icon = SweetAlertIcon.Success;
                    break;
                case "question":
                    icon = SweetAlertIcon.Question;
                    break;
                default:
                    icon = SweetAlertIcon.Warning;
                    break;
            }
            SweetAlertResult result = await service.FireAsync(new SweetAlertOptions
            {
                Title = _title,
                Text = _text,
                Icon = icon,
                ShowCancelButton = true,
                ConfirmButtonText = "Yes",
                CancelButtonText = "No"
            });
            return result.IsConfirmed;
        }
    }
}
