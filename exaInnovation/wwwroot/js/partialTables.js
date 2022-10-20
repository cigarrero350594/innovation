


// Premade test data, you can also use your own
var testDataUrl = "https://raw.githubusercontent.com/chennighan/RapidlyPrototypeJavaScript/master/lesson4/data.json"

//$("#ModulosIndex").click(function (env) {
//    var _url ="Tareas/Index";
//    var id = $(this).attr('data-id');
//    var urlComplete = _url + '/' + id;
//    console.log(urlComplete);
//    loadData(urlComplete);
//});

function loadData(_urlComplete) {
    $.ajax({
        type: 'GET',
        url: _urlComplete,
        contentType: "text/plain",
        dataType: 'json',
        success: function (data) {
            myJsonData = data;
            populateDataTable(myJsonData);
        },
        error: function (e) {
            console.log("There was an error with your request...");
            console.log("error: " + JSON.stringify(e));
        }
    });
}

// populate the data table with JSON data
function populateDataTable(data) {
    console.log("populating data table...");
    console.log(data);
    // clear the table before populating it with more data
    $("#DataTable").DataTable().clear();
    console.log("Longitud" + data.customer);
    var length = data.length;//Object.keys(data.customer).length;
    if (length > 0) {
        for (var i = 0; i < length; i++) {
            var customer = data[i];
            console.log("Customer For " + customer);
            // You could also use an ajax property on the data table initialization
            $('#DataTable').dataTable().fnAddData([
                customer.id,
                customer.nombre,
                customer.fechaCreacion,
                customer.estado
            ]);
        }
    }
    else {
        $("#DataTable").DataTable().destroy();
        console.log('Sin Info');

    }
}


$('.js-reload-details').on('click', function (evt) {
    var _url = "Tareas/Index";
    var id = $(this).attr('data-id');
    var urlComplete = _url + '/' + id;
    console.log(urlComplete);
    loadData(urlComplete);
});



var table = $('#DataTable').DataTable();
$('#DataTable tbody').on('click', 'tr', function () {
    if ($(this).hasClass('selected')) {
        console.log('Clicked over rOW_')
        $(this).removeClass('selected');
    }
    else {
        table.$('tr.selected').removeClass('selected');
        $(this).addClass('selected');
        console.log('Clicked over rOW')
    }
});

$('#edit').click(function () {
    //table.row('.selected').remove().draw(false);
    console.log('Clicked over rOW')
    table.row('.selected');
    console.log(table.row('.selected').data());

    var ids = $.map(table.rows('.selected').data(), function (item) {
        return item[0]
    });
    console.log(ids)
    var _url = "Tareas/Edit";
    var id = ids;
    EditTask(_url + '/' + id);
});


function EditTask(_urlComplete) {

    $.get(_urlComplete, function (data) {
      
    });
}