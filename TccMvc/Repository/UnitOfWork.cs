using TccMvc.Context;
using TccMvc.Repository.Interfaces;

namespace TccMvc.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ProdutoRepository _produtoRepository;
        private CategoriaRepository _categoriaRepository;
        private ClienteRepository _clienteRepository;
        private CarrinhoDeComprasRepository _carrinhoDeComprasRepository;
        private AluguelRepository _aluguelRepository;

        protected AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }
        public IProdutoRespository ProdutoRepository
        {
            get
            {
                //Esses objetos são inicializados sob demanda, ou seja, a cada chamada do método,
                //é verificado se já existe uma instância do objeto. Se não houver, uma nova instância é criada e retornada.
                return _produtoRepository = _produtoRepository ?? new ProdutoRepository(_context);
            }
        }

        public ICategoriaRepository CategoriaRepository
        {
            get
            {
              
                return _categoriaRepository = _categoriaRepository ?? new CategoriaRepository(_context);

            }
        }
        public IClienteRepository ClienteRepository
        {
            get
            {

                return _clienteRepository = _clienteRepository ?? new ClienteRepository(_context);

            }
        }
        public ICarrinhoDeComprasRepository CarrinhoDeComprasRepository
        {
            get
            {

                return _carrinhoDeComprasRepository = _carrinhoDeComprasRepository ?? new CarrinhoDeComprasRepository(_context);

            }
        }
        public IAluguelRepository AluguelRepository
        {
            get
            {

                return _aluguelRepository = _aluguelRepository ?? new AluguelRepository(_context);

            }
        }
    
        public  async Task Commit()
        {
            await _context.SaveChangesAsync();
        }
    }
}
