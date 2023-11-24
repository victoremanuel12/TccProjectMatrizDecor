<!-- Início do README -->

<h1>Projeto de TCC em C# utilizando o Padrão MVC, Repository, e ASP.NET Core</h1>

<h3>Bem-vindo ao repositório do meu projeto de Trabalho de Conclusão de Curso (TCC), desenvolvido em C# utilizando o padrão de arquitetura MVC (Model-View-Controller) e a implementação do padrão Repository com a utilização da Interface de Unidade de Trabalho (IUnitOfWork). Este projeto também incorpora conhecimentos em HTML, CSS e JavaScript para proporcionar uma experiência de usuário eficiente e agradável.</h3>

<h4>Objetivo</h4>
<p>Este sistema foi concebido para atender às necessidades específicas de uma empresa localizada em Lauro de Freitas, especializada em decoração e organização de eventos. Anteriormente, as operações eram realizadas manualmente em papel, e o projeto visa otimizar esses processos por meio de uma aplicação web.</p>

<h4>Tecnologias Utilizadas</h4>
<ul>
  <li><strong>C#</strong>: A linguagem de programação principal utilizada no desenvolvimento do projeto.</li>
  <li><strong>ASP.NET Core</strong>: O framework web utilizado para a construção da aplicação, permitindo uma arquitetura modular e escalável.</li>
  <li><strong>MVC (Model-View-Controller)</strong>: Padrão de arquitetura que organiza a aplicação em três componentes principais, facilitando a manutenção e escalabilidade do código.</li>
  <li><strong>Repository Pattern com IUnitOfWork</strong>: Abstração para o acesso a dados, facilitando a gestão das operações no banco de dados.</li>
  <li><strong>HTML, CSS e JavaScript</strong>: Tecnologias web fundamentais para a construção de interfaces intuitivas e interativas.</li>
  <li><strong>SQL Server</strong>: Banco de dados relacional utilizado para persistência de dados.</li>
</ul>

<h4>Funcionalidades Principais</h4>
<p><strong>Desenvolvido para Atender Necessidades Específicas:</strong> Este sistema foi criado para atender às necessidades de uma empresa situada em Lauro de Freitas, especializada em decoração e organização de eventos. Antes da implementação deste sistema, as operações eram realizadas manualmente, utilizando processos em papel.</p>

<p><strong>Áreas no ASP.NET Core:</strong> Implementação de áreas para segmentar funcionalidades específicas da aplicação. Destaque para a área administrativa, que é acessível apenas pelo usuário administrador.</p>

<p><strong>Usuário Admin:</strong> Possibilidade de criar um usuário administrador com login específico, garantindo acesso restrito à área administrativa.</p>

<h4>Estrutura do Projeto</h4>
<ul>
  <li><strong>Controllers:</strong> Contém os controladores responsáveis pela lógica de negócios, seguindo o padrão MVC.</li>
  <li><strong>Views:</strong> Armazena as visualizações da aplicação, onde a interface do usuário é definida em HTML com o suporte de CSS e JavaScript.</li>
  <li><strong>Models:</strong> Classes que representam os objetos de domínio da aplicação.</li>
  <li><strong>ViewModels:</strong> Classes que encapsulam dados específicos para as visualizações, facilitando a comunicação entre controllers e views.</li>
  <li><strong>Repositories:</strong> Implementação do padrão Repository para abstrair o acesso a dados.</li>
  <li><strong>Areas:</strong> Módulos específicos da aplicação, como a área administrativa, organizando de forma estruturada as funcionalidades.</li>
</ul>

<h4>Banco de Dados</h4>
<p>O projeto utiliza o banco de dados SQL Server para armazenar e recuperar dados. O relacionamento entre as tabelas é crucial para a integridade dos dados. A seguir, uma breve descrição das tabelas e seus relacionamentos:</p>

<ol>
  <li><strong>Tabela Usuarios:</strong> Armazena informações sobre os usuários da aplicação.</li>
    <ul><li>Relacionamento: Pode ter um relacionamento com outras tabelas dependendo das funcionalidades específicas.</li></ul>
  <li><strong>Tabela Produtos:</strong> Contém dados sobre os produtos disponíveis na aplicação.</li>
    <ul><li>Relacionamento: Pode estar relacionada a outras tabelas, como a tabela de pedidos, dependendo da lógica de negócios.</li></ul>
  <li><strong>Tabela Pedidos:</strong> Registra informações sobre os pedidos feitos pelos usuários.</li>
    <ul><li>Relacionamento: Possui relacionamento com a tabela de usuários e a tabela de produtos para rastrear os pedidos associados a usuários específicos e aos produtos correspondentes.</li></ul>
  <li><strong>Tabela CarrinhoDeCompras:</strong> Vincula produtos adicionados ao carrinho a um login de usuário específico.</li>
    <ul><li>Relacionamento: Está relacionada à tabela de usuários para associar produtos a usuários específicos.</li></ul>
</ol>

<h4>Exemplo de Utilização do Carrinho de Compras</h4>
<p>Ao navegar pela aplicação, os usuários podem adicionar produtos ao carrinho de compras. A tabela CarrinhoDeCompras registra essas associações, permitindo que os usuários visualizem e finalizem suas compras posteriormente. O relacionamento com a tabela Usuarios assegura que os itens no carrinho estão vinculados a um login específico.</p>

<h4>Como Executar o Projeto</h4>
<p><strong>Requisitos Prévios:</strong> Certifique-se de ter o .NET Core SDK instalado em sua máquina e um servidor SQL Server disponível.</p>
<p><strong>Configuração do Banco de Dados:</strong> Edite o arquivo `appsettings.json` para fornecer a string de conexão com o banco de dados SQL Server.</p>
<p><strong>Clone o Repositório:</strong> Execute o comando `git clone https://github.com/seu-usuario/seu-projeto.git`.</p>
<p><strong>Restaure as Dependências:</strong> Execute `dotnet restore` na raiz do projeto.</p>
<p><strong>Atualize o Banco de Dados:</strong> Utilize o Entity Framework Core para aplicar as migrações e criar o banco de dados.</p>
<pre>
  <code>dotnet ef migrations add Inicial
  dotnet ef database update</code>
</pre>

<!-- Fim do README -->
