using Compact.Api.Models.ResponseModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Compact.Api.Controllers
{
    public class DashboardController : ControllerBase
    {
        [HttpGet("/api/dashboard/popularPosts")]
        [ProducesResponseType(typeof(LineChartResponse), 200)]
        public ActionResult<IEnumerable<string>> GetPopularPosts()
        {
            Random rnd = new Random();

            var response = new LineChartResponse
            {
                Labels = new string[] { "Label1", "Label2", "Label3" },
                DataSets = new List<DataSet> {
                    new DataSet {
                        Label = "Item 1",
                        DataPoints = new int[] { rnd.Next(0, 200), rnd.Next(0, 200), rnd.Next(0, 200) }
                    },
                    new DataSet {
                        Label = "Item 2",
                        DataPoints = new int[] { rnd.Next(0, 200), rnd.Next(0, 200), rnd.Next(0, 200) }
                    }
                }
            };

            return Ok(response);
        }

        [HttpGet("/api/dashboard/impressionsVersusViews")]
        [ProducesResponseType(typeof(LineChartResponse), 200)]
        public ActionResult<IEnumerable<string>> GetImpressions()
        {
            Random rnd = new Random();

            var response = new LineChartResponse
            {
                Labels = new string[] { "Label1", "Label2", "Label3" },
                DataSets = new List<DataSet> {
                    new DataSet {
                        Label = "Impressions",
                        DataPoints = new int[] { rnd.Next(0, 200), rnd.Next(0, 200), rnd.Next(0, 200) }
                    },
                    new DataSet {
                        Label = "Views",
                        DataPoints = new int[] { rnd.Next(0, 100), rnd.Next(0, 100), rnd.Next(0, 100) }
                    }
                }
            };

            return Ok(response);
        }

        [HttpGet("/api/dashboard/views")]
        [ProducesResponseType(typeof(LineChartResponse), 200)]
        public ActionResult<IEnumerable<string>> GetViews()
        {
            Random rnd = new Random();

            var response = new LineChartResponse
            {
                Labels = new string[] { "Label1", "Label2", "Label3" },
                DataSets = new List<DataSet> {
                    new DataSet {
                        Label = "Views",
                        DataPoints = new int[] { rnd.Next(0, 100), rnd.Next(0, 100), rnd.Next(0, 100) }
                    }
                }
            };

            return Ok(response);
        }

        [HttpGet("/api/dashboard/clients")]
        [ProducesResponseType(typeof(LineChartResponse), 200)]
        public ActionResult<IEnumerable<string>> GetClients()
        {
            Random rnd = new Random();

            var response = new LineChartResponse
            {
                Labels = new string[] { "Label1", "Label2", "Label3" },
                DataSets = new List<DataSet> {
                    new DataSet {
                        Label = "Client 1",
                        DataPoints = new int[] { rnd.Next(0, 200), rnd.Next(0, 200), rnd.Next(0, 200) }
                    },
                    new DataSet {
                        Label = "Client 2",
                        DataPoints = new int[] { rnd.Next(0, 50), rnd.Next(0, 50), rnd.Next(0, 50) }
                    }
                }
            };

            return Ok(response);
        }

        [HttpGet("/api/dashboard/achievements")]
        [ProducesResponseType(typeof(LineChartResponse), 200)]
        public ActionResult<IEnumerable<string>> GetAchievements()
        {
            Random rnd = new Random();

            var response = new LineChartResponse
            {
                Labels = new string[] { "Label1", "Label2", "Label3" },
                DataSets = new List<DataSet> {
                    new DataSet {
                        Label = "Total Achievements",
                        DataPoints = new int[] { 1, 3, 10 }
                    }
                }
            };

            return Ok(response);
        }
    }
}