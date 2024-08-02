
var folders = document.querySelectorAll('.folder');
var files = document.querySelectorAll('.file');
var path = document.getElementById('path');
var foldersInPath = [];
var folderPath = path.innerText;
if (folderPath == "") {
    folderPath = "\/"
    path.innerText = folderPath;
}

function GoToBackDirectory() {
    $.ajax({
        url: '/File/Back',
        method: 'POST',
        data: folderPath,
        success: function (data) {
            console.log("Go to back directory:" + folderPath)
            $('#partial-view').html(data)
        }
    });
}

files.forEach(function (file) {

    file.addEventListener('click', async function (event) {
        console.log("ClickOnFile")
        var name = file.querySelector("#name").innerHTML;
        console.log(folderPath + name)
        var pth = folderPath + name;


        $.ajax({
          url: '/File/DownloadFile',
          method: 'POST',
          data: pth,
          success: function (data, type, fileName) {
              console.log("Success click on file")
              const blob = new Blob([data], { type: 'application/octet-stream' });
              const a = document.createElement('a');
              const url = URL.createObjectURL(blob);
              console.log("Имя файла полученное от сервера:" + name)
              console.log(blob.size + blob.text());
        
  
              a.href = url;
              a.download = name;
              document.body.appendChild(a);
              a.click();
              document.body.removeChild(a);
              URL.revokeObjectURL(url);
          }
       })
    });
});


folders.forEach(function (folder) {
    folder.addEventListener('click', function (event) {
        var name = folder.querySelector("#name").innerText;
        console.log(name)
        $.ajax({
            url: '/File/ChangeDirectory',
            method: 'POST',
            data: folderPath + name,
            success: function (data) {
                console.log("Change Directory")
                $('#partial-view').html(data)
                //folderPath += name;
            }
        })
    });
});