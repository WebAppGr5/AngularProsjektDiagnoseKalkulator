function validerBruker(bruker) {
  const regexp = /^[a-zA-ZæøåÆØÅ\.\-\_\@]{3,30}$/;
  const ok = regnexp.test(bruker);
  if (!ok) {
    $("#feilBrukernavn").html("Brukernavnet må være mellom 3 og 30 tegn.")
    return false;
  }
  else {
    $("#feilBrukernavn").html("");
    return true;
  }
}
function validerPassord(passord) {
  const regexp = /^(?=.*[A-Za-z])(?=.*\d)[a-zA-ZæøåÆØÅ\d]{6,30}$/;
  const ok = regnexp.test(passord);
  if (!ok) {
    $("#feilPassord").html("Det må være minst en bokstav og et tall, ha mer enn 6 tegn, men være mindre enn 30.");
    return false;
  }
  else {
    $("#feilPassord").html("");
    return true;
  }
}
