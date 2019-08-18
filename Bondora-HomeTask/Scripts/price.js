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