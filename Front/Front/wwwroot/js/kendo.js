function Click() {
    alert($("#Button").data("kendoTextBox").value());
    $("#Button").data("kendoButton").enable(false);
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
function Cargar(e) {
    $("#color").data("kendoDropDownList").dataSource.read();
}
//# sourceMappingURL=kendo.js.map