using Project.identityserver.Domain.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Project.identityserver.Domain.Core.Data
{
    public class PagedListMongo<TEntity> where TEntity : class
    {
        public PagedListMongo() { }

        public PagedListMongo(IQueryable<TEntity> entities, int totalregistros, PaginationObject pagination)
        {
            Order = pagination.Order;
            Page = pagination.Page;

            TotalRecords = totalregistros;
            CurrentPage = pagination.Page.Index;
            PageSize = pagination.Page.Quantity;
            TotalPages = (int)Math.Ceiling(TotalRecords / (double)pagination.Page.Quantity);
            Results = entities.ToList();
        }

        public int TotalRecords { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public IList<TEntity> Results { get; set; }

        public int FirstRecordOnPage
        {
            get { return TotalRecords > 0 ? (CurrentPage - 1) * PageSize + 1 : 0; }
        }

        public int LastRecordOnPage
        {
            get { return Math.Min(CurrentPage * PageSize, TotalRecords); }
        }

        [JsonIgnore]
        public Page Page { get; set; }
                
        [JsonIgnore]
        public Order Order { get; set; }
    }
}