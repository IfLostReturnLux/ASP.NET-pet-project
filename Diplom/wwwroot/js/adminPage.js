
var buttons = document.querySelectorAll('.show-block');
var currentBlock = null;
buttons.forEach(function (button) {
    button.addEventListener('click', function () {
        var targetId = this.getAttribute('data-target');
        var targetBlock = document.getElementById(targetId);

        if (targetBlock.style.display === 'none') {
            targetBlock.style.display = 'block';
            if (targetBlock != currentBlock & currentBlock != null) {
                currentBlock.style.display = 'none';
                currentBlock = targetBlock;
            }
            else {
                currentBlock = targetBlock;
            }
        } else {
            targetBlock.style.display = 'none';
        }
    });
});


//function togglePopup() {
//    var form = document.getElementsByClassName("form-container")
//    const overlay = document.querySelectorAll('show-popup');
//    overlay.classList.toggle('show');
//    forEach(item in items) {
//        var body = '<label asp-for="' + item + '" class="form-label"></label> < input asp-for= "' + item + '" class= "form-input" type = "text" placeholder = "Enter Your ' + item + '" > <span asp-validation-for="' + item +'"></span>';
// 
//        form.appendChild(body);
//    };
//
//}

var popupButtons = document.querySelectorAll('.show-popup');
popupButtons.forEach(function (button) {
    button.addEventListener('click', function () {
        var targetId = this.getAttribute('data-target');
        var targetBlock = document.getElementById(targetId);
        targetBlock.classList.toggle('show');
    });
});

//var dropdownItems = document.querySelectorAll('.dropdown-item')
//var dropdownInput = document.getElementById('dropdown-input')
//var dropdownContent = document.getElementById('dropdown-content')
//dropdownItems.forEach(function (item) {
//    item.addEventListener('click', function () {
//        dropdownInput.value = item.textContent;
//        dropdownContent.classList.remove('show');
//    });
//});
//
//dropdownInput.addEventListener('click', function () {
//    document.getElementById('dropdown-content').classList.toggle('show')
//})
//window.onclick = function (event) {
//    if (!event.target.matches('dropdown-input')) {
//        dropdownContent.classList.remove('show');
//    }
//}