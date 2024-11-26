
using Microsoft.EntityFrameworkCore;
using PcStore.Data;
using PcStore.Data.Models;
using PcStore.Services.Data.Interfaces;
using PcStore.Web.ViewModels.Laptop;
using PcStore.Web.ViewModels.MyCart;
using System.Web.Mvc;

namespace PcStore.Services.Data
{
    public class MyCartService : BaseService, IMyCartService
    {
    }
}
