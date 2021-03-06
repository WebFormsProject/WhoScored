﻿using System;

namespace WhoScored.MVP.Models.CustomEventArgs
{
    public class IdEventArgs : EventArgs
    {
        public IdEventArgs(int id)
        {
            this.Id = id;
        }

        public int Id { get; private set; }
    }
}