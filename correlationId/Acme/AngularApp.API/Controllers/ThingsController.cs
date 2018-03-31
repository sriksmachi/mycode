using System.Linq;
using AngularApp.API.Models;
using AngularApp.API.Repositories;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Things Controller
/// </summary>
namespace AngularApp.API.Controller
{
    /// <summary>
    /// Things Controller
    /// </summary>
    [Route("api/[controller]")]
    public class ThingsController : Microsoft.AspNetCore.Mvc.Controller
    {
        /// <summary>
        /// The things repository
        /// </summary>
        private readonly IThingsRepository _thingsRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ThingsController"/> class.
        /// </summary>
        /// <param name="thingsRepository">The things repository.</param>
        public ThingsController(IThingsRepository thingsRepository)
        {
            _thingsRepository = thingsRepository;
        }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns>List of Things.</returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_thingsRepository.GetAll());
        }

        /// <summary>
        /// Adds the specified thing.
        /// </summary>
        /// <param name="thing">The thing.</param>
        /// <returns>Things Item.</returns>
        [HttpPost]
        public IActionResult Add([FromBody] Thing thing)
        {
            if (thing == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Thing newThing = _thingsRepository.Add(thing);

            return CreatedAtRoute("GetSingleThing", new { id = newThing.Id }, newThing);
        }

        /// <summary>
        /// Partiallies the update.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="patchDoc">The patch document.</param>
        /// <returns>Things Item</returns>
        [HttpPatch("{id:int}")]
        public IActionResult PartiallyUpdate(int id, [FromBody] JsonPatchDocument<Thing> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest();
            }

            Thing existingEntity = _thingsRepository.GetSingle(id);

            if (existingEntity == null)
            {
                return NotFound();
            }

            Thing thing = existingEntity;
            patchDoc.ApplyTo(thing, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Thing updatedThing = _thingsRepository.Update(id, thing);

            return Ok(updatedThing);
        }

        /// <summary>
        /// Singles the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Things Item</returns>
        [HttpGet]
        [Route("{id:int}", Name = "GetSingleThing")]
        public IActionResult Single(int id)
        {
            Thing thing = _thingsRepository.GetSingle(id);

            if (thing == null)
            {
                return NotFound();
            }

            return Ok(thing);
        }

        /// <summary>
        /// Removes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Remove(int id)
        {
            Thing thing = _thingsRepository.GetSingle(id);

            if (thing == null)
            {
                return NotFound();
            }

            _thingsRepository.Delete(id);
            return NoContent();
        }

        /// <summary>
        /// Updates the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="thing">The thing.</param>
        /// <returns>Things Item</returns>
        [HttpPut]
        [Route("{id:int}")]
        public IActionResult Update(int id, [FromBody]Thing thing)
        {
            var thingToCheck = _thingsRepository.GetSingle(id);

            if (thingToCheck == null)
            {
                return NotFound();
            }

            if (id != thing.Id)
            {
                return BadRequest("Ids do not match");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Thing updatedThing = _thingsRepository.Update(id, thing);

            return Ok(updatedThing);
        }
    }
}
