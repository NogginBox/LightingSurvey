using System;

namespace LightingSurvey.Data.Models
{
    public class SurveyDates
    {
        public DateTime Created { get; private set; }

        public DateTime Modified { get; private set; }

        public DateTime? Completed { get; private set; }

        public void Create(DateTime datetime)
        {
            Created = datetime;
            Modify(datetime);
        }

        public void Modify(DateTime datetime)
        {
            Modified = datetime;
        }

        public void Complete(DateTime datetime)
        {
            Completed = datetime;
            Modify(datetime);
        }
    }
}