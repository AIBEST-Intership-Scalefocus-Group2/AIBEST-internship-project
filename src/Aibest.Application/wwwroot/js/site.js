// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$("document").ready(function () {
    var doc = new jsPDF('p', 'pt', 'A4');

    var specialElementHandlers = {
        '#editor': function (element, renderer) {
            return true;
        }
    };

    $('#generate-pdf').on('click', function () {
        doc.fromHTML($('#cv-content').html(), 30, 15, {
            'width': 2500,
            'elementHandlers': specialElementHandlers
        });
        doc.save('resume.pdf');
    })
});

