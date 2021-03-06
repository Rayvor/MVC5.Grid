﻿using System;
using System.Linq.Expressions;
using System.Web;

namespace NonFactors.Mvc.Grid
{
    public interface IGridColumn
    {
        String Name { get; set; }
        String Format { get; set; }
        String CssClasses { get; set; }
        Boolean IsEncoded { get; set; }
        IHtmlString Title { get; set; }

        IGridColumnSort Sort { get; }
        IGridColumnFilter Filter { get; }

        IHtmlString ValueFor(IGridRow<Object> row);
    }

    public interface IGridColumn<T, TValue> : IGridProcessor<T>, IGridColumn
    {
        IGrid<T> Grid { get; }

        Func<T, Object> RenderValue { get; set; }
        Expression<Func<T, TValue>> Expression { get; set; }

        new IGridColumnSort<T, TValue> Sort { get; set; }
        new IGridColumnFilter<T, TValue> Filter { get; set; }
    }
}
