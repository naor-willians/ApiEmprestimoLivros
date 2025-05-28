using EmprestimoLivros.Models;

namespace EmprestimoLivros.Services.EmprestimoLivros
{
    public interface IEmprestimoInterface
    {
        Task<ResponseModel<List<EmprestimoModel>>> GetEmprestimos();

        Task<ResponseModel<List<EmprestimoModel>>> CreateEmprestimo(EmprestimoModel emprestimo);

        Task<ResponseModel<EmprestimoModel>> GetEmprestimoById(int id);

        Task<ResponseModel<List<EmprestimoModel>>> UpdateEmprestimo(EmprestimoModel emprestimo);

        Task<ResponseModel<List<EmprestimoModel>>> DeleteEmprestimo(int id);
    }
}
