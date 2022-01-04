# MailHub.Core

## Introdução:
Esse projeto foi desenvolvido para ser uma abstração de uma biblioteca de disparo de email. O intuito é padronizar a nomenclatura das classes e facilitar futuras mudanças de implementação nas formas de envio.

## Cenário Hipotético:
Quando falamos em envio de e-mail através do .NET, a primeira coisa que pensamos é utilizar as classes do namespace *System.Net.Mail* para fazer os disparos através de um servidor SMTP. Logo, é comum ver projetos utilizando a classe *MailMessage* espalhadas por todas as camadas de uma aplicação.

O problema do cenário acima é o alto acoplamento do projeto com a biblioteca System.Net.Mail que só trabalha com o envio de e-mail via SMTP. E, se por acaso, você precisar alterar o seu projeto para enviar email através de um serviço externo via HTTP ou através de uma Queue/Log do RabbitMQ ou Apache Kafka? Possivelmente, você vai ter que refatorar todo o seu projeto ou vai fazer algum “contorno” para tratar essa situação.

O ideal para mitigar esse cenário, seria você criar abstrações para isolar a implementação em classes especializadas nesse tipo de ação, como por exemplo: ter uma classe *MailSmtpService* que esteja altamente acoplada ao System.Net.Mail. 

A questão é que criar abstrações e especializações para esse tipo de serviço é trabalhoso e acaba não sendo valorizado pela equipe de desenvolvimento, pois afinal: "Só queremos enviar um e-mail". Isso faz com que muitas vezes essas abstrações não sejam realizadas e força a equipe de desenvolvimento a criar soluções de contorno para quando queremos trocar o envio de e-mail de SMTP para qualquer outro protoloco, por exemplo.

## Onde entra o MailHub.Core:

O MailHub.Core é uma bibilioteca que já possui os artefatos (classes, interfaces e value objects) para reduzir o trabalho desta abstração. Ao utilizar o Mailhub.Core com algumas implementações disponíveis como o Mailhub.Smtp, Mailhub.Http, MailHub.MessageBrokers você poderá trocar a forma que o seu e-mail sai da aplicação com o mínimo de esforço necessário dentro do seu projeto.

## Downsides:
Como nem tudo são flores, caso você espalhe as classes do Mailhub.Core por dentro da sua aplicação, você poderá criará um alto acoplameneto do seu projeto com o  MailHub.Core. Como isso é uma decisão de design e precisá ser avaliada em relação ao tipo de projeto que vocês estão construindo, converse com a sua equipe e avalie os contras antes de prosseguir.
