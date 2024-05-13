

var folders = document.querySelectorAll('.folder');
var path = document.getElementById('path')
console.log(folders.length);
var foldersInPath = [];
var folderPath = "/";
foldersInPath.forEach(function (folder) {
    folderPath += folder + "/";
    path.innerText = "PATH::" + folderPath;
})


folders.forEach(function (folder) {
    folder.addEventListener('click', function (event) {
        var name = folder.querySelector("#name").innerText;
        console.log(name)
        $.ajax({
            url: '/File/ChangeDirectory',
            method: 'POST',
            data: folderPath + name,
            success: function () {
                console.log("Change Directory")
            }
        })
        //fetch('/File/ChangeDirectory', {
        //    method: 'POST',
        //    headers: {
        //        'Content-Type': 'application/json',
        //    },
        //    body: JSON.stringify({ message: folderPath + name })
        //})
    });
});