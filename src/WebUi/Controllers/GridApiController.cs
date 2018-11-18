namespace WebUi.Controllers
{
    using Domain.Aggregates;
    using Domain.Entities;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/grid/{name}/{row}/{column}")]
    public class GridApiController : ControllerBase
    {
        readonly InMemoryGridFactory inMemoryGridFactory;

        public GridApiController(InMemoryGridFactory inMemoryGridFactory)
        {
            this.inMemoryGridFactory = inMemoryGridFactory;
        }

        public IActionResult Click(string name, int row, int column)
        {
            Grid grid = inMemoryGridFactory.GetOrCreate(name);
            grid.Click(new SquareIndex(row, column));
            return Ok();
        }
    }
}