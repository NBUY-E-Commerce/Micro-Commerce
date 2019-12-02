var toggler = document.getElementsByClassName("caret");

for (let i = 0; i < toggler.length; i++) {
    toggler[i].addEventListener("click", function () {
        $(this).parent().parent().children("ul.nested").slideToggle();
        $(this).toggleClass("caret-down");
    });
}

$(".btn-plus").on("click", function () {
    $(this).toggleClass("btn-success").toggleClass("btn-danger");
    $(this).children().toggleClass("rotate135");
    $(this).parent().children(".add-category").slideToggle("slow");
});

$.each($("#subcategories").find(".cat-li-element"), function (indexInArray, valueOfElement) {
    $(this).hover(function () {
        // over
        $(this).children("div.btn-group-sm").removeClass("d-none");
        $(this).children("span").addClass("text-primary");

    }, function () {
        // out
        $(this).children("div.btn-group-sm").addClass("d-none");
        $(this).children("span").removeClass("text-primary");
    });
});