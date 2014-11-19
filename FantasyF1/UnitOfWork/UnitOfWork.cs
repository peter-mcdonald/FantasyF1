using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FantasyF1.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public FantasyF1Entities Db { get; set; }

        public UnitOfWork(FantasyF1Entities Db)
        {
            this.Db = Db;
        }

        public IEnumerable<T> Execute<T>(Query query) where T : class
        {
            return query.Execute();
        }

        //static List<T> Split<T>(this string str, char separator, Func<string, T> Convert)
        //{
        //    return Process(str, s => s.Split(separator), Convert).ToList();
        //}

        //static IEnumerable<TOutput> Process<TInput, TData, TOutput>(TInput input, Func<TInput, IEnumerable<TData>> GetData, Func<TData, TOutput> Convert)
        //{
        //    return from datum in GetData(input)
        //           select Convert(datum);
        //}
    }

    public class Query
    {
        public List<Team> Execute()
        {
            return new List<Team>()
                {
                    new Team()
                        {
                            TeamId = 1,
                            TeamName = "Tam"
                        }
                };

        }

    }
}