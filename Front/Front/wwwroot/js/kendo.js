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
//# sourceMappingURL=kendo.js.map