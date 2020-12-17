$(document).ready(function () {
    // Show Uploaded file names
    if (document.querySelector(".custom-file-input")) {
        let fileInput = document.querySelector(".custom-file-input");

        fileInput.addEventListener('change', (e) => {
            let fileOutput = document.querySelector(".custom-file-label");
            fileOutput.textContent = Array.from(fileInput.files).map(x => x.name).join(", ");
        });
    }

    // Make Cooking Vessel Create form dynamic
    if (document.getElementById("Form")) {
        const functionalSelect = document.getElementById("Form");
        const options = functionalSelect.children;
        const formsCount = document.getElementById("FormsCount");
        const formsCountParent = formsCount.parentNode;
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
                formsCountParent.classList.add('d-none');
                formsCount.setAttribute('disabled', 'disabled');

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
                formsCountParent.classList.add('d-none');
                formsCount.setAttribute('disabled', 'disabled');

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
                formsCountParent.classList.add('d-none');
                formsCount.setAttribute('disabled', 'disabled');

                nameParent.classList.add('d-none');
                name.setAttribute('disabled', "disabled");

                diameterParent.classList.add('d-none');
                diameter.setAttribute('disabled', "disabled");

                areaParent.classList.add('d-none');
                area.setAttribute('disabled', "disabled");

                break;
            case '4':
                formsCountParent.classList.add('d-none');
                formsCount.setAttribute('disabled', 'disabled');

                sideAParent.classList.add('d-none');
                sideA.setAttribute('disabled', "disabled");

                diameterParent.classList.add('d-none');
                diameter.setAttribute('disabled', "disabled");

                sideBParent.classList.add('d-none');
                sideB.setAttribute('disabled', "disabled");

                break;
            case '5':
                nameParent.classList.add('d-none');
                name.setAttribute('disabled', "disabled");

                sideAParent.classList.add('d-none');
                sideA.setAttribute('disabled', "disabled");

                sideBParent.classList.add('d-none');
                sideB.setAttribute('disabled', "disabled");

                areaParent.classList.add('d-none');
                area.setAttribute('disabled', "disabled");

                break;
            default:
                break;
        }

        functionalSelect.addEventListener("change", (e) => {
            parents.forEach(x => x.classList.add('d-none'));
            inputs.forEach(x => x.setAttribute('disabled', 'disabled'));

            let selectedOption = Array.from(options).filter(x => x.value == functionalSelect.value)[0];
            let value = selectedOption.value;
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
                case '5':
                    formsCountParent.classList.remove('d-none');
                    formsCount.removeAttribute('disabled',);

                    diameterParent.classList.remove('d-none');
                    diameter.removeAttribute('disabled');

                    heightParent.classList.remove('d-none');
                    height.removeAttribute('disabled');

                    break;
                default:
                    break;
            }
        });
    }

    // Make Recipe Details Form Show and Hide Nutrition
    if (document.getElementById('showNutritionInfo')) {
        let btn = document.getElementById('showNutritionInfo');

        let nutritionInfo = document.getElementById('nutrition-info-list-item');
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
});

