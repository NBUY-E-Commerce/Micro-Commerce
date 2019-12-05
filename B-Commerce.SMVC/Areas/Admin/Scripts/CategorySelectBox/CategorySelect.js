

var categorySelect = function (data, selectchange) {


    var ui, header;
    var stack = [];
    var self = this;

  
    this.selectedid = -1;
    var createHeader = function () {
        $(header).html("");
        var searchBar = $('');
        $(header).append(searchBar);
        if (stack.length > 1) {

            var navigationBar = $("<div></div>");
            var navigationicon = $('<a> <img src="/Areas/Admin/Scripts/CategorySelectBox/return-button.svg" style="height:25px;" /></a>');

            navigationBar.append(navigationicon);
            navigationicon.click(function () {
                //sonuncuyu sıl
                stack.pop();

                var prevpagedata = stack[stack.length - 1];

                self.openCategoryTree(prevpagedata);

            })

            $(header).append(navigationBar);


        }
        selectedid = -1;
    }
    this.createUI = function (ownerdomelement) {
        header = $("<header></header>");

        ui = $("<div class='categorySelect'><div></div></div>");

        ui.prepend(header);
        stack.push(data);
        self.openCategoryTree(data);
        $(ownerdomelement).html(ui);


    }
    this.openCategoryTree = function (categorydata) {

        var categoryListUi = $("<div class='categorySelectContent'><ul class='names' id='myList'></ul></div>");


        $(categorydata).each(function (index, item) {


            var categorydomelem = $("<a></a>");
            categorydomelem.attr("data-hasSubCategory", item.HasSubCategory);
            categorydomelem.attr("data-id", item.ID);
            categorydomelem.text(item.Name);
            categorydomelem.data("subcats", item.SubCategories);

            categorydomelem.click(function () {

                var hasSubCategory = $(this).data("hassubcategory");
                if (hasSubCategory) {
                    var subcatdata = $(this).data("subcats");
                    stack.push(subcatdata);
                    self.openCategoryTree(subcatdata);
                } else {
                    $(".selecteditem").removeClass("selecteditem");
                    var id = $(this).attr("data-id");
                    $(this).addClass("selecteditem");

                    self.selectedid = id;
                    selectchange(id);

                }

            });

            var lielem = $("<li></li>");
            lielem.append(categorydomelem);
            categoryListUi.find(">ul").append(lielem);

        });


        ui.find(">div").html(categoryListUi);
        createHeader();

    }


}

