// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var i = 0;
function buttonClick() {
  document.getElementById("inc").value = ++i;
}

function incrementValue() {
  var value = parseInt(document.getElementById("number").value, 10);
  value = isNaN(value) ? 0 : value;
  if (value < 10) {
    value++;
    document.getElementById("number").value = value;
  }
}
function decrementValue() {
  var value = parseInt(document.getElementById("number").value, 10);
  value = isNaN(value) ? 0 : value;
  if (value > 1) {
    value--;
    document.getElementById("number").value = value;
  }
}
