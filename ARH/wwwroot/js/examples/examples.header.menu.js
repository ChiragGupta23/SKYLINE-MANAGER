
(function($) {

	'use strict';

	// Toggle Mega Sub Menu Expand Button
	var megaSubMenuToggleButton = function() {

		var $button = $('.mega-sub-nav-toggle');

		$button.on('click', function(){
			$(this).toggleClass('toggled');
		});

	};

	$(function() {
		megaSubMenuToggleButton();
	});

}).apply(this, [jQuery]);