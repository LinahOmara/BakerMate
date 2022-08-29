/*
 * Copyright (c) 2019-present RaisaEnergy. All Rights Reserved.
 * 
 * Licensed Material - Property of RaisaEnergy.
 */

using System;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Primitives;

namespace Abrar.BakerOrg.Filters
{
    public class QueryStringConstraintAttribute : ActionMethodSelectorAttribute
    {
        public string ParamName { get; private set; }
        public bool ParamPresent { get; private set; }

        public QueryStringConstraintAttribute(string paramName, bool paramPresent = true)
        {
            this.ParamName = paramName;
            this.ParamPresent = paramPresent;
        }

        public override bool IsValidForRequest(RouteContext routeContext, ActionDescriptor action)
        {
            var value = routeContext.HttpContext.Request.Query[ParamName];
            return ParamPresent ? !StringValues.IsNullOrEmpty(value) : StringValues.IsNullOrEmpty(value);
        }
    }
}
