

const expirationInput = document.getElementById('ExpirationInput');
const expirationLabel = document.getElementById('ExpirationLabel');


expirationInput.addEventListener('input', function () {

    expirationLabel.textContent = expirationInput.value;
});


const cardNameInput = document.getElementById('CardNameId');
const cardNameLabel = document.getElementById('CardNameLabel');


cardNameInput.addEventListener('input', function () {
  
    cardNameLabel.textContent = cardNameInput.value;
});


function reiniciarPagina() {

    location.reload();
}