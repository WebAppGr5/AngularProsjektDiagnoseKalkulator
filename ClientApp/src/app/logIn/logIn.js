function login() {
  const brukerOK = validerBruker($("#bruker")).val();
  const passordOK = validerPassord($("#passord")).val();

  if (brukerOK && passordOK) {
    const bruker = {
      brukerN: $("#bruker").val(),
      passord: $("#passord").val()
    }
    $.post("Bruker/login", bruker, function (OK) {
      if (OK) {
        window.Location.href = 'minSide.html';
      }
      else {
        $("#feil").html("Feil brukernavn eller Passord, prøv på nytt eller opprett ny bruker.");
      }
    })
      .fail(function () {
        $("#feil").html("Server feil oppstod, prøv på nytt senere.")
      });
  }
}
