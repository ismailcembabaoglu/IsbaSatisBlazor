function openOnScreenKeyboard() {
    window.open('osk.exe');
}
window.exampleJsFunctions = {
    sendKeyToFocusedElement: function (element, key) {
        if (element) {
            element.value += key; // Varsayılan davranış, elementin değerine tuşu ekler
            // Diğer özel davranışlar için burada kod ekleyebilirsiniz
        }
    }
};
