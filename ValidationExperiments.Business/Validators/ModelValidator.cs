using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace ValidationExperiments.Business.Validators
{
    public static class ModelValidator
    {
        private static IList<ValidationResult> GetModelValidationResults(object model)
        {
            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(model, null, null);
            
            Validator.TryValidateObject(model, ctx, validationResults, true);
            return validationResults;            
        }
        public static void ValidateModel(object model)
        {
            var ctx = new ValidationContext(model, null, null);
            
            Validator.ValidateObject(model, ctx, true);

            //if (GetModelValidationResults(model).Count() > 0)
            //    throw new Exception("Invalid model.");
        }
    }
}
