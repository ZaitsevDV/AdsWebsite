$(document).ready(function () {

    $("#TypeId").on("change", function () {
        if (this.value === "4") {
            $("#New_item").hide();
        }
        else {
            $("#New_item").show();
        }
    });
});

$(document).ready(function () {
    $(function () {
        $("#datetimepicker").datetimepicker({
            useCurrent: true,
            format: "DD.MM.YYYY hh:mm A"
        });
    });

    $(function () {
        var actionCount = 1;
        $("#newAction").click(function () {
            var clon = $("#action_group").clone();
            clon.children(".control-label").text("Action " + actionCount);
            clon.children("div.col-md-3").children("input").val("");
            $("#action_conteiner").append(clon);
            actionCount++;
        });
    });

});