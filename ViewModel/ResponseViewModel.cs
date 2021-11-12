using System;

namespace ViewModel
{
    public class ResponseViewModel<T>
    {
        public ResponseViewModel()
        {
            Error = new ErrorViewModel();
        }

        public ErrorViewModel Error { get; set; }

        public T Data { get; set; }

    }
}
