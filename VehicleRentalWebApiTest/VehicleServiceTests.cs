using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using VehicleRentalWebApi;
using VehicleRentalWebApi.Controllers;
using VehicleRentalWebApi.Data;
using VehicleRentalWebApi.Data.EFCore;
using VehicleRentalWebApi.Models;

namespace VehicleRentalWebApiTest
{
    class VehicleServiceTests
    {
        private const string ServiceBaseURL = "https://localhost:44387/";
        private EfCoreVehicleRepository repository;


        [Test]
        public void DeleteVehicleTest()
        {
            var vehicleController = new VehiclesController(repository);
            //var repo = new EfCoreVehicleRepository();
            var vehicle = new Vehicle();

            vehicle.Id = 3;

            var client = new HttpClient { BaseAddress = new Uri(ServiceBaseURL) };

            client.DeleteAsync("api/vehicles/3");

            var _response = client.GetAsync("api/vehicles/3").Result;

            Assert.AreEqual(_response.StatusCode, HttpStatusCode.NotFound);
        }

        [Test]
        public void UpdateVehicleTest()
        {
            var vehicleController = new VehiclesController(repository);
            //var repo = new EfCoreVehicleRepository();
            var vehicle = new Vehicle();

            vehicle.Id = 2;
            vehicle.LicensePlate = "CJ-10-UPP";
            vehicle.Details = "Testing update";
            vehicle.Status = "In tests";

            var client = new HttpClient { BaseAddress = new Uri(ServiceBaseURL) };
            var jsonVehicle = JsonConvert.SerializeObject(vehicle);
            var payload = new StringContent(jsonVehicle, Encoding.UTF8, "application/json");

            client.PutAsync("api/vehicles/2", payload);

            var _response = client.GetAsync("api/vehicles/2").Result;
            var responseResult = JsonConvert.DeserializeObject<Vehicle>(_response.Content.ReadAsStringAsync().Result);

            Assert.IsNotNull(responseResult);
            Assert.AreEqual(vehicle.Id, responseResult.Id);
            Assert.AreEqual(vehicle.LicensePlate, responseResult.LicensePlate);
            Assert.AreEqual(vehicle.Details, responseResult.Details);
            Assert.AreEqual(vehicle.Status, responseResult.Status);
        }

        [Test]
        public void CreateVehicleTest()
        {
            var vehicleController = new VehiclesController(repository);
            //var repo = new EfCoreVehicleRepository();
            var vehicle = new Vehicle();

            vehicle.LicensePlate = "CJ-10-NTE";
            vehicle.Details = "Testing";
            vehicle.Status = "In tests";
              
            var client = new HttpClient { BaseAddress = new Uri(ServiceBaseURL) };
            var jsonVehicle = JsonConvert.SerializeObject(vehicle);
            var payload = new StringContent(jsonVehicle, Encoding.UTF8, "application/json");

            var _responseB = client.GetAsync("api/vehicles").Result;
            var responseResultB = JsonConvert.DeserializeObject<List<Vehicle>>(_responseB.Content.ReadAsStringAsync().Result);

            client.PostAsync("api/vehicles", payload);

            var _responseA = client.GetAsync("api/vehicles").Result;
            var responseResultA = JsonConvert.DeserializeObject<List<Vehicle>>(_responseA.Content.ReadAsStringAsync().Result);

            Assert.IsTrue(responseResultB.Count > 0);
            Assert.IsTrue(responseResultA.Count > 0);
            Assert.AreNotEqual(responseResultA, responseResultB);        
        }
  
        [Test]
        public void GetVehicleByIdIntegrationTest()
        {
            var client = new HttpClient { BaseAddress = new Uri(ServiceBaseURL) };
            var _response = client.GetAsync("api/vehicles/1").Result;
            var responseResult =
                JsonConvert.DeserializeObject<Vehicle>(_response.Content.ReadAsStringAsync().Result);
            Assert.AreEqual(_response.StatusCode, HttpStatusCode.OK);
            Assert.AreEqual(responseResult!=null, true);
            Assert.AreEqual(responseResult.Id, 1);
        }

        [Test]
        public void GetAllVehiclesIntegrationTest()
        {
            var client = new HttpClient { BaseAddress = new Uri(ServiceBaseURL) };
            var _response = client.GetAsync("api/vehicles").Result;
            var responseResult =
                JsonConvert.DeserializeObject<List<Vehicle>>(_response.Content.ReadAsStringAsync().Result);
            Assert.AreEqual(_response.StatusCode, HttpStatusCode.OK);
            Assert.AreEqual(responseResult.Any(), true);
        }
    }
}
