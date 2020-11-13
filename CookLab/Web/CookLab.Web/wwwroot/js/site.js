// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function solve() {

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

    functionalSelect.addEventListener("change", (e) => {
        e.preventDefault();
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
                areaParent.classList.remove('d-none');
                area.removeAttribute('disable');

                heightParent.classList.remove('d-none');
                height.removeAttribute('disable');

                break;
            default:
                break;
        }
    })
}