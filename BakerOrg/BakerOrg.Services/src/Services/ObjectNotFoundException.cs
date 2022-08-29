/*
 * Copyright (c) 2019-present RaisaEnergy. All Rights Reserved.
 * 
 * Licensed Material - Property of RaisaEnergy.
 */

using System;

namespace Abrar.BakerOrg.Services
{
    public class ObjectNotFoundException : Exception
    {
        public ObjectNotFoundException()
        {
        }

        public ObjectNotFoundException(string message) : base(message)
        {
        }

        public ObjectNotFoundException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
