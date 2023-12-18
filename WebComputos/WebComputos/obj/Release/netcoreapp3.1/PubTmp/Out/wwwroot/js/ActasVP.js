var dataTable;

$(document).ready(function () {
    carg1();
    carg2();
    carg3();
    carg4();
    idres1();
    idres2();
    idres3();
    idres4();
    Incidente();
});


function Incidente() {
    $("input[name=Chein]").click(function () {
        var res = $('input:radio[name=Chein]:checked').val();
        document.getElementById("incidente").value = res;
    });
}



function idres1() {
    $("#casid1").focus(function () {
        var b = document.getElementById("casid1").value;
        document.getElementById("idres1").value = b;     
    });
    $("#casid1").change(function () {
        var b = document.getElementById("casid1").value;
        document.getElementById("idres1").value = b;
    });
}

function idres2() {
    $("#casid2").focus(function () {
        var b = document.getElementById("casid2").value;
        document.getElementById("idres2").value = b;
    });
    $("#casid2").change(function () {
        var b = document.getElementById("casid2").value;
        document.getElementById("idres2").value = b;
    });
}

function idres3() {
    $("#casid3").focus(function () {
        var b = document.getElementById("casid3").value;
        document.getElementById("idres3").value = b;
    });
    $("#casid3").change(function () {
        var b = document.getElementById("casid3").value;
        document.getElementById("idres3").value = b;
    });
}

function idres4() {
    $("#casid4").focus(function () {
        var b = document.getElementById("casid4").value;
        document.getElementById("idres4").value = b;
    });
    $("#casid4").change(function () {
        var b = document.getElementById("casid4").value;
        document.getElementById("idres4").value = b;
    });
}

function carg1() {
    $("#Seccion1").change(function () {
        var url = "/admin/TActas/CargarGob";
        var a = document.getElementById("cmb1").value;
        var b = document.getElementById("Seccion1").value;
        $.getJSON(url, { ide: a, ids: b }, function (data) {
            var items = '';
            $("#casid1").empty();
            $.each(data, function (j, row) {
                items += "<option value='" + row.value + "'>" + row.text + "</option>";
            });
            $("#casid1").html(items);
            document.getElementById("casid1").focus();
        }) 
    });
         
}
function carg2() {
    $("#Seccion2").change(function () {
        var url = "/admin/TActas/CargarGob";
        var a = document.getElementById("cmb2").value;
        var b = document.getElementById("Seccion2").value;
        $.getJSON(url, { ide: a, ids: b }, function (data) {
            var items = '';
            $("#casid2").empty();
            $.each(data, function (j, row) {
                items += "<option value='" + row.value + "'>" + row.text + "</option>";
            });
            $("#casid2").html(items);
            document.getElementById("casid2").focus();
        })
    });
}
function carg3() {
    $("#Seccion3").change(function () {
        var url = "/admin/TActas/CargarGob";
        var a = document.getElementById("cmb3").value;
        var b = document.getElementById("Seccion3").value;
        $.getJSON(url, { ide: a, ids: b }, function (data) {
            var items = '';
            $("#casid3").empty();
            $.each(data, function (j, row) {
                items += "<option value='" + row.value + "'>" + row.text + "</option>";
            });
            $("#casid3").html(items);
            document.getElementById("casid3").focus();
        })
    });
}
function carg4() {
    $("#Seccion4").change(function () {
        var url = "/admin/TActas/CargarGob";
        var a = document.getElementById("cmb4").value;
        var b = document.getElementById("Seccion4").value;
        $.getJSON(url, { ide: a, ids: b }, function (data) {
            var items = '';
            $("#casid4").empty();
            $.each(data, function (j, row) {
                items += "<option value='" + row.value + "'>" + row.text + "</option>";
            });
            $("#casid4").html(items);
            document.getElementById("casid4").focus();
        })
    });
}


