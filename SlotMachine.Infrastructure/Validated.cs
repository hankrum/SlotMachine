﻿using System;

namespace SlotMachine.Infrastructure
{
    public static class Validated
    {
        public static void NotNull(object tested, string message)
        {
            if (tested == null)
            {
                throw new ArgumentNullException(message);
            }
        }
    }
}
