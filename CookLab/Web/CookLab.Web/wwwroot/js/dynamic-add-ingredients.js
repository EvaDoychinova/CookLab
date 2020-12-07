// Make Recipe Create Form dynamically add ingredients
function recipeIngredientsDynamicSelectListOnCreate() {
    let btn = document.getElementById('btn-add-ingredient');

    let allIngredientsContainer = document.getElementById('all-ingredients-container');

    let ingredientContainer = document.querySelector('div.ingredient-container');
    let ingredientContainerContent = ingredientContainer.innerHTML;

    let index = 1;

    btn.addEventListener('click', (e) => {
        let newIngredientContainerContent = ingredientContainerContent.replace(/_0_/g, `_${index}_`).replace(/\[0\]/g, `[${index}]`);
        let newIngredientContainer = document.createElement('div');
        newIngredientContainer.classList.add('row');
        newIngredientContainer.classList.add('ingredient-container');
        newIngredientContainer.insertAdjacentHTML("beforeend", newIngredientContainerContent);
        allIngredientsContainer.appendChild(newIngredientContainer);

        index++;

        $('.select-ingredients').select2({
            placeholder: 'Choose ingredient...'
        });

        $('.select-partOfRecipe').select2({
            placeholder: 'Part of recipe...'
        });
    });
}

// Make Recipe Edit Form dynamically change ingredients
function recipeIngredientsDynamicSelectListOnEdit() {
    let btn = document.getElementById('btn-add-ingredient');

    let allIngredientsContainer = document.getElementById('all-ingredients-container');

    let ingredientsLength = document.querySelectorAll('div.ingredient-container').length;
    let ingredientContainer = document.querySelectorAll('div.ingredient-container')[0];
    let ingredientContainerContent = ingredientContainer.innerHTML;

    let index = ingredientsLength;

    btn.addEventListener('click', (e) => {
        let newIngredientContainerContent = ingredientContainerContent.replace(/_0_/g, `_${index}_`).replace(/\[0\]/g, `[${index}]`);
        let newIngredientContainer = document.createElement('div');
        newIngredientContainer.classList.add('row');
        newIngredientContainer.classList.add('ingredient-container');
        newIngredientContainer.insertAdjacentHTML('beforeend', newIngredientContainerContent);

        let ingredientSelect = newIngredientContainer.children[0].children[0];
        let weightInput = newIngredientContainer.children[1].children[0];
        let partOfRecipeSelect = newIngredientContainer.children[2].children[0];

        Array.from(ingredientSelect.children).forEach(x => x.removeAttribute('selected'));
        weightInput.removeAttribute('value');
        Array.from(partOfRecipeSelect.children).forEach(x => x.removeAttribute('selected'));

        allIngredientsContainer.appendChild(newIngredientContainer);

        $('.select-ingredients').select2({
            placeholder: 'Choose ingredient...'
        });

        $('.select-partOfRecipe').select2({
            placeholder: 'Part of recipe...'
        });

        index++;
    });
}