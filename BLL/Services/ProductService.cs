using System;
using DAL.Models.Dtos.Product;
using DAL.Models;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace BLL.Services
{
    public class ProductService
    {
        public readonly IMapper _mapper;
        public ProductService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Tuple<int, string> AddImageProduct(List<IFormFile> data, long productId)
        {
            using (var _context = new StoreDbContext())
            {
                try
                {
                    foreach (var imgobj in data)
                    {
                        var guid = Guid.NewGuid();
                        var filePath = Path.Combine("wwwroot", imgobj.Name + "_" + imgobj.FileName + guid + ".jpg");
                        if (imgobj != null)
                        {
                            var fileStream = new FileStream(filePath, FileMode.Create);
                            imgobj.CopyTo(fileStream);
                        }
                        var image = new ImageProduct
                        {
                            ImageName = imgobj.FileName,
                            ImageUrl = filePath.Remove(0, 7),
                            FkProduct = productId
                        };
                        _context.ImageProducts.Add(image);
                        _context.SaveChanges();
                    }
                    return Tuple.Create(1, "Succes Add " + data.Count() + " Image To Product");
                }
                catch (Exception Ex)
                {
                    return Tuple.Create(-1, Ex.Message);
                }
            }
        }

        public Tuple<int, string> CreateProduct(long categoryId,Product prdckObj, long userId, DescriptionProduct dscObj, CategoryProduct catobj)
        {
            using (var _context = new StoreDbContext())
            {
                using (var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        var storId = _context.Stores.Where(s => s.FkUser == userId).FirstOrDefault().Id;
                        #region add product
                        prdckObj.FkStore = storId;
                        prdckObj.CreatedAt = DateTime.Now;
                        if(prdckObj.FkCategory == 0)
                        {
                            _context.CategoryProducts.Add(catobj);
                            _context.SaveChanges();
                            prdckObj.FkCategory = catobj.Id;
                        }
                        _context.Products.Add(prdckObj);
                        _context.SaveChanges();
                        #endregion add product
                        #region add description product
                        dscObj.ProductId = prdckObj.Id;
                        _context.DescriptionProducts.Add(dscObj);
                        _context.SaveChanges();
                        #endregion add description product
                        transaction.Commit();
                        return Tuple.Create(1, "Success Add Product");

                    }
                    catch (Exception Ex)
                    {
                        transaction.Rollback();
                        return Tuple.Create(-1, Ex.Message);
                    }
                    
                }
            }
        }


    }
}
