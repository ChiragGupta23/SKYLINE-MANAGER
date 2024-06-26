
(function($) {

	'use strict';

	var datatableInit = function() {

		var $table = $('#datatable-ajax');
		$table.dataTable({
			dom: '<"row"<"col-lg-6"l><"col-lg-6"f>><"table-responsive"t>p',
			bProcessing: true,
			sAjaxSource: $table.data('url')
		});

	};

	$(function() {
		datatableInit();
	});

}).apply(this, [jQuery]);