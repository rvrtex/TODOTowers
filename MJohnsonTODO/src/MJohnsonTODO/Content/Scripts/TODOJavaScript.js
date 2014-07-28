
//$(function () {
//    $("#todo-form").submit(function (e) {
//        e.preventDefault();
      
//        var title = $("#Title").val(),
//          details = $("#details").val(),
//          numberToDiplay = $("#numberInListToDisplay").val(),
//          todo = {
//              Title: title,
//              Details: details
//          };
//        if (numberToDiplay < 12) {
//            $.ajax({
//                url: "http://localhost:49886/save/todo",
//                type: "POST",
//                data: {
//                    details: todo.Details,
//                    title: todo.Title
//                },
//                contentType: 'application/json; charset=utf-8',
//                dataType: "json",
//                error: function (data, error, status) {
//                    alert('error');
//                }

//            });
//        }
//        else {
//            alert("Your List is Full. Remove and item to make room for more.")
//        }

//    });
//});


$(function () {
    $(".DeleteButton").click(function (e) {
        e.preventDefault();

        var id = $("#myID").val(),
          todo = {
              Id: id            
          };
       
        $.ajax({
            url: "http://localhost:49886/delete/element",
            type: "POST",
            data: JSON.stringify({
                myID: todo.Id
               }),
            contentType: 'application/json; charset=utf-8',
            dataType: "json",
            success: function (data) {
                if (data.success) {
                   // window.location.href = "/";
                } else {
                    alert('error');
                }
            },
            error: function (data, error, status) {
                alert('error');
            }
        });
    });
});


$(document).ready(function (e) {

    $('.dropdown').on('click', function (e) {

        $(this).next('.dropdownwrap').slideToggle();

    });

})

$(document).ready(function (e) {

    $('.dropdownAll').on('click', function () {

        $('.dropdownwrap').slideToggle();

    });

})

function css(selector, property, value) {
    for (var i = 0; i < document.styleSheets.length; i++) {//Loop through all styles
        //Try add rule
        try {
            document.styleSheets[i].insertRule(selector + ' {' + property + ':' + value + '}', document.styleSheets[i].cssRules.length);
        } catch (err) { try { document.styleSheets[i].addRule(selector, property + ':' + value); } catch (err) { } }//IE
    }
}