using Microsoft.AspNetCore.Mvc;
using Domain;
using DataAccessEF;
using Newshore.UseCase.SearchFlights;
using Newshore.UseCase;
using Domain.Interfaces;

namespace NewShore.Controllers
{
    [ApiController]
    [Route("Api")]
    public class SearchFlightsController : ControllerBase
    {
        private readonly ILogger<SearchFlightsController> _logger;
        private readonly Services Services;
        private List<SearchFlightsResponse> Flights;
        public List<Flight> flights;
        private List<Flight> NewOrigin;
        private string RouteOrigin;
        private readonly IUnitOfWork unitOfWork;

        public SearchFlightsController(ILogger<SearchFlightsController> logger,
            IUnitOfWork unitOfWork)
        {
            _logger = logger;
            this.Flights = new List<SearchFlightsResponse>();
            this.flights = new List<Flight>();
            this.NewOrigin = new List<Flight>();
            Services = new Services();
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("SearchList")]
        public async Task<List<SearchFlightsResponse>> Get()
        {
            var FlightsRaw = await Services.GetSearchFlight();
            if (FlightsRaw != null)
            {
                Flights = new List<SearchFlightsResponse>(FlightsRaw);
                Ok();
                return Flights;
            }
            else
            {
                return Flights;
            }
        }

        [HttpGet]
        [Route("SearchRoute")]
        public async Task<JourneyFlight> Get(string origin, string destination)
        {
            //Check if it exist already on the database
            //unitOfWork.Journey.

            var FlightsRaw = await Services.GetSearchFlight();
            if (FlightsRaw != null)
            {
                Flights = new List<SearchFlightsResponse>(FlightsRaw);
                List<SearchFlightsResponse> route = Flights.Where(f => f.DepartureStation == origin).ToList();

                var SumPrice = 0.0;

                for (int i = 0; i < route.Count; i++)
                {
                    NewOrigin.Add(new Flight
                    {
                        FlightOrigin = Flights[i].DepartureStation,
                        FlightDestination = Flights[i].ArrivalStation,
                        FlightPrice = Flights[i].Price,
                        Transport = new Transport()
                        {
                            FlightCarrier = Flights[i].FlightCarrier,
                            FlightNumber = Flights[i].FlightNumber
                        }
                    });
                }


                for (int i = 0; i < Flights.Count; i++)
                {
                    if (Flights[i].ArrivalStation == destination)
                    {
                        RouteOrigin = Flights[i].DepartureStation;

                        for (int J = 0; J < NewOrigin.Count; J++)
                        {
                            if (NewOrigin[J].FlightDestination == RouteOrigin)
                            {
                                flights.Add(new Flight
                                {
                                    FlightOrigin = Flights[J].DepartureStation,
                                    FlightDestination = Flights[J].ArrivalStation,
                                    FlightPrice = Flights[J].Price,
                                    Transport = new Transport()
                                    {
                                        FlightCarrier = Flights[J].FlightCarrier,
                                        FlightNumber = Flights[J].FlightNumber
                                    }
                                });
                                SumPrice += Flights[J].Price;

                            }
                        }
                        flights.Add(new Flight
                        {
                            FlightOrigin = Flights[i].DepartureStation,
                            FlightDestination = Flights[i].ArrivalStation,
                            FlightPrice = Flights[i].Price,
                            Transport = new Transport()
                            {
                                FlightCarrier = Flights[i].FlightCarrier,
                                FlightNumber = Flights[i].FlightNumber
                            }
                        });
                        SumPrice += Flights[i].Price;

                    }
                }

                var journey = new Journey()
                {
                    JourneyOrigin = origin,
                    JourneyDestination = destination,
                    JourneyPrice = SumPrice
                };


                var journeyFlight = new JourneyFlight();

                for (int i = 0; i < flights.Count; i++)
                {
                    journeyFlight.Journey = journey;
                    journeyFlight.Flight = flights[i];
                }
                
                unitOfWork.JourneyFlight.SaveJourneyFlight(journeyFlight);               
                
                Ok();
                return journeyFlight;
            }
            else
            {
                var response = new JourneyFlight();
                return response;
            }

        }

    }
}
