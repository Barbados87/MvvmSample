using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MVVMExample.ViewModelBase
{
    public delegate string ValidationRuleDelegate(object instance, string memberName);

    public class DataErrorSupport : IDataErrorInfo
    {
        private readonly Dictionary<string, List<ValidationRuleDelegate>> _validationRules;
        private readonly List<ValidationRuleDelegate> _validationRuleList;
        private readonly object _instance;

        public DataErrorSupport(object instance)
        {
            if (instance == null) { throw new ArgumentNullException("instance"); }
            _instance = instance;

            _validationRules = new Dictionary<string, List<ValidationRuleDelegate>>();
            _validationRuleList = new List<ValidationRuleDelegate>();

            CreateRules();
        }

        private void CreateRules()
        {
            // Get all validation attributes
            var validations =
                _instance.GetType().GetProperties().SelectMany(
                    property =>
                    property.GetCustomAttributes(typeof(ValidationAttribute), true).OfType<ValidationAttribute>().Select(attribute => new { property, attribute }));

            // Add rules based on each validation attribute
            foreach (var v in validations)
            {
                // Prevent closure 
                var validation = v;
                AddValidationRule(validation.property.Name, (o, name) =>
                    {
                        if (!validation.attribute.IsValid(validation.property.GetValue(_instance, null)))
                        {
                            return validation.attribute.FormatErrorMessage(validation.property.Name);
                        }

                        return string.Empty;
                    });
            }
        }

        public string Error
        {
            get { return this[""]; }
        }

        public string this[string memberName]
        {
            get
            {
                memberName = memberName ?? "";
                string errorMessage;
                if (string.IsNullOrEmpty(memberName))
                {
                    // We need to use a List because the Dictionary.ValuesCollection doesn't preserve the order.
                    errorMessage = ExecuteValidationRules(_validationRuleList, memberName);
                }
                else
                {
                    List<ValidationRuleDelegate> rules = new List<ValidationRuleDelegate>();

                    if (_validationRules.ContainsKey(memberName))
                    {
                        rules.AddRange(_validationRules[memberName]);
                    }
                    if (_validationRules.ContainsKey("")) 
                    {
                        // The default validation rule is always executed.
                        rules.AddRange(_validationRules[""]);
                    }
                    
                    errorMessage = ExecuteValidationRules(rules, memberName);
                }

                return errorMessage;
            }
        }
        
        public DataErrorSupport AddValidationRule(string memberName, ValidationRuleDelegate validationRule)
        {
            memberName = memberName ?? "";
            if (_validationRules.ContainsKey(memberName))
            {
                _validationRules[memberName].Add(validationRule);
                //throw new ArgumentException("A ValidationRule with the same memberName '" + memberName + "' is already registered.");
            }
            else
            {
                _validationRules.Add(memberName, new List<ValidationRuleDelegate> { validationRule });    
            }
            
            _validationRuleList.Add(validationRule);
            return this;
        }

        private string ExecuteValidationRules(IEnumerable<ValidationRuleDelegate> validationRules, string memberName)
        {
            StringBuilder errorBuilder = new StringBuilder();
            foreach (ValidationRuleDelegate validationRule in validationRules)
            {
                string error = validationRule(_instance, memberName);
                if (!string.IsNullOrEmpty(error))
                {
                    errorBuilder.AppendInNewLine(error);
                }
            }

            return errorBuilder.ToString();
        }
    }
}