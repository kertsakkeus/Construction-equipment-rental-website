function setPrice(time) {
    var price = document.getElementById("product_price");
    var type = document.getElementById("product_type").innerHTML;

    type = type.substring(36);
    type = type.substring(0, type.length - 7);

    price.innerHTML = priceCalculation(type, time).toString() + "€";
}

function priceCalculation(type, rentTime) {
    var OneTime = 100;
    var Premium = 60;
    var Regular = 40; 

    var rentalPrice;
    if (type == "Regular") {
        if (rentTime <= 2) {
            rentalPrice = OneTime + (Premium * rentTime);
            return rentalPrice;
        }
        else {
            rentalPrice = OneTime + (Premium * 2) + (Regular * (rentTime - 2));
            return rentalPrice;
        }
    }
    else if (type == "Heavy") {
        rentalPrice = OneTime + (Premium * rentTime);
        return rentalPrice;
    }
    else if (type == "Specialized") {
        if (rentTime <= 3) {
            rentalPrice = Premium * rentTime;
            return rentalPrice;
        }
        else {
            rentalPrice = (Premium * 3) + (Regular * (rentTime - 3));
            return rentalPrice;
        }
    }
    else {
        return 0;
    }
}

function addToCart() {
    var id = document.URL.substring(document.URL.length - 1);
    var price = document.getElementById("product_price").innerHTML;
    var cart_price = document.getElementById("cart_price");
    var cart_number = document.getElementById("cart_num");

    price = price.substring(0, price.length - 1);
    var subCartPrice = cart_price.innerHTML.substring(0, cart_price.innerHTML.length - 1);

    if (price != "0") {
        cart_price.innerHTML = (parseInt(subCartPrice, 10) + parseInt(price, 10)).toString() + "€";
        cart_number.innerHTML = (parseInt(cart_number.innerHTML, 10) + 1).toString();
        document.cookie += " Id=" + id;
        document.cookie += " Price=" + price;

        console.log(document.cookie);
    }
    else {
        alert("Please choose renting time!");
    }
}