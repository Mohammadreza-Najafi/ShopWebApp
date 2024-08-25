const cookieName = "cart-items";
function addToCart(id, name, price, picture) {

    let products = $.cookie(cookieName);
    if (products == undefined) {
        products = [];
    } else {
        products = JSON.parse(products);
    }

    const count = $("#productCount").val();
    const currentProduct = products.find(x => x.id === id);
    if (currentProduct !== undefined) {
        products.find(x => x.id === id).count = parseInt(currentProduct.count) + parseInt(count);
    } else {

        const product = {
            id,
            name,
            unitPrice : price,
            picture,
            count
        }

        products.push(product);
    }

    $.cookie(cookieName, JSON.stringify(products), { expires: 2, path: "/" });
    updateCart();
}

function updateCart() {

    let products = $.cookie(cookieName);
    products = JSON.parse(products);
    $("#cart_items_count").text(products.length);

    let cartItemsWrapper = $("#cart-items-wrapper");
    cartItemsWrapper.html('');
    products.forEach(x => {
        const product = ` <li class="furgan-mini-cart-item mini_cart_item">
                                                    <a href="#" class="remove remove_from_cart_button" onclick="removeFromCart('${x.id}')">×</a>
                                                    <a href="#">
                                                        <img src="/ProductPictures/${x.picture}"
                                                             class="attachment-furgan_thumbnail size-furgan_thumbnail"
                                                             alt="img" width="600" height="778">${x.name}&nbsp;
                                                    </a>
                                                    <span class="quantity">
                                                        ${x.count} × <span class="furgan-Price-amount amount">
                                                            <span class="furgan-Price-currencySymbol">$</span>${x.unitPrice}
                                                        </span>
                                                    </span>
                                                </li>`;

        cartItemsWrapper.append(product);
    })
}

function removeFromCart(id) {
    let products = $.cookie(cookieName);
    products = JSON.parse(products);
    const itemToRemove = products.findIndex(x => x.id === id);
    products.splice(itemToRemove, 1);
    $.cookie(cookieName, JSON.stringify(products), { expires: 2, path: "/" });
    updateCart();
}

function changeCartItemCount(id, totalId, count) {
    var products = $.cookie(cookieName);
    products = JSON.parse(products);

    var productIndex = products.findIndex(x => x.id == id)
    products[productIndex].count = count;

    var product = products[productIndex];
    const newPrice = parseInt(product.unitPrice) * parseInt(count);

    $(`#${totalId}`).text(newPrice);
    //products[productIndex].totalPrice = newPrice;

    $.cookie(cookieName, JSON.stringify(products), { expires: 2, path: "/" });
    updateCart();

}