using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Entities;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class CarsController : ApiController
    {
        private CarFinderSvcDemoEntities db = new CarFinderSvcDemoEntities();

        /// <summary>
        /// The GetMakes action leverages the GetMakes SQL Stored Procedure to return a list of Car Makes
        /// </summary>
        /// <returns></returns>
        /// 
        [Route("api/cars/GetMakes")]
        [HttpGet]
        public IEnumerable<string> GetMakes()
        {
            var returnData = db.GetUniqueCarMake();
            return returnData;
        }

        /// <summary>
        /// The GetMakesByYear returns a list of all cars by a specific year
        /// </summary>
        /// <param name="year">This is a test</param>
        /// <returns></returns>
        /// 
        [Route("api/cars/GetMakesByYear")]
        [HttpGet]
        public IEnumerable<string> GetMakesByYear(string year)
        {
            var makes = db.GetCarMakesForYear(year);
            return makes;
        }

        ///// <summary>
        ///// Returns all car makes by year
        ///// </summary>
        ///// <param name="year"></param>
        ///// <param name="CarMakesPerPage"></param>
        ///// <returns></returns>
        //[HttpGet]
        //[Route("GetMakesByYear")]
        //[ActionName("GetCarMakesByYear")]
        //public IHttpActionResult GetCarMakeByYear(string year, int CarMakesPerPage = 50)
        //{
        //    // Get total number of records
        //    int total = db.Cars.Count();
        //    // Select the car makes based on paging parameters
        //    var makesBY = db.GetCarMakesForYear(year)
        //        .Take(CarMakesPerPage)
        //        .ToList();
        //    //through error code and message in case object is null
        //    if (makesBY == null)
        //    {
        //        return Content(HttpStatusCode.NotFound, "Car not found");
        //    }
        //    // Return the list of cars
        //    return Ok(new
        //    {
        //        Data = makesBY,
        //        Paging = new
        //        {
        //            Total = total,
        //            Limit = CarMakesPerPage,
        //            Returned = makesBY.Count
        //        }
        //    });
        //}


        ///// <summary>
        ///// This gets all the cars with a given engine size
        ///// </summary>
        ///// <param name="size"></param>
        ///// <returns></returns>
        //[Route("api/cars/GetCarEngineSizecc")]
        //[HttpGet]
        //public IEnumerable<CarEngineSizecc_Result> GetCarEngineSizecc(string size)
        //{
        //    var engine = db.CarEngineSizecc(size);
        //    return engine;
        //}


       /// <summary>
       /// This is a new thing
       /// </summary>
       /// <param name="size">This is a test</param>
       /// <returns></returns>
        [Route("api/cars/GetCarEngineSizecc")]
        [HttpGet]
        public IEnumerable<CustomModel> GetCarEngineSizecc(string size)
        {
            var engine = db.CarEngineSizecc(size)
                .Select(x => new CustomModel
                {
                    Year = x.year,
                    Make = x.Make,
                    Model = x.model,
                    HP = x.engine_power_ps,
                    Seats = x.seats,
                    Doors = x.doors
                }).ToList();
            return engine;
        }

        /// <summary>
        /// Return All SUV's
        /// </summary>
        /// <returns></returns>
        [Route("api/cars/GetAllSUVs")]
        [HttpGet]
        public IEnumerable<string> GetAllSUVs()
        {
            var suv = db.GetAllSuvs().Select(u => u.model).Distinct();
            
            return suv;
        }

        /// <summary>
        /// Return all cars by a certain weight
        /// </summary>
        /// <returns></returns>
        [Route("api/cars/CarsOrderedByWeight")]
        [HttpGet]
        public IEnumerable<CustomModel> CarsOrderByWeight()
        {
            var weight = db.CarsOrderedByWeight()
                 .Select(x => new CustomModel
                 {
                     Year = x.year,
                     Make = x.Make,
                     Model = x.model,
                     HP = x.engine_power_ps,
                     Seats = x.seats,
                     Doors = x.doors
                 }).ToList();
            return weight;
        }

        /// <summary>
        /// Return all cars over 300HP
        /// </summary>
        /// <returns></returns>
        [Route("api/cars/CarsOver300HP")]
        [HttpGet]
        public IEnumerable<CustomModel> CarsOver300HP()
        {
            var HP = db.CarsOver300HP()
                 .Select(x => new CustomModel
                 {
                     Year = x.year,
                     Make = x.make,
                     Model = x.model,
                     HP = x.engine_power_ps,
                     Seats = x.seats,
                     Doors = x.doors
                 }).ToList();
            return HP;
        }

        /// <summary>
        /// Return all cars that have a weight under 2000kg
        /// </summary>
        /// <returns></returns>
        [Route("api/cars/CarsWeightUnder2000kg")]
        [HttpGet]
        public IEnumerable<CustomModel> WeightUnder2000kg()
        {
            var weight = db.CarsWeightUnder2000kg()
                 .Select(x => new CustomModel
                 {
                     Year = x.year,
                     Make = x.make,
                     Model = x.model,
                     HP = x.engine_power_ps,
                     Seats = x.seats,
                     Doors = x.doors,
                     Weight = x.weight_kg
                 }).ToList();
            return weight;
        }

        /// <summary>
        /// Return all cars with a given year and make
        /// </summary>
        /// <returns></returns>
        [Route("api/cars/GetCarModelsYearMake")]
        [HttpGet]
        public IEnumerable<string> WeightUnder2000kg(string year, string make)
        {
            var model = db.GetCarModelsYearMake(year, make);
            return model;
        }

        /// <summary>
        /// Return all cars with a given year, make, model, and trim
        /// </summary>
        /// <returns></returns>
        [Route("api/cars/GetCarYearMakeModelTrim")]
        [HttpGet]
        public IEnumerable<CustomModel> YearMakeModelTrim(string year, string make, string model, string trim = "")
        {
            var car = db.GetCarYearMakeModelTrim(year, make, model, trim)
                 .Select(x => new CustomModel
                 {
                     Year = x.year,
                     Make = x.make,
                     Model = x.model,
                     HP = x.engine_power_ps,
                     Seats = x.seats,
                     Doors = x.doors,
                     Weight = x.weight_kg
                 }).ToList();
            return car;
        }

        /// <summary>
        /// Return all cars from a unique year, make, and model
        /// </summary>
        /// <returns></returns>
        [Route("api/cars/GetModelTrimYearMakeModel")]
        [HttpGet]
        public IEnumerable<string> ModelTrim(string year, string make, string model)
        {
            var car = db.GetModelTrimYearMakeModel(year, make, model);
            return car;
        }

        /// <summary>
        /// Return all cars from a unique year
        /// </summary>
        /// <returns></returns>
        [Route("api/cars/GetUniqueCarMakeForYear")]
        [HttpGet]
        public IEnumerable<string> UniqueCarMake(string year)
        {
            var car = db.GetUniqueCarMakeForYear(year);
            return car;
        }

        /// <summary>
        /// Return all cars by model
        /// </summary>
        /// <returns></returns>
        [Route("api/cars/GetUniqueCarModel")]
        [HttpGet]
        public IEnumerable<string> UniqueCarModel()
        {
            var car = db.GetUniqueCarModel();
            return car;
        }

        /// <summary>
        /// Return all cars by model year
        /// </summary>
        /// <returns></returns>
        [Route("api/cars/GetUniqueModelYears")]
        [HttpGet]
        public IEnumerable<string> UniqueModelYears()
        {
            var car = db.GetUniqueModelYears();
            return car;
        }

        /// <summary>
        /// Return all cars with unique trim levels
        /// </summary>
        /// <returns></returns>
        [Route("api/cars/GetUniqueTrimLevels")]
        [HttpGet]
        public IEnumerable<string> UniqueTrimLevel()
        {
            var car = db.GetUniqueTrimLevels();
            return car;
        }

        /// <summary>
        /// Return all mid-engine cars
        /// </summary>
        /// <returns></returns>
        [Route("api/cars/MidEngineCars")]
        [HttpGet]
        public IEnumerable<CustomModel> MidEnginCars()
        {
            var car = db.MidEngineCars()
                 .Select(x => new CustomModel
                 {
                     Year = x.year,
                     Make = x.Make,
                     Model = x.model,
                     HP = x.engine_power_ps,
                     Seats = x.seats,
                     Doors = x.doors,
                     Weight = x.weight_kg
                 }).ToList();
            return car;
        }

        /// <summary>
        /// Return all cars by HorsePower
        /// </summary>
        /// <returns></returns>
        [Route("api/cars/OrderByHorsePower")]
        [HttpGet]
        public IEnumerable<CustomModel> OrderByHP()
        {
            var car = db.OrderByHorsePower()
                 .Select(x => new CustomModel
                 {
                     Year = x.year,
                     Make = x.Make,
                     Model = x.model,
                     HP = x.engine_power_ps,
                     Seats = x.seats,
                     Doors = x.doors,
                     Weight = x.weight_kg
                 }).ToList();
            return car;
        }

        /// <summary>
        /// Return all cars by HorsePower over 300 and weight
        /// </summary>
        /// <returns></returns>
        [Route("api/cars/OrderByHPOver300AndWeight")]
        [HttpGet]
        public IEnumerable<CustomModel> OrderByHPandWeight()
        {
            var car = db.OrderByHPOver300AndWeight()
                 .Select(x => new CustomModel
                 {
                     Year = x.year,
                     Make = x.Make,
                     Model = x.model,
                     HP = x.engine_power_ps,
                     Seats = x.seats,
                     Doors = x.doors,
                     Weight = x.weight_kg
                 }).ToList();
            return car;
        }

        /// <summary>
        /// Return all cars under 2000 Kg with at least 300 horsepower
        /// </summary>
        /// <returns></returns>
        [Route("api/cars/WeightUnder2000Least300HP")]
        [HttpGet]
        public IEnumerable<CustomModel> Under2000AtLeast300HP()
        {
            var car = db.WeightUnder2000Least300HP()
                 .Select(x => new CustomModel
                 {
                     Year = x.year,
                     Make = x.Make,
                     Model = x.model,
                     HP = x.engine_power_ps,
                     Seats = x.seats,
                     Doors = x.doors,
                     Weight = x.weight_kg
                 }).ToList();
            return car;
        }

        /// <summary>
        /// Get all the car years
        /// </summary>
        /// <returns></returns>
        /// 
        [Route("api/cars/GetAllYearsofCars")]
        [HttpGet]
        public IEnumerable<string> GetYears()
        {
            var returnData = db.GetAllYearsofCars();
            return returnData;
        }

    }
}
