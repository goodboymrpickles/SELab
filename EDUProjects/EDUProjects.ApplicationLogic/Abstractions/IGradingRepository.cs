using EDUProjects.ApplicationLogic.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace EDUProjects.ApplicationLogic.Abstractions
{
    public interface IGradingRepository : IRepository<Grading>
    {
        Grading getGradeByProjectID(Guid projectId);

        Grading getFeedbackById(Guid gradingId);

    }
}
