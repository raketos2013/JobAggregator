using JobAggregator.Core.Entities;
using JobAggregator.Core.Queries;
using Microsoft.EntityFrameworkCore;

namespace JobAggregator.Core.Extensions;

public static class QueryableExtensions
{
    public static async Task<PagedList<T>> SortSkipTakeAsync<T>(this IQueryable<T> items, Query query) where T : class
    {
        if (string.IsNullOrEmpty(query.SortColumn))
        {
            query.SortColumn = "Id";
        }
        var property = typeof(T).GetProperty(query.SortColumn);
        if (property != null)
        {
            if (query.IsAscending)
            {
                items = items.OrderBy(x => EF.Property<object>(x, query.SortColumn));
            }
            else
            {
                items = items.OrderByDescending(x => EF.Property<object>(x, query.SortColumn));
            }
        }
        return await PagedList<T>.ToPagedList(items, query.Skip, query.Take);
    }

    public static IQueryable<Vacancy> SearchByTerm(this IQueryable<Vacancy> query, string? term)
    {
        if (string.IsNullOrEmpty(term))
        {
            return query;
        }
        term = term.Trim().ToLower();
        return query.Where(x => EF.Functions.Like(x.Name.ToLower(), $"%{term}%") ||
                                EF.Functions.Like(x.Description.ToLower(), $"%{term}%"));
    }

    public static IQueryable<Organization> SearchByTerm(this IQueryable<Organization> query, string? term)
    {
        if (string.IsNullOrEmpty(term))
        {
            return query;
        }
        term = term.Trim().ToLower();
        return query.Where(x => EF.Functions.Like(x.Name.ToLower(), $"%{term}%"));
    }

    public static IQueryable<User> SearchByTerm(this IQueryable<User> query, string? term)
    {
        if (string.IsNullOrEmpty(term))
        {
            return query;
        }
        term = term.Trim().ToLower();
        return query.Where(x => EF.Functions.Like(x.Name.ToLower(), $"%{term}%") ||
                                EF.Functions.Like(x.LastName.ToLower(), $"%{term}%"));
    }
}
