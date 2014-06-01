var init = require('../../Yose/static/minesweeper.js');
var $ = require('jquery');

describe('init', function() {

	beforeEach(function() {
		$('body').empty();
		$('body').append('<table id="grid"></table>');
	});
	
	it('works on a table#grid', function() {
		expect($('table#grid').length).toEqual(1);
	});

	it('adds one cell', function() {
		init();
		expect($('table td#cell-1x1').length).toEqual(1);
	});

});
