using System;
using System.Linq;

namespace DataStructuresAndAlgorithms.Api.Services
{
    public class BaseService
    {
        public virtual string OriginalOutputs { get; set; }
        public virtual string CustomOutputs { get; set; }

        public virtual void ThrowInValidOperationExceptionIfAnyMethodNotFoundOfTheGivenMethods(object obj, params string[] methodNames)
        {
            foreach (string methodName in methodNames)
            {
                if (obj.GetType()?.GetMethods()?.FirstOrDefault(m => m.Name.Equals(methodName, StringComparison.OrdinalIgnoreCase)) is null)
                    throw new InvalidOperationException($"The required '{methodName}' method was not found in the '{obj.GetType().Name}' class");
            }
        }

        public virtual void ConsoleWriteResults(dynamic enumerableObject, Type originalType)
        {
            string outputs = "";
            foreach (var item in enumerableObject)
            {
                outputs += item;
                Console.WriteLine(item);
            }

            SetupOutputs(enumerableObject, outputs, originalType);
        }

        public virtual void SetupOutputs(object obj, string outputs, Type originalType)
        {
            if (obj.GetType() == originalType) OriginalOutputs += outputs;
            else CustomOutputs += outputs;
        }
    }
}
