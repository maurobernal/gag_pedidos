function Click() {
    alert($("#Tbx").data("kendoTextBox").value());
    $("#Button").data("kendoButton").enable(false);
}

function Cargar() {
    $("#color").data("kendoDropDownList").dataSource.read();
}

function Open(e: Event) {
    console.info("Open");
}

function Change(e: Event) {
    console.info("Change");
}

function DataBound(e: Event) {
    console.info("DataBound");
}