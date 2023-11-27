//<script>
    
//    function updateCardInfo() {
//        // Obtener valores de los campos
//        var cardNumber = document.getElementById('inputCardNumber').value;
//    var cardName = document.getElementById('inputCardName').value;
//    var expirationDate = document.getElementById('inputExpirationDate').value;

//    // Actualizar la información de la tarjeta con los valores ingresados
//    document.getElementById('cardNumberLabel').innerText = cardNumber;
//    document.getElementById('cardHolder').innerText = cardName;
//    }

//    document.getElementById('inputCardNumber').addEventListener('input', updateCardInfo);
//    document.getElementById('inputCardName').addEventListener('input', updateCardInfo);
//    document.getElementById('inputExpirationDate').addEventListener('input', updateCardInfo);
//</script>



// Obtener referencia al input y al label de la fecha de expiración
const expirationInput = document.getElementById('ExpirationInput');
const expirationLabel = document.getElementById('ExpirationLabel');

// Agregar un event listener al input de la fecha de expiración
expirationInput.addEventListener('input', function () {
    // Actualizar el contenido del label con el valor del input
    expirationLabel.textContent = expirationInput.value;
});

// Obtener referencia al input y al label del nombre del titular
const cardNameInput = document.getElementById('CardNameId');
const cardNameLabel = document.getElementById('CardNameLabel');

// Agregar un event listener al input del nombre del titular
cardNameInput.addEventListener('input', function () {
    // Actualizar el contenido del label con el valor del input
    cardNameLabel.textContent = cardNameInput.value;
});


function reiniciarPagina() {
    // Utilizamos la función location.reload() para recargar la página
    location.reload();
}