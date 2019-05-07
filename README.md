# SESockets

Está biblioteca foi feita para criar conexões simples e faceis com soquetes TCP e UDP.

## Projetos

### SESockets
A biblioteca com o módulo principal criada com tecnologia .NET Standard , assim compatível com qualquer 
aplicação seja ela em .NET Framework como .NET Core

#### Conexões com outras aplicações
Podemos utilizar a biblioteca criando um conexão com ela extendendo a classe `WireConnection`, ao implementar métodos dela não precisa se preocupar com implementaão da biblioteca.

    public interface WireConnection
    {
        void Send(byte[] bytes);

        void Receive(byte[] bytes);

        void Log(string text);

        //Chamado após efetuar conexão com servidor ou cliente
        void OnConnectToServer(IPAddress ip);

        //Chamado após criar server
        void OnCreateServer(IPAddress ip);

        //Chamado quando um cliente conecta no server
        void OnClientConnectToServer(IPAddress ip);
        
     }
     
#### Criando servidor/client
Para criar um servidor ou cliente, podemos utilizar dependendo do protocolo (UDP e TCP) as classes que extendem `Comunicator`

- TCPComunicator
- UDPComunicator

É nelas que é feito toda mágica!


#### Indo Fundo
Também é utilizada uma classe para cada cliente dentro do código `TcpConnectedClient`, a chave aqui é que o servidor armazena a **lista** de clientes  e o cliente utilizando mesma variável de lista, apenas adiciona um elemento com os dados da conexão com servidor.

> Esta classe é totalmente escodinda do usuário final, ficando para próximas atualizações um extensão melhor deste código se necessário

#### Códigos
Ainda futuramente podemos trabalhar com códigos de mensagens, funcionando para ser extendida para a aplicação final.
Estes códigos armazenariam bytes para serem lidos e definidos quais seriam as próximas informações enviadas e recebidas.


#### Portabilidade
Como o código foi criado para .Net Standard ele possui a vantagem de ser utilizado por **Qualquer** plataforma final.



### SESClient
Um projeto de console para conexão de um cliente a um servidor.

### SESServer
Um projeto de console para criar servidor que aceite conexão de clientes.
