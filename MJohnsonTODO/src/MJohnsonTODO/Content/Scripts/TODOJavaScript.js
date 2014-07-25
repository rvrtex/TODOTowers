
$(function () {
    $("#todo-form").submit(function (e) {
        e.preventDefault();
      
        var title = $("#Title").val(),
          details = $("#details").val(),
          todo = {
              Title: title,
              Details: details
          };

        $.ajax({
            url: "http://localhost:49886/save/todo",
            type: "POST",
            data: {
                details: todo.Details,
                title: todo.Title
            },
            contentType: 'application/json; charset=utf-8',
            dataType: "json",                                                                                                           
            error: function (data, error, status) {
                alert('error');
            }
        });
       

    });
});


$(function () {
    $("#IsDoneCheckBox").click(function (e) {
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
                    window.location.href = "/";
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
