var $ = $ || require('jquery');

function init() {
	var table = $('table#grid');
	table.append('<tr><td id="cell-1x1"></td></tr>');
};

var module = module || {};
module.exports = init;
