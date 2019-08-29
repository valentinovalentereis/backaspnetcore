namespace ExemploBaseEF.APIException
{
    using System;
    using System.Collections.Generic;

    public class ApiException
    {
        public string message { get; set; }
        public string detail { get; set; }
        public IList<string> errors { get; set; }

        public ApiException(Exception exception)
        {
            message = exception.Message;
            detail = exception.StackTrace;
            errors = new List<string>();

            CarregarInnerException(exception.InnerException);
        }

        private void CarregarInnerException(Exception exception)
        {
            if (exception != null)
            {
                errors.Add(exception.Message);
                CarregarInnerException(exception.InnerException);
            }
        }
    }
}
