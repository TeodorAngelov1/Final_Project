﻿namespace PcStore.Services.Data
{
    using PcStore.Services.Data.Interfaces;
    public class BaseService : IBaseService
    {
        public bool IsGuidValid(string? id, ref Guid parsedGuid)
        {
            if (String.IsNullOrWhiteSpace(id))
            {
                return false;
            }

            bool isGuidValid = Guid.TryParse(id, out parsedGuid);
            if (!isGuidValid)
            {
                return false;
            }

            return true;
        }
    }
}
