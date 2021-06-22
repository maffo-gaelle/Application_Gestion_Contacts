// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var contactPersonnels = document.getElementById('list-Personnels');
console.log(contactPersonnels);
function GetPersonnalContact() {
    console.log("ok j'y suis");
    contactPersonnels.innerHTML("<div>Helle</div>");
    //listPosts = $("#posts-js");
    //pagina = $("#posts-pagination");
    //$.get("post/newestJson", function (data) {
    //    datas = jQuery.parseJSON(data);
    //    posts(datas);
    //});
}

//$('body').confirmation({
//  selector: '[data-toggle="confirmation"]'
//});

$('.demo').confirmation({
  onConfirm: function() {
        // do something
    },
  onCancel: function() {
        // do something
    }
});
