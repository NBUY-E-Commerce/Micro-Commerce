
var basketManager = function () {

    this.addToBasket = function (producid, count) {
        $.ajax({
            url: "/ShoppingCart/AddToCart",
            data: { productid: producid, count: count },
            method: "POST",
            success: function () {



            }


        })


        //sepete ekle işlemi için productservise gidicem
        //eğer tokenım varsa onu, ürünid mi ,adet
        //eğer token yoksa visitortoken 'i

    }


}



function addToBasket(productid) {

    var _basketManager = new basketManager();
    _basketManager.addToBasket(productid, 1);

}




