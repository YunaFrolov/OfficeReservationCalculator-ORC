$(document).ready(function () {

    $('.date-picker').datepicker({
        changeMonth: true,
        changeYear: true,
        showButtonPanel: true,
        dateFormat: 'mm-yy',
        onClose: function (dateText, inst) {
            $(this).datepicker('setDate', new Date(inst.selectedYear, inst.selectedMonth, 1));
            onChangeMonth(inst.selectedMonth, inst.selectedYear);
            document.getElementById("hMonth").innerHTML = inst.selectedYear  + "-" +  (inst.selectedMonth+1);  
        }
    });


})


function onChangeMonth(chosenMonth, chosenYear) {
    document.getElementById("rShowResults").style.display = "none";
    

    $.ajax({
        url: "/Home/_calcMonthRevenue",
        type: "GET",
        dataType: "text",
        data: { iChosenMonth: chosenMonth+1, iChosenYear: chosenYear },
        success: function (data) {
            document.getElementById("rShowResults").style.display = "block";
            DisplayRevenue(data);
        }, error: function (_calcMonthRevenue) {
            alert("An Error Occured: Calculating Revenue");
        }
    })


    $.ajax({
        url: "/Home/_calcMonthCapacity",
        type: "GET",
        dataType: "json",
        data: { iChosenMonth: chosenMonth + 1, iChosenYear: chosenYear },
        success: function (data) {
            document.getElementById("rShowResults").style.display = "block";
            DisplayUnreserved(data);
        }, error: function (_calcMonthCapacity) {
            alert("An Error Occured: Calculating Capacity");
        }
    })

}


function DisplayRevenue(data) {
    
    document.getElementById("month_revenue").innerHTML = data;
}

function DisplayUnreserved(data) {
    
    document.getElementById("unreserved_offices").innerHTML = data;
}
