using System;
using DAL.Models;
using AutoMapper;
using DAL.Models.Dtos.Store;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class StoreServices
    {
        private readonly IMapper _mapper;

        public StoreServices(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Tuple<int,List<StoreDetailToCustomerDto>, string> GetStoreDetailToCustomer()
        {
            List<StoreDetailToCustomerDto> obj = new List<StoreDetailToCustomerDto>();
            using (var _context = new StoreDbContext())
            {
                try
                {
                    var stores = _context.Stores.ToList();
                    foreach (var item in stores)
                    {
                        var data = _mapper.Map<StoreDetailToCustomerDto>(item);
                        var user = _context.Users.Where(u => u.FkStore == item.Id).FirstOrDefault();
                        data.Phone = user.Phone;
                        var adrs = _context.Addresses.Where(a => a.Id == user.FkAddres).FirstOrDefault();
                        data.Addresses = adrs;
                        obj.Add(data);
                    }
                    return Tuple.Create(1, obj, "This List Of stores");
                }
                catch (Exception Ex)
                {
                    return Tuple.Create(-1, obj, Ex.Message);
                }
            }
        }

        public Tuple<int, string> CreateStore(Store store, long userId)
        {
            using (var _context = new StoreDbContext())
            {
                using (var _transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        var user = _context.Users.Where(u => u.Id == userId).FirstOrDefault();
                        if (user != null)
                        {
                            user.FkRoleBase = 2;
                            store.FkUser = userId;
                            store.IsOpen = true;
                            store.CreatedAt = DateTime.Now;
                            _context.Stores.Add(store);
                            _context.SaveChanges();
                            user.FkStore = store.Id;
                            _context.Users.Update(user);
                            _context.SaveChanges();
                            _transaction.Commit();
                            return Tuple.Create(1, "Create store succes");
                        }
                        else
                        {
                            return Tuple.Create(-1, "User not found");
                        }
                        
                    }
                    catch (Exception Ex)
                    {
                        _transaction.Rollback();
                        return Tuple.Create(-1, Ex.Message);
                    }
                }
            }
        }
        
        //GetStoreDetail for Store Admin
        public Tuple<int, StoreDetailAdminDto,string> GetStores(long id)
        {
            StoreDetailAdminDto obj = new StoreDetailAdminDto();
            using (var _context = new StoreDbContext())
            {
                try
                {
                    var store = _context.Stores.Where(s => s.FkUser == id).FirstOrDefault();
                    if (store != null)
                    {
                        obj = _mapper.Map<StoreDetailAdminDto>(store);
                        return Tuple.Create(1, obj, "Succes Get Store Detail");
                    }
                    return Tuple.Create(-1, obj, "You not have A Store");

                }
                catch (Exception Ex)
                {
                    return Tuple.Create(-1, obj, Ex.Message);
                }
            }
        }
    }
}
