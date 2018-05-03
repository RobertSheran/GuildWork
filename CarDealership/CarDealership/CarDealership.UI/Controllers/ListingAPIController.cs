using CarDealership.BLL.Factories;
using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarDealership.UI.Controllers
{
    public class ListingAPIController : ApiController
    {
        [Route("api/listings/search")]
        [AcceptVerbs("Get")]
        public IHttpActionResult Search(int? minYear, int? maxYear, int? minPrice, int? maxPrice, string make)
        {
            var repo = RepositoryManagerFactory.Create();
            try
            {
                var perameters = new ListingSearchPerameters()
                {
                    MakeModel = make,
                    MaxPrice = maxPrice,
                    MinPrice = minPrice,
                    MinYear = minYear,
                    MaxYear = maxYear
                };
                var result = repo.Search(perameters);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("api/listings/searchNew")]
        [AcceptVerbs("Get")]
        public IHttpActionResult SearchNew(int? minYear, int? maxYear, int? minPrice, int? maxPrice, string make)
        {
            var repo = RepositoryManagerFactory.Create();
            try
            {
                var perameters = new ListingSearchPerameters()
                {
                    MakeModel = make,
                    MaxPrice = maxPrice,
                    MinPrice = minPrice,
                    MinYear = minYear,
                    MaxYear = maxYear
                };
                var result = repo.SearchNew(perameters);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("api/listings/searchUsed")]
        [AcceptVerbs("Get")]
        public IHttpActionResult SearchUsed(int? minYear, int? maxYear, int? minPrice, int? maxPrice, string make)
        {
            //MinPrice=&MaxPrice=MinYear=&MaxYear=&Make=
            var repo = RepositoryManagerFactory.Create();
            try
            {
                var perameters = new ListingSearchPerameters()
                {
                    MakeModel = make,
                    MaxPrice = maxPrice,
                    MinPrice = minPrice,
                    MinYear = minYear,
                    MaxYear =maxYear
                };
                var result = repo.SearchUsed(perameters);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}