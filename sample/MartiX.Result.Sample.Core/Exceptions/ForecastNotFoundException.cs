using System;

namespace MartiX.Result.Sample.Core.Exceptions
{
    public class ForecastNotFoundException : Exception
    {
        public ForecastNotFoundException() : base("Forecast not found.") { }
    }
}
