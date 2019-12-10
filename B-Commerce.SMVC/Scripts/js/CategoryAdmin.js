
$("#CategoryArea").on("click", ".caret", function () {
    $(this).toggleClass("caret-down");
    if ($(this).hasClass("caret-down")) {
        let id = $(this).parent().attr("cat-id");
        this.result;
        var self = this;

        $.ajax({
            type: "POST",
            url: "CategoryBrain/GetCategoryByMasterID",
            data: `id=${parseInt(id)}`,
            dataType: "json",

            success: function (response) {
                var innerLiElements = "";

                for (let i = 0; i < response.categories.length; i++) {
                    let cat = response.categories[i];
                    let spanClass = cat.HasSubCategory ? "caret" : "";
                    let altElements = cat.HasSubCategory ? "<ul class='nested cat-li-alt-elements'></ul>" : "";
                    innerLiElements += ` <li>
                                        <div class="cat-li-element" cat-id="${cat.ID}">
                                                            <span class="${spanClass}">${cat.Name}</span>

                                                            <div class="btn-group-sm d-none" role="group" cat-id="${cat.ID}">
                                                                <button type="button" class="btn btn-link btn-edit" data-toggle="modal" data-target="#editCategory"><i class="fas fa-edit"></i></button>
                                                                <button class="btn btn-link btn-del" data-toggle="modal" data-target="#deleteModal">
                                                                    <i class="fas fa-minus"></i>
                                                                </button>
                                                            </div>
                                                        </div>
                                                    ${altElements}
                                                    </li> `;
                }

                self.result = innerLiElements;
            },
            complete: function () {
                $(self).parent().parent().children(".cat-li-alt-elements").html(self.result);
            }
        });
    }
    $(this).parent().parent().children("ul.nested").slideToggle();
});

//add form animation
$(".btn-plus").on("click", function () {
    $(this).toggleClass("btn-success").toggleClass("btn-danger");
    $(this).children().toggleClass("rotate135");
    $(this).parent().children(".add-category").slideToggle("slow");
});

//update delete hover
$("#CategoryArea").on("mouseenter", ".cat-li-element", function () {
    $(this).children("div.btn-group-sm").removeClass("d-none");
    $(this).children("span").addClass("text-primary");
});

$("#CategoryArea").on("mouseleave", ".cat-li-element", function () {
    $(this).children("div.btn-group-sm").addClass("d-none");
    $(this).children("span").removeClass("text-primary");
});

//btn-del click
$("#CategoryArea").on("click", ".btn-del", function () {
    let id = $(this).parent().attr("cat-id");
    console.log(id);
    $("#deleteForm").find("[name*='ID']").val(id);
})

//btn-edit click
$("#CategoryArea").on("click", ".btn-edit", function () {
    let id = $(this).parent().attr("cat-id");
    $.ajax({
        type: "POST",
        url: "/CategoryBrain/GetCategoryByID",
        data: `id=${parseInt(id)}`,
        dataType: "json",
        success: function (response) {
            console.log(id);
        },
        complete: function (response) {
            var selectedCat = response.responseJSON.Category;

            $("#editForm").find("[name*='ID']").val(selectedCat.ID);
            $("#editForm").find("[name*='CategoryName']").val(selectedCat.CategoryName)
            $("#editForm").find("[name*='Description']").val(selectedCat.Description);
            $("#editForm").find("[name*='MasterCategoryID']").val(selectedCat.MasterCategoryID);
            $(`#selectMasterCatA option[value*=${selectedCat.MasterCategoryID}]`).attr('selected', 'selected');
            $("#editForm").find("[name*='isActive']").val(selectedCat.isActive);
            $("#editForm").find("[name*='isActive']").prop('checked',selectedCat.isActive);

        }
    });
})

//comboboxes
$("#selectMasterCatA").change(function () {
    var seletedId = $(this).val();
    $("#hiddenMasterCatA").val(seletedId);
});

$("#selectMasterCatU").change(function () {
    var seletedId = $(this).val();
    $("#hiddenMasterCatU").val(seletedId);
});

//checkbox function
$("#editForm").find("[name*='isActive']").change(function () {
    if (this.checked) {
        $("#editForm").find("[name*='isActive']").val(true);
    } else {
        $("#editForm").find("[name*='isActive']").val(false);
    }
});