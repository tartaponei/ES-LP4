// Write your JavaScript code.
function CarregarUsuarioLogado() {
    var nome = '@HttpContextAccessor.HttpContext.Session.GetString("NomeUsuarioLogado")'

    if (nome != "") {
        var divNome = document.getElementById("NomeUsuarioLogado");
        divNome.innerHTML = "Olá, " + nome;

        var divLog = document.getElementById("log");
        divLog.innerHTML = "Logoff" + "<a href='../Usuario/Login/0'> </a>";

    }

    else {
        var divLog = document.getElementById("log");
        divLog.innerHTML = "Login";
    }

}