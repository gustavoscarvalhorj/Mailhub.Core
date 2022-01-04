# MailHub.Core

## Introdução:
Esse projeto foi desenvolvido para ser uma abstração de uma biblioteca de disparo de email. O intuito é padronizar a nomenclatura das classes e facilitar futuras mudanças de implementação das formas de envio.

## Cenário Hipotético:
Quando falamos em envio de e-mail através do .NET, a primeira coisa que pensamos é utilizar as classes do namespace *System.Net.Mail* para fazer os disparos através de um servidor SMTP. Logo, é comum ver projetos utilizando a classe *MailMessage* espalhadas por todas as camadas de nossa aplicação.

O problema do cenário acima é que você forçou um alto acoplamento do seu projeto com uma biblioteca que só trabalha com o envio de e-mail via SMTP. E, se por acaso, você precisar alterar o seu projeto para enviar email através de um serviço externo via HTTP ou através de uma Queue/Log do RabbitMQ ou Apache Kafka? Possivelmente, você vai ter que refatorar todo o seu projeto ou vai fazer algum “contorno” para tratar essa situação.

O ideal para mitigar esse cenário, seria você criar abstrações para isolar a implementação em classes especializadas nesse tipo de ação. A questão é que criar abstrações para esse tipo de serviço é trabalhoso e acaba não sendo valorizado pela equipe de desenvolvimento, pois afinal: "Só queremos enviar um e-mail". Isso faz com que muitas vezes essas abstrações não sejam realizadas, e quando é necessário trocar a forma de envio de e-mail algumas soluções de contorno são utilizadas para isso. 

## Onde entra o MailHub.Core:

O MailHub.Core é uma bibilioteca que já possui os artefatos (classes, interfaces e value objects) para reduzir o trabalho desta abstração. Ao utilizar o Mailhub.Core com algumas implementações disponíveis como o Mailhub.Smtp, Mailhub.Http, MailHub.MessageBrokers você poderá trocar a forma que o seu e-mail sai da aplicação com o mínimo de esforço necessário dentro do seu projeto.

## Downsides:
Afinal como nem tudo são flores, caso você espalhe as classes do Mailhub.Core por dentro da sua aplicação, você poderá criará um alto acoplameneto do seu projeto com o  MailHub.Core. Como isso é uma decisão de design e precisá ser avaliada em relação ao tipo de projeto que vocês estão construindo, converse com a sua equipe e avalie os contras antes de prosseguir.
