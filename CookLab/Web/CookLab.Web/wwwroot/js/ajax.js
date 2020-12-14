$(document).ready(function () {
    // Change portions count
    if (document.getElementById('desiredPortions')) {
        let valueInput = document.getElementById('desiredPortions');
        let currentValue = valueInput.value;

        let calories = document.getElementById('nutrition-calories');
        let carbohydrates = document.getElementById('nutrition-carbohydrates');
        let proteins = document.getElementById('nutrition-proteins');
        let fats = document.getElementById('nutrition-fats');
        let fibres = document.getElementById('nutrition-fibres');

        valueInput.parentNode.addEventListener('click', (e) => {
            if (e.target.parentNode.getAttribute('id') == 'desiredPortions-reduce') {
                if (currentValue > 0) {
                    currentValue--;
                }
            }
            else if (e.target.parentNode.getAttribute('id') == 'desiredPortions-add') {
                if (currentValue < 100) {
                    currentValue++;
                }
            }

            let caloriesPerPortion = calories.innerHTML.split(' ')[1];
            let newCaloriesPerPortion = parseFloat(caloriesPerPortion) * valueInput.value / currentValue;
            calories.innerHTML = calories.innerHTML.replace(caloriesPerPortion, newCaloriesPerPortion.toFixed(2).toString());

            let carbohydratesPerPortion = carbohydrates.innerHTML.split(' ')[1];
            let newCarbohydratesPerPortion = parseFloat(carbohydratesPerPortion) * valueInput.value / currentValue;
            carbohydrates.innerHTML = carbohydrates.innerHTML.replace(carbohydratesPerPortion, newCarbohydratesPerPortion.toFixed(2).toString());

            let proteinsPerPortion = proteins.innerHTML.split(' ')[1];
            let newProteinsPerPortion = parseFloat(proteinsPerPortion) * valueInput.value / currentValue;
            proteins.innerHTML = proteins.innerHTML.replace(proteinsPerPortion, newProteinsPerPortion.toFixed(2).toString());

            let fatsPerPortion = fats.innerHTML.split(' ')[1];
            let newFatsPerPortion = parseFloat(fatsPerPortion) * valueInput.value / currentValue;
            fats.innerHTML = fats.innerHTML.replace(fatsPerPortion, newFatsPerPortion.toFixed(2).toString());

            let fibresPerPortion = fibres.innerHTML.split(' ')[1];
            let newFibresPerPortion = parseFloat(fibresPerPortion) * valueInput.value / currentValue;
            fibres.innerHTML = fibres.innerHTML.replace(fibresPerPortion, newFibresPerPortion.toFixed(2).toString());

            valueInput.value = currentValue;
        });

        valueInput.addEventListener('change', (e) => {
            console.log(currentValue);
            console.log(e.target.value);

            if (e.target.value > 0 && e.target.value < 100) {
                let caloriesPerPortion = calories.innerHTML.split(' ')[1];
                let newCaloriesPerPortion = parseFloat(caloriesPerPortion) * currentValue / e.target.value;
                calories.innerHTML = calories.innerHTML.replace(caloriesPerPortion, newCaloriesPerPortion.toFixed(2).toString());

                let carbohydratesPerPortion = carbohydrates.innerHTML.split(' ')[1];
                let newCarbohydratesPerPortion = parseFloat(carbohydratesPerPortion) * currentValue / e.target.value;
                carbohydrates.innerHTML = carbohydrates.innerHTML.replace(carbohydratesPerPortion, newCarbohydratesPerPortion.toFixed(2).toString());

                let proteinsPerPortion = proteins.innerHTML.split(' ')[1];
                let newProteinsPerPortion = parseFloat(proteinsPerPortion) * currentValue / e.target.value;
                proteins.innerHTML = proteins.innerHTML.replace(proteinsPerPortion, newProteinsPerPortion.toFixed(2).toString());

                let fatsPerPortion = fats.innerHTML.split(' ')[1];
                let newFatsPerPortion = parseFloat(fatsPerPortion) * currentValue / e.target.value;
                fats.innerHTML = fats.innerHTML.replace(fatsPerPortion, newFatsPerPortion.toFixed(2).toString());

                let fibresPerPortion = fibres.innerHTML.split(' ')[1];
                let newFibresPerPortion = parseFloat(fibresPerPortion) * currentValue / e.target.value;
                fibres.innerHTML = fibres.innerHTML.replace(fibresPerPortion, newFibresPerPortion.toFixed(2).toString());

                currentValue = valueInput.value;
            }
        });
    }
});