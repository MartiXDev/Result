using System;
using System.Collections.Generic;

namespace MartiX.Result.AspNetCore
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ExpectedFailuresAttribute(params ResultStatus[] resultStatuses) : Attribute
    {
        public IEnumerable<ResultStatus> ResultStatuses { get; } = resultStatuses;
    }
}
