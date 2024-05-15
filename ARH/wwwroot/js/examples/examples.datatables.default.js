$(document).ready(function () {



    var table = $('#example').DataTable({
        select: false,
        "columnDefs": [{
            className: "Name",
            "targets": [0],
            "visible": false,
            "searchable": false
        }]
    });//End of create main table


    $('#example tbody').on('click', 'tr', function () {

        alert(table.row(this).data()[0]);

    });
});

(function ($) {
    'use strict';
    var datatableInit = function () {
        $('#datatable-default').dataTable({
            dom: '<"row"<"col-lg-6"l><"col-lg-6"f>><"table-responsive"t>p'
        });
    };
    $(function () {
        datatableInit();
    });
}).apply(this, [jQuery]);
