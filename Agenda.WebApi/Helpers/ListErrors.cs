using System;
using System.Collections.Generic;
using System.Web.Http.ModelBinding;

namespace Agenda.WebApi.Helpers
{

    //classe auxiliar no retorno de errors de validação dos models
    public class ListErrors
    {
        public static List<String> toList(IEnumerable<ModelError> err)
        {
            var errors = new List<String>();
            foreach (var e in err)
            {
                errors.Add(e.ErrorMessage);
            }
            return errors;
        }
    }
}