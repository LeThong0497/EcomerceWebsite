function addProductToCart(id, name, price, img) {
    var list = [];
    
    if (JSON.parse(localStorage.getItem(`cart`)) != null) {
        list = JSON.parse(localStorage.getItem(`cart`));
    }

    let product = {
        productId: id,
        name: name,
        price: price,
        img: img
    }
 
    list.push(product);
    localStorage.setItem(`cart`, JSON.stringify(list));
    updateCart();
}

function updateCart() {
    document.getElementById("badge").innerHTML = JSON.parse(localStorage.getItem('cart')).length;
}


function createCart() {
     var listItem = JSON.parse(localStorage.getItem(`cart`));
    
    var list2 = [];

    listItem?.map(function (item, index) {
        if (list2.find(pr => pr.productId == item.productId) === undefined) {
            let product = {
                productId: item.productId,
                name: item.name,
                price: item.price,
                img: item.img,
                total: function () {
                    let j;
                    var count = 0;
                    for (j = index; j < listItem.length; j++) {
                        if (listItem[j].productId == item.productId)
                            count++;
                    }
                    return count;
                }

            };
            list2.push(product);
        }
    });
   

    const cartElem = document.getElementById('cart-item');
    const productItemElement = document.createElement('table');
    productItemElement.classList.add('table');

    var tblBody = document.createElement("tbody");
    var money=0;
     list2.map(function (item, i) {
        var tr = document.createElement('tr');

        var td1 = document.createElement('td');
        td1.innerHTML = i + 1;

        var td2 = document.createElement('td');
        td2.innerHTML = item.name;

        var td3 = document.createElement('td');
         td3.innerHTML = item.total() + '  x  ' + item.price;
         money = money + item.total() * item.price;
        var td4 = document.createElement('td');
        const img = document.createElement('img');
        img.setAttribute('src', item.img);
        img.classList.add('img');
        td4.appendChild(img);

        var td5 = document.createElement('td');

       /* const btnUpdate = document.createElement('button');
        btnUpdate.innerHTML = 'Update';
        btnUpdate.classList.add('btn', 'btn-primary');
*/
        const btnDelete = document.createElement('button');
        btnDelete.innerHTML = 'Delete';
         btnDelete.classList.add('btn', 'btn-danger', 'ml-2');
         btnDelete.addEventListener('click', function () {
             removeItem(item.productId);
             console.log(item.productId);
         });
        //td5.appendChild(btnUpdate);
        td5.appendChild(btnDelete);

        tr.appendChild(td1);
        tr.appendChild(td2);
        tr.appendChild(td3);
        tr.appendChild(td4);
        tr.appendChild(td5);

        tblBody.appendChild(tr);

     });
    var tblFoot = document.createElement("tfoot");
    var tdf = document.createElement("td");
    tdf.classList.add('h5','text-danger');
    tdf.innerHTML = "Tổng tiền : " + `<strong>${money}</strong> VND` ;
    tblFoot.appendChild(tdf);

    productItemElement.appendChild(tblBody);
    productItemElement.appendChild(tblFoot);
    cartElem.appendChild(productItemElement);

}

function removeItem(id) {
    var listItem = JSON.parse(localStorage.getItem(`cart`));
    var temp= listItem.filter(function (item) {
        return item.productId !== id;
    });
    localStorage.setItem(`cart`, JSON.stringify(temp));
    location.reload();
}