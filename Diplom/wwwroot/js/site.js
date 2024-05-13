var dropdownButtons = document.querySelectorAll(".dropdown-button")

dropdownButtons.forEach(function (button) {
    button.addEventListener('click', function () {
        var dropdownContent = button.getAttribute('data-target');
        console.log(dropdownContent);
        document.getElementById(dropdownContent).classList.toggle('show');
    })
})

function StorageData() {
    $.ajax({
        type: "POST",
        url: "/Storage",
        success: function (result) {
            result.forEach((key, element) => {
                console.log(key,element)
                localStorage.setItem(key,element)
            })
        }
    })
}