function Click() {

    alert($("#Button").data("kendoTextBox").value())
    $("#Button").data("kendoButton").enable(false);
}


function Open(e: Event)
{
    console.info("Open");
}

function Change(e: Event) {
    console.info("Change");
}


function DataBound(e: Event) {
    console.info("DataBound");
}