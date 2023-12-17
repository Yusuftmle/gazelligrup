var world = document.getElementsByTagName("path");
for (var i = 0; i < world.length; i++) {
	var country = world[i];
	country.setAttribute("data-toggle", "tooltip");
	country.setAttribute("data-placement", "top");
	country.setAttribute("title", country.getAttribute("id"));
}

$(function () {
  $('[data-toggle="tooltip"]').tooltip()
})


var btn = $('#button');

$(window).scroll(function () {
    if ($(window).scrollTop() > 300) {
        btn.addClass('show');
    } else {
        btn.removeClass('show');
    }
});

btn.on('click', function (e) {
    e.preventDefault();
    $('html, body').animate({ scrollTop: 0 }, '300');
});




// find all "length" properties
spotlight.byName('length');

// or find all "map" properties on jQuery
spotlight.byName('map', { 'object': jQuery, 'path': '$' });

// or all properties with `jQuery` objects
spotlight.byKind(jQuery);

// or all properties with `RegExp` values
spotlight.byKind('RegExp');

// or all properties with `null` values
spotlight.byKind('null');

// or all properties with `undefined` values
spotlight.byKind('undefined');

// or all constructors
spotlight.byKind('constructor');

// or all properties with the value `0`
spotlight.byValue(0);

// or all properties containing "oo" in their name
spotlight.custom(function (value, key) { return key.indexOf('oo') > -1; });

// or all properties with falsey values
spotlight.custom(function (value) { return !value; });


