# SistemasTarefasNovo.API

Decidi refazer um projeto de To-Do List que criei no início do meu aprendizado, buscando agora incorporar boas práticas e aderir aos princípios do S.O.L.I.D.

Arquitetura:
Optei por migrar de um projeto centralizado em um único ponto para uma arquitetura de camadas, adotando a CLEAN ARCHITECTURE:

SistemasTarefas.API
SistemasTarefas.Application
SistemasTarefas.Domain
SistemasTarefas.Infra.Data
SistemasTarefas.Infra.Ioc

Repository Pattern:
Abandonei a abordagem que exigia herdar todos os métodos da classe base, optando por uma abordagem que permite o uso seletivo dos métodos necessários. Isso pode ser considerado uma forma de "composição", onde posso utilizar apenas o que é necessário, evitando violações dos princípios do S.O.L.I.D.

Biblioteca de Validação de Dados:
Incorporei a biblioteca Fluent Validation para a validação de dados. Essa escolha oferece uma abordagem mais expressiva e modular para garantir a integridade dos dados, contribuindo para a manutenção da qualidade do código.

Autenticação Token JWT:
Implementei a autenticação baseada em Token JWT, proporcionando um método seguro e eficaz para a autorização de usuários na aplicação. Este método adiciona uma camada adicional de segurança e é fundamental para garantir a autenticidade e a integridade das comunicações entre o cliente e o servidor.

Essas atualizações buscam promover uma arquitetura mais escalável, modular e aderente às melhores práticas de desenvolvimento de software.
