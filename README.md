# Assinado.Crypt
Biblioteca C# para encriptação de strings.
Utiliza como base a classe Rijndael, que é baseada em um algoritmo de mesmo nome e também conhecido como “Advanced Encryption Standard” (ou simplesmente “AES”).
Este padrão depende de uma chave e de um vetor de inicialização para a execução de operações de criptografia.

A biblioteca já vem com chaves prédefinidas, mas podem ser facilmente alteradas e manipuladas.

# Exemplos

Utilizando as chaves padrão:

var frase = "minhasenha";
var fraseCriptografada = frase.ToCrypt();

Criptografando com chaves customizadas:

var frase = "minhasenha";
var fraseCriptografada = frase.ToCrypt("gpjh387df2ghj65l", "l2345hsjfghjk54g");
