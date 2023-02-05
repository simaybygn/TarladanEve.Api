
using Microsoft.AspNetCore.Mvc;
using TarladanEve.Api.Data;
using TarladanEve.Api.Models;
using TarladanEve.Api.Models.Request.Product;
using TarladanEve.Api.Models.Request.User;
using TarladanEve.Api.Models.User;

namespace TarladanEve.Api.Controllers
{


    namespace BitirmeProjesi.API.Controllers
    {
        [ApiController]
        [Route("api/[controller]/[action]")]
        public class ProductController : ControllerBase
        {
            private DataContext _context;

            public ProductController(DataContext context)
            {
                _context = context;
            }

            [HttpGet(Name = "GetAllProducts")]

            public ActionResult GetProducts()
            {
                try
                {
                    var _products = _context.Products.ToList();

                    if(_products != null)
                    {
                        return Ok(_products);
                    }
                    else
                    {
                        return BadRequest("Ürün kaydı bulunamadı !");
                    }
                }
                catch(Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }


            //[HttpPost(Name = "GetProductsByCreatedIdAndName")]
            //public ActionResult GetProductsByCreatedIdAndName(GetAndDeleteProductRequest _request)
            //{
            //    try
            //    {
            //        var _products = _context.Products
            //            .Where(f => f.Name == _request.Name
            //                      || (f.CreatedUserName == _request.CreatedUserName).ToList();

            //        if (_products != null)
            //        {
            //            return Ok(_products);
            //        }
            //        else
            //        {
            //            return BadRequest("Bu bilgi ile kayıtlı ürün bulunamadı !");
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        return BadRequest(ex.Message);
            //    }
            //}

            [HttpPost(Name = "CreateProduct")]
            public ActionResult CreateProduct(CreateProductRequest _request)
            {
                try
                {
                    Product _product = _context.Products
                        .Where(f => f.Name == _request.Name
                                  && f.Type == _request.Type
                                  && f.Description == _request.Description
                                  && f.Price == _request.Price
                        //&& f.CreatedUserId == _request.CreatedUserId
                        ).FirstOrDefault();

                    if (_product == null) 
                    {
                         Product _newProduct = new Product();

                        _newProduct.Id = Guid.NewGuid();
                        _newProduct.Type = _request.Type;
                        _newProduct.Description = _request.Description;
                        _newProduct.Price = _request.Price;
                        _newProduct.Name = _request.Name;
                        //_newProduct.CreatedUserId = _request.CreatedUserId;

                        _context.Products.Add(_newProduct);
                        _context.SaveChanges();

                        return Ok(_newProduct.Id);
                    }
                    else
                    {
                        return BadRequest("Bu bilgiler ile bir ürün mevcut !");
                    }
                }
                catch(Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }


            [HttpPost(Name ="UpdateProduct")]
            public ActionResult UpdateProduct(UpdateProductRequest _request)
            {
                try
                {
                    Product _product = _context.Products
                          .Where(f => f.Name == _request.Name
                                      && f.Type == _request.Type
                                    //&& f.CreatedUserId == _request.CreatedUserId
                                   ).FirstOrDefault();

                    if(_product != null)
                    {
                        _product.Name = _request.Name;
                        _product.Price = _request.Price;
                        _product.Description = _request.Description;
                        _product.Type = _request.Type;

                        _context.Products.Update(_product);
                        _context.SaveChanges();

                        return Ok(true);
                    }
                    else 
                    {
                        return BadRequest("Ürün bulunamadı !");
                    }
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            [HttpPost(Name = "DeleteProduct")]
            public ActionResult DeleteProduct(GetAndDeleteProductRequest _request)
            {
                try
                {
                    var _product = _context.Products
                          .Where(f => f.Id == _request.Id ).FirstOrDefault();

                    if (_product != null)

                    {
                        _context.Products.Remove(_product);
                        _context.SaveChanges();

                        return Ok(true);
                    }
                    else
                    {
                        return BadRequest("Bu bilgi ile kayıtlı ürün bulunamadı !");
                    }
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }
    }

}
