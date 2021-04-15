using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecipesApi.Models;
using RecipesApi.Services;
using RecipesApi.Models;
using RecipesApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace RecipesApi.Controllers
{

   
    [ApiController]
    [Route("[controller]")]
    public class RecipeController : ControllerBase
    {
        
            private readonly RecipeService _recipeService;

            public RecipeController(RecipeService recipeService)
            {
                _recipeService = recipeService;
            }

            [HttpGet]
            public ActionResult<List<Recipe>> Get() =>
                _recipeService.Get();

            [HttpGet("{id:length(24)}", Name = "GetRecipe")]
            public ActionResult<Recipe> Get(string id)
            {
                var recipe = _recipeService.Get(id);

                if (recipe == null)
                {
                    return NotFound();
                }

                return recipe;
            }

            [HttpPost]
            public ActionResult<Recipe> Create(Recipe recipe)
            {
                _recipeService.Create(recipe);

                return CreatedAtRoute("GetRecipe", new {id = recipe.Id.ToString()}, recipe);
            }

            [HttpPut("{id:length(24)}")]
            public IActionResult Update(string id, Recipe recipeIn)
            {
                var recipe = _recipeService.Get(id);

                if (recipe == null)
                {
                    return NotFound();
                }

                _recipeService.Update(id, recipeIn);

                return NoContent();
            }

            [HttpDelete("{id:length(24)}")]
            public IActionResult Delete(string id)
            {
                var recipe = _recipeService.Get(id);

                if (recipe == null)
                {
                    return NotFound();
                }

                _recipeService.Remove(recipe.Id);

                return NoContent();
            }

        }
    }

