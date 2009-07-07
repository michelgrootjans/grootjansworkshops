$(document).ready(function() {

    $('.tabs').tabs();

    $('table').listify(); //make table rows clickable when ONE link exists in the row

    $('table').tablesorter({ widgets: ['zebra'] }); // Sortable tables

    $('.accordion').accordion({ autoHeight: false, collapsible: true, active: 100});
});