function Click() {
    alert($("#Tbx").data("kendoTextBox").value());
    $("#Button").data("kendoButton").enable(false);
}
function Cargar() {
    $("#color").data("kendoDropDownList").dataSource.read();
}
function Open(e) {
    console.info("Open");
}
function Change(e) {
    console.info("Change");
}
function DataBound(e) {
    console.info("DataBound");
}
//# sourceMappingURL=kendo.js.map