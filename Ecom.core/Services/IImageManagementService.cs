using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace Ecom.core.Services
{
    public interface IImageManagementService
    {
        Task<List<string>> AddImageAsync(IFormFileCollection files, string src);
        void DeleteImageAsync (string src);
    }
}
