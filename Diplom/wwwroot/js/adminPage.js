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
//
//    const overlay = document.querySelectorAll('show-popup');
//    overlay.classList.toggle('show');
//}

var popupButtons = document.querySelectorAll('.show-popup');
popupButtons.forEach(function (button) {
    button.addEventListener('click', function () {
        var targetId = this.getAttribute('data-target');
        var targetBlock = document.getElementById(targetId);
        targetBlock.classList.toggle('show');
    });
});