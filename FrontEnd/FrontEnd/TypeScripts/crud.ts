var orderId: any;
let urlUpdateOrder: string = "";

function Getddl() {
    return {
        option: $("#filter").data("kendoDropDownList").value()
    }
}

function readGrid() {
    $("#Grid").data("kendoGrid").dataSource.read()
}


function onClick() {
    return window.location.assign("/api/Grid_Create_Order")
}

function GetOrderId() {
    return { orderId: orderId }
}

function Confirm() {

    $.post(urlUpdateOrder, {
        Id: orderId,
        State: 1,
    }).done(
        () => {
            window.location.href = "/api/order";
        }
    );

}

class OrderModel {
    Id: any;
    State: any;

}