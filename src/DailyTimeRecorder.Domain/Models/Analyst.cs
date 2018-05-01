using DailyTimeRecorder.Domain.Core.Models;

namespace DailyTimeRecorder.Domain.Models
{
    public class Analyst : Entity
    {
        protected Analyst() : base(0) { }
        private Analyst(long id) : base(id) { }

        public string Email { get; private set; }
        public string Name { get; private set; }

        #region Factory
        public static Analyst CreateExisting(long id, string name, string email)
        {
            return new Analyst(id)
            {
                Name = name,
                Email = email
            };
        }
        public static Analyst CreateNew(string name, string email)
        {
            return new Analyst
            {
                Name = name,
                Email = email
            };
        }
        #endregion
    }
}
