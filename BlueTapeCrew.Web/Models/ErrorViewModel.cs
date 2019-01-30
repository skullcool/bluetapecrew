using System;

namespace BlueTapeCrew.Web.Models
{
    public class ErrorViewModel
    {
        public ErrorViewModel(){}

        public ErrorViewModel(Exception ex)
        {
            Exception = ex;
        }

        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        public Exception Exception { get; set; }
    }
}