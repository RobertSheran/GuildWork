$(document).ready(function () {
    $('#page-title').css('text-align', 'center');
    var moneyIn = 0;
    var change = 0;


    LoadItems();

    $('#add-dolor-button').click(function (event) {
        moneyIn += 1;
        $('#add-money').val(moneyIn.toFixed(2));
    });


    $('#add-quarter-button').click(function (event) {
        moneyIn += .25;
        $('#add-money').val(moneyIn.toFixed(2));
    });

    $('#add-dime-button').click(function (event) {
        moneyIn += .1;
        $('#add-money').val(moneyIn.toFixed(2));
    });

    $('#add-nickle-button').click(function (event) {
        moneyIn += .05;
        $('#add-money').val(moneyIn.toFixed(2));
    });

    document.getElementById('items-container').addEventListener('click', function (event) {

        $("#item-lable").val(event.target.id);
    });


    $("#perchace-button").click(function (event) {
        GetChangeOrERRORResponse($("#item-lable"), $('#add-money'));
        $('#items-container').empty();
        LoadItems();
    });

    $("#return-change-button").click(function (event) {
        $('#add-money').val(0);
        moneyIn = 0;
        $("#change-lable").val(0);
        $("#message-lable").val("");
        $("#item-lable").val("");
    });

    



});

function GetChangeOrERRORResponse(itemNumber, amount) {

    var change = $('#change-lable');
    var message = $("#message-lable");
    var quarters = 0;
    var dimes = 0;
    var nickles = 0;
    var pennies = 0;

    $.ajax({
        type: 'GET',
        url: 'http://localhost:8080/money/' + amount.val().toString() + '/item/' + itemNumber.val().toString(),
        success: function (data) {
            quarters = data.quarters;
            dimes = data.dimes;
            nickles = data.nickels;
            pennies = data.pennies;

            message.val("Thank You");
            change.val((.25*quarters)+(.1*dimes)+(.05*nickles)+(.01*pennies)).toFixed(2);            
        },

        error: function (request,data,status) {   
            message.val(request.responseJSON.message);
        }

    });
}



function LoadItems() {
    var contentRows = $('#items-container');

    $.ajax({
        type: 'GET',
        url: 'http://localhost:8080/items',
        success: function (itemArray) {

            $.each(itemArray, function (index, item) {
                var id = item.id;
                var name = item.name;
                var price = item.price;
                var quantity = item.quantity;
                var name = item.name;

                

                var row = "<div class='panel panel-default border-dark col-sm-4'>";
                row += "<div id=" + id + ">" + id + "</div>";
                row += "<div>" + name + "</div>";
                row += "<div>" + price + "</div>";
                row += "<div>" + quantity + "</div>";
                row += "</div>";

                contentRows.append(row);
            });
        },
        error: function () {
            alert("big win error, load items failed");

        }
    });




}