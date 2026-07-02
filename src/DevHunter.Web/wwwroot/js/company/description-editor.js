var descriptionEditor = document.getElementById("description-editor");
var descriptionInput = document.getElementById("description-input");

descriptionEditor.addEventListener("input", function () {
	descriptionInput.value = descriptionEditor.innerHTML;
});
