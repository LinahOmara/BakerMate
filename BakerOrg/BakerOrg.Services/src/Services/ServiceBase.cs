/*
 * Copyright (c) 2019-present RaisaEnergy. All Rights Reserved.
 * 
 * Licensed Material - Property of RaisaEnergy.
 */

using System;

namespace Abrar.BakerOrg.Services
{
    public class ServiceBase
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
