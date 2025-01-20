using App.Domain.Core.Entities.Inspection;
using App.Domain.Core.Entities.Users;

namespace App.Infra.Data.Db
{
    public static class InMemoryDb
    {
        public static User CurrentUser { get; set; }
        public static Operator CurrentOperator { get; set; }
    }
}