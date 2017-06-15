using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class CustomModel
    {
        /// <summary>
        /// Gets the year for the car
        /// </summary>
        /// <value>
        /// Year
        /// </value>
        public string Year { get; set; }

        /// <summary>
        /// Gets the Horsepower for a car
        /// </summary>
        /// <value>
        /// HorsePower
        /// </value>
        public string HP { get; set; }

        /// <summary>
        /// Gets the make of the car
        /// </summary>
        /// <value>
        /// Make
        /// </value>
        public string Make { get; set; }

        /// <summary>
        /// Gets the model of the car
        /// </summary>
        /// <value>
        /// Model
        /// </value>
        public string Model { get; set; }

        /// <summary>
        /// Gets the number of doors for a car
        /// </summary>
        /// <value>
        /// Doors
        /// </value>
        public string Doors { get; set; }

        /// <summary>
        /// Gets the number of seats for a car
        /// </summary>
        /// <value>
        /// Seats
        /// </value>
        public string Seats { get; set; }

        /// <summary>
        /// Gets the weight for the car
        /// </summary>
        /// <value>
        /// Weight
        /// </value>
        public string Weight { get; set; }

    }
}