/*
 * Copyright (c) 2022-present Baker Mate. All Rights Reserved.
 * 
 * Licensed Material - Property of Baker Mate.
 */

using System;

namespace BakerMate.Services
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
