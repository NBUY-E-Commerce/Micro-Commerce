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

    this.UpdateProductCountOfBasket = function (producid, count, owner) {
        $(owner).prepend('<div class="spinner-border loader" role="status" style="width: 15px;height: 15px;">< span class="sr-only"> Loading...</span></div>');

        $.ajax({
            url: "/ShoppingCart/UpdateProductCountOfShoppingCart",
            data: { ProductID: producid, NewCount: count },
            method: "POST",
            async: false,
            success: function (d) {
                console.log(d);

                if (d.Code != 0) {
                    location.href = "/Error/General";
                } else {
                    location.href = "/ShoppingCart/Details";
                }
            }, complete: function () {
                $(owner).find(".loader").remove();
            }
        })
    }
}

function addToBasket(owner, productid) {
    var _basketManager = new basketManager();
    _basketManager.addToBasket(productid, 1, owner);
}


// count 0 giderse Product Sepetten Silinir
function UpdateBasket(productid, count, owner) {
    var _basketManager = new basketManager();
    _basketManager.UpdateProductCountOfBasket(productid, count, owner);
}

function UpdateAllProductCountsOfBasket() {
    
    try {
        var listofproducts = $('input[name ="basketproduct"]');
        $.each(listofproducts, function (indexInArray, element) {
            UpdateBasket($(element).attr("data-productid"), $(element).val(), element);
        });
    } catch (error) {
        //hata olursa işlemler
        alert(error.message)
    }

}