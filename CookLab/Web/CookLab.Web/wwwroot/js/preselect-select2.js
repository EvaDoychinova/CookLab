// Preselect Categories for Recipe Edit Form
function preselectCategoriesForRecipeEdit(categories) {
    $('#CategoriesCategoryId').val(Array.from(categories));
    $('#CategoriesCategoryId').trigger('change');
}