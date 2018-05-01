using DailyTimeRecorder.Domain.Core.Interfaces;
using DailyTimeRecorder.Domain.Models;
using System.Linq;

namespace DailyTimeRecorder.Domain.Interfaces
{
    public interface IAnalystRepository : IReadRepository<Analyst>
    {
        IQueryable<Analyst> GetOptionallyByNameAndEmail(string name, string email);
    }
}
