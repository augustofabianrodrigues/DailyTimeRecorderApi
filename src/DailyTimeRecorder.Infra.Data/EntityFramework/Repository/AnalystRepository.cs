using DailyTimeRecorder.Domain.Interfaces;
using DailyTimeRecorder.Domain.Models;
using DailyTimeRecorder.Infra.Data.EntityFramework.Context;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace DailyTimeRecorder.Infra.Data.EntityFramework.Repository
{
    public sealed class AnalystRepository : Repository<Analyst>, IAnalystRepository
    {
        public AnalystRepository(
            DailyTimeRecorderContext context) : base(context)
        {
        }

        public IQueryable<Analyst> GetOptionallyByNameAndEmail(string name, string email)
        {
            IQueryable<Analyst> result = null;
            if (!string.IsNullOrWhiteSpace(name))
                result = Find(analyst => analyst.Name.Equals(name));
            if (string.IsNullOrWhiteSpace(email))
                return result ?? GetAll();

            Expression<Func<Analyst, bool>> predicate = analyst => analyst.Email.Equals(email);
            result = result?.Where(predicate) ?? Find(predicate);

            return result;
        }
    }
}
