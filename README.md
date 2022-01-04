# MailHub.Core [![Generic badge](https://img.shields.io/badge/v1.0.2-development-green.svg)](https://shields.io/)

## Introdução:
Esse projeto foi desenvolvido para ser uma abstração de uma biblioteca de disparo de email. O intuito é padronizar a nomenclatura das classes e facilitar futuras mudanças de implementação nas formas de envio.

## Cenário Hipotético:
Quando falamos em envio de e-mail através do .NET, a primeira coisa que pensamos é utilizar as classes do namespace *System.Net.Mail* para fazer os disparos através de um servidor SMTP. Logo, é comum ver projetos utilizando a classe *MailMessage* espalhadas por todas as camadas de uma aplicação.

O problema do cenário acima é o alto acoplamento do projeto com a biblioteca System.Net.Mail que só trabalha com o envio de e-mail via SMTP. E, se por acaso, você precisar alterar o seu projeto para enviar email através de um serviço externo via HTTP ou através de uma Queue/Log do RabbitMQ ou Apache Kafka? Possivelmente, você vai ter que refatorar todo o seu projeto ou vai fazer algum “contorno” para tratar essa situação.

O ideal para mitigar esse cenário, seria você criar abstrações para isolar a implementação em classes especializadas nesse tipo de ação, como por exemplo: ter uma classe *MailSmtpService* que esteja altamente acoplada ao System.Net.Mail. 

A questão é que criar abstrações e especializações para esse tipo de serviço é trabalhoso e acaba não sendo valorizado pela equipe de desenvolvimento, pois afinal: "Só queremos enviar um e-mail". Isso faz com que muitas vezes essas abstrações não sejam realizadas e força a equipe de desenvolvimento a criar soluções de contorno para quando queremos trocar o envio de e-mail de SMTP para qualquer outro protocolo.

## Onde entra o MailHub.Core:

O MailHub.Core é uma bibilioteca que já possui os artefatos (classes, interfaces e value objects) para reduzir o trabalho desta abstração. Ao utilizar o Mailhub.Core com algumas implementações disponíveis como o [Mailhub.Smtp](https://github.com/gustavoscarvalhorj/Mailhub.Smtp), Mailhub.Http, MailHub.MessageBrokers você poderá trocar a forma que o seu e-mail sai da aplicação com o mínimo de esforço necessário dentro do seu projeto.

## Downsides:
Caso as classes do Mailhub.Core sejam espalhadas por dentro da sua aplicação, criará um alto acoplameneto do seu projeto com o MailHub.Core. Essa decisão precisa ser discutida com a equipe técnica responsável pelo projeto, para garantir que todos concordam com a adoção desta abstração.

## Abstrações
O MailHub.Core fornece algumas classes, value objects e interfaces para padronizar a sua aplicação e possibilitar a implementação dos serviços de disparos de e-mail, segue abaixo alguns dos artefatos a qual nos referimos:

**Email:** Este ValueObject é utilizado para criar um estado válido e imutável de *Email*. Utilize-o sempre que for instânciar um novo e-mail dentro da sua aplicação.
```cs
var email = new Email("meuemail@a.com.br") 
//Caso o e-mail seja nulo, a aplicação lançará ArgumentNullException.
//Caso o e-mail seja inválido, a aplicação lançará um ArgumentException.
```

**Para criar uma mensagem**: A classe Mensagem mapeia os dados necessários para o envio de um e-mail. Você pode visualizar todos os atributos e métodos que ela dispões através deste [link](Mailhub.Core/Domain/Model/Message.cs)

```cs
var _from = new Email("meufrom@a.com.br");
var _to =  new Email("meuto@a.com.br");
var _subject = "Teste";
var _body = "<p>Este é o corpo do meu e-mail</p>";
var message = new Message(_to, _from, _subject, _body);
```

**Implementando um serviço que receba apenas um parâmetro utilizando a interface *IEmailService< T >*:**
O MailHub.Core fornece duas interfaces para criações de serviço de disparo de e-mail. A interface *IEmailService< T >* pede apenas um único parâmetro, o tipo deste parâmetro pode ser informado dentro da implementação do serviço. Vide um exemplo abaixo:
```cs
public class EmailService :  IEmailService<Message>
{
    public async Task<Result> SendAsync(Message message){
      //...
    }
}
```

**Implementando um serviço que receba dois parâmetros utilizando a interface *IEmailService< T , Z >*:**
A interface *IEmailService<T,Z>* pede dois parâmetros, o tipo destes parâmetros podem ser informados dentro da implementação do serviço. Vide um exemplo abaixo:
```cs
public class EmailService : IEmailService<Message, SmtpCredentials>
{
    public async Task<Result> SendAsync(Message message, SmtpCredentials credentials)
    {
         //...
    }
}
```
Obs.: Para maior entendimento, vale acessar o repositório do Mailhub.Smtp e visualizar a implementação deste serviço. Repare que a classe SmtpCredentials informada no exemplo acima faz parte do projeto [Mailhub.Smtp](https://github.com/gustavoscarvalhorj/Mailhub.Smtp). 

## License

MIT: Clique [aqui](LICENSE.txt) para visualizar a licença 
