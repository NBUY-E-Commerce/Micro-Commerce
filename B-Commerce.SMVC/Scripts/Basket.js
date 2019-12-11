var basketManager = function () {
    this.addToBasket = function (producid, count, owner) {
        $(owner).prepend('<div class="spinner-border loader" role="status" style="width: 15px;height: 15px;"><span class="sr-only"> Loading...</span></div>');
        $.ajax({
            url: "/ShoppingCart/AddToCart",
            data: { productid: producid, count: count },
            method: "POST",
            success: function (d) {
                console.log(d);

                if (d.Code != 0) {
                    location.href = "/Error/General";
                } else {
                    //işlem basarılı
                    $("#currentbasketcount").text(d.shoppingCartModel.cardProduct.length);
                }
            }, complete: function () {
                $(owner).find(".loader").remove();
            }
        })

        //sepete ekle işlemi için productservise gidicem
        //eğer tokenım varsa onu, ürünid mi ,adet
        //eğer token yoksa visitortoken 'i
    };

    this.UpdateProductCountOfBasket = function (UpdateProductCounts, owner) {
        //var deferedObject = $.Deferred();
        $(owner).prepend('<div class="spinner-border loader" role="status" style="width: 15px;height: 15px;"><span class="sr-only"> Loading...</span></div>');

        $.ajax({
            url: "/ShoppingCart/UpdateProductCountOfShoppingCart",
            data: { UpdateProductCounts: UpdateProductCounts },
            method: "POST",
            success: function (d) {

                if (d.Code != 0) {
                    location.href = "/Error/General";
                } else {
                    location.href = "/ShoppingCart/Details"
                }

            },
            complete: function () {
                $(owner).find(".loader").remove();
            }
        })

        //return deferedObject.promise();
    };
}

function addToBasket(owner, productid) {
    var _basketManager = new basketManager();
    _basketManager.addToBasket(productid, 1, owner);
}


// count 0 giderse Product Sepetten Silinir
function UpdateBasket(productid, count, owner) {
    var list = [];
    var obj = { Token: "", ProductID: productid, NewCount: count };
    list.push(obj)
    var _basketManager = new basketManager();
    _basketManager.UpdateProductCountOfBasket(list, owner);
}

function UpdateAllProductCountsOfBasket() {
    var _basketManager = new basketManager();

    try {
        var listofproducts = $('input[name="basketproduct"]');
        var list = [];
        $.each(listofproducts, function (indexInArray, element) {
            var obj = { Token: "", ProductID: $(element).attr("data-productid"), NewCount: $(element).val() };
            list.push(obj);
        });
        _basketManager.UpdateProductCountOfBasket(list);
        //_basketManager.UpdateProductCountOfBasket(list, element).done(function () {
        //    if (indexInArray == allcount - 1) {
        //        location.href = "/ShoppingCart/Details";
        //    }
        //})
    } catch (error) {
        //hata olursa işlemler
        alert(error.message);
    }

}