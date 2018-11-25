namespace WebUi.Controllers
{
    using System.Collections.Generic;
    using Domain.Aggregates;
    using Domain.Entities;
    using Domain.Events;
    using Microsoft.AspNetCore.Mvc;
    using Models;

    [Route("api/grid/{name}/{row}/{column}")]
    public class GridApiController : ControllerBase
    {
        readonly InMemoryGridFactory inMemoryGridFactory;

        public GridApiController(InMemoryGridFactory inMemoryGridFactory)
        {
            this.inMemoryGridFactory = inMemoryGridFactory;
        }

        [HttpPost]
        public IActionResult Click(string name, int row, int column)
        {
            Grid grid = inMemoryGridFactory.GetOrCreate(name);

            List<SquareChangedEventArgs> squareChanged = new List<SquareChangedEventArgs>();
            List<SequenceFoundEventArgs> sequenceFound = new List<SequenceFoundEventArgs>();

            grid.SquareChanged += (sender, args) =>
            {
                squareChanged.Add(args);
            };

            grid.SequenceFound += (sender, args) =>
            {
                sequenceFound.Add(args);
            };

            grid.Click(new SquareIndex(row, column));

            ClickResponseModel result = new ClickResponseModel
            {
                ChangedSquares = squareChanged,
                SequencesFound = sequenceFound
            };

            return Ok(result);
        }
    }
}