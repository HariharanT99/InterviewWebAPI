using System;

namespace ViewModel
{
    public class ResponseViewModel<T>
    {

        public ErrorViewModel Error { get; set; }

        public T Data { get; set; }

    }
}
