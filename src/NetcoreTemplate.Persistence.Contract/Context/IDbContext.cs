﻿using Microsoft.EntityFrameworkCore;

 namespace NetcoreTemplate.Persistence.Contract.Context
{
    public interface IDbContext
    {
        DbContext Instance { get; }
    }
}