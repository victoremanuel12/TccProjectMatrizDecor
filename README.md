


<h1>Projeto de TCC em C# utilizando o Padrão MVC, Repository, e ASP.NET Core</h1>
<h3>Bem-vindo ao repositório do meu projeto de Trabalho de Conclusão de Curso (TCC), desenvolvido em C# utilizando o padrão de arquitetura MVC (Model-View-Controller) e a implementação do padrão Repository com a utilização da Interface de Unidade de Trabalho (IUnitOfWork). Este projeto também incorpora conhecimentos em HTML, CSS e JavaScript para proporcionar uma experiência de usuário eficiente e agradável.</h3>

<h4>Objetivo</h4>
Este sistema foi concebido para atender às necessidades específicas de uma empresa localizada em Lauro de Freitas, especializada em decoração e organização de eventos. Anteriormente, as operações eram realizadas manualmente em papel, e o projeto visa otimizar esses processos por meio de uma aplicação web.

<h4>Tecnologias Utilizadas</h4>
C#: A linguagem de programação principal utilizada no desenvolvimento do projeto.
ASP.NET Core: O framework web utilizado para a construção da aplicação, permitindo uma arquitetura modular e escalável.
MVC (Model-View-Controller): Padrão de arquitetura que organiza a aplicação em três componentes principais, facilitando a manutenção e escalabilidade do código.
Repository Pattern com IUnitOfWork: Abstração para o acesso a dados, facilitando a gestão das operações no banco de dados.
HTML, CSS e JavaScript: Tecnologias web fundamentais para a construção de interfaces intuitivas e interativas.
SQL Server: Banco de dados relacional utilizado para persistência de dados.
Funcionalidades Principais
Desenvolvido para Atender Necessidades Específicas: Este sistema foi criado para atender às necessidades de uma empresa situada em Lauro de Freitas, especializada em decoração e organização de eventos. Antes da implementação deste sistema, as operações eram realizadas manualmente, utilizando processos em papel.

Áreas no ASP.NET Core: Implementação de áreas para segmentar funcionalidades específicas da aplicação. Destaque para a área administrativa, que é acessível apenas pelo usuário administrador.

Usuário Admin: Possibilidade de criar um usuário administrador com login específico, garantindo acesso restrito à área administrativa.

<h4>Estrutura do Projeto</h4>
Controllers: Contém os controladores responsáveis pela lógica de negócios, seguindo o padrão MVC.
Views: Armazena as visualizações da aplicação, onde a interface do usuário é definida em HTML com o suporte de CSS e JavaScript.
Models: Classes que representam os objetos de domínio da aplicação.
ViewModels: Classes que encapsulam dados específicos para as visualizações, facilitando a comunicação entre controllers e views.
Repositories: Implementação do padrão Repository para abstrair o acesso a dados.
Areas: Módulos específicos da aplicação, como a área administrativa, organizando de forma estruturada as funcionalidades.
<h4>Banco de Dados</h4>
O projeto utiliza o banco de dados SQL Server para armazenar e recuperar dados. O relacionamento entre as tabelas é crucial para a integridade dos dados. A seguir, uma breve descrição das tabelas e seus relacionamentos:

Tabela Usuarios: Armazena informações sobre os usuários da aplicação.

Relacionamento: Pode ter um relacionamento com outras tabelas dependendo das funcionalidades específicas.
Tabela Produtos: Contém dados sobre os produtos disponíveis na aplicação.

Relacionamento: Pode estar relacionada a outras tabelas, como a tabela de pedidos, dependendo da lógica de negócios.
Tabela Pedidos: Registra informações sobre os pedidos feitos pelos usuários.

Relacionamento: Possui relacionamento com a tabela de usuários e a tabela de produtos para rastrear os pedidos associados a usuários específicos e aos produtos correspondentes.
Tabela CarrinhoDeCompras: Vincula produtos adicionados ao carrinho a um login de usuário específico.

Relacionamento: Está relacionada à tabela de usuários para associar produtos a usuários específicos.
Exemplo de Utilização do Carrinho de Compras
Ao navegar pela aplicação, os usuários podem adicionar produtos ao carrinho de compras. A tabela CarrinhoDeCompras registra essas associações, permitindo que os usuários visualizem e finalizem suas compras posteriormente. O relacionamento com a tabela Usuarios assegura que os itens no carrinho estão vinculados a um login específico.

<h4>Como Executar o Projeto</h4>
Requisitos Prévios: Certifique-se de ter o .NET Core SDK instalado em sua máquina e um servidor SQL Server disponível.
Configuração do Banco de Dados: Edite o arquivo appsettings.json para fornecer a string de conexão com o banco de dados SQL Server.
Clone o Repositório: Execute o comando git clone https://github.com/seu-usuario/seu-projeto.git.
Restaure as Dependências: Execute dotnet restore na raiz do projeto.
Atualize o Banco de Dados: Utilize o Entity Framework Core para aplicar as migrações e criar o banco de dados.
dotnet ef migrations add Inicial
dotnet ef database update
