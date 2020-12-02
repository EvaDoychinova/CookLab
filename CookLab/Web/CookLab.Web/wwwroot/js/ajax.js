function addOrRemoveRecipeFromUserList(recipeId) {
    let addOrRemoveSpan = document.getElementById('addOrRemoveSpan');
    let controller = addOrRemoveSpan.children[0];
    console.log(controller);

    controller.addEventListener('click', (e) => {
        let isInList = false;

        if (controller.id == 'removeRecipe') {
            isInList = true;
        }

        if (isInList) {
            controller.id = 'addRecipe';
            controller.innerHTML = '<i class="fas fa-heart i-hoverable"></i>';
            controller.nextElementSibling.innerHTML = 'Add to list';
        }
        else {
            controller.id = 'removeRecipe';
            controller.innerHTML = '<i class="fas fa-heart-broken i-hoverable"></i>';
            controller.nextElementSibling.innerHTML = 'Remove from list';
        }

        console.log(isInList);

        var antiForgeryToken = $('#antiForgeryForm input[name=__RequestVerificationToken]').val();
        var data = { recipeId: recipeId, isInList: isInList }

        console.log(data);

        console.log(JSON.stringify(data));

        $.ajax({
            type: "POST",
            url: "/api/UserRecipes",
            data: JSON.stringify(data),
            headers: {
                'X-CSRF-TOKEN': antiForgeryToken
            },
            success: function (data) {
                $('#usersCount').html(data.usersCount);
            },
            contentType: 'application/json',
        });

    });
}