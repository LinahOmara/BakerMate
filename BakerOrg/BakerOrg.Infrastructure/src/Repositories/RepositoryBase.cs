/*
 * Copyright (c) 2019-present RaisaEnergy. All Rights Reserved.
 * 
 * Licensed Material - Property of RaisaEnergy.
 */

using System;
using Abrar.BakerOrg.Services;

namespace Abrar.BakerOrg.Repositories
{
    public class RepositoryBase
    {
        protected static void Assert(bool condition, string message)
        {
            if (!condition) throw new ArgumentException(message);
        }

        protected static void EnsureExists(object obj)
        {
            if (obj == null) throw new ObjectNotFoundException();
        }

        protected static void EnsureExists(object obj, string message)
        {
            if (obj == null) throw new ObjectNotFoundException(message);
        }
    }
}
