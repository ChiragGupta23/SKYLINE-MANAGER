

(function($) {

	'use strict';

	var datatableInit = function() {
		var $table = $('#datatable-toolbox');

		var table = $table.dataTable({
			sDom: '<"text-right mb-md"T><"row"<"col-lg-6"l><"col-lg-6"f>><"table-responsive"t>p',
			buttons: [
				{
					extend: 'print',
					text: 'Print'
				},
				{
					extend: 'excel',
					text: 'Download'
				},
				{
					extend: 'colvis',
					columns: ':not(".select-disabled")'
				}
			]
		});

		$('<div />').addClass('dt-buttons mb-2 pb-1 text-end').prependTo('#datatable-default_wrapper');

		$table.DataTable().buttons().container().prependTo( '#datatable-default_wrapper .dt-buttons' );

		$('#datatable-default_wrapper').find('.btn-secondary').removeClass('btn-secondary').addClass('btn-default');
	};

	$(function() {
		datatableInit();
	});

}).apply(this, [jQuery]);
