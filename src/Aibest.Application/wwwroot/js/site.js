// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$("document").ready(function () {
    window.jsPDF = window.jspdf.jsPDF;


    var specialElementHandlers = {
        '#editor': function (element, renderer) {
            return true;
        }
    };

    $('#generate-pdf').on('click', function () {
        var element = document.getElementById("cv-content")
        var opt = {
            margin: 1,
            filename: 'myfile.pdf',
            image: {type: 'jpeg', quality: 0.98},
            html2canvas: { scrollY: 0, scrollX: 0},
            jsPDF: {unit: 'pt', format: 'a4', orientation: 'portrait'}
        };
        html2pdf().set(opt).from(element).save();


    })
});

