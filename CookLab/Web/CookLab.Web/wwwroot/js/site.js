// Show Uploaded file names
function showUploadedFilesNames() {
    let fileInput = document.querySelector(".custom-file-input");

    fileInput.addEventListener('change', (e) => {
        let fileOutput = document.querySelector(".custom-file-label");
        fileOutput.textContent = Array.from(fileInput.files).map(x => x.name).join(", ");
    });
}

// Make Cooking Vessel Create form dynamic
function cookingVesselFunctionalCreateForm() {

    const functionalSelect = document.getElementById("Form");
    const options = functionalSelect.children;
    const name = document.getElementById("Name");
    const nameParent = name.parentNode;
    const diameter = document.getElementById("Diameter");
    const diameterParent = diameter.parentNode;
    const sideA = document.getElementById("SideA");
    const sideAParent = sideA.parentNode;
    const sideB = document.getElementById("SideB");
    const sideBParent = sideB.parentNode;
    const height = document.getElementById("Height");
    const heightParent = height.parentNode;
    const area = document.getElementById("Area");
    const areaParent = area.parentNode;

    const parents = document.querySelectorAll('div.form-group');
    const inputs = document.querySelectorAll('input.form-control');

    switch (functionalSelect.value) {
        case '0':
            parents.forEach(x => x.classList.add('d-none'));
            inputs.forEach(x => x.setAttribute('disabled', 'disabled'));

            break;
        case '1':
            nameParent.classList.add('d-none');
            name.setAttribute('disabled', "disabled");

            sideAParent.classList.add('d-none');
            sideA.setAttribute('disabled', "disabled");

            sideBParent.classList.add('d-none');
            sideB.setAttribute('disabled', "disabled");

            areaParent.classList.add('d-none');
            area.setAttribute('disabled', "disabled");

            break;
        case '2':
            nameParent.classList.add('d-none');
            name.setAttribute('disabled', "disabled");

            diameterParent.classList.add('d-none');
            diameter.setAttribute('disabled', "disabled");

            sideBParent.classList.add('d-none');
            sideB.setAttribute('disabled', "disabled");

            areaParent.classList.add('d-none');
            area.setAttribute('disabled', "disabled");

            break;
        case '3':
            nameParent.classList.add('d-none');
            name.setAttribute('disabled', "disabled");

            diameterParent.classList.add('d-none');
            diameter.setAttribute('disabled', "disabled");

            areaParent.classList.add('d-none');
            area.setAttribute('disabled', "disabled");

            break;
        case '4':
            sideAParent.classList.add('d-none');
            sideA.setAttribute('disabled', "disabled");

            diameterParent.classList.add('d-none');
            diameter.setAttribute('disabled', "disabled");

            sideBParent.classList.add('d-none');
            sideB.setAttribute('disabled', "disabled");

            break;
        default:
            break;
    }

    functionalSelect.addEventListener("change", (e) => {
        parents.forEach(x => x.classList.add('d-none'));
        inputs.forEach(x => x.setAttribute('disabled', 'disabled'));

        let selectedOption = Array.from(options).filter(x => x.value == functionalSelect.value)[0];
        let value = selectedOption.value;
        console.log(value);
        selectedOption.setAttribute('selected', 'selected');
        options[0].removeAttribute('selected');
        switch (value) {
            case '1':
                diameterParent.classList.remove('d-none');
                diameter.removeAttribute('disabled');

                heightParent.classList.remove('d-none');
                height.removeAttribute('disabled');

                break;
            case '2':
                sideAParent.classList.remove('d-none');
                sideA.removeAttribute('disabled');

                heightParent.classList.remove('d-none');
                height.removeAttribute('disabled');

                break;
            case '3':
                sideAParent.classList.remove('d-none');
                sideA.removeAttribute('disabled');

                sideBParent.classList.remove('d-none');
                sideB.removeAttribute('disabled');

                heightParent.classList.remove('d-none');
                height.removeAttribute('disabled');

                break;
            case '4':
                nameParent.classList.remove('d-none');
                name.removeAttribute('disabled');

                heightParent.classList.remove('d-none');
                height.removeAttribute('disabled');

                areaParent.classList.remove('d-none');
                area.removeAttribute('disabled');

                break;
            default:
                break;
        }
    });
}

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
        newIngredientContainer.insertAdjacentHTML("beforeend",newIngredientContainerContent);
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
    $('.select-ingredients').select2({
        placeholder: 'Choose ingredient...'
    });

    $('.select-partOfRecipe').select2({
        placeholder: 'Part of recipe...'
    });

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

// Make Recipe Details Form Show and Hide Nutrition
function showNutritionInfoForRecipe() {
    let btn = document.getElementById('showNutritionInfo');
    let nutritionInfo = document.getElementById('nutritin-info-list-item');
    nutritionInfo.style.display = 'none';

    btn.addEventListener('click', (e) => {
        if (nutritionInfo.style.display == 'none') {
            nutritionInfo.style.display = 'block';
        }
        else {
            nutritionInfo.style.display = 'none';
        }
    });
}

// Preselect Categories for Recipe Edit Form
function preselectCategoriesForRecipeEdit(categories) {
    $("#CategoriesCategory").val(Array.from(categories).map(x => x.id));
}
