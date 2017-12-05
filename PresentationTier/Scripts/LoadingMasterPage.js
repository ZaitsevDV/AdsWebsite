
$(function() {
    $("#categoriesBar").load("/Category/_Categories");
});

//function getSubCategories(objectCategory, categoryId) {
//    if (objectCategory != null) {
//        $("#categoriesBar").load('@(Url.Action("_Categories", "Category"))/' + categoryId);
//    }
//};

function getSubjectsById(objectCategory, isCategory) {
    if (objectCategory != null) {
        $("[name=category]").text("Category: " + objectCategory.text);
        $("#content").load("/Home/Subjects?id=" + objectCategory.id + "&isCategory=" + isCategory);
    }
};

function getDetailsSubject(inventoryNumber) {
    $("#content").load("/Home/ViewSubject?inventoryNumber=" + inventoryNumber);
};
