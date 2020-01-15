# Assinado.Crypt
Biblioteca C# para encriptação de strings.
Utiliza como base a classe Rijndael, que é baseada em um algoritmo de mesmo nome e também conhecido como “Advanced Encryption Standard” (ou simplesmente “AES”).
Este padrão depende de uma chave e de um vetor de inicialização para a execução de operações de criptografia.

A biblioteca já vem com chaves prédefinidas, mas podem ser facilmente alteradas e manipuladas.

# Intalação da biblioteca via Nuget Packge

    Install-Package Assinado.Crypt -Version 1.0.0

# Exemplos para criptografar

Criptografando utilizando as chaves padrão:

    var frase = "minhasenha";
    var fraseCriptografada = frase.ToCrypt();

Criptografando com chaves customizadas:

    var frase = "minhasenha";
    var fraseCriptografada = frase.ToCrypt("gpjh387df2ghj65l", "l2345hsjfghjk54g");

# Exemplos para descriptografar

Descriptografando utilizando as chaves padrão:

    var frase = "minhasenha";
    var fraseCriptografada = frase.ToDecrypt();

Descriptografando com chaves as customizadas:

    var frase = "minhasenha";
    var fraseCriptografada = frase.ToDecrypt("gpjh387df2ghj65l", "l2345hsjfghjk54g");
